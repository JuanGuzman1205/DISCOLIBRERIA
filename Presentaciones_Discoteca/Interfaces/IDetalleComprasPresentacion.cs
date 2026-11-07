using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IDetalleComprasPresentacion
    {
        Task<DetalleCompras> Insertar(DetalleCompras entidad);
        Task<DetalleCompras> Actualizar(DetalleCompras entidad);
        Task<List<DetalleCompras>> Consultar();
        Task<List<DetalleCompras>> Buscar(DetalleCompras entidad);
        Task<DetalleCompras> Borrar(DetalleCompras entidad);
    }
}