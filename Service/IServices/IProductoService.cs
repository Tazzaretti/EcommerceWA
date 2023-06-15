using System.Collections.Generic;
using Model.Models;

namespace Model.Services
{
    public interface IProductosService
    {
        void AgregarProducto(Productos producto);
        Productos ObtenerProductoPorId(int id);
        void ActualizarProducto(Productos producto);
        void EliminarProducto(int id);
        IEnumerable<Productos> ObtenerTodosLosProductos();
    }
}