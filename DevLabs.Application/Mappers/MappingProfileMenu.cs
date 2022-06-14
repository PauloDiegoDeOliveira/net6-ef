using AutoMapper;
using DevLabs.Application.DTOs.Menu;
using DevLabs.Domain.Entitys;

namespace DevLabs.Application.Mappers
{
    public class MappingProfileMenu : Profile
    {
        public MappingProfileMenu()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<PostMenuDto, Menu>().ReverseMap();
            CreateMap<PutMenuDto, Menu>().ReverseMap();
            CreateMap<Menu, ViewMenuDto>().ReverseMap();
        }
    }
}