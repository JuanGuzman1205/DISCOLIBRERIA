using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IMetodosPagosPresentacion
    {
        Task<MetodosPagos> Insertar(MetodosPagos entidad);
        Task<MetodosPagos> Actualizar(MetodosPagos entidad);
        Task<List<MetodosPagos>> Consultar();
        Task<List<MetodosPagos>> Buscar(MetodosPagos entidad);
        Task<MetodosPagos> Borrar(MetodosPagos entidad);
    }
}