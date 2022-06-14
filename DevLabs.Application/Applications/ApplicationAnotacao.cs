using AutoMapper;
using DevLabs.Application.Applications.Base;
using DevLabs.Application.DTOs.Anotacao;
using DevLabs.Application.DTOs.Pagination;
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
    public class ApplicationAnotacao : ApplicationBase<Anotacao, ViewAnotacaoDto, PostAnotacaoDto, PutAnotacaoDto>, IApplicationAnotacao
    {
        private readonly IServiceAnotacao serviceAnotacao;

        public ApplicationAnotacao(IServiceAnotacao serviceAnotacao,
                                  IMapper mapper) : base(serviceAnotacao, mapper)

        {
            this.serviceAnotacao = serviceAnotacao;
        }

        public async Task<ViewPagedListDto<Anotacao, ViewAnotacaoDto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            PagedList<Anotacao> pagedList = await serviceAnotacao.GetPaginationAsync(parametersPalavraChave);
            return new ViewPagedListDto<Anotacao, ViewAnotacaoDto>(pagedList, mapper.Map<List<ViewAnotacaoDto>>(pagedList));
        }

        public async Task<ViewAnotacaoDto> PostAsync(PostAnotacaoDto postAnotacaoDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo)
        {
            Anotacao objeto = mapper.Map<Anotacao>(postAnotacaoDTO);

            objeto.PolulateInformations(objeto, await PathCreator.CreateIpPath(caminhoFisico),
                                                await PathCreator.CreateAbsolutePath(caminhoAbsoluto),
                                                await PathCreator.CreateRelativePath(await PathCreator.CreateAbsolutePath(caminhoAbsoluto), splitRelativo));

            UploadFormMethods<Anotacao> uploadClass = new();
            await uploadClass.UploadImage(objeto);

            return mapper.Map<ViewAnotacaoDto>(await serviceAnotacao.PostAsync(objeto));
        }

        public async Task<ViewAnotacaoDto> PutAsync(PutAnotacaoDto putAnotacaoDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo)
        {
            Anotacao objeto = mapper.Map<Anotacao>(putAnotacaoDTO);
            Anotacao consulta = await serviceAnotacao.GetByIdAsync(putAnotacaoDTO.Id);

            if (consulta is null)
                return null;

            if (putAnotacaoDTO.ImagemUpload is not null)
            {
                UploadFormMethods<Anotacao> uploadClass = new();
                await uploadClass.DeleteImage(consulta);

                objeto.PolulateInformations(objeto, await PathCreator.CreateIpPath(caminhoFisico),
                                                    await PathCreator.CreateAbsolutePath(caminhoAbsoluto),
                                                    await PathCreator.CreateRelativePath(await PathCreator.CreateAbsolutePath(caminhoAbsoluto), splitRelativo));

                await uploadClass.UploadImage(objeto);
            }
            else
            {
                objeto.PutInformations(consulta);
            }

            return mapper.Map<ViewAnotacaoDto>(await serviceAnotacao.PutAsync(objeto));
        }

        public override async Task<ViewAnotacaoDto> DeleteAsync(Guid id)
        {
            Anotacao consulta = await serviceAnotacao.GetByIdAsync(id);

            if (consulta is null)
                return null;

            UploadFormMethods<Anotacao> uploadClass = new();
            await uploadClass.DeleteImage(consulta);
            return await base.DeleteAsync(id);
        }

        public bool ValidateIdAnotacaoPut(Guid id)
        {
            return serviceAnotacao.ValidateIdAnotacaoPut(id);
        }

        public bool ValidateNamePost(PostAnotacaoDto dto)
        {
            Anotacao obj = mapper.Map<Anotacao>(dto);
            bool query = serviceAnotacao.ValidateNamePost(obj);
            return mapper.Map<bool>(query);
        }

        public bool ValidateNamePut(PutAnotacaoDto dto)
        {
            Anotacao obj = mapper.Map<Anotacao>(dto);
            bool query = serviceAnotacao.ValidateNamePut(obj);
            return mapper.Map<bool>(query);
        }
    }
}