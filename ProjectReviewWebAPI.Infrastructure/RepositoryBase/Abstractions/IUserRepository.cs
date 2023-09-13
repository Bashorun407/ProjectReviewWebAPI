using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Domain.Enums;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        //Task<PagedList<User>> GetAllUsers(UserRequestInputParameter parameter);
        //Task<PagedList<User>> GetAllUsers();

        /*        Task<PagedList<User>> GetUsersBySpecialization(UserRequestInputParameter parameter);
                Task<PagedList<User>> GetUsersByUserRole(UserRequestInputParameter parameter);
                Task<PagedList<User>> GetByApplicationStatus(UserRequestInputParameter parameter);*/

        Task<IEnumerable<User>> GetAllUsers(UserRequestInputParameter param, bool trackChanges);
        //Task<StandardResponse<IEnumerable<User>>> GetAllUsers();
        Task<User> GetById(string id, bool trackChanges);
        Task<User> GetByUserId(string userId, bool trackChanges);
        Task<User> GetByUsername(string username, bool trackChanges);

        Task<User> GetUserByPhoneNumber(string phoneNumber, bool trackChanges);
        Task<User> GetUserByEmail(string email, bool trackChanges);
        Task<IEnumerable<User>> GetBySpecialization(UserRequestInputParameter param, Specialization specialization, bool trackChanges);
        Task<IEnumerable<User>> GetByUserRole(UserRequestInputParameter param, UserRole role, bool trackChanges);
        Task<IEnumerable<User>> GetByUserType(UserRequestInputParameter param, UserType type, bool trackChanges);
        Task<IEnumerable<User>> GetByApplicationStatus(UserRequestInputParameter param, ApplicationStatus applicationStatus, bool trackChanges);
        Task<IEnumerable<User>> GetAllServiceProvidersWithRating(UserRequestInputParameter param, bool trackChanges);
        Task<IEnumerable<User>> GetAllProjectsByUserId(UserRequestInputParameter param, string userId, bool trackChanges);
        Task<User> GetUserRatingByUserId(string userId, bool trackChanges);
        
    }
}
