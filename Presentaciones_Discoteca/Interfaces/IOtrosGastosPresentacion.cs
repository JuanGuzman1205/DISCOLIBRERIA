using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IOtrosGastosPresentacion
    {
        Task<OtrosGastos> Insertar(OtrosGastos entidad);
        Task<OtrosGastos> Actualizar(OtrosGastos entidad);
        Task<List<OtrosGastos>> Consultar();
        Task<List<OtrosGastos>> Buscar(OtrosGastos entidad);
        Task<OtrosGastos> Borrar(OtrosGastos entidad);
    }
}