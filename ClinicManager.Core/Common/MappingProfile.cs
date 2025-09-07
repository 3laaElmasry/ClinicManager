
using AutoMapper;
using ClinicManager.Core.DTO.User;
using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PatientRegister, RegisterModel>();
            CreateMap<RegisterModel, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            CreateMap<PatientRegister, Patient>();

            CreateMap<DoctorRegister, Doctor>();
            CreateMap<DoctorRegister, RegisterModel>();

        }
    }
}
