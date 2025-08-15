using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Entities
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [Required]
        public int Quantify { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Request_date { get; set; }

        [Required]
        public DateTime Withdrawal_date { get; set; }

        [Required]
        public DateTime Return_date { get; set; }

        //Navegation
        public Fine Fine { get; set; }

        public Reservation() { }

        public Reservation(int id, int quantify, string description, DateTime request_date, DateTime withdrawal_date, DateTime return_date, Student student, Book book)
        {
            Id = id;
            Quantify = quantify;
            Description = description;
            Request_date = request_date;
            Withdrawal_date = withdrawal_date;
            Return_date = return_date;
            Student = student;
            Book = book;
        }
    }
}
