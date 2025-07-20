using MedicalApp.Domain;
using MedicalApp.Domain.Entitys;
using MedicalApp.Domain.Enums;
using MedicalApp.Persistence;
using MedicalApp.Persistence.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Xml.Schema;

namespace MedicalApp.Visual
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            MedicalContext context = new MedicalContext(new DbContextOptionsBuilder<MedicalContext>().Options, new User());
            Person pedro = new Person("juan", "perez", "afdasdfa", "adsfadsad");
            context.Persons.Add(pedro);
            context.SaveChanges();

            var ty = new Doctor(pedro, new List<Specialties>() { Specialties.Pediatra });
            context.Doctors.Add(ty);
            context.SaveChanges();
            ty.Specialties = new List<Specialties>() { Specialties.Pediatra, Specialties.Cirujano };
            context.Doctors.Update(ty);
            context.SaveChanges();
            context.Doctors.Remove(context.Doctors.First());
            context.SaveChanges();


            context.Patients.Add(new Patient(pedro, Insurance.Humano));
            context.SaveChanges();

            context.Persons.Remove(context.Persons.First());
            context.SaveChanges();
        }
    }
}
