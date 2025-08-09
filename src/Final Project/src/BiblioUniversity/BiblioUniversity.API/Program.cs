
using BiblioUniversity.Infraestructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BiblioUniversity.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BiblioContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly("BiblioUniversity.Infraestructure")));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
