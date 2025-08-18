using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.DTOs.EntitiesDTOs
{
    public class FineDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ReservationId { get; set; }
        public int Amaunt { get; set; }
        public Fine_status Fine_Status { get; set; }

        public FineDTO() { }

        public FineDTO(Fine fine)
        {
            Id = fine.Id;
            Description = fine.Description;
            ReservationId = fine.ReservationId;
            Amaunt = fine.Amaunt;
            Fine_Status = fine.Fine_Status;
        }
    }
}
