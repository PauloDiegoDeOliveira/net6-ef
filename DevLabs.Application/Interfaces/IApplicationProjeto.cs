using DevLabs.Application.DTOs.Pagination;
using DevLabs.Application.DTOs.Projeto;
using DevLabs.Application.Interfaces.Base;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Pagination;
using System;
using System.Threading.Tasks;

namespace DevLabs.Application.Interfaces
{
    public interface IApplicationProjeto : IApplicationBase<Projeto, ViewProjetoIncludeDto, PostProjetoDto, PutProjetoDto>
    {
        Task<ViewPagedListDto<Projeto, ViewProjetoPadraoDto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        Task<ViewProjetoIncludeDto> PostAsync(PostProjetoDto postProjetoDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo, string base64string, string extensao);

        Task<ViewProjetoIncludeDto> PutAsync(PutProjetoDto putProjetoDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo, string base64string, string extensao);

        Task<ViewProjetoIncludeDto> GetByIdDetailsAsync(Guid id);

        bool ValidateIdProjectPut(Guid id);

        bool ValidateNamePost(PostProjetoDto dto);

        bool ValidateNamePut(PutProjetoDto dto);

        bool ValidateIdURLHomologacaoPut(Guid id);

        bool ValidateIdURLProducaoPut(Guid id);

        bool ValidateIdURLDocumentacaoPut(Guid id);

        bool ValidateIdContaPut(Guid id);
    }
}