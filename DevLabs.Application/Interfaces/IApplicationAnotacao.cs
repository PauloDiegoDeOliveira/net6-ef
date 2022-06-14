using DevLabs.Application.DTOs.Anotacao;
using DevLabs.Application.DTOs.Pagination;
using DevLabs.Application.Interfaces.Base;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Pagination;
using System;
using System.Threading.Tasks;

namespace DevLabs.Application.Interfaces
{
    public interface IApplicationAnotacao : IApplicationBase<Anotacao, ViewAnotacaoDto, PostAnotacaoDto, PutAnotacaoDto>
    {
        Task<ViewPagedListDto<Anotacao, ViewAnotacaoDto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        Task<ViewAnotacaoDto> PostAsync(PostAnotacaoDto postAnotacaoDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo);

        Task<ViewAnotacaoDto> PutAsync(PutAnotacaoDto putAnotacaoDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo);

        bool ValidateIdAnotacaoPut(Guid id);

        bool ValidateNamePost(PostAnotacaoDto dto);

        bool ValidateNamePut(PutAnotacaoDto dto);
    }
}