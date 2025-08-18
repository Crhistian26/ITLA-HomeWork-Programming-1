using BiblioUniversity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.DTOs.CreateDTOs
{
    public class CreateStockBookDTO
    {
        public int BookId { get; set; }
        public int Available { get; set; }
        public int Existing { get; set; }

        public CreateStockBookDTO() { }

        public CreateStockBookDTO(Stock_Book stock)
        {
            BookId = stock.BookId;
            Available = stock.Available;
            Existing = stock.Existing;
        }
    }
}
