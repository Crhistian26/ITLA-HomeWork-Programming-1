
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

namespace MedicalApp.Persistence
{
    public class MedicalContext : DbContext
    {
        public readonly User _user;
        public MedicalContext() { }
        public MedicalContext(DbContextOptions options, User user): base(options) { _user = user; }
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

        public override int SaveChanges()
        {
            //foreach (var entry in this.ChangeTracker.Entries())
            //{
            //    if(entry.State == EntityState.Added && entry.Entity is Entity add)
            //    {
            //        AuditoryEnties auditoryEnties = new AuditoryEnties(add.GetAuditoryData(),entry.State,entry.)
            //    }

            //}
            return base.SaveChanges();
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

    }
}
