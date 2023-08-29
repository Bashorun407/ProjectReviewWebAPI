using AutoMapper;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
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
            CreateMap<Comment, CommentResponseDto>();
            CreateMap<CommentRequestDto, Comment>();
            CreateMap<Project,  ProjectResponseDto>();
            CreateMap<ProjectUpdateDto, Project>();
            CreateMap<CommentRequestDto, Project>();
            CreateMap<Rating, RatingResponseDto>();
            CreateMap<RatingRequestDto, Rating>();
            CreateMap<Transaction, TransactionResponseDto>();
            CreateMap<TransactionRequestDto, Transaction>();
            CreateMap<User, UserResponseDto>();
            //CreateMap<UserRequestDto, User>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
