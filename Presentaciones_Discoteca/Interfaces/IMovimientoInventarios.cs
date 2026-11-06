using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IMovimientoInventariosPresentacion
    {
        MovimientoInventarios Insertar(MovimientoInventarios entidad);
        MovimientoInventarios Actualizar(MovimientoInventarios entidad);
        List<MovimientoInventarios> Consultar();
        List<MovimientoInventarios> Buscar(MovimientoInventarios entidad);
        MovimientoInventarios Borrar(MovimientoInventarios entidad);
    }
}