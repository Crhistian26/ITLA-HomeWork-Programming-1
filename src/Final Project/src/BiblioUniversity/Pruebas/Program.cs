using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Entities.DataOnly;
using BiblioUniversity.Infraestructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Pruebas
{
    internal class Program
    {
        static private readonly BiblioContext _context = new BiblioContext(new DbContextOptionsBuilder<BiblioContext>().Options);
        static void Main(string[] args)
        {
            var f = new Person(0, "maria", "Fermanda", "2222222", "8095734", "Lo mina") { };
            _context.Persons.Add(f);
            var e = new Enrollment(0, "699680");
            _context.Enrollments.Add(e);
            var s = new Student(0, f, e);
            _context.Students.Add(s);
            _context.SaveChanges();

            var f = new Person (0, "maria", "Fermanda", "2222222", "8095734", "Lo mina"){};
            _context.Persons.Add (f);
            _context.SaveChanges();
            var e = new Enrollment(0, "699680");
            _context.Enrollments.Add (e);
            _context.SaveChanges();
            var s = new Student(0, f, e);
            _context.Students.Add (s);
            _context.SaveChanges();
        }
    }
}
