using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IEventosPresentacion
    {
        Eventos Insertar(Eventos entidad);
        Eventos Actualizar(Eventos entidad);
        List<Eventos> Consultar();
        List<Eventos> Buscar(Eventos entidad);
        Eventos Borrar(Eventos entidad);
    }
}