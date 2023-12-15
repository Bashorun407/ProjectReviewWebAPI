using Microsoft.EntityFrameworkCore;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Infrastructure.Persistence;
using ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;

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

        public async Task<PagedList<Rating>> GetAll(RatingRequestInputParameter parameter, bool trackChanges)
        {
           var result =  FindAll(trackChanges)
                .OrderByDescending(c => c.StarRating)
                .AsQueryable();

            return await PagedList<Rating>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<Rating> GetRatingByUserId(string userId, bool trackChanges)
        {
            var result = await FindByCondition(c => c.UserId.Equals(userId), trackChanges).SingleOrDefaultAsync();

            return result;
        }

    }
}
