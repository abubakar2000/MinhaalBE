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

        [Route("mail/{email}")]
        [HttpPost]
        public async Task<string> Email(string email)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("abu8632632@gmail.com");
            mail.To.Add(email);
            mail.Subject = "OTP Notification and Login";
            mail.Body = "There was a login event. The Otp is <fgthmpj>";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            

            NetworkCredential nec = new NetworkCredential("abu8632632@gmail.com", "zjdqgaopoycdwimf");
            
            smtp.Credentials = nec;
            smtp.Send(mail);
            return "Sent";

        }

        [Route("mail/{email}/{content}")]
        [HttpPost]
        public async Task<string> Email(string email,string content)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("abu8632632@gmail.com");
            mail.To.Add(email);
            mail.Subject = "Notification";
            mail.Body = content;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;


            NetworkCredential nec = new NetworkCredential("abu8632632@gmail.com", "zjdqgaopoycdwimf");

            smtp.Credentials = nec;
            smtp.Send(mail);
            return "Sent";

        }
    }
}