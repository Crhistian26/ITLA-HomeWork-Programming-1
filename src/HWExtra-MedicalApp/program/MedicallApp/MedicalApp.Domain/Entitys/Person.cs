using MedicalApp.Domain.DTO;
using MedicalApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Entitys
{
    [Table("Persons")]
    public class Person : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(11)]
        public string Id_Card { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        //Navegacion
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

        public Person() { }

        public Person(string name, string lastname, string id_Card, string phone)
        {
            Name = name;
            Lastname = lastname;
            Id_Card = id_Card;
            Phone = phone;
        }

        public AuditoryData GetAuditoryData()
        {
            AuditoryData data = new AuditoryData(Id, "Persons");
            return data;
        }
    }
}

