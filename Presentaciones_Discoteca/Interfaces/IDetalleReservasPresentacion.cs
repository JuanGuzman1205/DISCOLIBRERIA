using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IDetalleReservasPresentacion
    {
        DetalleReservas Insertar(DetalleReservas entidad);
        DetalleReservas Actualizar(DetalleReservas entidad);
        List<DetalleReservas> Consultar();
        List<DetalleReservas> Buscar(DetalleReservas entidad);
        DetalleReservas Borrar(DetalleReservas entidad);
    }
}