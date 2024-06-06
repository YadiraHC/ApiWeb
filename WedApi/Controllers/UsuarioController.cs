using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WedApi.Services.IServices;

namespace WedApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        
        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()//El var acepta todo
        {
            var response = await _usuarioServices.ObtenerUsuarios();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser (int id)//Es singular
        {
            return Ok (await _usuarioServices.ByID(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UsuarioResponse request)
        {
            return Ok(await _usuarioServices.Crear(request));
        }

        //EliminarUsuario

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UsuarioResponse request)
        {
            return Ok(await _usuarioServices.ActualizarUsuario(id, request));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return Ok(await _usuarioServices.EliminarUsuario(id));
        }
    }
}
