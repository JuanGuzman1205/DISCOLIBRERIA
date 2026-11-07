using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios_Discoteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElementosInternosController : ControllerBase
    {
        private IElementosInternosAplicacion iAplicacion;

        public ElementosInternosController(IElementosInternosAplicacion iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost("Insertar")]
        public ElementosInternos Insertar([FromBody] ElementosInternos entidad)
        {
            return this.iAplicacion.Insertar(entidad);
        }

        [HttpPost("Actualizar")]
        public ElementosInternos Actualizar([FromBody] ElementosInternos entidad)
        {
            return this.iAplicacion.Actualizar(entidad);
        }

        [HttpPost("Borrar")]
        public ElementosInternos Borrar([FromBody] ElementosInternos entidad)
        {
            return this.iAplicacion.Borrar(entidad);
        }

        [HttpPost("Consultar")]
        public List<ElementosInternos> Consultar()
        {
            return this.iAplicacion.Consultar();
        }
    }
}