using Model.Models;

namespace Service.Services
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