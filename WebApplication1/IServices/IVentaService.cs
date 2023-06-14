using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IVentaService
    {
        IEnumerable<Venta> GetVentas();
        Venta GetVentaById(int id);
        void AddVenta(Venta venta);
        void UpdateVenta(Venta venta);
        void DeleteVenta(int id);
    }
}