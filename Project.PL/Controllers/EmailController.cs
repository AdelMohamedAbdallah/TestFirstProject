using Microsoft.AspNetCore.Mvc;

namespace Project.PL.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult SendEmail()
        {
            return View();
        }

    }
}
