namespace CleanArchitecture.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string nombreClase, object key):base($"Entity \"{nombreClase}\" ({key}) no fue encontrado")
        { 
            
        }
    }
}
