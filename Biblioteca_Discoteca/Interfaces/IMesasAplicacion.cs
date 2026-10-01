using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IMesasAplicacion
    {
        Mesas Insertar(Mesas entidad);
        List<Mesas> Consultar();
        Mesas Actualizar(Mesas entidad);
        Mesas Borrar(Mesas entidad);
    }
}
