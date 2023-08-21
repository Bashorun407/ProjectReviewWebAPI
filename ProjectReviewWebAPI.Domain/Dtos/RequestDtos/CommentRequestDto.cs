using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public class CommentRequestDto
    {
        private string UserName { get; set; }
        private string Comments { get; set; }
    }
}
