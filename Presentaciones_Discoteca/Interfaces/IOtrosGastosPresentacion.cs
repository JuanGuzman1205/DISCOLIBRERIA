using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IOtrosGastosPresentacion
    {
        OtrosGastos Insertar(OtrosGastos entidad);
        OtrosGastos Actualizar(OtrosGastos entidad);
        List<OtrosGastos> Consultar();
        List<OtrosGastos> Buscar(OtrosGastos entidad);
        OtrosGastos Borrar(OtrosGastos entidad);
    }
}