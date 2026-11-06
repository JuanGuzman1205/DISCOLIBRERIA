using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios_Discoteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetalleReparacionesController : ControllerBase
    {
        private IDetalleReparacionesAplicacion iAplicacion;

        public DetalleReparacionesController(IDetalleReparacionesAplicacion iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost("Insertar")]
        public DetalleReparaciones Insertar([FromBody] DetalleReparaciones entidad)
        {
            return this.iAplicacion.Insertar(entidad);
        }

        [HttpPost("Actualizar")]
        public DetalleReparaciones Actualizar([FromBody] DetalleReparaciones entidad)
        {
            return this.iAplicacion.Actualizar(entidad);
        }

        [HttpPost("Borrar")]
        public DetalleReparaciones Borrar([FromBody] DetalleReparaciones entidad)
        {
            return this.iAplicacion.Borrar(entidad);
        }

        [HttpPost("Consultar")]
        public List<DetalleReparaciones> Consultar()
        {
            return this.iAplicacion.Consultar();
        }
    }
}