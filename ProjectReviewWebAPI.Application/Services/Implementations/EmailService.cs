using Microsoft.Extensions.Configuration;
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
        public IConfiguration configuration { get; }

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {

            var emailSettings = configuration.GetSection("EmailSettings");
            var mail = emailSettings["email"];
            var pw = emailSettings["password"];

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

