
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectReview.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        // POST api/<AuthenticationController>
        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto userRegisterDto)
        {
            var result = await _authenticationService.RegisterUser(userRegisterDto);

            if(!result.identity.Succeeded)
            {
                foreach(var error in result.identity.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            string encodedToken = System.Text.Encodings.Web.UrlEncoder.Default.Encode(result.emailToken);
            string callback_url = Request.Scheme + "://" + Request.Host + $"/api/authentication/confirm-email/{userRegisterDto.Email}/{encodedToken}";

            //Sends email to user to confirm registration
            _authenticationService.SendConfirmationEmail(userRegisterDto.Email, callback_url);
            return StatusCode(201, "Account created successfully. Please confirm your email");
        }


        //[Authorize(Roles = "Admin")]
        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserRegisterDto userRegisterDto)
        {
            var result = await _authenticationService.RegisterAdmin(userRegisterDto);
            if (!result.identity.Succeeded)
            {
                foreach (var error in result.identity.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto loginDto)
        {
            if(! await _authenticationService.ValidateUser(loginDto))
            {
                return Unauthorized();
            }

            return Ok(new {token = await _authenticationService.CreateToken()});
        }

        [HttpGet("confirm-email/{email}/{token}")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            string decodedToken = WebUtility.UrlDecode(token);
            var result=await _authenticationService.ConfirmEmailAddress(email, decodedToken);

            return StatusCode(result.StatusCode, result.Message);
        }

    }
}
