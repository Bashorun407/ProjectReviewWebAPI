using Microsoft.AspNetCore.Http;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;

namespace ProjectReviewWebAPI.Application.Services.Abstractions
{
    public interface IUserService
    {
        
        Task<StandardResponse<PagedList<UserResponseDto>>> GetAllUsers(UserRequestInputParameter parameter);
        Task<StandardResponse<UserResponseDto>> GetById(string id);
        Task<StandardResponse<UserResponseDto>> GetByUserId(string userId);
        Task<StandardResponse<UserResponseDto>> GetByEmail(string email);
        Task<StandardResponse<UserResponseDto>> GetByPhoneNumber(string phoneNumber);
        Task<StandardResponse<UserResponseDto>> GetByUsername(string username);
        Task<StandardResponse<PagedList<UserResponseDto>>> GetBySpecialization(UserRequestInputParameter parameter);
        Task<StandardResponse<PagedList<UserResponseDto>>> GetByApplicationStatus(UserRequestInputParameter parameter);
        Task<StandardResponse<PagedList<UserResponseDto>>> GetByRole(UserRequestInputParameter parameter);
        Task<StandardResponse<PagedList<UserResponseDto>>> GetByUserType(UserRequestInputParameter parameter);
        Task<StandardResponse<PagedList<UserResponseDto>>> GetAllProjectsByUserId(UserRequestInputParameter parameter);
        Task<StandardResponse<PagedList<ServiceProviderResponseDto>>> GetAllServiceProviders(UserRequestInputParameter parameter);
        Task<StandardResponse<UserResponseDto>> GetRatingByUserId(string userId);
        Task<StandardResponse<UserUpdateResponseDto>> UpdateUser(string id,  UserUpdateRequestDto userUpdateDto);
        Task<StandardResponse<UserUpdateResponseDto>> ServiceProviderUpdate(string id, UserServiceProviderUpdateDto userUpdateDto);
        Task<StandardResponse<UserUpdateResponseDto>> JobRoleUpdate(string id, UserAdminUpdateDto userUpdateDto);
        Task<StandardResponse<UserResponseDto>> DeleteUser(string id);
        Task<StandardResponse<(bool, string)>> UploadProfileImage(string userId, IFormFile file);

    }
}
