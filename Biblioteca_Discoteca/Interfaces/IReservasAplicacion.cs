using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IReservasAplicacion
    {
        Reservas Insertar(Reservas entidad);
        List<Reservas> Consultar();
        Reservas Actualizar(Reservas entidad);
        Reservas Borrar(Reservas entidad);
    }
}
