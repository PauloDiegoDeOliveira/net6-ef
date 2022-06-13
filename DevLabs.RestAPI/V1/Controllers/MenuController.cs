using DevLabs.Application.DTOs.Menu;
using DevLabs.Application.DTOs.Pagination;
using DevLabs.Application.Interfaces;
using DevLabs.Application.Utilities.Paths;
using DevLabs.Domain.Core.Interfaces.Service;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Enums;
using DevLabs.Domain.Pagination;
using DevLabs.RestAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DevLabs.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/menus")]
    [ApiController]
    public class MenuController : MainController
    {
        private readonly IApplicationMenu applicationMenu;
        private readonly ActualEnvironment actualEnvironment;

        public MenuController(IApplicationMenu applicationMenu,
                                 IWebHostEnvironment environment,
                                 INotificador notificador,
                                 IUser user) : base(notificador, user)
        {
            this.applicationMenu = applicationMenu;

            actualEnvironment = environment.IsProduction() ? ActualEnvironment.Producao :
                environment.IsEnvironment("Homologation") ? ActualEnvironment.Homologacao : ActualEnvironment.Desenvolvimento;
        }

        /// <summary>
        /// Retorna todos os menus com filtro e paginação de dados.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] ParametersPalavraChave parameters)
        {
            ViewPagedListDTO<Menu, ViewMenuDTO> result = await applicationMenu.GetPaginationAsync(parameters);
            if (result.Pagina.Count is 0)
            {
                NotificarErro("Nenhuma menu foi encontrado.");
                return CustomResponseFail(ModelState);
            }

            return CustomResponseSuccess(result, "Menus encontrados.");
        }

        /// <summary>
        /// Insere um novo Menu.
        /// </summary>
        /// <param name="postMenuDTO"></param>
        /// <param name="diretorios"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] PostMenuDTO postMenuDTO, Diretorios diretorios)
        {
            if (!ModelState.IsValid) return CustomResponseFail(ModelState);

            if (!await PathSystem.ValidateURLs(diretorios.ToString(), actualEnvironment))
            {
                NotificarErro("Diretório não encontrado.");
                return CustomResponseFail(ModelState);
            }

            Dictionary<string, string> Urls = await PathSystem.GetURLs(diretorios.ToString(), actualEnvironment);

            ViewMenuDTO inserido = await applicationMenu.PostAsync(postMenuDTO, Urls["IP"], Urls["DNS"], Urls["SPLIT"]);

            return CustomResponseSuccess(inserido, "Menu criado com sucesso!");
        }

        /// <summary>
        /// Altera um Menu.
        /// </summary>
        /// <param name="putMenuDTO"></param>
        /// <param name="diretorios"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromForm] PutMenuDTO putMenuDTO, Diretorios diretorios)
        {
            if (!ModelState.IsValid) return CustomResponseFail(ModelState);

            if (putMenuDTO.ImagemUpload is not null)
            {
                if (!await PathSystem.ValidateURLs(diretorios.ToString(), actualEnvironment))
                {
                    NotificarErro("Diretório não encontrado.");
                    return CustomResponseFail(ModelState);
                }

                Dictionary<string, string> Urls = await PathSystem.GetURLs(diretorios.ToString(), actualEnvironment);

                ViewMenuDTO atualizado = await applicationMenu.PutAsync(putMenuDTO, Urls["IP"], Urls["DNS"], Urls["SPLIT"]);
                if (atualizado is null)
                {
                    NotificarErro("Nenhum menu foi encontrado com o id informado.");
                    return CustomResponseFail(ModelState);
                }

                return CustomResponseSuccess(atualizado, "Menu atualizado com sucesso!");
            }
            else
            {
                ViewMenuDTO atualizado = await applicationMenu.PutAsync(putMenuDTO, "", "", "");
                if (atualizado is null)
                {
                    NotificarErro("Nenhum menu foi encontrado com o id informado.");
                    return CustomResponseFail(ModelState);
                }

                return CustomResponseSuccess(atualizado, "Menu atualizado com sucesso!");
            }
        }

        /// <summary>
        /// Exclui um menu.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um menu o mesmo será alterado para status 3 excluído.</remarks>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ViewMenuDTO result = await applicationMenu.PutStatusAsync(id, Status.Excluido);
            if (result is null)
            {
                NotificarErro("Nenhum menu foi encontrado com o id informado.");
                return CustomResponseFail(ModelState);
            }

            return CustomResponseSuccess(result, "Menu excluído com sucesso.");
        }

        /// <summary>
        /// Altera o status.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPut("status")]
        public async Task<IActionResult> PutStatusAsync(Guid id, Status status)
        {
            if (status == 0)
            {
                NotificarErro("Nenhum status selecionado!");
                return CustomResponseFail(ModelState);
            }

            ViewMenuDTO result = await applicationMenu.PutStatusAsync(id, status);
            if (result is null)
            {
                NotificarErro("Nenhum menu foi encontrado com o id informado.");
                return CustomResponseFail(ModelState);
            }

            return result.Status switch
            {
                Status.Ativo => CustomResponseSuccess(result, "Menu atualizado para ativo com sucesso."),
                Status.Inativo => CustomResponseSuccess(result, "Menu atualizado para inativo com sucesso."),
                Status.Excluido => CustomResponseSuccess(result, "Menu atualizado para excluído com sucesso."),
                _ => CustomResponseSuccess(result, "Status atualizado com sucesso."),
            };
        }
    }
}