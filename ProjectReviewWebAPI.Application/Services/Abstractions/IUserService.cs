using Microsoft.AspNetCore.Http;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
using ProjectReviewWebAPI.Domain.Enums;
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
        //Task<StandardResponse<(IEnumerable<UserResponseDto> users, MetaData pagingData)>> GetAllUsers(UserRequestInputParameter parameter);
        Task<StandardResponse<IEnumerable<UserResponseDto>>> GetAllUsers(int pageNumber);
        Task<StandardResponse<UserResponseDto>> GetById(string id);
        Task<StandardResponse<UserResponseDto>> GetByUserId(string userId);
        Task<StandardResponse<UserResponseDto>> GetByEmail(string email);
        Task<StandardResponse<UserResponseDto>> GetByPhoneNumber(string phoneNumber);
        Task<StandardResponse<UserResponseDto>> GetByUsername(string username);
        Task<StandardResponse<IEnumerable<UserResponseDto>>> GetBySpecialization(int pageNumber, Specialization specialization);
        Task<StandardResponse<IEnumerable<UserResponseDto>>> GetByApplicationStatus(int pageNumber, ApplicationStatus applicationStatus);
        Task<StandardResponse<IEnumerable<UserResponseDto>>> GetByRole(int pageNumber, UserRole userRole);
        Task<StandardResponse<IEnumerable<UserResponseDto>>> GetByUserType(int pageNumber, UserType userType);
        Task<StandardResponse<IEnumerable<UserResponseDto>>> GetAllProjectsByUserId(int pageNumber, string userId);
        Task<StandardResponse<IEnumerable<ServiceProviderResponseDto>>> GetAllServiceProviders(int pageNumber);
        Task<StandardResponse<UserResponseDto>> GetRatingByUserId(string userId);
        Task<StandardResponse<UserUpdateResponseDto>> UpdateUser(string id,  UserUpdateRequestDto userUpdateDto);
        Task<StandardResponse<UserResponseDto>> DeleteUser(string id);
        Task<StandardResponse<(string, bool)>> UploadProfileImage(string userId, IFormFile file);

    }
}
