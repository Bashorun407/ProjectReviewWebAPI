﻿using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string? CoverImage { get; set; }
        public Category Category { get; set; }
        public string ProjectName { get; set;}
        public string ProjectId { get; set;}
        public string ProjectDescription { get; set;}
        [Column(TypeName = "Money")]
        public double Budget { get; set; }
        public string ProjectOwner { get; set; }

        [ForeignKey(nameof(User))]
        public string ProjectOwnerId { get; set; } 
        public string? ServiceProviderId { get; set; }
        public DateOnly StartDate { get; set; } 
        public DateOnly EndDate { get; set;}
        public ProjectCompletionStatus ProjectStatus { get; set; }
        public ProjectApprovalStatus ProjectApprovalStatus { get; set; }
    }
}