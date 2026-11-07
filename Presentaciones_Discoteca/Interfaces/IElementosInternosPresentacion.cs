using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IElementosInternosPresentacion
    {
        Task<ElementosInternos> Insertar(ElementosInternos entidad);
        Task<ElementosInternos> Actualizar(ElementosInternos entidad);
        Task<List<ElementosInternos>> Consultar();
        Task<List<ElementosInternos>> Buscar(ElementosInternos entidad);
        Task<ElementosInternos> Borrar(ElementosInternos entidad);

    }
}
