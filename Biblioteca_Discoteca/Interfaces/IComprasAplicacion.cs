using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IComprasAplicacion
    {
        Compras Insertar(Compras entidad);
        List<Compras> Consultar();
        Compras Actualizar(Compras entidad);
        Compras Borrar(Compras entidad);
    }
}
