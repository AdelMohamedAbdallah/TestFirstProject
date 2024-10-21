using Microsoft.AspNetCore.Mvc;

namespace Project.PL.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Register()
        {
            TempData["txt"] = "Welcom with you ....";
            return RedirectToAction("DepartmentServices", "Department");
        }
    }
}
