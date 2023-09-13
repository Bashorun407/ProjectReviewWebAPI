﻿using ProjectReviewWebAPI.Domain.Dtos;
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
    public interface ICommentService
    {
        Task<StandardResponse<CommentResponseDto>> CreateComment(CommentRequestDto commentRequestDto);
        Task<StandardResponse<IEnumerable<CommentResponseDto>>> GetAllComments(int pageNumber);
        Task<StandardResponse<IEnumerable<CommentResponseDto>>> GetCommentsByProjectId(string projectId);
        Task<StandardResponse<IEnumerable<CommentResponseDto>>> GetCommentsByUsername(string username);


/*        Task<StandardResponse<(IEnumerable<CommentResponseDto> comments, MetaData pagingData)>> GetAllComments(CommentRequestInputParameter parameter);
        Task<StandardResponse<(IEnumerable<CommentResponseDto> comments, MetaData pagingData)>> GetCommentsByProjectId(CommentRequestInputParameter parameter);
        Task<StandardResponse<(IEnumerable<CommentResponseDto> comments, MetaData pagingData)>> GetCommentsByUsername(CommentRequestInputParameter parameter);*/
    }
}
