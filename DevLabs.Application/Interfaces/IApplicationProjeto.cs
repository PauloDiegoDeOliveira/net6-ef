using DevLabs.Application.DTOs.Pagination;
using DevLabs.Application.DTOs.Projeto;
using DevLabs.Application.Interfaces.Base;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Pagination;
using System;
using System.Threading.Tasks;

namespace DevLabs.Application.Interfaces
{
    public interface IApplicationProjeto : IApplicationBase<Projeto, ViewProjetoIncludeDTO, PostProjetoDTO, PutProjetoDTO>
    {
        Task<ViewPagedListDTO<Projeto, ViewProjetoPadraoDTO>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        Task<ViewProjetoIncludeDTO> PostAsync(PostProjetoDTO postProjetoDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo, string base64string, string extensao);

        Task<ViewProjetoIncludeDTO> PutAsync(PutProjetoDTO putProjetoDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo, string base64string, string extensao);

        Task<ViewProjetoIncludeDTO> GetByIdDetailsAsync(Guid id);

        bool ValidateIdProjectPut(Guid id);

        bool ValidateNamePost(PostProjetoDTO dto);

        bool ValidateNamePut(PutProjetoDTO dto);

        bool ValidateIdURLHomologacaoPut(Guid id);

        bool ValidateIdURLProducaoPut(Guid id);

        bool ValidateIdURLDocumentacaoPut(Guid id);

        bool ValidateIdContaPut(Guid id);
    }
}