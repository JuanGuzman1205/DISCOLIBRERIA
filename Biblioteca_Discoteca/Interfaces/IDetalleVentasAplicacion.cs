using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IDetalleVentasAplicacion
    {
        DetalleVentas Insertar(DetalleVentas entidad);
        List<DetalleVentas> Consultar();
        DetalleVentas Actualizar(DetalleVentas entidad);
        DetalleVentas Borrar(DetalleVentas entidad);
    }
}
