using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios_Discoteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventariosController : ControllerBase
    {
        private IInventariosAplicacion iAplicacion;

        public InventariosController(IInventariosAplicacion iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost("Insertar")]
        public Inventarios Insertar([FromBody] Inventarios entidad)
        {
            return this.iAplicacion.Insertar(entidad);
        }

        [HttpPost("Actualizar")]
        public Inventarios Actualizar([FromBody] Inventarios entidad)
        {
            return this.iAplicacion.Actualizar(entidad);
        }

        [HttpPost("Borrar")]
        public Inventarios Borrar([FromBody] Inventarios entidad)
        {
            return this.iAplicacion.Borrar(entidad);
        }

        [HttpPost("Consultar")]
        public List<Inventarios> Consultar()
        {
            return this.iAplicacion.Consultar();
        }
    }
}