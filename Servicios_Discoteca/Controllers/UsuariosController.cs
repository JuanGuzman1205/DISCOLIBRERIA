using Biblioteca_Discoteca.Entidades;
using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Servicios_Discoteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosAplicacion iAplicacion;

        public UsuariosController(IUsuariosAplicacion iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost("Insertar")]
        public Usuarios Insertar([FromBody] Usuarios entidad)
        {
            return this.iAplicacion.Insertar(entidad);
        }

        [HttpPost("Actualizar")]
        public Usuarios Actualizar([FromBody] Usuarios entidad)
        {
            return this.iAplicacion.Actualizar(entidad);
        }

        [HttpPost("Borrar")]
        public Usuarios Borrar([FromBody] Usuarios entidad)
        {
            return this.iAplicacion.Borrar(entidad);
        }

        [HttpPost("Consultar")]
        public List<Usuarios> Consultar()
        {
            return this.iAplicacion.Consultar();
        }
    }
}