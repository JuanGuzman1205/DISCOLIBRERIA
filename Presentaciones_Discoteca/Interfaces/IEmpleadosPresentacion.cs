using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IEmpleadosPresentacion
    {
        Empleados Insertar(Empleados entidad);
        Empleados Actualizar(Empleados entidad);
        List<Empleados> Consultar();
        List<Empleados> Buscar(Empleados entidad);
        Empleados Borrar(Empleados entidad);
    }
}
