
using AutoMapper;
using ClinicManager.Core.DTO.User;

namespace ClinicManager.Core.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterPatient, RegisterModel>();
        }
    }
}
