using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IProductosPresentacion
    {
        Task<Productos> Insertar(Productos entidad);
        Task<Productos> Actualizar(Productos entidad);
        Task<List<Productos>> Consultar();
        Task<List<Productos>> Buscar(Productos entidad);
        Task<Productos> Borrar(Productos entidad);

    }
}
