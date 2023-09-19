using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public class ProjectRequestDto
    {
        public string CoverImage { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectOwnerId { get; set; }
        public string ClientUsername { get; set; }
        public Category Category { get; set; }


    }
}
