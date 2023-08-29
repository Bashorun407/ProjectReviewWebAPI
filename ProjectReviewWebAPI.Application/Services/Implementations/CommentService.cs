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

        public async Task<StandardResponse<IEnumerable<CommentResponseDto>>> GetAllComments()
        {
            var result = await _unitOfWork.CommentRepository.GetAll(false);
            var commentsDto = _mapper.Map<IEnumerable<CommentResponseDto>>(result);

            return StandardResponse<IEnumerable<CommentResponseDto>>.Success("All Comments retrieved", commentsDto, 200);
        }

        public async Task<StandardResponse<IEnumerable<CommentResponseDto>>> GetCommentsByProjectId(string projectId)
        {
            var result = await _unitOfWork.CommentRepository.GetCommentByProjectId(projectId, false);
            var commentsDto = _mapper.Map<IEnumerable<CommentResponseDto>>(result);

            return StandardResponse<IEnumerable<CommentResponseDto>>.Success("All comments by projectId", commentsDto, 200);
        }

        public async Task<StandardResponse<IEnumerable<CommentResponseDto>>> GetCommentsByUsername(string username)
        {
            var result = await _unitOfWork.CommentRepository.GetCommentByUsername(username, false);

            var commentsDto = _mapper.Map<IEnumerable<CommentResponseDto>>(result);

            return StandardResponse<IEnumerable<CommentResponseDto>>.Success("All comments by specified username", commentsDto, 200);
        }
    }
}
