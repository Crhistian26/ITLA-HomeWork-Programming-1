using BiblioUniversity.Domain.Exceptions;
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
    [Index(nameof(BookId), IsUnique = true)]
    public class Stock_Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [Required]
        public int Available { get; set; }

        [Required]
        public int Existing { get; set; }

        public Stock_Book() { }

        public Stock_Book(int id, int bookId, int available, int existing, Book book)
        {
            if (existing < available)
                throw new ExceptionEntity("Tienes mas libros disponibles que los de existencia, revise bien los datos");

            Id = id;
            BookId = bookId;
            Available = available;
            Existing = existing;
            Book = book;
        }

        public Stock_Book(int id, int bookId, int available, int existing, int bookid)
        {
            if (existing < available)
                throw new ExceptionEntity("Tienes mas libros disponibles que los de existencia, revise bien los datos");

            Id = id;
            BookId = bookId;
            Available = available;
            Existing = existing;
            BookId = bookid;
        }
    }
}
