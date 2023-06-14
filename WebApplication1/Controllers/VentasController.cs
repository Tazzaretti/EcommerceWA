using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Service.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly IVentaService _ventaService;

        public VentasController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpGet]
        public IActionResult GetVentas()
        {
            var ventas = _ventaService.GetVentas();
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        public IActionResult GetVentaById(int id)
        {
            var venta = _ventaService.GetVentaById(id);
            if (venta == null)
            {
                return NotFound();
            }
            return Ok(venta);
        }

        [HttpPost]
        public IActionResult AddVenta(Ventas venta)
        {
            _ventaService.AddVenta(venta);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVenta(int id, Ventas venta)
        {
            if (id != venta.IdVenta)
            {
                return BadRequest();
            }

            _ventaService.UpdateVenta(venta);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVenta(int id)
        {
            _ventaService.DeleteVenta(id);
            return Ok();
        }
    }
}