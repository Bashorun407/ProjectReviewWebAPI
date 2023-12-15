using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Domain.Enums;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;

namespace ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {

        Task<PagedList<User>> GetAllUsers(UserRequestInputParameter param, bool trackChanges);
        
        Task<User> GetById(string id, bool trackChanges);
        //Task<User> GetByUserId(string userId, bool trackChanges);
        Task<User> GetByUsername(string username, bool trackChanges);

        Task<User> GetUserByPhoneNumber(string phoneNumber, bool trackChanges);
        Task<User> GetUserByEmail(string email, bool trackChanges);
        Task<PagedList<User>> GetBySpecialization(UserRequestInputParameter param,  bool trackChanges);
        Task<PagedList<User>> GetByUserRole(UserRequestInputParameter param, bool trackChanges);
        Task<PagedList<User>> GetByUserType(UserRequestInputParameter param, bool trackChanges);
        Task<PagedList<User>> GetByApplicationStatus(UserRequestInputParameter param, bool trackChanges);
        Task<PagedList<User>> GetAllServiceProvidersWithRating(UserRequestInputParameter param, bool trackChanges);
        Task<PagedList<User>> GetAllProjectsByUserId(UserRequestInputParameter param, bool trackChanges);
        Task<User> GetUserRatingByUserId(string userId, bool trackChanges);
        
    }
}
