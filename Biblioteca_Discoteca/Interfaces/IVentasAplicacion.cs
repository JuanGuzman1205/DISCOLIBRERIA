using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IVentasAplicacion
    {
        Ventas Insertar(Ventas entidad);
        List<Ventas> Consultar();
        Ventas Actualizar(Ventas entidad);
        Ventas Borrar(Ventas entidad);
    }
}
