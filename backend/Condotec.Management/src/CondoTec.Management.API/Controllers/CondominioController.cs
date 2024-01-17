using Microsoft.AspNetCore.Mvc;

namespace CondoTec.Management.API.Controllers
{
    public class CondominioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
