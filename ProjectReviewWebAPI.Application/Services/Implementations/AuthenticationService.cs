using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Utility.Utility;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Application.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private User _user;
        private readonly IEmailService _emailService;


        public AuthenticationService(ILogger<AuthenticationService> logger, IMapper mapper, UserManager<User> userManager, IConfiguration config, IEmailService emailService)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _config = config;
            _emailService = emailService;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        }

        public async Task<(IdentityResult identity, string emailToken)> RegisterUser(UserRegisterDto userRegisterDto)
        {
           
            var user = _mapper.Map<User>(userRegisterDto);
            //assigning a unique UserId to each user
            user.UserId = Utilities.GenerateUniqueId();
            user.Specialization = Domain.Enums.ServiceProviderSpecialization.None;
            user.Role = Domain.Enums.UserRole.REGULAR;
            user.UserType = Domain.Enums.UserType.CLIENT;

            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
            string token = string.Empty;
            //Send an email to notify user
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            }
            
            return (result, token);
        }
        
        public async Task<(IdentityResult identity, string emailToken)> RegisterAdmin(UserRegisterDto userRegisterDto)
        {
           
            var user = _mapper.Map<User>(userRegisterDto);
            //assigning a unique UserId to each user
            user.UserId = Utilities.GenerateUniqueId();
            user.Specialization = Domain.Enums.ServiceProviderSpecialization.None;
            user.Role = Domain.Enums.UserRole.REGULAR;
            user.UserType = Domain.Enums.UserType.CLIENT;

            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
            string token = string.Empty;
            //Send an email to notify user
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            }
            
            return (result, token);
        }

        public async Task<bool> ValidateUser(UserLoginDto userLoginDto)
        {
            _user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userLoginDto.Password));

            if (!result)
                _logger.LogWarning($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");
            return result;

        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
             {
             new Claim(ClaimTypes.Name, _user.UserName)
             };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials,
        List<Claim> claims)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        public void SendConfirmationEmail(string email, string callback_url)
        {
            string title = "Confirm Email";
            string body = $"Hello, \nKindly confirm your email by clicking this: {callback_url}";
            _emailService.SendEmailAsync(email, title, body);
        }

        public async Task<StandardResponse<string>> ConfirmEmailAddress(string email, string token)
        {
            string trimedToken = token.Replace(" ", "+");
            User user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
               return StandardResponse<string>.Failed("User not found", 404);
            }
            if (user.EmailConfirmed)
            {
                return StandardResponse<string>.Failed($"Email: {user.Email} has already been confirmed", 404);
            }
            IdentityResult result = await _userManager.ConfirmEmailAsync(user, trimedToken);
            if (!result.Succeeded)
            {
                return StandardResponse<string>.Failed($"Failed, unable to confirm your email: {user.Email}", 406);
            }
            return StandardResponse<string>.Success("Email confirmed",string.Empty, 200);
        }

        public void SendResetPasswordEmail(string email, string callback_url)
        {
            string title = "Confirm Password";
            string body = $"Hello, \nKindly confirm your password.";
            _emailService.SendEmailAsync(email, title, body);
        }
    }
}
