﻿using Microsoft.EntityFrameworkCore;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Infrastructure.Persistence;
using ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Infrastructure.RepositoryBase.Implementations
{
    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        private readonly DbSet<Rating> _ratings;

        public RatingRepository(ApplicationDbContext context) : base(context)
        {
            _ratings = context.Set<Rating>();
        }

        public async Task<PagedList<Rating>> GetAllRating(RatingRequestInputParameter parameter)
        {
            var result = await _ratings.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize)
                .ToListAsync();
            var count = await _ratings.CountAsync();

            return new PagedList<Rating>(result, count, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<Rating> GetRatingByProjectId(string projectId)
        {
            return await _ratings.FindAsync();
        }
    }
}
