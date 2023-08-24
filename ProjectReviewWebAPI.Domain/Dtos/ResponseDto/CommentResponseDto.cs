using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.ResponseDto
{
    public class CommentResponseDto
    {
        public string ProjectId { get; set; }
        public string UserName { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
