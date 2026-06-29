
using Dsw2026Ej15.Data.Interfaces;
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Api.Middleware;
using Microsoft.EntityFrameworkCore;

namespace Dsw2026Ej15
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            
            builder.Services.AddDbContext<Dsw2026Ej15DbContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                });
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHealthChecks();
            builder.Services.AddScoped<IPersistence, PersistenceEf>();
            var app = builder.Build();
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.MapHealthChecks("/healt-check");

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
    