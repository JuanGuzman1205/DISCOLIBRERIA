using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IMesasPresentacion
    {
        Mesas Insertar(Mesas entidad);
        Mesas Actualizar(Mesas entidad);
        List<Mesas> Consultar();
        List<Mesas> Buscar(Mesas entidad);
        Mesas Borrar(Mesas entidad);

    }
}
