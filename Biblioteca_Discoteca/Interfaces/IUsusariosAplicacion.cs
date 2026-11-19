using Biblioteca_Discoteca.Entidades;
using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IUsuariosAplicacion
    {
        Usuarios Insertar(Usuarios entidad);
        List<Usuarios> Consultar();
        Usuarios Actualizar(Usuarios entidad);
        Usuarios Borrar(Usuarios entidad);
    }
}
