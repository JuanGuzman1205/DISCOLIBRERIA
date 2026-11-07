using aplicaciones_horarios.entidades;
using aplicaciones_horarios.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front_horarios.Pages.Ventanas
{
    public class AsignacionesModel : PageModel
    {
        private IAsignacionesPresentacion IAsignacionesPresentacion;

        public AsignacionesModel(IAsignacionesPresentacion IAsignacionesPresentacion)
        {
            this.IAsignacionesPresentacion = IAsignacionesPresentacion;
        }

        [BindProperty] public List<Asignaciones> Lista { get; set; }

        public void OnGet()
        {
            try
            {
                Lista = this.IAsignacionesPresentacion.Consultar();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
