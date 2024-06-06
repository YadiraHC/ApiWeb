using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WedApi.Services.IServices;

namespace WedApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorServices _autorServices;

        public AutoresController(IAutorServices autorServices)
        {
            _autorServices = autorServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAutores()
        {
            return Ok(await _autorServices.GetAutores());
        }
        [HttpPost]
        public async Task<IActionResult> CrearAutor([FromBody]Autor autor)
        {
            return Ok(await _autorServices.Crear(autor));
        }
    }
}
