using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public class ProjectAdminUpdateDto
    {
        public ProjectLevelApprovalStatus ProjectLevelApprovalStatus { get; set; }  
    }
}
