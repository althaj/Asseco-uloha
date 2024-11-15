namespace DatabazaOsob.CRUDService.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type type, int id)
            : base($"Entity of type {type.Name} with id {id} was not found.")
        {

        }
    }
}
