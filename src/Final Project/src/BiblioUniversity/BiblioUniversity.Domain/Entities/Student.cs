using BiblioUniversity.Domain.Entities.DataOnly;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Entities
{
    [Index(nameof(PersonId), IsUnique =  true)]
    [Index(nameof(EnrollmentId), IsUnique = true)]
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
        public ICollection<Reservation> Reservations { get; set; }

        public Student() { }
        public Student(Person person, Enrollment enrollment)
        {
            Person = person;
            Enrollment = enrollment;
        }

        public Student(int id, Person person, Enrollment enrollment)
        { 
            Id = id;
            Person = person;
            Enrollment = enrollment;
        }

        public Student(int id, int personid, int enrollmentid)
        {
            Id = id;
            PersonId = personid;
            EnrollmentId = enrollmentid;
        }

        public Student(int personid, int enrollmentid)
        {
            PersonId = personid;
            EnrollmentId = enrollmentid;
        }
    }
}
