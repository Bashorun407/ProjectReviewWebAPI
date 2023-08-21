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
    public interface IUserRepository : IRepository<User>
    {
        Task<PagedList<User>> GetAllUsers(UserRequestInputParameter parameter);
        Task<User> GetUserByPhoneNumber(string phoneNumber);
        Task<User> GetUserByEmail(string email);
        Task<PagedList<User>> GetUserBySpecialization(UserRequestInputParameter parameter);
        Task<PagedList<User>> GetUserByUserRole(UserRequestInputParameter parameter);
    }
}
