using Model.Models;

namespace Service.Services
{
    public interface IEnvioService
    {
        IEnumerable<Envios> GetEnvios();
        Envios GetEnvioById(int id);
        void AddEnvio(Envios envio);
    }
}