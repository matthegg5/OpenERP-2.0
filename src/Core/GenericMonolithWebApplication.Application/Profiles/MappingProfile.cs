using AutoMapper;
using GenericMonolithWebApplication.Application.ViewModels;
using GenericMonolithWebApplication.Domain.Entities;

namespace GenericMonolithWebApplication.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Part, PartsViewModel>().ReverseMap();
        }
    }
}