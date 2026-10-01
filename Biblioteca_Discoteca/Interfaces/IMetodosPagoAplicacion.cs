using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IMetodosPagoAplicacion
    {
        MetodosPagos Insertar(MetodosPagos entidad);
        List<MetodosPagos> Consultar();
        MetodosPagos Actualizar(MetodosPagos entidad);
        MetodosPagos Borrar(MetodosPagos entidad);
    }
}
