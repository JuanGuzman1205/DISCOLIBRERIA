using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IProductosAplicacion
    {
        Productos Insertar(Productos entidad);
        List<Productos> Consultar();
        Productos Actualizar(Productos entidad);
        Productos Borrar(Productos entidad);
    }
}
