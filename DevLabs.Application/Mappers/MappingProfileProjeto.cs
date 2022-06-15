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

            CreateMap<PostUrlHomologacaoDto, UrlHomologacao>().ReverseMap();
            CreateMap<PutUrlHomologacaoDto, UrlHomologacao>().ReverseMap();
            CreateMap<UrlHomologacao, ViewUrlHomologacaoDto>().ReverseMap();

            CreateMap<PostUrlProducaoDto, UrlProducao>().ReverseMap();
            CreateMap<PutUrlProducaoDto, UrlProducao>().ReverseMap();
            CreateMap<UrlProducao, ViewUrlProducaoDto>().ReverseMap();

            CreateMap<PostUrlDocumentacaoDto, UrlDocumentacao>().ReverseMap();
            CreateMap<PutUrlDocumentacaoDto, UrlDocumentacao>().ReverseMap();
            CreateMap<UrlDocumentacao, ViewUrlDocumentacaoDto>().ReverseMap();

            CreateMap<PostContaDto, Conta>().ReverseMap();
            CreateMap<PutContaDto, Conta>().ReverseMap();
            CreateMap<Conta, ViewContaDto>().ReverseMap();
        }
    }
}