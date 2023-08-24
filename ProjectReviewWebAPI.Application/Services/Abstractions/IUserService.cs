using Microsoft.AspNetCore.Http;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Application.Services.Abstractions
{
    public interface IUserService
    {
        //Task<StandardResponse<UserResponseDto>> CreateUser(UserRequestDto userRequestDto);
        Task<StandardResponse<(IEnumerable<UserResponseDto> users, MetaData pagingData)>> GetAllUsers(UserRequestInputParameter parameter);
        Task<StandardResponse<UserResponseDto>> GetById(string id);
        Task<StandardResponse<UserResponseDto>> GetByUserId(string userId);
        Task<StandardResponse<UserResponseDto>> GetByEmail(string email);
        Task<StandardResponse<UserResponseDto>> GetByPhoneNumber(string phoneNumber);
        Task<StandardResponse<(IEnumerable<UserResponseDto> users, MetaData pagingData)>> GetBySpecialization(UserRequestInputParameter parameter);
        Task<StandardResponse<(IEnumerable<UserResponseDto> users, MetaData pagingData)>> GetByRole(UserRequestInputParameter parameter);
        Task<StandardResponse<UserResponseDto>> UpdateUser(string id,  UserRequestDto userRequestDto);
        Task<StandardResponse<UserResponseDto>> DeleteUser(string id);
        Task<StandardResponse<(bool, string)>> UploadProfileImage(string userId, IFormFile file);

    }
}
