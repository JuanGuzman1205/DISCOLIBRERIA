using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios_Discoteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReparacionesController : ControllerBase
    {
        private IReparacionesAplicacion iAplicacion;

        public ReparacionesController(IReparacionesAplicacion iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost("Insertar")]
        public Reparaciones Insertar([FromBody] Reparaciones entidad)
        {
            return this.iAplicacion.Insertar(entidad);
        }

        [HttpPost("Actualizar")]
        public Reparaciones Actualizar([FromBody] Reparaciones entidad)
        {
            return this.iAplicacion.Actualizar(entidad);
        }

        [HttpPost("Borrar")]
        public Reparaciones Borrar([FromBody] Reparaciones entidad)
        {
            return this.iAplicacion.Borrar(entidad);
        }

        [HttpPost("Consultar")]
        public List<Reparaciones> Consultar()
        {
            return this.iAplicacion.Consultar();
        }
    }
}