using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Entities.DataOnly;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Infraestructure.DBContext
{
    public class BiblioContext : DbContext
    {
        public BiblioContext() { }
        public BiblioContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Persist Security Info=False;Trusted_Connection=True;database=BiblioUniversity;server=(local);TrustServerCertificate=True;");
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Librarian> Librarianes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Stock_Book> Stocks { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Fine> Fines { get; set; }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        
    }
}
