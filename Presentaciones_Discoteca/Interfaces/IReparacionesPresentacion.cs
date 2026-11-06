using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IReparacionesPresentacion
    {
        Reparaciones Insertar(Reparaciones entidad);
        Reparaciones Actualizar(Reparaciones entidad);
        List<Reparaciones> Consultar();
        List<Reparaciones> Buscar(Reparaciones entidad);
        Reparaciones Borrar(Reparaciones entidad);
    }
}