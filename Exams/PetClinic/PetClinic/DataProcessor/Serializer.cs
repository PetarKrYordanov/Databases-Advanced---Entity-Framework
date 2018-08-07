namespace PetClinic.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.DtoExport;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animalsByPhoneNumber = context.Passports.Where(e => e.OwnerPhoneNumber == phoneNumber).Select(e => new
            {
                OwnerName = e.OwnerName,
                AnimalName = e.Animal.Name,
                Age = e.Animal.Age,
                SerialNumber = e.SerialNumber,
                RegisteredOn = e.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
            })
            .OrderBy(e => e.Age)
            .ThenBy(e => e.SerialNumber)
            .ToArray();

            var animalsByPhoneNumberJson = JsonConvert.SerializeObject(animalsByPhoneNumber, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.Indented

            });
            return animalsByPhoneNumberJson;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var allProcedures = context.Procedures
                .Include(e=>e.Animal)
                .ThenInclude(e=>e.Passport)
                .Include(d=>d.ProcedureAnimalAids)
                .ThenInclude(d=>d.AnimalAid)
                .OrderBy(e => e.DateTime)
                .ThenBy(e => e.Animal.Passport.SerialNumber)
                .Select(e => new AllProcedureDto
                {
                    Passport = e.Animal.PassportSerialNumber,
                    OwnerNumber = e.Animal.Passport.OwnerPhoneNumber,
                    DateTime = e.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),

                    AnimalAids = e.ProcedureAnimalAids.Select(ai => new AnimaAidsDto
                    {
                        AnimalAidName = ai.AnimalAid.Name,
                        Price = ai.AnimalAid.Price
                    }).ToList(),
                    TotalPrice = e.ProcedureAnimalAids.Sum(f=>f.AnimalAid.Price)
                })
            .ToArray();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(AllProcedureDto[]), new XmlRootAttribute("Procedures"));
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), allProcedures, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
