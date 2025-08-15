using BiblioUniversity.Domain.Entities.DataOnly;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Edition { get; set; }

        [Required]
        public int Pages { get; set; }

        public string Url_image {  get; set; }
        public string Url_digital { get; set; }

        [Required]
        public ICollection<Author> Authors { get; set; }
        [Required]
        public ICollection<Genre> Genres { get; set; }
        [Required]
        public ICollection<Language> Languages { get; set; }

        //Navegation
        public Reservation Reservation { get; set; }

        public Book () 
        {
            Authors = new List<Author>();
            Genres = new List<Genre>();
            Languages = new List<Language>();
        }

        public Book(int id, string title, string edition, int pages, string url_image, string url_digital, List<Author> autors, List<Genre> genres, List<Language> languages)
            : this()
        {
            Id = id;
            Title = title;
            Edition = edition;
            Pages = pages;
            Url_image = url_image;
            Url_digital = url_digital;

            if (autors != null)
            { 
                foreach(Author author in autors)
                    Authors.Add(author);
            }

            if (genres != null)
            {
                foreach (Genre genre in genres)
                    Genres.Add(genre);
            }

            if (languages != null)
            {
                foreach (Language language in languages)
                    Languages.Add(language);
            }
        }

        public Book(int id, string title, string edition, int pages, string url_image, string url_digital)
        {
            Id = id;
            Title = title;
            Edition = edition;
            Pages = pages;
            Url_image = url_image;
            Url_digital = url_digital;
        }

    }
}
