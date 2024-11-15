using DatabazaOsob.CRUDService.Exceptions;
using DatabazaOsob.Model.Context;
using DatabazaOsob.Model.Entities.Base;

namespace DatabazaOsob.CRUDService.Service
{
    public class CRUDService<T> where T : Entity
    {
        public virtual T Create(T entity)
        {
            using(DatabazaOsobContext context = new DatabazaOsobContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }

            return entity;
        }

        public virtual void Delete(int id)
        {
            using (DatabazaOsobContext context = new DatabazaOsobContext())
            {
                context.Set<T>().Remove(Read(id));
            }
        }

        public virtual T Read(int id)
        {
            using (DatabazaOsobContext context = new DatabazaOsobContext())
            {
                T entity = context.Set<T>().FirstOrDefault(e => e.Id == id) ?? throw new EntityNotFoundException(typeof(T), id);
                return entity;
            }
        }

        public virtual T Update(T entity)
        {
            using (DatabazaOsobContext context = new DatabazaOsobContext())
            {
                context.Set<T>().Update(entity);
                context.SaveChanges();
            }

            return entity;
        }
    }
}
