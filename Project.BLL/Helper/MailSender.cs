﻿
using Project.BLL.Model;
using System.Net;
using System.Net.Mail;

namespace Project.BLL.Helper
{
    public static class MailSender
    {

        public static string SendMail(EmailVM mail)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.UseDefaultCredentials = false;

            smtpClient.EnableSsl = true;

            smtpClient.Credentials = new NetworkCredential("adel2852003adel@gmail.com", "hfav xzzn viix dxba");

            smtpClient.Send("adel2852003adel@gmail.com", mail.Email, mail.Title, mail.Message);

            return "Email sent successfully";
        }


    }
}