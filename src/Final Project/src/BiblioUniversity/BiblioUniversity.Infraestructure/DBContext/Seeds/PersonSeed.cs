using BiblioUniversity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Infraestructure.DBContext.Seeds
{
    public class PersonSeed : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(
                new Person (1,"Fernando Garcia", "Perez Mendosa", "8097896786", "40214335478", "Los Alcarrizos"),
                new Person (2,"Pedro Alvarez", "Ramirez Carrasco", "8295678976", "40234544556", "Los Mina"),
                new Person (3,"Laura Martinez", "Gomez Castillo", "8092345678", "40298765432", "Santo Domingo Este"),
                new Person (4, "Jose Ramirez", "Torres Mejia", "8293456789", "40287654321", "Villa Mella" ),
                new Person (5, "Carla Fernandez", "Lopez Santana", "8494567890", "40276543210", "San Cristobal" ),
                new Person (6, "Luis Castillo", "Morales Diaz", "8095678901", "40265432109", "Boca Chica" ),
                new Person (7, "Linus", "Benedict Torvalds", "8297768909", "43123435654", "La Capital")
            );
        }
    }
}
