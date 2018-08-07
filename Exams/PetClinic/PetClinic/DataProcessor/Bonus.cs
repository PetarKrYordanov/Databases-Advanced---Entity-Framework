namespace PetClinic.DataProcessor
{
    using System;
    using System.Linq;
    using PetClinic.Data;

    public class Bonus
    {
        public static string UpdateVetProfession(PetClinicContext context, string phoneNumber, string newProfession)
        {
            var result = string.Empty;

            var vet = context.Vets.FirstOrDefault(e => e.PhoneNumber == phoneNumber);
            if (vet==null)
            {
                result = $"Vet with phone number {phoneNumber} not found!";
                return result;
            }
            var oldProfession = vet.Profession;

            vet.Profession = newProfession;
            context.Vets.Update(vet);
            context.SaveChanges();
            result = $"{vet.Name}'s profession updated from {oldProfession} to {newProfession}.";
            return result;
        }
    }
}
