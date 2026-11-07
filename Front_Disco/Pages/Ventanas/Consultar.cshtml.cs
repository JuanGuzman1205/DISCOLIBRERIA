
using Inventario_Discoteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Pages
{
    public class ProductosModel : PageModel
    {
        private IProductosPresentacion IProductosPresentacion;

        public ProductosModel(IProductosPresentacion IProductosPresentacion)
        {
            this.IProductosPresentacion = IProductosPresentacion;
        }

        [BindProperty]
        public List<Productos> Lista { get; set; } = new List<Productos>();

        public string ErrorMensaje { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                Lista = await this.IProductosPresentacion.Consultar();

                if (Lista == null)
                {
                    ErrorMensaje = "La consulta devolvió una lista nula.";
                    Lista = new List<Productos>();
                }
            }
            catch (Exception ex)
            {
                ErrorMensaje = ex.Message;
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
