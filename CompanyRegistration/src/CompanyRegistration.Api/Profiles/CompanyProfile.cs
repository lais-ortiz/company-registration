using AutoMapper;
using CompanyRegistration.Api.Models;
using CompanyRegistration.Domain.Entities;

namespace CompanyRegistration.Api.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
        }
    }
}
