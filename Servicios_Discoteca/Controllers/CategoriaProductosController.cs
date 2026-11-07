using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios_Discoteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaProductosController : ControllerBase
    {
        private ICategoriaProductosAplicacion iAplicacion;

        public CategoriaProductosController(ICategoriaProductosAplicacion iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost("Insertar")]
        public CategoriaProductos Insertar([FromBody] CategoriaProductos entidad)
        {
            return this.iAplicacion.Insertar(entidad);
        }

        [HttpPost("Actualizar")]
        public CategoriaProductos Actualizar([FromBody] CategoriaProductos entidad)
        {
            return this.iAplicacion.Actualizar(entidad);
        }

        [HttpPost("Borrar")]
        public CategoriaProductos Borrar([FromBody] CategoriaProductos entidad)
        {
            return this.iAplicacion.Borrar(entidad);
        }

        [HttpPost("Consultar")]
        public List<CategoriaProductos> Consultar()
        {
            return this.iAplicacion.Consultar();
        }
    }
}