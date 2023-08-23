﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Infrastructure.UoW.Abstraction;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using ProjectReviewWebAPI.Utility.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly IPhotoService _photoService;


        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<StandardResponse<UserResponseDto>> CreateUser(UserRequestDto userRequestDto)
        {
            _logger.LogInformation("Creating user.");
            var user = _mapper.Map<User>(userRequestDto);

            //Setting the userId of user
            user.UserId = Utilities.GenerateUniqueId();
            _logger.LogInformation("Adding user to database");
            await _unitOfWork.UserRepository.CreateAsync(user);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation($"Saved user with id: {user.Id} to database successfully");

            var userDto = _mapper.Map<UserResponseDto>(user);

            return StandardResponse<UserResponseDto>.Success("User created successfully", userDto, 201);

        }

        public async Task<StandardResponse<UserResponseDto>> DeleteUser(string id)
        {
            _logger.LogInformation($"Checking for user with id: {id} ");
            var user = await _unitOfWork.UserRepository.GetById(id);

            if(user is null)
            {
                _logger.LogError($"user with id: {id} does not exist");
                return StandardResponse<UserResponseDto>.Failed("User not found in the database");
            }

            _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.SaveAsync();

            var userDto = _mapper.Map<UserResponseDto>(user);

            return StandardResponse<UserResponseDto>.Success($"User with id: {id} has been deleted.", userDto, 200);
        }

        public async Task<StandardResponse<(IEnumerable<UserResponseDto> users, MetaData pagingData)>> GetAllUsers(UserRequestInputParameter parameter)
        {
            var result = await _unitOfWork.UserRepository.GetAllUsers(parameter);

            var userDtos = _mapper.Map<IEnumerable<UserResponseDto>>(result);

            return StandardResponse<(IEnumerable<UserResponseDto>, MetaData)>.Success("Successfully retrieved all users", (userDtos, result.MetaData), 200);

        }

        public async Task<StandardResponse<UserResponseDto>> GetByEmail(string email)
        {
            var user = await _unitOfWork.UserRepository.GetUserByEmail(email);

            if(user is null)
            {
                return StandardResponse<UserResponseDto>.Failed($"User with email: {email} not found", 99);
            }
            var userDto = _mapper.Map<UserResponseDto>(user);

            return StandardResponse<UserResponseDto>.Success("User by email found", userDto, 200);
        }

        public async Task<StandardResponse<UserResponseDto>> GetById(string id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);

            if (user is null)
            {
                return StandardResponse<UserResponseDto>.Failed($"{id} is not a user");
            }

            var userDto = _mapper.Map<UserResponseDto>(user);

            return StandardResponse<UserResponseDto>.Success("Successfully retrieved a user", userDto, 200);
        }

        public async Task<StandardResponse<UserResponseDto>> GetByPhoneNumber(string phoneNumber)
        {
            var user = await _unitOfWork.UserRepository.GetUserByPhoneNumber(phoneNumber);

            if( user is null)
            {
                return StandardResponse<UserResponseDto>.Failed($"User with phone number: {phoneNumber} does not exist", 99);
            }

            var userDto = _mapper.Map<UserResponseDto>(user);

            return StandardResponse<UserResponseDto>.Success($"User with phone number: {phoneNumber} found.", userDto, 200);
        }

        public async Task<StandardResponse<(IEnumerable<UserResponseDto> users, MetaData pagingData)>> GetByRole(UserRequestInputParameter parameter)
        {
            var result = await _unitOfWork.UserRepository.GetUsersByUserRole(parameter);
            var usersDto = _mapper.Map<IEnumerable<UserResponseDto>>(result);

            return StandardResponse<(IEnumerable<UserResponseDto>, MetaData)>.Success("Users by role specified found", (usersDto, result.MetaData), 200);
        }

        public async Task<StandardResponse<(IEnumerable<UserResponseDto> users, MetaData pagingData)>> GetBySpecialization(UserRequestInputParameter parameter)
        {
            var result = await _unitOfWork.UserRepository.GetUsersBySpecialization(parameter);

            var usersDto = _mapper.Map<IEnumerable<UserResponseDto>>(result);

            return StandardResponse<(IEnumerable<UserResponseDto>, MetaData)>.Success("Users by specialization specified found", (usersDto, result.MetaData), 200);
        }

        public async Task<StandardResponse<UserResponseDto>> GetByUserId(string userId)
        {
            var user = await _unitOfWork.UserRepository.GetByUserId(userId);
            if(user is null)
            {
                return StandardResponse<UserResponseDto>.Failed($"User with id: {userId} does not exist", 99);
            }

            var userDto = _mapper.Map<UserResponseDto>(user);

            return StandardResponse<UserResponseDto>.Success($"User with id: {userId} found", userDto, 200);
        }

        public async Task<StandardResponse<UserResponseDto>> UpdateUser(string id, UserRequestDto userRequestDto)
        {
            _logger.LogInformation($"Checking for user with id: {id}");
            var userExists = await _unitOfWork.UserRepository.GetById(id);

            if(userExists is null)
            {
                _logger.LogError($"User with id: {id} does not exist.");
                return StandardResponse<UserResponseDto>.Failed($"User with id: {id} does not exist.");
            }

            var user = _mapper.Map<User>(userRequestDto);
            _logger.LogInformation($"Updating user with id: {id}");
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveAsync();
            var userDto = _mapper.Map<UserResponseDto>(user);

            return StandardResponse<UserResponseDto>.Success($"User with id: {id} has been updated successfully", userDto, 200);

        }

        public Task<StandardResponse<(bool, string)>> UploadProfileImage(string userId, IFormFile file)
        {
            /*var user = await _unitOfWork.UserEntityRepository.GetUserById(userId);
            if (user is null)
            {
                _logger.LogWarning($"No user with id {userId}");
                return StandardResponse<(bool, string)>.Failed("No user found", 406);
            }
            string url = _photoService.AddPhotoForUser(userId, file);
            if (string.IsNullOrWhiteSpace(url))
                return StandardResponse<(bool, string)>.Failed("Failed to upload", 500);
            user.ImageURL = url;
            _unitOfWork.UserEntityRepository.Update(user);
            await _unitOfWork.SaveAsync();
            return StandardResponse<(bool, string)>.Success("Successfully uploaded image", (false, url), 204);*/

            return null;
        }
    }
}
