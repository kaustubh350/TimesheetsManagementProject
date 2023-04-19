using AutoMapper;
using TimesheetsManagementProject.Models.Domain;
using TimesheetsManagementProject.Models.Dto;

namespace TimesheetsManagementProject.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Users, UsersDto>().ReverseMap();
        }
    }
}
