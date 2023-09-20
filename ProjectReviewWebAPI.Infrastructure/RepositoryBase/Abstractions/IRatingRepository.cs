using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions
{
    public interface IRatingRepository : IRepository<Rating>
    {

        Task<IEnumerable<Rating>> GetAll(RatingRequestInputParameter parameter, bool trackChanges);
        Task<Rating>GetRatingByUsername(string username, bool trackChanges);

/*        Task<PagedList<Rating>> GetAllRating(RatingRequestInputParameter parameter);
        Task<Rating> GetRatingByUserId(string userId);*/
    }
}
