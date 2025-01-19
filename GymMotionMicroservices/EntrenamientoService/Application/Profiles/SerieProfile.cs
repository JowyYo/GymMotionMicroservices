using AutoMapper;
using EntrenamientoService.Application.DTOs;
using EntrenamientoService.Domain.Entities;

namespace EntrenamientoService.Application.Profiles
{
    public class SerieProfile : Profile
    {
        public SerieProfile() 
        { 
            CreateMap<Serie, SerieDto>().ReverseMap();
        }
    }
}
