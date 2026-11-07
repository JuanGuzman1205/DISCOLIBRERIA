using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IMesasPresentacion
    {
        Task<Mesas> Insertar(Mesas entidad);
        Task<Mesas> Actualizar(Mesas entidad);
        Task<List<Mesas>> Consultar();
        Task<List<Mesas>> Buscar(Mesas entidad);
        Task<Mesas> Borrar(Mesas entidad);

    }
}
