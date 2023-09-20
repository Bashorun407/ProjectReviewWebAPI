using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Rating> _ratings;

        public RatingRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _ratings = context.Set<Rating>();
        }

        public async Task<IEnumerable<Rating>> GetAll(RatingRequestInputParameter parameter, bool trackChanges)
        {
           var result =  FindAll(trackChanges).OrderByDescending(c => c.StarRating).Skip((parameter.PageNumber - 1) * parameter.PageSize)
                .Take(parameter.PageSize);

            return result;
        }

        public async Task<Rating> GetRatingByUsername(string username, bool trackChanges)
        {
            var result = await FindByCondition(c => c.UserName.Equals(username), trackChanges).SingleOrDefaultAsync();

            return result;
        }



        /*public async Task<PagedList<Rating>> GetAllRating(RatingRequestInputParameter parameter)
        {
            var result = await _ratings.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize)
                .ToListAsync();
            var count = await _ratings.CountAsync();

            return new PagedList<Rating>(result, count, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<Rating> GetRatingByUserId(string userId)
        {
            var rate =  _ratings.Where(c=> c.UserId.Equals(userId)).FirstOrDefault();

            return rate;
        }
*/
    }
}
