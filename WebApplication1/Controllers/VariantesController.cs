using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Service.Services;
using Model.ViewModels;

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

        [HttpGet("ObtenerVariantePorId")]
        public IActionResult ObtenerVariantePorId(int id)
        {
            var variante = _varianteService.ObtenerVariantePorId(id);
            if (variante == null)
                return NotFound();

            var varianteViewModel = new VarianteViewModel
            {
                Color = variante.Color,
                Talle = variante.Talle,
                NombreProducto = variante.IdProductoNavigation.Articulo
            };

            return Ok(varianteViewModel);
        }

        [HttpPut("ActualizarVariantePorId")]
        public IActionResult ActualizarVariante(int id, Variante variante)
        {
            if (id != variante.Id)
                return BadRequest();

            _varianteService.ActualizarVariante(variante);
            return Ok();
        }

        [HttpDelete("EliminarVariantePorId")]
        public IActionResult EliminarVariante(int id)
        {
            _varianteService.EliminarVariante(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosVariantes()
        {
            var variantes = _varianteService.ObtenerTodosLosVariantes();

            var variantesViewModel = variantes.Select(variante => new VarianteViewModel
            {
                Color = variante.Color,
                Talle = variante.Talle,
                NombreProducto = variante.IdProductoNavigation.Articulo
            }).ToList();

            return Ok(variantesViewModel);
        }
    }
}