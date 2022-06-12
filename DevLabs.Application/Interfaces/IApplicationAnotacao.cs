using DevLabs.Application.DTOs.Anotacao;
using DevLabs.Application.DTOs.Pagination;
using DevLabs.Application.Interfaces.Base;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Pagination;
using System;
using System.Threading.Tasks;

namespace DevLabs.Application.Interfaces
{
    public interface IApplicationAnotacao : IApplicationBase<Anotacao, ViewAnotacaoDTO, PostAnotacaoDTO, PutAnotacaoDTO>
    {
        Task<ViewPagedListDTO<Anotacao, ViewAnotacaoDTO>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        Task<ViewAnotacaoDTO> PostAsync(PostAnotacaoDTO postAnotacaoDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo);

        Task<ViewAnotacaoDTO> PutAsync(PutAnotacaoDTO putAnotacaoDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo);

        bool ValidateIdAnotacaoPut(Guid id);

        bool ValidateNamePost(PostAnotacaoDTO dto);

        bool ValidateNamePut(PutAnotacaoDTO dto);
    }
}