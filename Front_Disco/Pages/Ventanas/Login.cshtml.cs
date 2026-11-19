using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Disco.Pages
{
    public class LoginModel : PageModel
    {
        public bool EstaLogueado { get; set; } = false;
        public string? ErrorMensaje { get; set; }

        [BindProperty]
        public string? NombreUsuario { get; set; }

        [BindProperty]
        public string? Contrasena { get; set; }

        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!string.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
            }
        }

        public void OnPostBtClean()
        {
            NombreUsuario = string.Empty;
            Contrasena = string.Empty;
            ErrorMensaje = null;
        }

        public IActionResult OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NombreUsuario) || string.IsNullOrWhiteSpace(Contrasena))
                {
                    ErrorMensaje = "Por favor, ingresa tu usuario y contraseña.";
                    return Page();
                }

                // TODO: Reemplaza esta validación con tu consulta real de usuarios
                if (NombreUsuario != "admin" || Contrasena != "12345")
                {
                    ErrorMensaje = "Credenciales incorrectas o usuario inactivo.";
                    Contrasena = string.Empty;
                    return Page();
                }

                HttpContext.Session.SetString("Usuario", NombreUsuario);
                EstaLogueado = true;
                ViewData["Logged"] = true;

                return RedirectToPage("/Consultar");
            }
            catch (Exception ex)
            {
                ErrorMensaje = "Ocurrió un error al iniciar sesión: " + ex.Message;
                return Page();
            }
        }

        public IActionResult OnPostBtClose()
        {
            HttpContext.Session.Clear();
            EstaLogueado = false;
            return Redirect("/");
        }
    }
}