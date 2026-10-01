using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IElementosInternosAplicacion
    {
        ElementosInternos Insertar(ElementosInternos entidad);
        List<ElementosInternos> Consultar();
        ElementosInternos Actualizar(ElementosInternos entidad);
        ElementosInternos Borrar(ElementosInternos entidad);
    }
}
