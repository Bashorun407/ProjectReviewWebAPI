using AutoMapper;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using ProjectReviewWebAPI.Shared.Dtos.ResponseDto;
using ProjectReviewWebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Application.Commons
{
    public class MapInitializers : Profile
    {
        public MapInitializers()
        {

            CreateMap<CommentRequestDto, Comment>();
            CreateMap<Comment, CommentResponseDto>();

            CreateMap<ProjectRequestDto, Project>();
            CreateMap<ProjectUpdateDto, Project>();
            CreateMap<ProjectServiceProviderUpdateDto, Project>();
            CreateMap<SelectServiceProviderDto, Project>();
            CreateMap<ProjectAdminUpdateDto,  Project>();
            CreateMap<Project, ProjectResponseDto>();

            CreateMap<RatingRequestDto, Rating>();
            CreateMap<Rating, RatingResponseDto>();

            CreateMap<TransactionRequestDto, Transaction>();
            CreateMap<Transaction, TransactionResponseDto>();

            CreateMap<UserRegisterDto, User>();
            CreateMap<UserUpdateRequestDto, User>();
            CreateMap<UserRequestDto, User>();
            CreateMap<UserServiceProviderUpdateDto, User>();
            CreateMap<UserAdminUpdateDto, User>();

            CreateMap<User, UserResponseDto>();
            CreateMap<User, UserUpdateResponseDto>();
            CreateMap<User, ServiceProviderResponseDto>();

        }
    }
}
