using BiblioUniversity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.DTOs.CreateDTOs
{
    public class CreateStudentDTO
    {
        public int PersonId { get; set; }
        public int EnrollmentId { get; set; }
        public int? ReservationId { get; set; }

        public CreateStudentDTO() { }

        public CreateStudentDTO(Student student)
        {
            PersonId = student.PersonId;
            EnrollmentId = student.EnrollmentId;
            ReservationId = student.Reservation?.Id;
        }
    }
}
}
