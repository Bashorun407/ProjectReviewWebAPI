using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;

namespace ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions
{
    public interface IRatingRepository : IRepository<Rating>
    {

        Task<PagedList<Rating>> GetAll(RatingRequestInputParameter parameter, bool trackChanges);
        Task<Rating>GetRatingByUsername(string username, bool trackChanges);
    }
}
