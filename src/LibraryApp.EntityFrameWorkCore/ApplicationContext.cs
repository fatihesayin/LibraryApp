using LibraryApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.EntityFrameworkCore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {}
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
    }
}

