using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IDetalleReparacionesPresentacion
    {
        Task<DetalleReparaciones> Insertar(DetalleReparaciones entidad);
        Task<DetalleReparaciones> Actualizar(DetalleReparaciones entidad);
        Task<List<DetalleReparaciones>> Consultar();
        Task<List<DetalleReparaciones>> Buscar(DetalleReparaciones entidad);
        Task<DetalleReparaciones> Borrar(DetalleReparaciones entidad);
    }
}