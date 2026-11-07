using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IFacturasPresentacion
    {
        Task<Facturas> Insertar(Facturas entidad);
        Task<Facturas> Actualizar(Facturas entidad);
        Task<List<Facturas>> Consultar();
        Task<List<Facturas>> Buscar(Facturas entidad);
        Task<Facturas> Borrar(Facturas entidad);
    }
}