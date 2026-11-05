using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface ICajasPresentacion
    {
        Cajas Insertar(Cajas entidad);
        Cajas Actualizar(Cajas entidad);
        List<Cajas> Consultar();
        List<Cajas> Buscar(Cajas entidad);
        Cajas Borrar(Cajas entidad);
    }
}