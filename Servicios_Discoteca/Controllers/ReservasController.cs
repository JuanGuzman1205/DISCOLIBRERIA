using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios_Discoteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservasController : ControllerBase
    {
        private IReservasAplicacion iAplicacion;

        public ReservasController(IReservasAplicacion iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost("Insertar")]
        public Reservas Insertar([FromBody] Reservas entidad)
        {
            return this.iAplicacion.Insertar(entidad);
        }

        [HttpPost("Actualizar")]
        public Reservas Actualizar([FromBody] Reservas entidad)
        {
            return this.iAplicacion.Actualizar(entidad);
        }

        [HttpPost("Borrar")]
        public Reservas Borrar([FromBody] Reservas entidad)
        {
            return this.iAplicacion.Borrar(entidad);
        }

        [HttpPost("Consultar")]
        public List<Reservas> Consultar()
        {
            return this.iAplicacion.Consultar();
        }
    }
}