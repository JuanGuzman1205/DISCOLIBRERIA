using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IDetalleReparacionesPresentacion
    {
        DetalleReparaciones Insertar(DetalleReparaciones entidad);
        DetalleReparaciones Actualizar(DetalleReparaciones entidad);
        List<DetalleReparaciones> Consultar();
        List<DetalleReparaciones> Buscar(DetalleReparaciones entidad);
        DetalleReparaciones Borrar(DetalleReparaciones entidad);
    }
}