using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.DTOs.CreateDTOs
{
    public class CreateReservationDTO
    {
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public int Quantify { get; set; }
        public string Description { get; set; }
        public Reservation_status Status { get; set; }
        public DateTime Request_date { get; set; }
        public DateTime Withdrawal_date { get; set; }
        public DateTime? Return_date { get; set; }

        public CreateReservationDTO() { }

        public CreateReservationDTO(int studentId, int bookId, int quantify, string description, DateTime request_date, DateTime withdrawal_date)
        {
            StudentId = studentId;
            BookId = bookId;
            Quantify = quantify;
            Description = description;
            Status = Reservation_status.Pending;
            Request_date = request_date;
            Withdrawal_date = withdrawal_date;
        }

        public CreateReservationDTO(Reservation reservation)
        {
            StudentId = reservation.StudentId;
            BookId = reservation.BookId;
            Quantify = reservation.Quantify;
            Description = reservation.Description;
            Request_date = reservation.Request_date;
            Withdrawal_date = reservation.Withdrawal_date;
            Status = reservation.Status;
            Return_date = reservation.Return_date;
        }
    }

}
