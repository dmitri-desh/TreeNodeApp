using AutoMapper;
using TreeNodeApp.Application.DTOs;
using TreeNodeApp.Core.Entities;

namespace TreeNodeApp.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Node, NodeDto>().ReverseMap();
            CreateMap<CreateNodeDto, Node>();
            CreateMap<UpdateNodeDto, Node>();

            CreateMap<Tree, TreeDto>().ReverseMap();
            CreateMap<CreateTreeDto, Tree>();

            // ExceptionLog mapping
            CreateMap<ExceptionLog, ExceptionLogDto>().ReverseMap();
        }
    }
}
