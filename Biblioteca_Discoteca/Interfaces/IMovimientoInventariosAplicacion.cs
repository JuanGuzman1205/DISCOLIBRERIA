using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IMovimientoInventariosAplicacion
    {
        MovimientoInventarios Insertar(MovimientoInventarios entidad);
        List<MovimientoInventarios> Consultar();
        MovimientoInventarios Actualizar(MovimientoInventarios entidad);
        MovimientoInventarios Borrar(MovimientoInventarios entidad);
    }
}
