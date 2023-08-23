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

        public async Task<StandardResponse<(IEnumerable<CommentResponseDto> comments, MetaData pagingData)>> GetAllComments(CommentRequestInputParameter parameter)
        {
            var result = await _unitOfWork.CommentRepository.GetAllComments(parameter);
            var commentsDto = _mapper.Map<IEnumerable<CommentResponseDto>>(result);

            return StandardResponse<(IEnumerable<CommentResponseDto>, MetaData)>.Success("All Comments retrieved", (commentsDto, result.MetaData), 200);
        }

        public async Task<StandardResponse<(IEnumerable<CommentResponseDto> comments, MetaData pagingData)>> GetCommentsByProjectId(CommentRequestInputParameter parameter)
        {
            var result = await _unitOfWork.CommentRepository.GetCommentByProjectId(parameter);
            var commentsDto = _mapper.Map<IEnumerable<CommentResponseDto>>(result);

            return StandardResponse<(IEnumerable<CommentResponseDto>, MetaData)>.Success("All comments by projectId", (commentsDto, result.MetaData), 200);
        }

        public async Task<StandardResponse<(IEnumerable<CommentResponseDto> comments, MetaData pagingData)>> GetCommentsByUsername(CommentRequestInputParameter parameter)
        {
            var result = await _unitOfWork.CommentRepository.GetCommentByUsername(parameter);

            var commentsDto = _mapper.Map<IEnumerable<CommentResponseDto>>(result);

            return StandardResponse<(IEnumerable<CommentResponseDto>, MetaData)>.Success("All comments by specified username", (commentsDto, result.MetaData), 200);
        }
    }
}
