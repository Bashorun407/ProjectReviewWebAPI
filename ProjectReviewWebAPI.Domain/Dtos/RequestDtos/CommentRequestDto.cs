using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public record CommentRequestDto /*(string username, string comments);*/
    {
        public string UserName { get; init; }
        public string Comments { get; init; }
    }
}
