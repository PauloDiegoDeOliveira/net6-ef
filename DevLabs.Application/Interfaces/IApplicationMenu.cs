using DevLabs.Application.DTOs.Menu;
using DevLabs.Application.DTOs.Pagination;
using DevLabs.Application.Interfaces.Base;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Pagination;
using System;
using System.Threading.Tasks;

namespace DevLabs.Application.Interfaces
{
    public interface IApplicationMenu : IApplicationBase<Menu, ViewMenuDTO, PostMenuDTO, PutMenuDTO>
    {
        Task<ViewPagedListDTO<Menu, ViewMenuDTO>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        Task<ViewMenuDTO> PostAsync(PostMenuDTO postMenuDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo);

        Task<ViewMenuDTO> PutAsync(PutMenuDTO putMenuDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo);

        bool ValidateIdMenuPut(Guid id);

        bool ValidateNamePost(PostMenuDTO dto);

        bool ValidateNamePut(PutMenuDTO dto);
    }
}