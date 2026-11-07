using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface ICajasPresentacion
    {
        Task<Cajas> Insertar(Cajas entidad);
        Task<Cajas> Actualizar(Cajas entidad);
        Task<List<Cajas>> Consultar();
        Task<List<Cajas>> Buscar(Cajas entidad);
        Task<Cajas> Borrar(Cajas entidad);
    }
}