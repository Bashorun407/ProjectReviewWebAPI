using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Dtos.RequestDtos
{
    public record PhotoRequestDto /*(string url, IFormFile file);*/
    {
        public string Url { get; init; }
        public IFormFile File { get; init; }
    }
}
