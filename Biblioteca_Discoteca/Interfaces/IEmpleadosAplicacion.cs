using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IEmpleadosAplicacion
    {
        Empleados Insertar(Empleados entidad);
        List<Empleados> Consultar();
        Empleados Actualizar(Empleados entidad);
        Empleados Borrar(Empleados entidad);
    }
}
