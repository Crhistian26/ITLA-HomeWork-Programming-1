using BiblioUniversity.Application.DTOs.EntitiesDTOs;
using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Entities.DataOnly;
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
        public List<Author> Authors { get; set; }
        public List<int> GenreIds { get; set; }
        public List<Genre> Genres { get; set; }
        public List<int> LanguageIds { get; set; }
        public List<Language> Languages { get; set; }
        public int? ReservationId { get; set; }

        public CreateBookDTO() { }

        public CreateBookDTO(BookDTO book)
        {
            Title = book.Title;
            Edition = book.Edition;
            Pages = book.Pages;
            Url_image = book.Url_image;
            Url_digital = book.Url_digital;
            AuthorIds = book.Authors?.Select(a => a.Id).ToList();
            GenreIds = book.Genres?.Select(g => g.Id).ToList();
            LanguageIds = book.Language?.Select(l => l.Id).ToList();
        }

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
        }
    }
}
