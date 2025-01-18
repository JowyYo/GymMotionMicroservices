using AutoMapper;
using EntrenamientoService.Application.DTOs;
using EntrenamientoService.Domain.Entities;

namespace EntrenamientoService.Application.Profiles
{
    public class EjercicioProfile : Profile
    {
        public EjercicioProfile() 
        { 
            CreateMap<Ejercicio, EjercicioDto>().ReverseMap();
        }
    }
}
