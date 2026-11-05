using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IElementosInternosPresentacion
    {
        ElementosInternos Insertar(ElementosInternos entidad);
        ElementosInternos Actualizar(ElementosInternos entidad);
        List<ElementosInternos> Consultar();
        List<ElementosInternos> Buscar(ElementosInternos entidad);
        ElementosInternos Borrar(ElementosInternos entidad);

    }
}
