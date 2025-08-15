using BiblioUniversity.Domain.Entities.DataOnly;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Infraestructure.DBContext.Seeds.DataOnly
{
    public class EnrollmentSeed : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasData(
                new Enrollment(1, "2025-0347"),
                new Enrollment(2,"2025-4533"),
                new Enrollment(3,"2025-9865"),
                new Enrollment(4,"2025-5467")
            );
        }
    }
}
