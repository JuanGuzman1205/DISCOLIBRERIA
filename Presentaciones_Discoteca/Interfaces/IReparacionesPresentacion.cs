using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IReparacionesPresentacion
    {
        Task<Reparaciones> Insertar(Reparaciones entidad);
        Task<Reparaciones> Actualizar(Reparaciones entidad);
        Task<List<Reparaciones>> Consultar();
        Task<List<Reparaciones>> Buscar(Reparaciones entidad);
        Task<Reparaciones> Borrar(Reparaciones entidad);
    }
}