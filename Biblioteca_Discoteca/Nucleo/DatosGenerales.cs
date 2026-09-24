using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Nucleo
{
    public class DatosGenerales
    {
        public static string ObtenerStringConexion()
        {
            return "server=localhost;database=SistemaGestion;Integrated Security=True;TrustServerCertificate=true;";
        }
    }
}
