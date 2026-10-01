using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IDetalleComprasAplicacion
    {
        DetalleCompras Insertar(DetalleCompras entidad);
        List<DetalleCompras> Consultar();
        DetalleCompras Actualizar(DetalleCompras entidad);
        DetalleCompras Borrar(DetalleCompras entidad);
    }
}
