using Domain.Entities;

namespace WedApi.Services.IServices
{
    public interface IUsuarioServices
    {//Este es el archivo de interfaz
        public Task<Response<List<Usuario>>> ObtenerUsuarios();
        public Task<Response<Usuario>> Crear(UsuarioResponse request);
        public Task<Response<Usuario>> ByID(int id);
        public Task<Response<Usuario>> ActualizarUsuario(int id, UsuarioResponse request);
        public Task<Response<string>> EliminarUsuario(int id);
    }
}
