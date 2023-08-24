using ProjectReviewWebAPI.Application.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace ProjectReviewWebAPI.Application.Services.Implementations
{
    public class EmailService : IEmailService
    {

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = "bobolah411cush@gmail.com";
            var pw = "encesyxlhgbsmqem";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };

            return client.SendMailAsync(
                new MailMessage(
                    from: mail,
                    to: email,
                    subject, 
                    message
                    ));
        }
    }
}
