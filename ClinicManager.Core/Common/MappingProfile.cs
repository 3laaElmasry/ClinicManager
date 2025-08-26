
using AutoMapper;
using ClinicManager.Core.DTO.User;
using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterPatient, RegisterModel>();
            CreateMap<RegisterModel, ApplicationUser>();
            CreateMap<RegisterPatient, Patient>();

        }
    }
}
