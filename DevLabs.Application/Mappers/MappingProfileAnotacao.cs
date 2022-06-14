using AutoMapper;
using DevLabs.Application.DTOs.Anotacao;
using DevLabs.Domain.Entitys;

namespace DevLabs.Application.Mappers
{
    public class MappingProfileAnotacao : Profile
    {
        public MappingProfileAnotacao()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<PostAnotacaoDto, Anotacao>().ReverseMap();
            CreateMap<PutAnotacaoDto, Anotacao>().ReverseMap();
            CreateMap<Anotacao, ViewAnotacaoDto>().ReverseMap();
        }
    }
}