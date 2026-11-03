using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface ICategoriaProductosPresentacion
    {
        CategoriaProductos Insertar(CategoriaProductos entidad);
        CategoriaProductos Actualizar(CategoriaProductos entidad);
        List<CategoriaProductos> Consultar();
        List<CategoriaProductos> Buscar(CategoriaProductos entidad);
        CategoriaProductos Borrar(CategoriaProductos entidad);

    }
}
