using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IFacturasPresentacion
    {
        Facturas Insertar(Facturas entidad);
        Facturas Actualizar(Facturas entidad);
        List<Facturas> Consultar();
        List<Facturas> Buscar(Facturas entidad);
        Facturas Borrar(Facturas entidad);
    }
}