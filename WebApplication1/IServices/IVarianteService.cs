using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IVarianteService
    {
        void AgregarVariante(Variante variante);
        Variante ObtenerVariantePorId(int id);
        void ActualizarVariante(Variante variante);
        void EliminarVariante(int id);
        IEnumerable<Variante> ObtenerTodosLosVariantes();
    }
}