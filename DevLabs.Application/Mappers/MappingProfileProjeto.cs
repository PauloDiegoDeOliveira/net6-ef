using AutoMapper;
using DevLabs.Application.DTOs.Conta;
using DevLabs.Application.DTOs.Projeto;
using DevLabs.Application.DTOs.URLDocumentacao;
using DevLabs.Application.DTOs.URLHomologacao;
using DevLabs.Application.DTOs.URLProducao;
using DevLabs.Domain.Entitys;

namespace DevLabs.Application.Mappers
{
    public class MappingProfileProjeto : Profile
    {
        public MappingProfileProjeto()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<PostProjetoDTO, Projeto>().ReverseMap();
            CreateMap<PutProjetoDTO, Projeto>().ReverseMap();
            CreateMap<Projeto, ViewProjetoIncludeDTO>().ReverseMap();
            CreateMap<Projeto, ViewProjetoPadraoDTO>().ReverseMap();

            CreateMap<PostURLHomologacaoDTO, URLHomologacao>().ReverseMap();
            CreateMap<PutURLHomologacaoDTO, URLHomologacao>().ReverseMap();
            CreateMap<URLHomologacao, ViewURLHomologacaoDTO>().ReverseMap();

            CreateMap<PostURLProducaoDTO, URLProducao>().ReverseMap();
            CreateMap<PutURLProducaoDTO, URLProducao>().ReverseMap();
            CreateMap<URLProducao, ViewURLProducaoDTO>().ReverseMap();

            CreateMap<PostURLDocumentacaoDTO, URLDocumentacao>().ReverseMap();
            CreateMap<PutURLDocumentacaoDTO, URLDocumentacao>().ReverseMap();
            CreateMap<URLDocumentacao, ViewURLDocumentacaoDTO>().ReverseMap();

            CreateMap<PostContaDTO, Conta>().ReverseMap();
            CreateMap<PutContaDTO, Conta>().ReverseMap();
            CreateMap<Conta, ViewContaDTO>().ReverseMap();
        }
    }
}