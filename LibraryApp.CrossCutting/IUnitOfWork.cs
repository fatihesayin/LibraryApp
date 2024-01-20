namespace LibraryApp.CrossCutting
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
        void Rollback();
    }   
}