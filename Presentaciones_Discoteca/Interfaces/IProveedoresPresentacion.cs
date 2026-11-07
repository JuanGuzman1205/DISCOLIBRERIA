using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IProveedoresPresentacion
    {
        Task<Proveedores> Insertar(Proveedores entidad);
        Task<Proveedores> Actualizar(Proveedores entidad);
        Task<List<Proveedores>> Consultar();
        Task<List<Proveedores>> Buscar(Proveedores entidad);
        Task<Proveedores> Borrar(Proveedores entidad);

    }
}
