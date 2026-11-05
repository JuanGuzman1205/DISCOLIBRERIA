using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios_Discoteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetalleVentasController : ControllerBase
    {
        private IDetalleVentasAplicacion iAplicacion;

        public DetalleVentasController(IDetalleVentasAplicacion iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost("Insertar")]
        public DetalleVentas Insertar([FromBody] DetalleVentas entidad)
        {
            return this.iAplicacion.Insertar(entidad);
        }

        [HttpPost("Actualizar")]
        public DetalleVentas Actualizar([FromBody] DetalleVentas entidad)
        {
            return this.iAplicacion.Actualizar(entidad);
        }

        [HttpPost("Borrar")]
        public DetalleVentas Borrar([FromBody] DetalleVentas entidad)
        {
            return this.iAplicacion.Borrar(entidad);
        }

        [HttpPost("Consultar")]
        public List<DetalleVentas> Consultar()
        {
            return this.iAplicacion.Consultar();
        }
    }
}