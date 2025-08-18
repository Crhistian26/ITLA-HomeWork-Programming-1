using BiblioUniversity.Domain.Enum;
using BiblioUniversity.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Entities
{
    public class Fine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        [Required]
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        [Required]
        public int Amaunt { get; set; }

        [Required]
        public Fine_status Fine_Status { get; set; }

        public Fine() { }

        public Fine(int id, string description, Reservation reservation, int amaunt, Fine_status fine_Status)
        {
            if (amaunt < 0)
                throw new ExceptionDomain("No puedes poner una multa de 0 pesos.");

            Id = id;
            Description = description;
            Reservation = reservation;
            Amaunt = amaunt;
            Fine_Status = fine_Status;
        }

        public Fine(int id, string description, int reservationId, int amaunt, Fine_status fine_Status)
        {
            Id = id;
            Description = description;
            ReservationId = reservationId;
            Amaunt = amaunt;
            Fine_Status = fine_Status;
        }
    }
}
