using AutoMapper;
using DevLabs.Application.Applications.Base;
using DevLabs.Application.DTOs.Anotacao;
using DevLabs.Application.DTOs.Pagination;
using DevLabs.Application.Interfaces;
using DevLabs.Application.Utilities;
using DevLabs.Domain.Core.Interfaces.Service;
using DevLabs.Domain.Entitys;
using DevLabs.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevLabs.Application.Applications
{
    public class ApplicationAnotacao : ApplicationBase<Anotacao, ViewAnotacaoDTO, PostAnotacaoDTO, PutAnotacaoDTO>, IApplicationAnotacao
    {
        private readonly IServiceAnotacao serviceAnotacao;

        public ApplicationAnotacao(IServiceAnotacao serviceAnotacao,
                                  IMapper mapper) : base(serviceAnotacao, mapper)

        {
            this.serviceAnotacao = serviceAnotacao;
        }

        public async Task<ViewPagedListDTO<Anotacao, ViewAnotacaoDTO>> GetPaginationAsync(ParametersPalavraChave parameters)
        {
            PagedList<Anotacao> pagedList = await serviceAnotacao.GetPaginationAsync(parameters);
            return new ViewPagedListDTO<Anotacao, ViewAnotacaoDTO>(pagedList, mapper.Map<List<ViewAnotacaoDTO>>(pagedList));
        }

        public async Task<ViewAnotacaoDTO> PostAsync(PostAnotacaoDTO postAnotacaoDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo)
        {
            Anotacao objeto = mapper.Map<Anotacao>(postAnotacaoDTO);

            PathCreator pathCreator = new PathCreator();
            objeto.PolulateInformations(objeto, await pathCreator.CreateIpPath(caminhoFisico),
                                                await pathCreator.CreateAbsolutePath(caminhoAbsoluto),
                                                await pathCreator.CreateRelativePath(await pathCreator.CreateAbsolutePath(caminhoAbsoluto), splitRelativo));

            UploadFormMethods<Anotacao> uploadClass = new UploadFormMethods<Anotacao>();
            await uploadClass.UploadImage(objeto);

            return mapper.Map<ViewAnotacaoDTO>(await serviceAnotacao.PostAsync(objeto));
        }

        public async Task<ViewAnotacaoDTO> PutAsync(PutAnotacaoDTO putAnotacaoDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo)
        {
            Anotacao objeto = mapper.Map<Anotacao>(putAnotacaoDTO);
            Anotacao consulta = await serviceAnotacao.GetByIdAsync(putAnotacaoDTO.Id);

            if (consulta is null)
                return null;

            if (putAnotacaoDTO.ImagemUpload is not null)
            {
                UploadFormMethods<Anotacao> uploadClass = new UploadFormMethods<Anotacao>();
                await uploadClass.DeleteImage(consulta);

                PathCreator pathCreator = new PathCreator();
                objeto.PolulateInformations(objeto, await pathCreator.CreateIpPath(caminhoFisico),
                                                    await pathCreator.CreateAbsolutePath(caminhoAbsoluto),
                                                    await pathCreator.CreateRelativePath(await pathCreator.CreateAbsolutePath(caminhoAbsoluto), splitRelativo));

                await uploadClass.UploadImage(objeto);
            }
            else
            {
                objeto.PutInformations(consulta);
            }

            return mapper.Map<ViewAnotacaoDTO>(await serviceAnotacao.PutAsync(objeto));
        }

        public override async Task<ViewAnotacaoDTO> DeleteAsync(Guid id)
        {
            Anotacao consulta = await serviceAnotacao.GetByIdAsync(id);

            if (consulta is null)
                return null;

            UploadFormMethods<Anotacao> uploadClass = new UploadFormMethods<Anotacao>();
            await uploadClass.DeleteImage(consulta);
            return await base.DeleteAsync(id);
        }

        public bool ValidateIdAnotacaoPut(Guid id)
        {
            return serviceAnotacao.ValidateIdAnotacaoPut(id);
        }

        public bool ValidateNamePost(PostAnotacaoDTO dto)
        {
            Anotacao obj = mapper.Map<Anotacao>(dto);
            bool query = serviceAnotacao.ValidateNamePost(obj);
            return mapper.Map<bool>(query);
        }

        public bool ValidateNamePut(PutAnotacaoDTO dto)
        {
            Anotacao obj = mapper.Map<Anotacao>(dto);
            bool query = serviceAnotacao.ValidateNamePut(obj);
            return mapper.Map<bool>(query);
        }
    }
}