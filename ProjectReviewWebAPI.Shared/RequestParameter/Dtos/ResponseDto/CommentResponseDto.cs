using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Dtos.ResponseDto
{
    public record CommentResponseDto 
    {
        public string UserName { get; init; }
        public string Comments { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
