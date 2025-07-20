using MedicalApp.Domain.DTO;
using MedicalApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Entitys
{
    public class AuditoryEnties
    {
        [Key]
        public int Id { get; set; }
        public string NameTable { get; set; }
        public int IdTable { get; set; }
        public EntityState EntityState { get; set; }
        public string OldDate {  get; set; }
        public string NewDate { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        public AuditoryEnties() { }
        
        public AuditoryEnties(AuditoryData auditoryData, EntityState entityState, string oldDate, string newDate, DateTime date, User user)
        {
            NameTable = auditoryData.NameTable;
            IdTable = auditoryData.IdEntity;
            EntityState = entityState;
            OldDate = oldDate;
            NewDate = newDate;
            User = user;
            Date = date;
        }
    }
}
