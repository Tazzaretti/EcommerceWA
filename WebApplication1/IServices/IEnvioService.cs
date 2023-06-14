using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IEnvioService
    {
        IEnumerable<Envio> GetEnvios();
        Envio GetEnvioById(int id);
        void AddEnvio(Envio envio);
    }
}