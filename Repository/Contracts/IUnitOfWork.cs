namespace Repository.Contracts
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        void Save();
    }
}
