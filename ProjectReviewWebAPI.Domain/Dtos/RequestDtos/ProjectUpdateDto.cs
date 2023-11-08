using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public record ProjectUpdateDto /*(string projectName, string projectDescription);*/
    {
        public string ProjectName { get; init; }
        public string ProjectDescription { get; init; }
    }
}
