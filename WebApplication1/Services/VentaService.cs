using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Services
{

    public class VentaService : IVentaService
    {
        private readonly ecommerceDBContext _context;

        public VentaService(ecommerceDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Venta> GetVentas()
        {
            return _context.Ventas.ToList();
        }

        public Venta GetVentaById(int id)
        {
            return _context.Ventas.FirstOrDefault(v => v.IdVenta == id);
        }

        public void AddVenta(Venta venta)
        {
            _context.Ventas.Add(venta);
            _context.SaveChanges();
        }

        public void UpdateVenta(Venta venta)
        {
            _context.Ventas.Update(venta);
            _context.SaveChanges();
        }

        public void DeleteVenta(int id)
        {
            var venta = _context.Ventas.FirstOrDefault(v => v.IdVenta == id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
                _context.SaveChanges();
            }
        }
    }
}