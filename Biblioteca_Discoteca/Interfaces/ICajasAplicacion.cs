using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface ICajasAplicacion
    {
        Cajas Insertar(Cajas entidad);
        List<Cajas> Consultar();
        Cajas Actualizar(Cajas entidad);
        Cajas Borrar(Cajas entidad);
    }
}
