using Microsoft.AspNetCore.Mvc;

namespace API_Servicos.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
