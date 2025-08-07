
using MedicalApp.Domain;
using MedicalApp.Domain.DTO;
using MedicalApp.Domain.Entitys;
using MedicalApp.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MedicalApp.Persistence
{
    public class MedicalContext : DbContext
    {
        private readonly User _user;
        public MedicalContext() { }

        public MedicalContext(DbContextOptions options) : base(options) {}

        public MedicalContext(DbContextOptions options, User user) : base(options) { _user = user; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Persist Security Info=False;Trusted_Connection=True;database=Medical;server=(local);TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasOne(d=>d.Person)
                .WithOne(p=> p.Doctor)
                .HasForeignKey<Doctor>(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Patient>()
                .HasOne(pa => pa.Person)
                .WithOne(pe => pe.Patient)
                .HasForeignKey<Patient>(pa => pa.PersonId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private string ChangeFormatValues(object value)
        {
            if (value == null)
            {
                return "NULL";
            }

            if (value is string)
            {
                return value.ToString();
            }

            if (value is System.Collections.IEnumerable enumerable)
            {
                var items = new List<string>();

                foreach (var item in enumerable)
                {
                    items.Add(item.ToString());
                }

                return $"[{string.Join(", ", items)}]";
            }
            
            return value.ToString();
        }
        public override int SaveChanges()
        {
            var entitys = ChangeTracker.Entries()
                .Where(e => 
                    e.State == EntityState.Modified ||
                    e.State == EntityState.Deleted ||
                    e.State == EntityState.Added
                ).ToList();

            foreach (var entry in entitys)
            {
                AuditoryData auditoryData = (entry.Entity as dynamic).GetAuditoryData();

                string oldData = "";
                string newData = "";                

                if (entry.State == EntityState.Added)
                {
                    newData = string.Join(
                        " | ",
                        entry.CurrentValues.Properties
                            .Select(p =>
                            $"{p.Name}: {ChangeFormatValues(entry.CurrentValues[p])}"
                        )
                    );
                }

                else if (entry.State == EntityState.Modified)
                {
                    oldData = string.Join(
                        " | ",
                        entry.OriginalValues.Properties
                            .Select(p =>
                            $"{p.Name}: {ChangeFormatValues(entry.OriginalValues[p])}"
                        )
                    );

                    newData = string.Join(
                        " | ",
                        entry.CurrentValues.Properties
                            .Select(p =>
                            $"{p.Name}: {ChangeFormatValues(entry.CurrentValues[p])}"
                        )
                    );
                }

                else if (entry.State == EntityState.Deleted)
                {
                    oldData = string.Join(
                        " | ",
                        entry.OriginalValues.Properties
                            .Select(p =>
                            $"{p.Name}: {ChangeFormatValues(entry.OriginalValues[p])}"
                        )
                    );
                }

                var audit = new AuditoryEnties(
                    auditoryData,
                    entry.State,
                    oldData,
                    newData,
                    DateTime.Now,
                    _user.Id
                );
                Auditories.Add(audit);
            }

            return base.SaveChanges();
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<AuditoryEnties> Auditories { get; set; }

    }
}
