using System.Collections.Generic;
using System.Linq;
using Model.Models;

namespace Model.Services
{
    public class ProductosService : IProductosService
    {
        private readonly ecommerceDBContext _dbContext;

        public ProductosService(ecommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AgregarProducto(Productos producto)
        {
            _dbContext.Productos.Add(producto);
            _dbContext.SaveChanges();
        }

        public Productos ObtenerProductoPorId(int id)
        {
            return _dbContext.Productos.FirstOrDefault(p => p.Id == id);
        }

        public void ActualizarProducto(Productos producto)
        {
            _dbContext.Productos.Update(producto);
            _dbContext.SaveChanges();
        }

        public void EliminarProducto(int id)
        {
            var producto = _dbContext.Productos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                _dbContext.Productos.Remove(producto);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Productos> ObtenerTodosLosProductos()
        {
            return _dbContext.Productos.ToList();
        }
    }
}