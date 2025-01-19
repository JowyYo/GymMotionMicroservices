using AutoMapper;
using EntrenamientoService.Application.DTOs;
using EntrenamientoService.Domain.Entities;

namespace EntrenamientoService.Application.Profiles
{
    public class EntrenamientoProfile : Profile
    {
        public EntrenamientoProfile() 
        { 
            CreateMap<Entrenamiento, EntrenamientoDto>().ReverseMap();
        }
    }
}
