using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IReparacionesAplicacion
    {
        Reparaciones Insertar(Reparaciones entidad);
        List<Reparaciones> Consultar();
        Reparaciones Actualizar(Reparaciones entidad);
        Reparaciones Borrar(Reparaciones entidad);
    }
}
