using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public class CommentRequestDto
    {
        public string ProjectId { get; set; }
        public string UserName { get; set; }
        public string Comments { get; set; }
    }
}
