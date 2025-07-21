using MedicalApp.Domain.DTO;
using MedicalApp.Domain.Enums;
using MedicalApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Entitys
{
    [Table("Consultations")]
    public class Consultation : IEntity
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Begin { get; set; }
        public TimeOnly End { get; set; }
        public bool Pending { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public Reason Reason { get; set; }
        public string? Notes { get; set; }

        public Consultation() { }

        public Consultation(DateOnly date, TimeOnly begin, TimeOnly end,bool pending, Patient patient, Doctor doctor, Reason reason, string? notes)
        {
            Date = date;
            Begin = begin;
            End = end;
            Pending = pending;
            PatientId = patient.Id;
            Patient = patient;
            DoctorId = doctor.Id;
            Doctor = doctor;
            Reason = reason;
            Notes = notes;
        }

        public Consultation(int id, DateOnly date, bool pending, Patient patient, Doctor doctor, Reason reason, string? notes)
        {
            Id = id;
            Date = date;
            Pending = pending;
            PatientId = patient.Id;
            Patient = patient;
            DoctorId = doctor.Id;
            Doctor = doctor;
            Reason = reason;
            Notes = notes;
        }

        public AuditoryData GetAuditoryData()
        {
            AuditoryData data = new AuditoryData(Id, "Consultations");
            return data;
        }
    }
}
