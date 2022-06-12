using AutoMapper;
using DevLabs.Application.Applications.Base;
using DevLabs.Application.DTOs.Menu;
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
    public class ApplicationMenu : ApplicationBase<Menu, ViewMenuDTO, PostMenuDTO, PutMenuDTO>, IApplicationMenu
    {
        private readonly IServiceMenu serviceMenu;

        public ApplicationMenu(IServiceMenu serviceMenu,
                                  IMapper mapper) : base(serviceMenu, mapper)

        {
            this.serviceMenu = serviceMenu;
        }

        public async Task<ViewPagedListDTO<Menu, ViewMenuDTO>> GetPaginationAsync(ParametersPalavraChave parameters)
        {
            PagedList<Menu> pagedList = await serviceMenu.GetPaginationAsync(parameters);
            return new ViewPagedListDTO<Menu, ViewMenuDTO>(pagedList, mapper.Map<List<ViewMenuDTO>>(pagedList));
        }

        public async Task<ViewMenuDTO> PostAsync(PostMenuDTO postMenuDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo)
        {
            Menu objeto = mapper.Map<Menu>(postMenuDTO);

            PathCreator pathCreator = new PathCreator();
            objeto.PolulateInformations(objeto, await pathCreator.CreateIpPath(caminhoFisico),
                                                await pathCreator.CreateAbsolutePath(caminhoAbsoluto),
                                                await pathCreator.CreateRelativePath(await pathCreator.CreateAbsolutePath(caminhoAbsoluto), splitRelativo));

            UploadFormMethods<Menu> uploadClass = new UploadFormMethods<Menu>();
            await uploadClass.UploadImage(objeto);

            return mapper.Map<ViewMenuDTO>(await serviceMenu.PostAsync(objeto));
        }

        public async Task<ViewMenuDTO> PutAsync(PutMenuDTO putMenuDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo)
        {
            Menu objeto = mapper.Map<Menu>(putMenuDTO);
            Menu consulta = await serviceMenu.GetByIdAsync(putMenuDTO.Id);

            if (consulta is null)
                return null;

            if (putMenuDTO.ImagemUpload is not null)
            {
                UploadFormMethods<Menu> uploadClass = new UploadFormMethods<Menu>();
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

            return mapper.Map<ViewMenuDTO>(await serviceMenu.PutAsync(objeto));
        }

        public override async Task<ViewMenuDTO> DeleteAsync(Guid id)
        {
            Menu consulta = await serviceMenu.GetByIdAsync(id);

            if (consulta is null)
                return null;

            UploadFormMethods<Menu> uploadClass = new UploadFormMethods<Menu>();
            await uploadClass.DeleteImage(consulta);
            return await base.DeleteAsync(id);
        }

        public bool ValidateIdMenuPut(Guid id)
        {
            return serviceMenu.ValidateIdMenuPut(id);
        }

        public bool ValidateNamePost(PostMenuDTO dto)
        {
            Menu obj = mapper.Map<Menu>(dto);
            bool query = serviceMenu.ValidateNamePost(obj);
            return mapper.Map<bool>(query);
        }

        public bool ValidateNamePut(PutMenuDTO dto)
        {
            Menu obj = mapper.Map<Menu>(dto);
            bool query = serviceMenu.ValidateNamePut(obj);
            return mapper.Map<bool>(query);
        }
    }
}