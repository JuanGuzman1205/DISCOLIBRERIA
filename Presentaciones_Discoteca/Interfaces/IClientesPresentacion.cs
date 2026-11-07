using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IClientesPresentacion
    {
        Task<Clientes> Insertar(Clientes entidad);
        Task<Clientes> Actualizar(Clientes entidad);
        Task<List<Clientes>> Consultar();
        Task<List<Clientes>> Buscar(Clientes entidad);
        Task<Clientes> Borrar(Clientes entidad);

    }
}
