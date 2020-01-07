namespace Meta.Domain.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        IContatoRepository ContatoRepository { get; }
    }
}