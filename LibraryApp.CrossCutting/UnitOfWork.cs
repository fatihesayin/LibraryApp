using LibraryApp.EntityFrameworkCore;

namespace LibraryApp.CrossCutting
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}