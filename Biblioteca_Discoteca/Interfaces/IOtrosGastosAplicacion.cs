using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IOtrosGastosAplicacion
    {
        OtrosGastos Insertar(OtrosGastos entidad);
        List<OtrosGastos> Consultar();
        OtrosGastos Actualizar(OtrosGastos entidad);
        OtrosGastos Borrar(OtrosGastos entidad);
    }
}
