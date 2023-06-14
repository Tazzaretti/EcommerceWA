using Model.Models;

namespace Service.Services
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
            _context.Variante.Add(variante);
            _context.SaveChanges();
        }

        public Variante ObtenerVariantePorId(int id)
        {
            return _context.Variante.FirstOrDefault(v => v.Id == id);
        }

        public void ActualizarVariante(Variante variante)
        {
            _context.Variante.Update(variante);
            _context.SaveChanges();
        }

        public void EliminarVariante(int id)
        {
            var variante = _context.Variante.FirstOrDefault(v => v.Id == id);
            if (variante != null)
            {
                _context.Variante.Remove(variante);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Variante> ObtenerTodosLosVariantes()
        {
            return _context.Variante.ToList();
        }
    }
}