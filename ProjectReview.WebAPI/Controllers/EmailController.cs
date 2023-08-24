using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectReviewWebAPI.Application.Services.Abstractions;

namespace ProjectReview.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("sendMail")]
        public async Task<IActionResult> SendMail()
        {
            var receiver = "olusheyidan@gmail.com";
            var subject = "Dot Net Test Mail";
            var message = "Hello Bashorun DotNet";

            await _emailService.SendEmailAsync(receiver, subject, message);
            return Ok("sent");
        }
    }
}
