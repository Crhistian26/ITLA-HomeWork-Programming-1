using BiblioUniversity.Domain.Entities.DataOnly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [Required]
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }
       

        //Navegation
        public Reservation Reservation { get; set; }

        public Student() { }

        public Student(int id, Person person, Enrollment enrollment)
        { 
            Id = id;
            Person = person;
            Enrollment = enrollment;
        }

    }
}
