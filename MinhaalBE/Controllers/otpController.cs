using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentEmail.Smtp;
using FluentEmail.Core;
using System.Net;
using System.Net.Mail;

namespace MinhaalBE.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class otpController : ControllerBase
    {

        [Route("mail")]
        [HttpPost]
        public async Task<string> Email()
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("abu8632632@gmail.com");
            mail.To.Add("abubakarasifmughal2ooo@gmail.com");
            mail.Subject = "A subject";
            mail.Body = "A mail body";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            

            NetworkCredential nec = new NetworkCredential("abu8632632@gmail.com", "SolutionAveIsTheFuture$$");
            
            smtp.Credentials = nec;
            smtp.Send(mail);
            return "Sent";

        }
    }
}