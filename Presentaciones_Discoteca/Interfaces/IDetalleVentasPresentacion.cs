using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IDetalleVentasPresentacion
    {
        Task<DetalleVentas> Insertar(DetalleVentas entidad);
        Task<DetalleVentas> Actualizar(DetalleVentas entidad);
        Task<List<DetalleVentas>> Consultar();
        Task<List<DetalleVentas>> Buscar(DetalleVentas entidad);
        Task<DetalleVentas> Borrar(DetalleVentas entidad);
    }
}