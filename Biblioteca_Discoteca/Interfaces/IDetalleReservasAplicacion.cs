using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IDetalleReservasAplicacion
    {
        DetalleReservas Insertar(DetalleReservas entidad);
        List<DetalleReservas> Consultar();
        DetalleReservas Actualizar(DetalleReservas entidad);
        DetalleReservas Borrar(DetalleReservas entidad);
    }
}
