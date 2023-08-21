using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.ResponseDto
{
    public class ProjectResponseDto
    {
        private string CoverImage { get; set; }
        private string ProjectName { get; set; }
        private string Category { get; set; }
        private string ProjectOwner { get; set; }

        private DateOnly StartDate { get; set; }
        private DateOnly EndDate { get; set; }
    }
}
