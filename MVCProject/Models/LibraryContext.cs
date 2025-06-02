using Microsoft.EntityFrameworkCore;
using System;

namespace MVCProject.Models
{
    public class LibraryContext :DbContext
    {
        public LibraryContext() { 
        
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }

        public DbSet<Categeories> Categeories { get; set; }

        public DbSet<Librarians> Librarians { get; set; }

        public DbSet<Sales> Sales { get; set; }

        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
