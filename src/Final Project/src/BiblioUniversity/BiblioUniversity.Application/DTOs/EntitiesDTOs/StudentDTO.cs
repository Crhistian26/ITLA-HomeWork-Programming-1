using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Entities.DataOnly;
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
        public Person Person { get; set; }
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }

        public StudentDTO() { }

        public StudentDTO(Student student)
        {
            Id = student.Id;
            PersonId = student.PersonId;
            Person = student.Person;
            EnrollmentId = student.EnrollmentId;
            Enrollment = student.Enrollment;
        }
    }
}
