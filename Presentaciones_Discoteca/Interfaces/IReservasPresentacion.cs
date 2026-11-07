using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IReservasPresentacion
    {
        Task<Reservas> Insertar(Reservas entidad);
        Task<Reservas> Actualizar(Reservas entidad);
        Task<List<Reservas>> Consultar();
        Task<List<Reservas>> Buscar(Reservas entidad);
        Task<Reservas> Borrar(Reservas entidad);
    }
}