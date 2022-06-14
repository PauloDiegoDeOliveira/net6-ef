using AutoMapper;
using DevLabs.Application.Applications.Base;
using DevLabs.Application.DTOs.Menu;
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
    public class ApplicationMenu : ApplicationBase<Menu, ViewMenuDto, PostMenuDto, PutMenuDto>, IApplicationMenu
    {
        private readonly IServiceMenu serviceMenu;

        public ApplicationMenu(IServiceMenu serviceMenu,
                                  IMapper mapper) : base(serviceMenu, mapper)

        {
            this.serviceMenu = serviceMenu;
        }

        public async Task<ViewPagedListDto<Menu, ViewMenuDto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            PagedList<Menu> pagedList = await serviceMenu.GetPaginationAsync(parametersPalavraChave);
            return new ViewPagedListDto<Menu, ViewMenuDto>(pagedList, mapper.Map<List<ViewMenuDto>>(pagedList));
        }

        public async Task<ViewMenuDto> PostAsync(PostMenuDto postMenuDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo)
        {
            Menu objeto = mapper.Map<Menu>(postMenuDTO);

            objeto.PolulateInformations(objeto, await PathCreator.CreateIpPath(caminhoFisico),
                                                await PathCreator.CreateAbsolutePath(caminhoAbsoluto),
                                                await PathCreator.CreateRelativePath(await PathCreator.CreateAbsolutePath(caminhoAbsoluto), splitRelativo));

            UploadFormMethods<Menu> uploadClass = new();
            await uploadClass.UploadImage(objeto);

            return mapper.Map<ViewMenuDto>(await serviceMenu.PostAsync(objeto));
        }

        public async Task<ViewMenuDto> PutAsync(PutMenuDto putMenuDTO, string caminhoFisico, string caminhoAbsoluto, string splitRelativo)
        {
            Menu objeto = mapper.Map<Menu>(putMenuDTO);
            Menu consulta = await serviceMenu.GetByIdAsync(putMenuDTO.Id);

            if (consulta is null)
                return null;

            if (putMenuDTO.ImagemUpload is not null)
            {
                UploadFormMethods<Menu> uploadClass = new();
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

            return mapper.Map<ViewMenuDto>(await serviceMenu.PutAsync(objeto));
        }

        public override async Task<ViewMenuDto> DeleteAsync(Guid id)
        {
            Menu consulta = await serviceMenu.GetByIdAsync(id);

            if (consulta is null)
                return null;

            UploadFormMethods<Menu> uploadClass = new();
            await uploadClass.DeleteImage(consulta);
            return await base.DeleteAsync(id);
        }

        public bool ValidateIdMenuPut(Guid id)
        {
            return serviceMenu.ValidateIdMenuPut(id);
        }

        public bool ValidateNamePost(PostMenuDto dto)
        {
            Menu obj = mapper.Map<Menu>(dto);
            bool query = serviceMenu.ValidateNamePost(obj);
            return mapper.Map<bool>(query);
        }

        public bool ValidateNamePut(PutMenuDto dto)
        {
            Menu obj = mapper.Map<Menu>(dto);
            bool query = serviceMenu.ValidateNamePut(obj);
            return mapper.Map<bool>(query);
        }
    }
}