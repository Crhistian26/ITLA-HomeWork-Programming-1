using BiblioUniversity.Domain.Entities.DataOnly;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Infraestructure.BaseDatosContext.Seeds.DataOnly
{
    public class AuthorSeed : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(
                new Author(1, "Robert C. Martin"),
                new Author(2, "Miguel Angel Duran Garcia"),
                new Author(3, "Nicolas Schurmann")
                );

        }
    }
}
