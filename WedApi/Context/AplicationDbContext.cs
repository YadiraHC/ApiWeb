using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace WedApi.Context
{
    public class AplicationDbContext : DbContext//va a ereedar de entutyfra,eword
    {
        public AplicationDbContext(DbContextOptions options):base(options) 
        { }
        //Modelos a mapear
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insertar en tablas roles
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Yadira",
                    User = "usuario",
                    Password = "123",
                    FkRol = 1//Aqui debes poner el rol correspondiente
                }
            );

            //Insertar en tablas roles
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol = 1,
                    Nombre = "sa",
                }
            );
        }
    }
}
