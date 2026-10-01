using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IClientesAplicacion
    {
        Clientes Insertar(Clientes entidad);
        List<Clientes> Consultar();
        Clientes Actualizar(Clientes entidad);
        Clientes Borrar(Clientes entidad);
    }
}
