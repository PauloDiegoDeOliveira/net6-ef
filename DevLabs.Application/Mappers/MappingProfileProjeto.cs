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
            CreateMap<PostProjetoDto, Projeto>().ReverseMap();
            CreateMap<PutProjetoDto, Projeto>().ReverseMap();
            CreateMap<Projeto, ViewProjetoIncludeDto>().ReverseMap();
            CreateMap<Projeto, ViewProjetoPadraoDto>().ReverseMap();

            CreateMap<PostUrlHomologacaoDto, URLHomologacao>().ReverseMap();
            CreateMap<PutUrlHomologacaoDto, URLHomologacao>().ReverseMap();
            CreateMap<URLHomologacao, ViewUrlHomologacaoDto>().ReverseMap();

            CreateMap<PostUrlProducaoDto, URLProducao>().ReverseMap();
            CreateMap<PutUrlProducaoDto, URLProducao>().ReverseMap();
            CreateMap<URLProducao, ViewUrlProducaoDto>().ReverseMap();

            CreateMap<PostUrlDocumentacaoDto, URLDocumentacao>().ReverseMap();
            CreateMap<PutUrlDocumentacaoDto, URLDocumentacao>().ReverseMap();
            CreateMap<URLDocumentacao, ViewUrlDocumentacaoDto>().ReverseMap();

            CreateMap<PostContaDto, Conta>().ReverseMap();
            CreateMap<PutContaDto, Conta>().ReverseMap();
            CreateMap<Conta, ViewContaDto>().ReverseMap();
        }
    }
}