using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private readonly IEnvioService _envioService;

        public EnviosController(IEnvioService envioService)
        {
            _envioService = envioService;
        }

        [HttpGet]
        public IActionResult GetEnvios()
        {
            var envios = _envioService.GetEnvios();
            return Ok(envios);
        }

        [HttpGet("{id}")]
        public IActionResult GetEnvioById(int id)
        {
            var envio = _envioService.GetEnvioById(id);
            if (envio == null)
            {
                return NotFound();
            }
            return Ok(envio);
        }

        [HttpPost]
        public IActionResult CreateEnvio(Envio envio)
        {
            // Aquí puedes realizar la lógica para guardar el envío en la base de datos
            // utilizando tu servicio de envío (IEnvioService)

            // Por ejemplo, podrías llamar al método correspondiente del servicio:
            _envioService.AddEnvio(envio);

            // Si el envío se ha guardado correctamente, devuelve una respuesta exitosa (HTTP 200)
            return Ok();
        }
    }
}