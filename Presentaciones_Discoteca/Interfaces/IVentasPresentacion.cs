using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IVentasPresentacion
    {
        Task<Ventas> Insertar(Ventas entidad);
        Task<Ventas> Actualizar(Ventas entidad);
        Task<List<Ventas>> Consultar();
        Task<List<Ventas>> Buscar(Ventas entidad);
        Task<Ventas> Borrar(Ventas entidad);
    }
}