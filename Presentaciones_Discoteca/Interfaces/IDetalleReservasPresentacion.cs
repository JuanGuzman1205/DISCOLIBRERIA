using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IDetalleReservasPresentacion
    {
        Task<DetalleReservas> Insertar(DetalleReservas entidad);
        Task<DetalleReservas> Actualizar(DetalleReservas entidad);
        Task<List<DetalleReservas>> Consultar();
        Task<List<DetalleReservas>> Buscar(DetalleReservas entidad);
        Task<DetalleReservas> Borrar(DetalleReservas entidad);
    }
}