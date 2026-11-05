using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios_Discoteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetodosPagosController : ControllerBase
    {
        private IMetodosPagoAplicacion iAplicacion;

        public MetodosPagosController(IMetodosPagoAplicacion iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost("Insertar")]
        public MetodosPagos Insertar([FromBody] MetodosPagos entidad)
        {
            return this.iAplicacion.Insertar(entidad);
        }

        [HttpPost("Actualizar")]
        public MetodosPagos Actualizar([FromBody] MetodosPagos entidad)
        {
            return this.iAplicacion.Actualizar(entidad);
        }

        [HttpPost("Borrar")]
        public MetodosPagos Borrar([FromBody] MetodosPagos entidad)
        {
            return this.iAplicacion.Borrar(entidad);
        }

        [HttpPost("Consultar")]
        public List<MetodosPagos> Consultar()
        {
            return this.iAplicacion.Consultar();
        }
    }
}