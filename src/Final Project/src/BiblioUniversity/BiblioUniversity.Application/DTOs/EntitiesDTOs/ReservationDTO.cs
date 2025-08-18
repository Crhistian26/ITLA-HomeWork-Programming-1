using BiblioUniversity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.DTOs.EntitiesDTOs
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public int Quantify { get; set; }
        public string Description { get; set; }
        public DateTime Request_date { get; set; }
        public DateTime Withdrawal_date { get; set; }
        public DateTime Return_date { get; set; }
        public int? FineId { get; set; }

        public ReservationDTO() { }

        public ReservationDTO(Reservation reservation)
        {
            Id = reservation.Id;
            StudentId = reservation.StudentId;
            BookId = reservation.BookId;
            Quantify = reservation.Quantify;
            Description = reservation.Description;
            Request_date = reservation.Request_date;
            Withdrawal_date = reservation.Withdrawal_date;
            Return_date = reservation.Return_date;
            FineId = reservation.Fine?.Id;
        }

    }
}
