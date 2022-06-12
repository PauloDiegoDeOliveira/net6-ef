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
            CreateMap<PostMenuDTO, Menu>().ReverseMap();
            CreateMap<PutMenuDTO, Menu>().ReverseMap();
            CreateMap<Menu, ViewMenuDTO>().ReverseMap();
        }
    }
}