using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface ICategoriaProductosAplicacion
    {
        CategoriaProductos Insertar(CategoriaProductos entidad);
        List<CategoriaProductos> Consultar();
        CategoriaProductos Actualizar(CategoriaProductos entidad);
        CategoriaProductos Borrar(CategoriaProductos entidad);
    }
}
