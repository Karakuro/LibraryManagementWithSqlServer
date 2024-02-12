using Microsoft.EntityFrameworkCore;

namespace LibraryManagementWithSql.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookShelf> BookShelves { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
