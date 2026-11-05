using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios_Discoteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {
        private IEventosAplicacion iAplicacion;

        public EventosController(IEventosAplicacion iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost("Insertar")]
        public Eventos Insertar([FromBody] Eventos entidad)
        {
            return this.iAplicacion.Insertar(entidad);
        }

        [HttpPost("Actualizar")]
        public Eventos Actualizar([FromBody] Eventos entidad)
        {
            return this.iAplicacion.Actualizar(entidad);
        }

        [HttpPost("Borrar")]
        public Eventos Borrar([FromBody] Eventos entidad)
        {
            return this.iAplicacion.Borrar(entidad);
        }

        [HttpPost("Consultar")]
        public List<Eventos> Consultar()
        {
            return this.iAplicacion.Consultar();
        }
    }
}