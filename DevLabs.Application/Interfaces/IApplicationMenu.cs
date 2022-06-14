using DevLabs.Application.DTOs.Menu;
using DevLabs.Application.DTOs.Pagination;
using DevLabs.Application.Interfaces.Base;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Pagination;
using System;
using System.Threading.Tasks;

namespace DevLabs.Application.Interfaces
{
    public interface IApplicationMenu : IApplicationBase<Menu, ViewMenuDto, PostMenuDto, PutMenuDto>
    {
        Task<ViewPagedListDto<Menu, ViewMenuDto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        Task<ViewMenuDto> PostAsync(PostMenuDto postMenuDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo);

        Task<ViewMenuDto> PutAsync(PutMenuDto putMenuDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo);

        bool ValidateIdMenuPut(Guid id);

        bool ValidateNamePost(PostMenuDto dto);

        bool ValidateNamePut(PutMenuDto dto);
    }
}