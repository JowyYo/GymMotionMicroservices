using EjercicioService.Application.Repository;
using EjercicioService.Domain.Entities;

namespace EjercicioService.Infrastructure.Repositories
{
    public class EjercicioRepository : IEjercicioRepository
    {
        private readonly ApplicationDbContext _db;

        public EjercicioRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create(Ejercicio ejercicio)
        {
            _db.Ejercicios.Add(ejercicio);
        }

        public IEnumerable<Ejercicio> GetAll()
        {
            return _db.Ejercicios.ToList();
        }

        public Ejercicio GetById(Guid id)
        {
            return _db.Ejercicios.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return _db.SaveChanges() >= 0;
        }
    }
}
