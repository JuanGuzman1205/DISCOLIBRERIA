using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IDetalleReparacionesAplicacion
    {
        DetalleReparaciones Insertar(DetalleReparaciones entidad);
        List<DetalleReparaciones> Consultar();
        DetalleReparaciones Actualizar(DetalleReparaciones entidad);
        DetalleReparaciones Borrar(DetalleReparaciones entidad);
    }
}
