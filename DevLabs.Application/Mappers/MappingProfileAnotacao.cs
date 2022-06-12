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
            CreateMap<PostAnotacaoDTO, Anotacao>().ReverseMap();
            CreateMap<PutAnotacaoDTO, Anotacao>().ReverseMap();
            CreateMap<Anotacao, ViewAnotacaoDTO>().ReverseMap();
        }
    }
}