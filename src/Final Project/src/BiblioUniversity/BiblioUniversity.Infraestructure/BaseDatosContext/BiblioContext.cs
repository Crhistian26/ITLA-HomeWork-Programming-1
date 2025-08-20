using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Entities.DataOnly;
using BiblioUniversity.Infraestructure.BaseDatosContext.Seeds;
using BiblioUniversity.Infraestructure.BaseDatosContext.Seeds.DataOnly;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Infraestructure.BaseDatosContext
{
    public class BiblioContext : DbContext
    {
        public BiblioContext() { }
        public BiblioContext(DbContextOptions<BiblioContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Database=BiblioUniversity;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonSeed());
            modelBuilder.ApplyConfiguration(new EnrollmentSeed());
            modelBuilder.ApplyConfiguration(new StudentSeed());
            modelBuilder.ApplyConfiguration(new LibrarianSeed());
            modelBuilder.ApplyConfiguration(new UserSeed());
            modelBuilder.ApplyConfiguration(new AuthorSeed());
            modelBuilder.ApplyConfiguration(new LanguageSeed());
            modelBuilder.ApplyConfiguration(new GenreSeed());
            modelBuilder.ApplyConfiguration(new BookSeed());
            modelBuilder.ApplyConfiguration(new StockSeed());
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
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}
