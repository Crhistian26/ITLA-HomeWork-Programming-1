using MedicalApp.Domain.DTO;
using MedicalApp.Domain.Entitys;
using MedicalApp.Domain.Enums;
using MedicalApp.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalApp.Domain.Entitys
{
    [Table("Patients")]
    public class Patient : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int? PersonId { get; set; }

        [Required]
        public Person Person { get; set; }

        public Insurance Insurance { get; set; }

        //Navegacion
        public Consultation Consultation { get; set; }

        public Patient() { }

        public Patient(Person person, Insurance insurance)
        {
            Person = person;
            PersonId = person.Id;
            Insurance = insurance;
        }

        public AuditoryData GetAuditoryData()
        {
            AuditoryData data = new AuditoryData(Id, "Patients");
            return data;
        }
    }
}