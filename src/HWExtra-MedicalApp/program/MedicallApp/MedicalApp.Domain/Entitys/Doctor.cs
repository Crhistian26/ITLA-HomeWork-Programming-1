using MedicalApp.Domain.DTO;
using MedicalApp.Domain.Enums;
using MedicalApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Entitys
{
    public class Doctor : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int? PersonId { get; set; }
        [Required]
        public Person Person { get; set; }
        public List<Specialties> Specialties { get; set; }


        //Navegacion
        public Consultation Consultation { get; set; }
        public User User { get; set; }

        public Doctor() { }

        public Doctor(Person person, List<Specialties> specialties)
        {
            PersonId = person.Id;
            Person = person;
            Specialties = specialties;
        }

        public AuditoryData GetAuditoryData()
        {
            AuditoryData data = new AuditoryData(Id, "Doctors");
            return data;
        }
    }
}
