using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.ResponseDto
{
    public record CommentResponseDto /*(string username, string comments, DateTime createdAt);*/
    {
        public string UserName { get; init; }
        public string Comments { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
