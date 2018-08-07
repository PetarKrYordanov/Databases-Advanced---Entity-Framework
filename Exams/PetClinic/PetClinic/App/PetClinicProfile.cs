namespace PetClinic.App
{
    using AutoMapper;
    using PetClinic.DataProcessor.DtoImport;
    using PetClinic.Models;

    public class PetClinicProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public PetClinicProfile()
        {
            CreateMap<PassportDto, Passport>().ReverseMap();
        }
    }
}
