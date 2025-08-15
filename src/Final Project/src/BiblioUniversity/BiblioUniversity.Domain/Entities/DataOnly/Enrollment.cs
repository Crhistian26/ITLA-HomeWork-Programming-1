using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Entities.DataOnly
{
    [Index(nameof(Code), IsUnique = true)]
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }


        //Navegation
        public Student Student { get; set; }
        public Enrollment() { }

        public Enrollment(int id, string code)
        {
            Id = id;
            Code = code;
        }
    }
}
