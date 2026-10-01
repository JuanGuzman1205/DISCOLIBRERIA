using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IEventosAplicacion
    {
        Eventos Insertar(Eventos entidad);
        List<Eventos> Consultar();
        Eventos Actualizar(Eventos entidad);
        Eventos Borrar(Eventos entidad);
    }
}
