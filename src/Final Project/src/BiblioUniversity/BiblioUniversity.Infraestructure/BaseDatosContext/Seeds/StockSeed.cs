using BiblioUniversity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Infraestructure.BaseDatosContext.Seeds
{
    public class StockSeed : IEntityTypeConfiguration<Stock_Book>
    {
        public void Configure(EntityTypeBuilder<Stock_Book> builder)
        {
            builder.HasData(
                new Stock_Book(1,1,10,11),
                new Stock_Book(2, 2, 10, 11),
                new Stock_Book(3, 3, 10, 11),
                new Stock_Book(4, 4, 10, 11)
            );
        }
    }
}

