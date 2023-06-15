using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.ViewModels;
using Service.Services;

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

            var enviosViewModel = envios.Select(envio => new EnviosViewModel
            {
                Destino = envio.Destino,
                Origen = envio.Origen
            }).ToList();

            return Ok(enviosViewModel);
        }

        [HttpGet("GetEnvioById")]
        public IActionResult GetEnvioById(int id)
        {
            var envio = _envioService.GetEnvioById(id);
            if (envio == null)
            {
                return NotFound();
            }
            var enviosViewModel = new EnviosViewModel
            {
                Destino = envio.Destino,
                Origen = envio.Origen
            };

            return Ok(enviosViewModel);
        }

        [HttpPost]
        public IActionResult CreateEnvio(Envios envio)
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