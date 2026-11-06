using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios_Discoteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OtrosGastosController : ControllerBase
    {
        private IOtrosGastosAplicacion iAplicacion;

        public OtrosGastosController(IOtrosGastosAplicacion iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost("Insertar")]
        public OtrosGastos Insertar([FromBody] OtrosGastos entidad)
        {
            return this.iAplicacion.Insertar(entidad);
        }

        [HttpPost("Actualizar")]
        public OtrosGastos Actualizar([FromBody] OtrosGastos entidad)
        {
            return this.iAplicacion.Actualizar(entidad);
        }

        [HttpPost("Borrar")]
        public OtrosGastos Borrar([FromBody] OtrosGastos entidad)
        {
            return this.iAplicacion.Borrar(entidad);
        }

        [HttpPost("Consultar")]
        public List<OtrosGastos> Consultar()
        {
            return this.iAplicacion.Consultar();
        }
    }
}