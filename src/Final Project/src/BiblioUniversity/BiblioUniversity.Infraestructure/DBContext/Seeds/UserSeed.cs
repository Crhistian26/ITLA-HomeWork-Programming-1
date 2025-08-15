using BiblioUniversity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BiblioUniversity.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Infraestructure.DBContext.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User(1, "2025-0347", "2025-0347", Rol.Student, 1),
                new User(2, "2025-4533", "2025-4533",Rol.Student, 2),
                new User(3, "2025-9865", "2025-9865", Rol.Student,3),
                new User(4, "2025-5467", "2025-5467", Rol.Student,4),
                new User(5, "B02342", "B02342", Rol.Librarian,5),
                new User(6, "B03342", "B03342", Rol.Librarian,6),
                new User(7,"Admin","123", Rol.Admin,7)
                );
        }
    }
}
