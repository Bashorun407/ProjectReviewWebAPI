using Microsoft.AspNetCore.Identity;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Application.Services.Abstractions
{
    public interface IAuthenticationService
    {
        Task<(IdentityResult identity, string emailToken)> RegisterUser(UserRegisterDto userRegisterDto);
        Task<(IdentityResult identity, string emailToken)> RegisterAdmin(UserRegisterDto userRegisterDto);
        void SendResetPasswordEmail(string email, string callback_url);
        void SendConfirmationEmail(string email, string callback_url);
        Task<bool> ValidateUser(UserLoginDto userLoginDto);
        Task<string> CreateToken();
    }
}
