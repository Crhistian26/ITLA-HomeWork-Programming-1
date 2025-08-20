using BiblioUniversity.Application.DTOs.EntitiesDTOs;
using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Entities.DataOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.DTOs.CreateDTOs
{
    public class CreateStudentDTO
    {
        public PersonDTO Person { get; set; }
        public int PersonId { get; set; }
        public Enrollment Enrollment { get; set; }
        public int EnrollmentId { get; set; }
        public CreateStudentDTO() { }

        public CreateStudentDTO(Student student)
        {
            Person = new PersonDTO(student.Person);
            Enrollment = student.Enrollment;
        }
    }
}

