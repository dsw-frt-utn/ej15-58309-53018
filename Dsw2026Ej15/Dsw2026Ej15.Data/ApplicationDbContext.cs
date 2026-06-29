using Microsoft.EntityFrameworkCore;
using Dsw2026Ej15.Domain.Entities; 

public class ApplicationDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Speciality> Specialities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Crea un archivo llamado clinica.db en la carpeta de ejecución
        optionsBuilder.UseSqlite("Data Source=clinica.db");
    }
}