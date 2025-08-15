using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Entities.DataOnly;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Infraestructure.DBContext.Seeds
{
    public class BookSeed : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book(1, "Ultimate Python: de cero a experto", "1ra",256,"",""),
                new Book(2, "Aprendiendo Git y Github", "1ra", 234, "", ""),
                new Book(3, "Clean Code", "1ra", 456, "", ""),
                new Book(4, "Ultimate TypeScript: Guía completa para principiantes (Spanish Edition)", "1ra", 624, "", "")
                );

            builder
                .HasMany(a => a.Authors)
                .WithMany(b => b.Books)
                .UsingEntity(r => r.HasData(
                    new {AuthorsId = 3, BooksId = 1},
                    new {AuthorsId = 2, BooksId = 2},
                    new {AuthorsId = 1, BooksId = 3},
                    new {AuthorsId = 3, BooksId = 4}
                ));

            builder
                .HasMany(a => a.Languages)
                .WithMany(b => b.Books)
                .UsingEntity(r => r.HasData(
                    new { LanguagesId = 1, BooksId = 1 },
                    new { LanguagesId = 1, BooksId = 2 },
                    new { LanguagesId = 2, BooksId = 3 },
                    new { LanguagesId = 1, BooksId = 4 }
                ));

            builder
                .HasMany(a => a.Genres)
                .WithMany(b => b.Books)
                .UsingEntity(r => r.HasData(
                    new { GenresId = 1, BooksId = 1 },
                    new { GenresId = 1, BooksId = 2 },
                    new { GenresId = 1, BooksId = 3 },
                    new { GenresId = 1, BooksId = 4 }
                ));
        }
    }
}
