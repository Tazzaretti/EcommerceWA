using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class EnvioService : IEnvioService
    {
        private readonly ecommerceDBContext _context;

        public EnvioService(ecommerceDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Envio> GetEnvios()
        {
            return _context.Envios.ToList();
        }

        public Envio GetEnvioById(int id)
        {
            return _context.Envios.FirstOrDefault(e => e.Id == id);
        }
        public void AddEnvio(Envio envio)
        {
            // Agrega lógica para guardar el envío en la base de datos utilizando tu DbContext
            // Por ejemplo, podrías hacer algo como esto:
            _context.Envios.Add(envio);
            _context.SaveChanges();
        }
    }
}