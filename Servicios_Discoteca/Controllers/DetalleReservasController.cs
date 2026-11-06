using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios_Discoteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetalleReservasController : ControllerBase
    {
        private IDetalleReservasAplicacion iAplicacion;

        public DetalleReservasController(IDetalleReservasAplicacion iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost("Insertar")]
        public DetalleReservas Insertar([FromBody] DetalleReservas entidad)
        {
            return this.iAplicacion.Insertar(entidad);
        }

        [HttpPost("Actualizar")]
        public DetalleReservas Actualizar([FromBody] DetalleReservas entidad)
        {
            return this.iAplicacion.Actualizar(entidad);
        }

        [HttpPost("Borrar")]
        public DetalleReservas Borrar([FromBody] DetalleReservas entidad)
        {
            return this.iAplicacion.Borrar(entidad);
        }

        [HttpPost("Consultar")]
        public List<DetalleReservas> Consultar()
        {
            return this.iAplicacion.Consultar();
        }
    }
}