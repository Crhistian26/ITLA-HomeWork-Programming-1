using BiblioUniversity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.DTOs.CreateDTOs
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public string Edition { get; set; }
        public int Pages { get; set; }
        public string Url_image { get; set; }
        public string Url_digital { get; set; }
        public List<int> AuthorIds { get; set; }
        public List<int> GenreIds { get; set; }
        public List<int> LanguageIds { get; set; }
        public int? ReservationId { get; set; }

        public CreateBookDTO() { }

        public CreateBookDTO(Book book)
        {
            Title = book.Title;
            Edition = book.Edition;
            Pages = book.Pages;
            Url_image = book.Url_image;
            Url_digital = book.Url_digital;
            AuthorIds = book.Authors?.Select(a => a.Id).ToList();
            GenreIds = book.Genres?.Select(g => g.Id).ToList();
            LanguageIds = book.Languages?.Select(l => l.Id).ToList();
            ReservationId = book.Reservation?.Id;
        }
    }
}
