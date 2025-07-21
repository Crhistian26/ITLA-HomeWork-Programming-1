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
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Rol Rol { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        //Navegacion
        public Consultation Consultation { get; set; }

        public User() { }
        public User(Rol rol, string username, string password, Doctor? doctor)
        {
            Rol = rol;
            Username = username;
            Password = password;
            Doctor = doctor;
        }

        public AuditoryData GetAuditoryData()
        {
            AuditoryData data = new AuditoryData(Id, "Users");
            return data;
        }
    }
}
