using Model.Models;

namespace Service.Services
{
    public interface IVentaService
    {
        IEnumerable<Ventas> GetVentas();
        Ventas GetVentaById(int id);
        void AddVenta(Ventas venta);
        void UpdateVenta(Ventas venta);
        void DeleteVenta(int id);
    }
}