using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IComprasPresentacion
    {
        Task<Compras> Insertar(Compras entidad);
        Task<Compras> Actualizar(Compras entidad);
        Task<List<Compras>> Consultar();
        Task<List<Compras>> Buscar(Compras entidad);
        Task<Compras> Borrar(Compras entidad);

    }
}
