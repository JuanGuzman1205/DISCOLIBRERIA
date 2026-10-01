using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IInventariosAplicacion
    {
        Inventarios Insertar(Inventarios entidad);
        List<Inventarios> Consultar();
        Inventarios Actualizar(Inventarios entidad);
        Inventarios Borrar(Inventarios entidad);
    }
}
