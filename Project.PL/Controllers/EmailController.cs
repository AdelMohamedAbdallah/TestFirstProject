using Microsoft.AspNetCore.Mvc;
using Project.BLL.Model;
using System.Net;
using System.Net.Mail;

namespace Project.PL.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendEmail(EmailVM email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                    smtp.Credentials = new NetworkCredential("adel3052003adel@gmail.com", "1q2w3e4@");

                    smtp.EnableSsl = true;

                    smtp.Send("adel3052003adel@gmail.com", "adel2852003adel@gmail.com", email.Title, email.Message);

                    ViewBag.Message = "Email sent successfully";

                    return RedirectToAction("SendEmail");
                }

                return View();

            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error :" + ex.Message;
                return View();
            }
        }

    }
}
