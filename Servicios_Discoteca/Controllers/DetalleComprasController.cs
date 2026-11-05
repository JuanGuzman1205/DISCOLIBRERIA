using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios_Discoteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetalleComprasController : ControllerBase
    {
        private IDetalleComprasAplicacion iAplicacion;

        public DetalleComprasController(IDetalleComprasAplicacion iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost("Insertar")]
        public DetalleCompras Insertar([FromBody] DetalleCompras entidad)
        {
            return this.iAplicacion.Insertar(entidad);
        }

        [HttpPost("Actualizar")]
        public DetalleCompras Actualizar([FromBody] DetalleCompras entidad)
        {
            return this.iAplicacion.Actualizar(entidad);
        }

        [HttpPost("Borrar")]
        public DetalleCompras Borrar([FromBody] DetalleCompras entidad)
        {
            return this.iAplicacion.Borrar(entidad);
        }

        [HttpPost("Consultar")]
        public List<DetalleCompras> Consultar()
        {
            return this.iAplicacion.Consultar();
        }
    }
}