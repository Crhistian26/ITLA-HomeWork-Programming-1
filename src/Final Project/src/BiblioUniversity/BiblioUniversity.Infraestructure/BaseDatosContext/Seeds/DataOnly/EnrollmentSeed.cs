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
    public class EnrollmentSeed : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasData(
                new Enrollment(1, "20250347"),
                new Enrollment(2,"20254533"),
                new Enrollment(3,"20259865"),
                new Enrollment(4,"20255467")
            );
        }
    }
}
