using AutoMapper;
using EjercicioService.Application.DTOs;
using EjercicioService.Domain.Entities;

namespace EjercicioService.Application.Profiles
{
    public class EjercicioProfile : Profile
    {
        public EjercicioProfile() 
        { 
            CreateMap<Ejercicio, EjercicioDto>().ReverseMap();
        }
    }
}
