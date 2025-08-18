using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.DTOs.CreateDTOs
{
    public class CreateFineDTO
    {
        public string Description { get; set; }
        public int ReservationId { get; set; }
        public int Amaunt { get; set; }
        public Fine_status Fine_Status { get; set; }

        public CreateFineDTO() { }

        public CreateFineDTO(Fine fine)
        {
            Description = fine.Description;
            ReservationId = fine.ReservationId;
            Amaunt = fine.Amaunt;
            Fine_Status = fine.Fine_Status;
        }
    }
}
