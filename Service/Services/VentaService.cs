using Model.Models;

namespace Service.Services
{

    public class VentaService : IVentaService
    {
        private readonly ecommerceDBContext _context;

        public VentaService(ecommerceDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Ventas> GetVentas()
        {
            return _context.Ventas.ToList();
        }

        public Ventas GetVentaById(int id)
        {
            return _context.Ventas.FirstOrDefault(v => v.IdVenta == id);
        }

        public void AddVenta(Ventas venta)
        {
            _context.Ventas.Add(venta);
            _context.SaveChanges();
        }

        public void UpdateVenta(Ventas venta)
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