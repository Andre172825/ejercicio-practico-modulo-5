using ejercicio_practico_modulo_5.Models;
using Microsoft.EntityFrameworkCore;

namespace ejercicio_practico_modulo_5.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Andre\source\repos\ejercicio-practico-modulo-5\OrigenDatos\Libreria.mdf;Integrated Security=True";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(cadenaConexion);
            }
        }

        public DbSet<Libro> Libros { get; set; }
    }
}
