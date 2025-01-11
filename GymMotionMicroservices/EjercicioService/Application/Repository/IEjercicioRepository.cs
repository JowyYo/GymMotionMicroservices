using EjercicioService.Domain.Entities;

namespace EjercicioService.Application.Repository
{
    public interface IEjercicioRepository
    {
        bool SaveChanges();
        IEnumerable<Ejercicio> GetAll();
        Ejercicio GetById(Guid id);
        void Create(Ejercicio ejercicio);
    }
}
