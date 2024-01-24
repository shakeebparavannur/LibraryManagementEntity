using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext>options):base(options)
        {
            
        }
        public DbSet <Book> Books { get; set; }
        public DbSet <BookCopy> BookCopies { get; set; }
        public DbSet <Author> Authors { get; set; }
        public DbSet <Borrowing> Borrowings { get; set; }
        public DbSet <Publisher> Publishers  { get; set; }
        public DbSet <User> Users  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasIndex(b => b.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(b => b.PhoneNumber)
                .IsUnique();
        }

    }
}
