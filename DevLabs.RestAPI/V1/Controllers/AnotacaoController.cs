using DevLabs.Application.DTOs.Anotacao;
using DevLabs.Application.DTOs.Pagination;
using DevLabs.Application.Interfaces;
using DevLabs.Application.Structs;
using DevLabs.Application.Utilities.Paths;
using DevLabs.Application.Utilities.Text;
using DevLabs.Domain.Core.Interfaces.Service;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Enums;
using DevLabs.Domain.Pagination;
using DevLabs.RestAPI.Controllers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DevLabs.RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/anotacoes")]
    [ApiController]
    public class AnotacaoController : MainController
    {
        private readonly IApplicationAnotacao aplicationAnotacao;
        private readonly ActualEnvironment actualEnvironment;

        public AnotacaoController(IApplicationAnotacao aplicationAnotacao,
                                  IWebHostEnvironment environment,
                                  INotificador notificador,
                                  IUser user) : base(notificador, user)
        {
            this.aplicationAnotacao = aplicationAnotacao;
            actualEnvironment = environment.IsProduction() ? ActualEnvironment.Producao :
               environment.IsEnvironment("Homologation") ? ActualEnvironment.Homologacao : ActualEnvironment.Desenvolvimento;
        }

        /// <summary>
        /// Retorna todas as anotações com filtro e paginação de dados.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] ParametersPalavraChave parameters)
        {
            ViewPagedListDto<Anotacao, ViewAnotacaoDto> result = await aplicationAnotacao.GetPaginationAsync(parameters);
            if (result.Pagina.Count is 0)
            {
                NotificarErro("Nenhuma anotação foi encontrada.");
                return CustomResponseFail(ModelState);
            }

            return CustomResponseSuccess(result, await TextSystem.GetText(1));
        }

        /// <summary>
        /// Insere uma nova anotação.
        /// </summary>
        /// <param name="postAnotacaoDTO"></param>
        /// <param name="diretorios"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] PostAnotacaoDto postAnotacaoDTO, Diretorios diretorios)
        {
            if (!ModelState.IsValid) return CustomResponseFail(ModelState);

            if (!await PathSystem.ValidateURLs(diretorios.ToString(), actualEnvironment))
            {
                NotificarErro("Diretório não encontrado.");
                return CustomResponseFail(ModelState);
            }

            Dictionary<string, string> Urls = await PathSystem.GetURLs(diretorios.ToString(), actualEnvironment);

            ViewAnotacaoDto inserido = await aplicationAnotacao.PostAsync(postAnotacaoDTO, Urls["IP"], Urls["DNS"], Urls["SPLIT"]);

            return CustomResponseSuccess(inserido, "Anotação criado com sucesso!");
        }

        /// <summary>
        /// Altera uma anotação.
        /// </summary>
        /// <param name="putAnotacaoDTO"></param>
        /// <param name="diretorios"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromForm] PutAnotacaoDto putAnotacaoDTO, Diretorios diretorios)
        {
            if (!ModelState.IsValid) return CustomResponseFail(ModelState);

            if (putAnotacaoDTO.ImagemUpload is not null)
            {
                if (!await PathSystem.ValidateURLs(diretorios.ToString(), actualEnvironment))
                {
                    NotificarErro("Diretório não encontrado.");
                    return CustomResponseFail(ModelState);
                }

                Dictionary<string, string> Urls = await PathSystem.GetURLs(diretorios.ToString(), actualEnvironment);

                ViewAnotacaoDto atualizado = await aplicationAnotacao.PutAsync(putAnotacaoDTO, Urls["IP"], Urls["DNS"], Urls["SPLIT"]);
                if (atualizado is null)
                {
                    NotificarErro("Nenhuma anotação foi encontrada com o id informado.");
                    return CustomResponseFail(ModelState);
                }

                return CustomResponseSuccess(atualizado, "Anotação atualizado com sucesso!");
            }
            else
            {
                ViewAnotacaoDto atualizado = await aplicationAnotacao.PutAsync(putAnotacaoDTO, "", "", "");
                if (atualizado is null)
                {
                    NotificarErro("Nenhuma anotação foi encontrada com o id informado.");
                    return CustomResponseFail(ModelState);
                }

                return CustomResponseSuccess(atualizado, "Anotação atualizado com sucesso!");
            }
        }

        /// <summary>
        /// Exclui uma anotação.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir uma anotação o mesmo será alterado para status 3 excluído.</remarks>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ViewAnotacaoDto result = await aplicationAnotacao.PutStatusAsync(id, Status.Excluido);
            if (result is null)
            {
                NotificarErro("Nenhuma anotação foi encontrada com o id informado.");
                return CustomResponseFail(ModelState);
            }

            return CustomResponseSuccess(result, "Anotação excluída com sucesso.");
        }

        /// <summary>
        /// Atualização parcial com HTTP PATCH.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patch"></param>
        /// <remarks>Modelo: [ { "op": "replace", "path": "/titulo", "value": "Teste path 1" } ]</remarks>
        [HttpPatch("{id:guid}")]
        public async Task<ActionResult> PatchAsync(Guid id, [FromBody] JsonPatchDocument<PutAnotacaoDto> patch)
        {
            if (patch is null)
            {
                NotificarErro("O patch não pode ser nulo.");
                return CustomResponseFail(ModelState);
            }

            EntityToDto<Anotacao, PutAnotacaoDto> objetoPermissao = await aplicationAnotacao.MapStructById(id);
            if (objetoPermissao.Equals(default(EntityToDto<Anotacao, PutAnotacaoDto>)))
            {
                NotificarErro("Nenhuma anotação foi encontrada com o id informado.");
                return CustomResponseFail(ModelState);
            }

            patch.ApplyTo(objetoPermissao.Dto, ModelState);

            bool isValid = TryValidateModel(objetoPermissao.Dto);
            if (!isValid)
            {
                NotificarErro("Ação ou campo inválido.");
                return CustomResponseFail(ModelState);
            }

            await aplicationAnotacao.MapStructSaveChangesAsync(objetoPermissao);

            return CustomResponseSuccess("Anotação atualizada com sucesso!");
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

            ViewAnotacaoDto result = await aplicationAnotacao.PutStatusAsync(id, status);
            if (result is null)
            {
                NotificarErro("Nenhuma anotação foi encontrada com o id informado.");
                return CustomResponseFail(ModelState);
            }

            return result.Status switch
            {
                Status.Ativo => CustomResponseSuccess(result, "Anotação atualizada para ativa com sucesso."),
                Status.Inativo => CustomResponseSuccess(result, "Anotação atualizada para inativa com sucesso."),
                Status.Excluido => CustomResponseSuccess(result, "Anotação atualizada para excluída com sucesso."),
                _ => CustomResponseSuccess(result, "Status atualizado com sucesso."),
            };
        }
    }
}