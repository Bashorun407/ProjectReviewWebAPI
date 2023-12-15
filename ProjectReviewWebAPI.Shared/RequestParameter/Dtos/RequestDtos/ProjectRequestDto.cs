using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Dtos.RequestDtos
{
    public record ProjectRequestDto
    {
        public string CoverImage { get; init; }
        public string ProjectName { get; init; }
        public string ProjectDescription { get; init; }
        public string ProjectOwnerId { get; init; }
     
        public Category Category { get; init; }
    }
}
