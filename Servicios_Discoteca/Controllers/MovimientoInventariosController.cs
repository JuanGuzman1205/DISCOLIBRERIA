using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios_Discoteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimientoInventariosController : ControllerBase
    {
        private IMovimientoInventariosAplicacion iAplicacion;

        public MovimientoInventariosController(IMovimientoInventariosAplicacion iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost("Insertar")]
        public MovimientoInventarios Insertar([FromBody] MovimientoInventarios entidad)
        {
            return this.iAplicacion.Insertar(entidad);
        }

        [HttpPost("Actualizar")]
        public MovimientoInventarios Actualizar([FromBody] MovimientoInventarios entidad)
        {
            return this.iAplicacion.Actualizar(entidad);
        }

        [HttpPost("Borrar")]
        public MovimientoInventarios Borrar([FromBody] MovimientoInventarios entidad)
        {
            return this.iAplicacion.Borrar(entidad);
        }

        [HttpPost("Consultar")]
        public List<MovimientoInventarios> Consultar()
        {
            return this.iAplicacion.Consultar();
        }
    }
}