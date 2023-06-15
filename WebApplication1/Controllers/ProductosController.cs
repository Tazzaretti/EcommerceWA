using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.Services;
using Model.ViewModels;
using System.Text.RegularExpressions;

namespace Model.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosService _productosService;

        public ProductosController(IProductosService productosService)
        {
            _productosService = productosService;
        }

        [HttpPost]
        public IActionResult AgregarProducto(Productos producto)
        {
            _productosService.AgregarProducto(producto);
            return Ok();
        }

        [HttpGet("ObtenerProductoPorId")]
        public IActionResult ObtenerProductoPorId(int id)
        {
            var producto = _productosService.ObtenerProductoPorId(id);
            if (producto == null)
                return NotFound();

            var productoViewModel = new ProductoViewModel
            {
                Articulo = producto.Articulo,
                Marca = producto.Marca,
                Precio = producto.Precio
            };

            return Ok(productoViewModel);
        }

        [HttpPut("ActualizarProductoPorID")]
        public IActionResult ActualizarProducto(int id, Productos producto)
        {
            if (id != producto.Id)
                return BadRequest();

            _productosService.ActualizarProducto(producto);
            return Ok();
        }

        [HttpDelete("EliminarProductoPorID")]
        public IActionResult EliminarProducto(int id)
        {
            _productosService.EliminarProducto(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosProductos()
        {
            var productos = _productosService.ObtenerTodosLosProductos();

            var productoViewModel = productos.Select(producto => new ProductoViewModel
            {
                Articulo = producto.Articulo,
                Marca = producto.Marca,
                Precio = producto.Precio
            }).ToList();

            return Ok(productos);
        }
    }
}