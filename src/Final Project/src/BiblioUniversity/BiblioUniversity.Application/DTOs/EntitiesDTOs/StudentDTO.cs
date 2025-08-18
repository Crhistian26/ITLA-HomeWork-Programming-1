using BiblioUniversity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.DTOs.EntitiesDTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int EnrollmentId { get; set; }
        public int? ReservationId { get; set; }

        public StudentDTO() { }

        public StudentDTO(Student student)
        {
            Id = student.Id;
            PersonId = student.PersonId;
            EnrollmentId = student.EnrollmentId;
            ReservationId = student.Reservation?.Id;
        }
    }
}
