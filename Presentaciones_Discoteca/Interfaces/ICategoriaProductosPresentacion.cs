using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface ICategoriaProductosPresentacion
    {
        Task<CategoriaProductos> Insertar(CategoriaProductos entidad);
        Task<CategoriaProductos> Actualizar(CategoriaProductos entidad);
        Task<List<CategoriaProductos>> Consultar();
        Task<List<CategoriaProductos>> Buscar(CategoriaProductos entidad);
        Task<CategoriaProductos> Borrar(CategoriaProductos entidad);

    }
}
