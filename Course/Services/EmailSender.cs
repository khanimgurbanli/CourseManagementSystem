using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Course.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("sahdkjasd@gmail.com", "Confirm  email link from Students Course");
            msg.Subject = subject;
            msg.To.Add(email);
            msg.Body = htmlMessage;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("nobodynobodyva@gmail.com", "shsdjsdhjs");
            client.Timeout = 20000;
            client.Send(msg);

            return Task.CompletedTask;
        }
    }
}
