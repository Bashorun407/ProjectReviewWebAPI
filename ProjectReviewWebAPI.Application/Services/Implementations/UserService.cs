﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using ProjectReviewWebAPI.Shared.Dtos.ResponseDto;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Infrastructure.UoW.Abstraction;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using ProjectReviewWebAPI.Utility.Utility;


namespace ProjectReviewWebAPI.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly IPhotoService _photoService;
        private readonly IEmailService _emailService;


        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger, IEmailService emailService, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _emailService = emailService;
            _photoService = photoService;
        }


        public async Task<StandardResponse<UserResponseDto>> DeleteUser(string id)
        {
            _logger.LogInformation($"Checking for user with id: {id} ");
            //var user = await _unitOfWork.UserRepository.GetById(id, false);
            var user = await _unitOfWork.UserRepository.GetById(id, false);

            if(user == null)
            {
                _logger.LogError($"user with id: {id} does not exist");
                return StandardResponse<UserResponseDto>.Failed("User not found in the database");
            }

            _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.SaveAsync();

            var userDto = _mapper.Map<UserResponseDto>(user);

            return StandardResponse<UserResponseDto>.Success($"User with id: {id} has been deleted.", userDto, 200);
        }


        public async Task<StandardResponse<PagedList<UserResponseDto>>> GetAllUsers(UserRequestInputParameter parameter)
        {

            var result = await _unitOfWork.UserRepository.GetAllUsers(parameter, false);
            if (!result.Any())
            {
                return StandardResponse<PagedList<UserResponseDto>>.Failed("There are no users yet", 99);
            }

            var userDtos = _mapper.Map<IEnumerable<UserResponseDto>>(result);
            var pagedList = new PagedList<UserResponseDto>(userDtos.ToList(), result.MetaData.TotalCount, parameter.PageNumber, parameter.PageSize);

            return StandardResponse<PagedList<UserResponseDto>>.Success($"All users", pagedList, 200);

        }

        public async Task<StandardResponse<PagedList<UserResponseDto>>> GetByApplicationStatus(UserRequestInputParameter parameter)
        {

            var result = await _unitOfWork.UserRepository.GetByApplicationStatus(parameter, false);

            if (!result.Any())
            {
                return StandardResponse<PagedList<UserResponseDto>>.Failed($"There are no users by the applicationStatus specified: {parameter.SearchTerm} yet", 99);
            }

            var usersDto =  _mapper.Map<IEnumerable<UserResponseDto>>(result);
            var pagedList = new PagedList<UserResponseDto>(usersDto.ToList(), result.MetaData.TotalCount, parameter.PageNumber, parameter.PageSize);

            return StandardResponse<PagedList<UserResponseDto>>.Success($"Users by application status specified found ", pagedList, 200);

        }

        public async Task<StandardResponse<UserResponseDto>> GetByEmail(string email)
        {
            var user = await _unitOfWork.UserRepository.GetUserByEmail(email, false);

            if(user is null)
            {
                return StandardResponse<UserResponseDto>.Failed($"User with email: {email} not found", 99);
            }
            var userDto = _mapper.Map<UserResponseDto>(user);

            return StandardResponse<UserResponseDto>.Success("User by email found", userDto, 200);
        }

        public async Task<StandardResponse<UserResponseDto>> GetById(string id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id, false);

            if (user is null)
            {
                return StandardResponse<UserResponseDto>.Failed($"{id} is not a user");
            }

            var userDto = _mapper.Map<UserResponseDto>(user);

            return StandardResponse<UserResponseDto>.Success("Successfully retrieved a user", userDto, 200);
        }

        public async Task<StandardResponse<UserResponseDto>> GetByPhoneNumber(string phoneNumber)
        {
            var user = await _unitOfWork.UserRepository.GetUserByPhoneNumber(phoneNumber, false);

            if( user is null)
            {
                return StandardResponse<UserResponseDto>.Failed($"User with phone number: {phoneNumber} does not exist", 99);
            }

            var userDto = _mapper.Map<UserResponseDto>(user);

            return StandardResponse<UserResponseDto>.Success($"User with phone number: {phoneNumber} found.", userDto, 200);
        }

        public async Task<StandardResponse<PagedList<UserResponseDto>>> GetByRole(UserRequestInputParameter parameter)
        {

            var result = await _unitOfWork.UserRepository.GetByUserRole(parameter, false);

            if (!result.Any())
            {
                return StandardResponse<PagedList<UserResponseDto>>.Failed($"User with role: {parameter.SearchTerm} does not exist", 99);

            }
            var usersDto = _mapper.Map<IEnumerable<UserResponseDto>>(result);
            var pagedList = new PagedList<UserResponseDto>(usersDto.ToList(), result.MetaData.TotalCount, parameter.PageNumber, parameter.PageSize);

            return StandardResponse<PagedList<UserResponseDto>>.Success($"Users by role specified found", pagedList, 200);
        }

        public async Task<StandardResponse<PagedList<UserResponseDto>>> GetBySpecialization(UserRequestInputParameter parameter)
        {

            var result = await _unitOfWork.UserRepository.GetBySpecialization(parameter, false);

            if (!result.Any())
            {
                return StandardResponse<PagedList<UserResponseDto>>.Failed($"User with specialization: {parameter.SearchTerm} does not exist", 99);

            }

            var usersDto = _mapper.Map<IEnumerable<UserResponseDto>>(result);
            var pagedList = new PagedList<UserResponseDto>(usersDto.ToList(), result.MetaData.TotalCount, parameter.PageNumber, parameter.PageSize);

            return StandardResponse<PagedList<UserResponseDto>>.Success($"Users by specialization specified found.", pagedList, 200);
        }

        public async Task<StandardResponse<UserResponseDto>> GetByUserId(string userId)
        {
            var user = await _unitOfWork.UserRepository.GetById(userId, false);
            if(user is null)
            {
                return StandardResponse<UserResponseDto>.Failed($"User with id: {userId} does not exist", 99);
            }

            var userDto = _mapper.Map<UserResponseDto>(user);

            return StandardResponse<UserResponseDto>.Success($"User with id: {userId} found", userDto, 200);
        }

        public async Task<StandardResponse<PagedList<UserResponseDto>>> GetByUserType(UserRequestInputParameter parameter)
        {

            var result = await _unitOfWork.UserRepository.GetByUserType(parameter,  false);

            if (!result.Any())
            {
                return StandardResponse<PagedList<UserResponseDto>>.Failed($"User with user-type: {parameter.SearchTerm} does not exist", 99);

            }

            var usersDto = _mapper.Map<IEnumerable<UserResponseDto>>(result);
            var pagedList = new PagedList<UserResponseDto>(usersDto.ToList(), result.MetaData.TotalCount, parameter.PageNumber, parameter.PageSize);

            return StandardResponse<PagedList<UserResponseDto>>.Success($"Users by user-type specified found", pagedList, 200);

        }

        public async Task<StandardResponse<PagedList<UserResponseDto>>> GetAllProjectsByUserId(UserRequestInputParameter parameter)
        {

            var result = await _unitOfWork.UserRepository.GetAllProjectsByUserId(parameter, false);

            if (!result.Any())
            {
                return StandardResponse<PagedList<UserResponseDto>>.Failed($"There are no projects with userId: {parameter.SearchTerm}", 99);
            }

            var usersDto = _mapper.Map<IEnumerable<UserResponseDto>>(result);
            var pagedList = new PagedList<UserResponseDto>(usersDto.ToList(), result.MetaData.TotalCount, parameter.PageNumber, parameter.PageSize);

            return StandardResponse<PagedList<UserResponseDto>>.Success($"Projects with user id: {parameter.SearchTerm}", pagedList, 200);

        }

        public async Task<StandardResponse<PagedList<ServiceProviderResponseDto>>> GetAllServiceProviders(UserRequestInputParameter parameter)
        {

            var result = await _unitOfWork.UserRepository.GetAllServiceProvidersWithRating(parameter, false);

            if (!result.Any())
            {
                return StandardResponse<PagedList<ServiceProviderResponseDto>>.Failed("There are no service providers yet");
            }

            var usersDto = _mapper.Map<IEnumerable<ServiceProviderResponseDto>>(result);
            var pagedList = new PagedList<ServiceProviderResponseDto>(usersDto.ToList(), result.MetaData.TotalCount, parameter.PageNumber, parameter.PageSize);

            return StandardResponse<PagedList<ServiceProviderResponseDto>>.Success($"All Service providers", pagedList, 200);
        }

        public async Task<StandardResponse<UserResponseDto>> GetRatingByUserId(string userId)
        {
            var result = await _unitOfWork.UserRepository.GetUserRatingByUserId(userId, false);

            if (result == null)
            {
                return StandardResponse<UserResponseDto>.Failed($"There are no rating by this id: {userId}", 99);
            }

            var userDto = _mapper.Map<UserResponseDto>(result);

            return StandardResponse<UserResponseDto>.Success($"Rating by user id: {userId} is: {result.Rating}", userDto, 200);
        }

        public async Task<StandardResponse<UserResponseDto>> GetByUsername(string username)
        {
            var result = await _unitOfWork.UserRepository.GetByUsername(username, false);

            if (result == null)
            {
                return StandardResponse<UserResponseDto>.Failed($"There is no user with username {username} ", 99);
            }

            var userDto = _mapper.Map<UserResponseDto>(result);

            return StandardResponse<UserResponseDto>.Success($"User with username {username}", userDto, 200);
        }

        public async Task<StandardResponse<UserUpdateResponseDto>> UpdateUser(string id, UserUpdateRequestDto userUpdateDto)
        {
            _logger.LogInformation($"Checking for user with id: {id}");
            //var userExists = await _unitOfWork.UserRepository.GetById(id, false);
            var userExists = await _unitOfWork.UserRepository.GetById(id, false);

            if(userExists is null)
            {
                _logger.LogError($"User with id: {id} does not exist.");
                return StandardResponse<UserUpdateResponseDto>.Failed($"User with id: {id} does not exist.");
            }

            //Checking if entered email is valid
            if (!Utilities.IsEmailValid(userUpdateDto.Email))
            {
                return StandardResponse<UserUpdateResponseDto>.Failed("Email is invalid", 99);
            }
            
            //Update happens here
           var updatedEntity = _mapper.Map(userUpdateDto, userExists);
            

            _logger.LogInformation($"Updating user with id: {id}");
  
            _unitOfWork.UserRepository.Update(updatedEntity);
            await _unitOfWork.SaveAsync();
            var userDto = _mapper.Map<UserUpdateResponseDto>(updatedEntity);

            //Sends email notification to user
            _emailService.SendEmailAsync(updatedEntity.Email, "Update Notification" , $"Hello {updatedEntity.FirstName}, \nYour details on BookReev has been successfully updated.");

            return StandardResponse<UserUpdateResponseDto>.Success($"User with id: {id} has been updated successfully", userDto, 200);

        }


        public async  Task<StandardResponse<(bool, string)>> UploadProfileImage(string userId, IFormFile file)
        {
            var result = await  _unitOfWork.UserRepository.GetById(userId, false);
           
            if (result is null)
            {
                _logger.LogWarning($"No user with id {userId}");

                return StandardResponse<(bool, string)>.Failed("user not found", 99);
               
            }

            var user = _mapper.Map<User>(result);

            string url =  _photoService.AddPhotoForUser(file);

            if (string.IsNullOrWhiteSpace(url))

                return StandardResponse<(bool, string)>.Failed("Failed to upload", 500);

            user.ProfilePicture = url;

            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveAsync();
            return StandardResponse<(bool, string)>.Success("Successfully uploaded image", (true, url), 204);

          
        }

        public async Task<StandardResponse<UserUpdateResponseDto>> ServiceProviderUpdate(string id, UserServiceProviderUpdateDto userUpdateDto)
        {
            _logger.LogInformation($"Checking for user with id: {id}");
            //var userExists = await _unitOfWork.UserRepository.GetById(id, false);
            var userExists = await _unitOfWork.UserRepository.GetById(id, false);

            if (userExists is null)
            {
                _logger.LogError($"User with id: {id} does not exist.");
                return StandardResponse<UserUpdateResponseDto>.Failed($"User with id: {id} does not exist.");
            }

            //Update happens here
            var updatedEntity = _mapper.Map(userUpdateDto, userExists);


            _logger.LogInformation($"Updating user with id: {id}");

            _unitOfWork.UserRepository.Update(updatedEntity);
            await _unitOfWork.SaveAsync();

            var userDto = _mapper.Map<UserUpdateResponseDto>(updatedEntity);

            //Sends email notification to user
            _emailService.SendEmailAsync(updatedEntity.Email, "Update Notification", $"Hello {updatedEntity.FirstName}, \nYour details on BookReev has been successfully updated.");

            return StandardResponse<UserUpdateResponseDto>.Success($"User with id: {id} has been updated successfully", userDto, 200);

        }

        public async Task<StandardResponse<UserUpdateResponseDto>> JobRoleUpdate(string id, UserAdminUpdateDto userUpdateDto)
        {
            _logger.LogInformation($"Checking for user with id: {id}");
            //var userExists = await _unitOfWork.UserRepository.GetById(id, false);
            var userExists = await _unitOfWork.UserRepository.GetById(id, false);

            if (userExists is null)
            {
                _logger.LogError($"User with id: {id} does not exist.");
                return StandardResponse<UserUpdateResponseDto>.Failed($"User with id: {id} does not exist.");
            }

            //Update happens here
            var updatedEntity = _mapper.Map(userUpdateDto, userExists);


            _logger.LogInformation($"Updating user job role with id: {id}");

            _unitOfWork.UserRepository.Update(updatedEntity);
            await _unitOfWork.SaveAsync();
            var userDto = _mapper.Map<UserUpdateResponseDto>(updatedEntity);

            //Sends email notification to user
            _emailService.SendEmailAsync(updatedEntity.Email, "Update Notification", $"Hello {updatedEntity.FirstName}, \nYour details on BookReev has been successfully updated.");

            return StandardResponse<UserUpdateResponseDto>.Success($"User with id: {id}'s job role has been updated successfully", userDto, 200);
        }
    }
}
