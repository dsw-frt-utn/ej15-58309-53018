
using Dsw2026Ej15.Data.Interfaces;
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Api.Middleware;

namespace Dsw2026Ej15
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IPersistence, PersistenceInMemory>();

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseMiddleware<ExceptionHandlingMiddleware>();

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
