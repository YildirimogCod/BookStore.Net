namespace Models.Exceptions
{
    public sealed class BookNotFoundException(int id) : NotFoundException($"Book with id: {id} not found.")
    {
    }
}
