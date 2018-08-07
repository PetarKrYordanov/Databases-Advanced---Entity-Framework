namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.DtoImport;
    using PetClinic.Models;

    public class Deserializer
    {

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var animalAids = new List<AnimalAid>();

            var deserializedItems = JsonConvert.DeserializeObject<AnimalAid[]>(jsonString);

            foreach (var aid in deserializedItems)
            {
                if (!IsValid(aid))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }
                if (animalAids.Any(x=>x.Name==aid.Name))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                animalAids.Add(aid);
                sb.AppendLine($"Record {aid.Name} successfully imported.");
            }
            context.AnimalAids.AddRange(animalAids);
            context.SaveChanges();


            var result = sb.ToString().Trim();
            return result;
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var inputJson = @"[{'Name':'DontInsertMe','Type':'cat','Age':3,'Passport':{'SerialNumber':'anothev150','OwnerName':'Owner','OwnerPhoneNumber':'12345','RegistrationDate':'15-04-2015'}},{'Name':'DontInsertMe','Type':'cat','Age':3,'Passport':{'SerialNumber':'anothev650','OwnerName':'Owner','OwnerPhoneNumber':'1234567890','RegistrationDate':'15-04-2015'}},{'Name':'DontInsertMe','Type':'cat','Age':3,'Passport':{'SerialNumber':'anothev950','OwnerName':'Owner','OwnerPhoneNumber':'+123456789123','RegistrationDate':'15-04-2015'}}]";
            var sb = new StringBuilder();
            var validPassports = new List<Passport>();
            var validAnimal = new List<Animal>();
            var deserializedItems = JsonConvert.DeserializeObject<AnimalDto[]>(jsonString);

            foreach (var item in deserializedItems)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }
                if (!IsValid(item.Passport))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }
                if (context.Passports.Any(e=>e.SerialNumber==item.Passport.SerialNumber))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }
                var passport = new Passport()
                {
                    SerialNumber = item.Passport.SerialNumber,
                    OwnerName = item.Passport.OwnerName,
                    RegistrationDate = DateTime.ParseExact(item.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    OwnerPhoneNumber = item.Passport.OwnerPhoneNumber,
                };
                validPassports.Add(passport);
                context.Passports.Add(passport);
                context.SaveChanges();
                var passportId = context.Passports.FirstOrDefault(e => e.SerialNumber == passport.SerialNumber).SerialNumber;

                var animal = new Animal();
                animal.Age = item.Age;
                animal.Name = item.Name;
                animal.PassportSerialNumber = passportId;
                animal.Type = item.Type;
                validAnimal.Add(animal);
                sb.AppendLine($"Record {animal.Name} Passport №: {passport.SerialNumber} successfully imported.");
            }
            context.Animals.AddRange(validAnimal);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var vetsFromString = new List<VetDto>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<VetDto>), new XmlRootAttribute("Vets"));
            using (TextReader reader = new StringReader(xmlString))
            {
                vetsFromString = (List<VetDto>)serializer.Deserialize(reader);
            }

            foreach (var vetDto in vetsFromString)
            {
                if (!IsValid(vetDto))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }
                if (context.Vets.Any(e=>e.PhoneNumber==vetDto.PhoneNumber))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var vet = new Vet()
                {
                    Age = vetDto.Age,
                    Name = vetDto.Name,
                    PhoneNumber = vetDto.PhoneNumber,
                    Profession = vetDto.Profession
                };

                context.Vets.Add(vet);
                context.SaveChanges();

                sb.AppendLine($"Record {vetDto.Name} successfully imported.");
            }


            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var proceduresDtos = new List<ProcedureDto>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ProcedureDto>), new XmlRootAttribute("Procedures"));
            using (TextReader reader = new StringReader(xmlString))
            {
                proceduresDtos = (List<ProcedureDto>)serializer.Deserialize(reader);
            }

            foreach (var item in proceduresDtos)
            {
                var currentVet = context.Vets.FirstOrDefault(e => e.Name == item.VetName);
                if (currentVet==null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }
                var currentAnimal = context.Animals.FirstOrDefault(e => e.PassportSerialNumber == item.AnimalSerialNumber);
                if (currentAnimal==null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }
                var currentAnimalAids = context.AnimalAids.Where(e => item.AnimalAids.Any(x => x.AnimalAidName == e.Name)).ToArray();
                if (currentAnimalAids.Select(e=>e.Name).ToArray().Distinct().Count()!=item.AnimalAids.Count())
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var procedure = new Procedure()
                {
                    AnimalId = currentAnimal.Id,
                    DateTime = DateTime.ParseExact(item.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    VetId =currentVet.Id
                };

                context.Procedures.Add(procedure);
                context.SaveChanges();
                var procedureId = procedure.Id;
                var procedureAnimalAids = new List<ProcedureAnimalAid>();
                foreach (var animalAid in currentAnimalAids)
                {
                    var procedureAnimalAid = new ProcedureAnimalAid()
                    {
                        ProcedureId = procedureId,
                        AnimalAidId = animalAid.Id
                    };
                    procedureAnimalAids.Add(procedureAnimalAid);
                }

                context.ProceduresAnimalAids.AddRange(procedureAnimalAids);
                context.SaveChanges();

                sb.AppendLine($"Record successfully imported.");
            }



            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static bool IsValid(object obj)
        {
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(obj,serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, context, results, true);
            return isValid;
        }
    }
}
