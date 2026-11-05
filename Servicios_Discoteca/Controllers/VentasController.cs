using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios_Discoteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentasController : ControllerBase
    {
        private IVentasAplicacion iAplicacion;

        public VentasController(IVentasAplicacion iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost("Insertar")]
        public Ventas Insertar([FromBody] Ventas entidad)
        {
            return this.iAplicacion.Insertar(entidad);
        }

        [HttpPost("Actualizar")]
        public Ventas Actualizar([FromBody] Ventas entidad)
        {
            return this.iAplicacion.Actualizar(entidad);
        }

        [HttpPost("Borrar")]
        public Ventas Borrar([FromBody] Ventas entidad)
        {
            return this.iAplicacion.Borrar(entidad);
        }

        [HttpPost("Consultar")]
        public List<Ventas> Consultar()
        {
            return this.iAplicacion.Consultar();
        }
    }
}