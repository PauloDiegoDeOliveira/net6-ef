using DevLabs.Application.DTOs.Pagination;
using DevLabs.Application.DTOs.Projeto;
using DevLabs.Application.Interfaces;
using DevLabs.Application.Utilities;
using DevLabs.Domain.Core.Interfaces.Service;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Enums;
using DevLabs.Domain.Pagination;
using DevLabs.RestAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DevLabs.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/projetos")]
    [ApiController]
    public class ProjetoController : MainController
    {
        private readonly IApplicationProjeto applicationProjeto;
        private readonly ActualEnvironment actualEnvironment;

        public ProjetoController(IApplicationProjeto applicationProjeto,
                                 IWebHostEnvironment environment,
                                 INotificador notificador,
                                 IUser user) : base(notificador, user)
        {
            this.applicationProjeto = applicationProjeto;

            actualEnvironment = environment.IsProduction() ? ActualEnvironment.Producao :
                environment.IsEnvironment("Homologation") ? ActualEnvironment.Homologacao : ActualEnvironment.Desenvolvimento;
        }

        /// <summary>
        /// Retorna todos os projetos com filtro e paginação de dados.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] ParametersPalavraChave parameters)
        {
            ViewPagedListDTO<Projeto, ViewProjetoPadraoDTO> result = await applicationProjeto.GetPaginationAsync(parameters);
            if (result.Pagina.Count is 0)
            {
                NotificarErro("Nenhum projeto foi encontrado.");
                return CustomResponseFail(ModelState);
            }

            return CustomResponseSuccess(result, "Anotações encontradas.");
        }

        /// <summary>
        /// Insere um novo projeto.
        /// </summary>
        /// <param name="postProjetoDTO"></param>
        /// <param name="diretorios"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PostProjetoDTO postProjetoDTO, Diretorios diretorios)
        {
            if (!ModelState.IsValid) return CustomResponseFail(ModelState);

            PathSystem pathSystem = new PathSystem();
            if (!await pathSystem.ValidateURLs(diretorios.ToString(), actualEnvironment))
            {
                NotificarErro("Diretório não encontrado.");
                return CustomResponseFail(ModelState);
            }

            Dictionary<string, string> Urls = await pathSystem.GetURLs(diretorios.ToString(), actualEnvironment);

            ExtensionSystem extensionSystem = new ExtensionSystem();
            string extensao = extensionSystem.GetExtensaoB64(postProjetoDTO.ImagemBase64);
            if (extensao is null)
            {
                NotificarErro("Extensão não suportada ou texto não se encontra em Base64.");
                return CustomResponseFail(ModelState);
            }

            ViewProjetoIncludeDTO inserido = await applicationProjeto.PostAsync(postProjetoDTO, Urls["IP"], Urls["DNS"], Urls["SPLIT"], extensionSystem.base64Data, extensao);

            return CustomResponseSuccess(inserido, "Projeto criado com sucesso!");
        }

        /// <summary>
        /// Altera um projeto.
        /// </summary>
        /// <param name="putProjetoDTO"></param>
        /// <param name="diretorios"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PutProjetoDTO putProjetoDTO, Diretorios diretorios)
        {
            if (!ModelState.IsValid) return CustomResponseFail(ModelState);

            if (!string.IsNullOrWhiteSpace(putProjetoDTO.ImagemBase64))
            {
                PathSystem pathSystem = new PathSystem();
                if (!await pathSystem.ValidateURLs(diretorios.ToString(), actualEnvironment))
                {
                    NotificarErro("Diretório não encontrado.");
                    return CustomResponseFail(ModelState);
                }

                Dictionary<string, string> Urls = await pathSystem.GetURLs(diretorios.ToString(), actualEnvironment);

                ExtensionSystem extensionSystem = new ExtensionSystem();
                string extensao = extensionSystem.GetExtensaoB64(putProjetoDTO.ImagemBase64);
                if (extensao is null)
                {
                    NotificarErro("Extensão não suportada ou texto não se encontra em Base64.");
                    return CustomResponseFail(ModelState);
                }

                ViewProjetoIncludeDTO atualizado = await applicationProjeto.PutAsync(putProjetoDTO, Urls["IP"], Urls["DNS"], Urls["SPLIT"], extensionSystem.base64Data, extensao);
                if (atualizado is null)
                {
                    NotificarErro("Nenhum projeto foi encontrado com o id informado.");
                    return CustomResponseFail(ModelState);
                }

                return CustomResponseSuccess(atualizado, "Projeto atualizado com sucesso!");
            }
            else
            {
                ViewProjetoIncludeDTO atualizado = await applicationProjeto.PutAsync(putProjetoDTO, "", "", "", "", "");
                if (atualizado is null)
                {
                    NotificarErro("Nenhum projeto foi encontrado com o id informado.");
                    return CustomResponseFail(ModelState);
                }

                return CustomResponseSuccess(atualizado, "Projeto atualizado com sucesso!");
            }
        }

        /// <summary>
        /// Exclui um projeto.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um projeto o mesmo será alterado para status 3 excluído.</remarks>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ViewProjetoIncludeDTO result = await applicationProjeto.PutStatusAsync(id, Status.Excluido);
            if (result is null)
            {
                NotificarErro("Nenhum projeto foi encontrado com o id informado.");
                return CustomResponseFail(ModelState);
            }

            return CustomResponseSuccess(result, "Projeto excluído com sucesso.");
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

            ViewProjetoIncludeDTO result = await applicationProjeto.PutStatusAsync(id, status);
            if (result is null)
            {
                NotificarErro("Nenhum projeto foi encontrado com o id informado.");
                return CustomResponseFail(ModelState);
            }

            return result.Status switch
            {
                Status.Ativo => CustomResponseSuccess(null, "Status do projeto atualizado para ativo com sucesso."),
                Status.Inativo => CustomResponseSuccess(null, "Status do projeto atualizado para inativo com sucesso."),
                Status.Excluido => CustomResponseSuccess(null, "Status do projeto atualizado para excluído com sucesso."),
                _ => CustomResponseSuccess(null, "Status atualizado com sucesso."),
            };
        }

        /// <summary>
        /// Retorna detalhes do projeto.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("detalhes/{id:guid}")]
        [ProducesResponseType(typeof(ViewProjetoIncludeDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdDetailsAsync(Guid id)
        {
            ViewProjetoIncludeDTO result = await applicationProjeto.GetByIdDetailsAsync(id);
            if (result is null)
            {
                NotificarErro("Nenhum projeto foi encontrado com o id informado.");
                return CustomResponseFail(ModelState);
            }

            return CustomResponseSuccess(result, "Detalhes do projeto.");
        }
    }
}