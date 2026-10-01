using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IProveedoresAplicacion
    {
        Proveedores Insertar(Proveedores entidad);
        List<Proveedores> Consultar();
        Proveedores Actualizar(Proveedores entidad);
        Proveedores Borrar(Proveedores entidad);
    }
}
