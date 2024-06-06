using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WedApi.Context;
using WedApi.Services.IServices;

namespace WedApi.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly AplicationDbContext _context;
        public string Mensaje;

        //Creacion de un constructor
        public UsuarioServices(AplicationDbContext context)
        {
            _context = context;//Sig q es una clase Privada; Es un encapsulamiento.
        }

        //Lista de usuarios
        public async Task<Response<List<Usuario>>> ObtenerUsuarios()
        {
            try
            {
                //List<Usuario> response = await _context.Usuarios.ToListAsync();
                List<Usuario> response = await _context.Usuarios.Include(y => y.Roles).ToListAsync();
                return new Response<List<Usuario>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }

        //Obtener usuario
        public async Task<Response<Usuario>> ByID(int id)
        {
            try
            {
                Usuario usuario = _context.Usuarios.Find(id);
                return new Response<Usuario>(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error ByID = " + ex.Message);
            }
        }

        //Crear Usuario
        public async Task<Response<Usuario>> Crear(UsuarioResponse request)
        {
            try
            {

                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    User = request.User,
                    Password = request.Password,
                    FkRol = request.FkRol
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario, "Se guardo-o");
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }

        // Actualizar Usuario
        public async Task<Response<Usuario>> ActualizarUsuario(int id, UsuarioResponse request)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return new Response<Usuario>(null, "No se encontro o no existe");
                }

                usuario.Nombre = request.Nombre;
                usuario.User = request.User;
                usuario.Password = request.Password;
                usuario.FkRol = request.FkRol;

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario, "Actualizado");
            }
            catch (Exception ex)
            {
                throw new Exception("Error Update: " + ex.Message);
            }
        }

        // Eliminar Usuario
        public async Task<Response<string>> EliminarUsuario(int id)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return new Response<string>("Usuario no encontrado.");
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return new Response<string>("Eliminado.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error Delete: " + ex.Message);
            }
        }
    }
}
