using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Entities.DataOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.DTOs.EntitiesDTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Edition { get; set; }
        public int Pages { get; set; }
        public string? Url_image { get; set; }
        public string? Url_digital { get; set; }

        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Language> Language { get; set; }

        public BookDTO() { }

        public BookDTO(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Edition = book.Edition;
            Pages = book.Pages;
            Url_image = book.Url_image;
            Url_digital = book.Url_digital;
            Authors = book.Authors.ToList();
            Genres = book.Genres.ToList();
            Language = book.Languages.ToList();
        }
    }
}
