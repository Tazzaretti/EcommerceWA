using Model.Models;

namespace Service.Services
{
    public class EnvioService : IEnvioService
    {
        private readonly ecommerceDBContext _context;

        public EnvioService(ecommerceDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Envios> GetEnvios()
        {
            return _context.Envios.ToList();
        }

        public Envios GetEnvioById(int id)
        {
            return _context.Envios.FirstOrDefault(e => e.Id == id);
        }
        public void AddEnvio(Envios envio)
        {
            // Agrega lógica para guardar el envío en la base de datos utilizando tu DbContext
            // Por ejemplo, podrías hacer algo como esto:
            _context.Envios.Add(envio);
            _context.SaveChanges();
        }
    }
}