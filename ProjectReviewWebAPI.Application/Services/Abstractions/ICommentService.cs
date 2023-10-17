using ProjectReviewWebAPI.Domain.Dtos;
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
        Task<StandardResponse<PagedList<CommentResponseDto>>> GetAllComments(CommentRequestInputParameter parameter);
        Task<StandardResponse<PagedList<CommentResponseDto>>> GetCommentsByUsername(CommentRequestInputParameter parameter);

    }
}
