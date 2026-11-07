using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IEmpleadosPresentacion
    {
        Task<Empleados> Insertar(Empleados entidad);
        Task<Empleados> Actualizar(Empleados entidad);
        Task<List<Empleados>> Consultar();
        Task<List<Empleados>> Buscar(Empleados entidad);
        Task<Empleados> Borrar(Empleados entidad);
    }
}
