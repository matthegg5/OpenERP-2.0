using AutoMapper;
using OpenERP.Application.ViewModels;
using OpenERP.Domain.Entities;

namespace OpenERP.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Part, PartsViewModel>().ReverseMap();
            CreateMap<PartRevision, PartRevisionsViewModel>().ReverseMap();
        }
    }
}