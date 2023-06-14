using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Service.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VariantesController : ControllerBase
    {
        private readonly IVarianteService _varianteService;

        public VariantesController(IVarianteService varianteService)
        {
            _varianteService = varianteService;
        }

        [HttpPost]
        public IActionResult AgregarVariante(Variante variante)
        {
            _varianteService.AgregarVariante(variante);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerVariantePorId(int id)
        {
            var variante = _varianteService.ObtenerVariantePorId(id);
            if (variante == null)
                return NotFound();

            return Ok(variante);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarVariante(int id, Variante variante)
        {
            if (id != variante.Id)
                return BadRequest();

            _varianteService.ActualizarVariante(variante);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarVariante(int id)
        {
            _varianteService.EliminarVariante(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosVariantes()
        {
            var variantes = _varianteService.ObtenerTodosLosVariantes();
            return Ok(variantes);
        }
    }
}