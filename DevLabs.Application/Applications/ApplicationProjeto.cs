using AutoMapper;
using DevLabs.Application.Applications.Base;
using DevLabs.Application.DTOs.Pagination;
using DevLabs.Application.DTOs.Projeto;
using DevLabs.Application.Interfaces;
using DevLabs.Application.Utilities.Image;
using DevLabs.Application.Utilities.Paths;
using DevLabs.Domain.Core.Interfaces.Service;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevLabs.Application.Applications
{
    public class ApplicationProjeto : ApplicationBase<Projeto, ViewProjetoIncludeDto, PostProjetoDto, PutProjetoDto>, IApplicationProjeto
    {
        private readonly IServiceProjeto serviceProjeto;

        public ApplicationProjeto(IServiceProjeto serviceProjeto,
                                  IMapper mapper) : base(serviceProjeto, mapper)

        {
            this.serviceProjeto = serviceProjeto;
        }

        public async Task<ViewPagedListDto<Projeto, ViewProjetoPadraoDto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            PagedList<Projeto> pagedList = await serviceProjeto.GetPaginationAsync(parametersPalavraChave);
            return new ViewPagedListDto<Projeto, ViewProjetoPadraoDto>(pagedList, mapper.Map<List<ViewProjetoPadraoDto>>(pagedList));
        }

        public async Task<ViewProjetoIncludeDto> PostAsync(PostProjetoDto postProjetoDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo, string base64string, string extensao)
        {
            Projeto objeto = mapper.Map<Projeto>(postProjetoDTO);

            objeto.PolulateInformations(await PathCreator.CreateIpPath(caminhoFisico),
                await PathCreator.CreateAbsolutePath(caminhoAbsoluto),
                await PathCreator.CreateRelativePath(await PathCreator.CreateAbsolutePath(caminhoAbsoluto), splitRelativo),
                extensao);

            UploadB64Methods<Projeto> uploadClass = new();
            await uploadClass.UploadImagem(objeto.CaminhoFisico, base64string);

            return mapper.Map<ViewProjetoIncludeDto>(await serviceProjeto.PostAsync(objeto));
        }

        public async Task<ViewProjetoIncludeDto> PutAsync(PutProjetoDto putProjetoDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo, string base64string, string extensao)
        {
            Projeto objeto = mapper.Map<Projeto>(putProjetoDTO);
            Projeto consulta = await serviceProjeto.GetByIdAsync(putProjetoDTO.Id);

            if (consulta is null)
                return null;

            if (!string.IsNullOrWhiteSpace(base64string))
            {
                UploadB64Methods<Projeto> uploadClass = new();
                await uploadClass.DeleteImage(consulta);

                objeto.PolulateInformations(await PathCreator.CreateIpPath(caminhoFisico),
                    await PathCreator.CreateAbsolutePath(caminhoAbsoluto),
                    await PathCreator.CreateRelativePath(await PathCreator.CreateAbsolutePath(caminhoAbsoluto), splitRelativo),
                    extensao);

                await uploadClass.UploadImagem(objeto.CaminhoFisico, base64string);
            }
            else
            {
                objeto.PutInformations(consulta);
            }

            return mapper.Map<ViewProjetoIncludeDto>(await serviceProjeto.PutAsync(objeto));
        }

        public override async Task<ViewProjetoIncludeDto> DeleteAsync(Guid id)
        {
            Projeto consulta = await serviceProjeto.GetByIdAsync(id);

            if (consulta is null)
                return null;

            UploadB64Methods<Projeto> uploadClass = new();
            await uploadClass.DeleteImage(consulta);

            return await base.DeleteAsync(id);
        }

        public async Task<ViewProjetoIncludeDto> GetByIdDetailsAsync(Guid id)
        {
            Projeto consulta = await serviceProjeto.GetByIdDetailsAsync(id);
            return mapper.Map<ViewProjetoIncludeDto>(consulta);
        }

        public bool ValidateIdProjectPut(Guid id)
        {
            return serviceProjeto.ValidateIdProjectPut(id);
        }

        public bool ValidateNamePost(PostProjetoDto dto)
        {
            Projeto obj = mapper.Map<Projeto>(dto);
            bool query = serviceProjeto.ValidateNamePost(obj);
            return mapper.Map<bool>(query);
        }

        public bool ValidateNamePut(PutProjetoDto dto)
        {
            Projeto obj = mapper.Map<Projeto>(dto);
            bool query = serviceProjeto.ValidateNamePut(obj);
            return mapper.Map<bool>(query);
        }

        public bool ValidateIdURLHomologacaoPut(Guid id)
        {
            return serviceProjeto.ValidateIdURLHomologacaoPut(id);
        }

        public bool ValidateIdURLProducaoPut(Guid id)
        {
            return serviceProjeto.ValidateIdURLProducaoPut(id);
        }

        public bool ValidateIdURLDocumentacaoPut(Guid id)
        {
            return serviceProjeto.ValidateIdURLDocumentacaoPut(id);
        }

        public bool ValidateIdContaPut(Guid id)
        {
            return serviceProjeto.ValidateIdContaPut(id);
        }
    }
}