﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.ResponseDto
{
    public class CommentResponseDto
    {
        private string UserName { get; set; }
        private string Comments { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}