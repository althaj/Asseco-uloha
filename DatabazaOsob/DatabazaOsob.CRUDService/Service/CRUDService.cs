using DatabazaOsob.CRUDService.Exceptions;
using DatabazaOsob.Model.Context;
using DatabazaOsob.Model.Entities.Base;
using Microsoft.Extensions.Logging;

namespace DatabazaOsob.CRUDService.Service
{
    public class CRUDService<T> where T : Entity
    {
        protected string? databaseFileName;

        private readonly ILogger<CRUDService<T>>? logger;

        public CRUDService(string? databaseFileName = null)
        {
            this.databaseFileName = databaseFileName;
        }

        public CRUDService(ILogger<CRUDService<T>> logger, string? databaseFileName = null)
        {
            this.databaseFileName = databaseFileName;

            this.logger = logger;
            logger.LogDebug($"NLog injected into {typeof(CRUDService<T>).Name}.");
        }

        public virtual T Create(T entity)
        {
            logger?.LogInformation("Creating new entity of type {0} with entity {1}.", typeof(T).Name, entity);
            using (DatabazaOsobContext context = new DatabazaOsobContext(databaseFileName))
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }

            return entity;
        }

        public virtual void Delete(int id)
        {
            logger?.LogInformation("Deleting entity of type {0} with id {1}.", typeof(T).Name, id);
            using (DatabazaOsobContext context = new DatabazaOsobContext(databaseFileName))
            {
                context.Set<T>().Remove(Read(id));
            }
        }

        public virtual T Read(int id)
        {
            logger?.LogInformation("Getting entity of type {0} with ID {1}.", typeof(T).Name, id);
            using (DatabazaOsobContext context = new DatabazaOsobContext(databaseFileName))
            {
                T entity = context.Set<T>().FirstOrDefault(e => e.Id == id) ?? throw new EntityNotFoundException(typeof(T), id);
                return entity;
            }
        }

        public virtual T Update(T entity)
        {
            logger?.LogInformation("Updating entity of type {0} with entity {1}.", typeof(T).Name, entity);
            using (DatabazaOsobContext context = new DatabazaOsobContext(databaseFileName))
            {
                context.Set<T>().Update(entity);
                context.SaveChanges();
            }

            return entity;
        }
    }
}
