using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class VarianteService : IVarianteService
    {
        private readonly ecommerceDBContext _context;

        public VarianteService(ecommerceDBContext context)
        {
            _context = context;
        }

        public void AgregarVariante(Variante variante)
        {
            _context.Variantes.Add(variante);
            _context.SaveChanges();
        }

        public Variante ObtenerVariantePorId(int id)
        {
            return _context.Variantes.FirstOrDefault(v => v.Id == id);
        }

        public void ActualizarVariante(Variante variante)
        {
            _context.Variantes.Update(variante);
            _context.SaveChanges();
        }

        public void EliminarVariante(int id)
        {
            var variante = _context.Variantes.FirstOrDefault(v => v.Id == id);
            if (variante != null)
            {
                _context.Variantes.Remove(variante);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Variante> ObtenerTodosLosVariantes()
        {
            return _context.Variantes.ToList();
        }
    }
}