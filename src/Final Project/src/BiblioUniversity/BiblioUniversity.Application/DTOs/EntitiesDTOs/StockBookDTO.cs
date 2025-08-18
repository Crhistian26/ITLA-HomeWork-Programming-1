using BiblioUniversity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.DTOs.EntitiesDTOs
{
    public class StockBookDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Available { get; set; }
        public int Existing { get; set; }

        public StockBookDTO() { }

        public StockBookDTO(Stock_Book stock)
        {
            Id = stock.Id;
            BookId = stock.BookId;
            Available = stock.Available;
            Existing = stock.Existing;
        }

    }
}
