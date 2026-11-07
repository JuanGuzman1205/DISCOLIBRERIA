using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IMovimientoInventariosPresentacion
    {
        Task<MovimientoInventarios> Insertar(MovimientoInventarios entidad);
        Task<MovimientoInventarios> Actualizar(MovimientoInventarios entidad);
        Task<List<MovimientoInventarios>> Consultar();
        Task<List<MovimientoInventarios>> Buscar(MovimientoInventarios entidad);
        Task<MovimientoInventarios> Borrar(MovimientoInventarios entidad);
    }
}