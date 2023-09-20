using AutoMapper;
using Microsoft.Extensions.Logging;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Infrastructure.UoW.Abstraction;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Application.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CommentService> _logger;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CommentService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<StandardResponse<CommentResponseDto>> CreateComment(CommentRequestDto commentRequestDto)
        {
            _logger.LogInformation($"Comments made by {commentRequestDto.UserName}");

            var comment = _mapper.Map<Comment>(commentRequestDto);
            await _unitOfWork.CommentRepository.CreateAsync(comment);

            _logger.LogInformation("Comment saved to database");
            await _unitOfWork.SaveAsync();

            var commentDto = _mapper.Map<CommentResponseDto>(comment);

            return StandardResponse<CommentResponseDto>.Success("Comment successful", commentDto, 201);
        }

        public async Task<StandardResponse<IEnumerable<CommentResponseDto>>> GetAllComments(int pageNumber)
        {
            var parameter = new CommentRequestInputParameter();
            parameter.PageNumber = pageNumber;
            parameter.PageSize = 2;

            var result = await _unitOfWork.CommentRepository.GetAll(parameter, false);

            if (!result.Any())
            {
                return StandardResponse<IEnumerable<CommentResponseDto>>.Failed("there are no comments yet", 99);
            }
            var commentsDto = _mapper.Map<IEnumerable<CommentResponseDto>>(result);

            return StandardResponse<IEnumerable<CommentResponseDto>>.Success($"All Comments retrieved are: {commentsDto.Count()}", commentsDto, 200);
        }


        public async Task<StandardResponse<IEnumerable<CommentResponseDto>>> GetCommentsByUsername(string username)
        {
            var result = await _unitOfWork.CommentRepository.GetCommentByUsername(username, false);

            if (!result.Any())
            {
                return StandardResponse<IEnumerable<CommentResponseDto>>.Failed($"there are no comments by user with username : {username} yet", 99);
            }

            var commentsDto = _mapper.Map<IEnumerable<CommentResponseDto>>(result);

            return StandardResponse<IEnumerable<CommentResponseDto>>.Success($"All comments by specified username are: {commentsDto.Count()}", commentsDto, 200);
        }
    }
}
