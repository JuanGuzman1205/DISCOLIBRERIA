using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IVentasPresentacion
    {
        Ventas Insertar(Ventas entidad);
        Ventas Actualizar(Ventas entidad);
        List<Ventas> Consultar();
        List<Ventas> Buscar(Ventas entidad);
        Ventas Borrar(Ventas entidad);
    }
}