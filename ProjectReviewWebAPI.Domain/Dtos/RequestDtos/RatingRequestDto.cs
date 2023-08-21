﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public class RatingRequestDto
    {
        private string ProjectId { get; set; }
        private int StarRating { get; set; }
        private int RateCount { get; set; }
        private double AverageRating { get; set; }
    }
}
