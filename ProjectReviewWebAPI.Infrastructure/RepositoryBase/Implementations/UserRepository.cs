using Microsoft.EntityFrameworkCore;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Domain.Enums;
using ProjectReviewWebAPI.Infrastructure.Persistence;
using ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;

namespace ProjectReviewWebAPI.Infrastructure.RepositoryBase.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbSet<User> _users;
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _users = _context.Set<User>();
        }

        public async Task<PagedList<User>> GetAllUsers(UserRequestInputParameter parameter, bool trackChanges)
        {
            var result = FindAll(trackChanges).OrderBy(c => c.LastName)
                .AsQueryable();

            return await PagedList<User>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<User> GetUserByEmail(string email, bool trackChanges)
        {
            return await FindByCondition(u => u.Email == email, trackChanges).SingleOrDefaultAsync();
        }

        public async Task<User> GetById(string id, bool trackChanges)
        {
            return await FindByCondition(c => c.Id==id, trackChanges).SingleOrDefaultAsync();
        }

        public async Task<User> GetUserByPhoneNumber(string phoneNumber, bool trackChanges)
        {

            return await FindByCondition(c => c.PhoneNumber == phoneNumber, trackChanges).FirstOrDefaultAsync();
        }

        public async Task<User> GetByUserId(string userId, bool trackChanges)
        {
            return await FindByCondition(c => c.UserId == userId, trackChanges).SingleOrDefaultAsync();
        }

        public async Task<PagedList<User>> GetBySpecialization(UserRequestInputParameter parameter, bool trackChanges)
        {
           var result = FindByCondition(c => c.Specialization.Equals(parameter.SearchTerm), trackChanges)
                .OrderBy(c => c.LastName)
                .AsQueryable();

            return await PagedList<User>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<PagedList<User>> GetByUserRole(UserRequestInputParameter parameter, bool trackChanges)
        {
            var result = FindByCondition(c => c.Role.Equals(parameter.SearchTerm), trackChanges)
                .OrderBy(c => c.LastName)
                .AsQueryable();


            return await PagedList<User>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<PagedList<User>> GetByApplicationStatus(UserRequestInputParameter parameter, bool trackChanges)
        {
            var result = FindByCondition(c => c.ApplicationStatus.Equals(parameter.SearchTerm), trackChanges)
                .OrderBy(c => c.LastName)
                .AsQueryable();

            return await PagedList<User>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<PagedList<User>> GetByUserType(UserRequestInputParameter parameter, bool trackChanges)
        {
            var result = FindByCondition(c => c.UserType.Equals(parameter.SearchTerm), trackChanges)
                .OrderByDescending(c => c.ChargeRate)
                .AsQueryable();
            
            return await PagedList<User>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<PagedList<User>> GetAllProjectsByUserId(UserRequestInputParameter parameter, bool trackChanges)
        {
            var result = FindByCondition(c => c.UserId.Equals(parameter.SearchTerm), trackChanges)
                .Include(c => c.Projects)
                .OrderBy(x => x.CreatedAt)
                .AsQueryable();
            
            return await PagedList<User>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<User> GetUserRatingByUserId(string userId, bool trackChanges)
        {
            var result = await FindByCondition(c => c.UserId.Equals(userId), trackChanges).Include(c => c.Rating).FirstOrDefaultAsync();

            return result;

        }

        public async Task<PagedList<User>> GetAllServiceProvidersWithRating(UserRequestInputParameter parameter, bool trackChanges)
        {
            var result = FindByCondition(c => c.UserType.Equals(UserType.SERVICE_PROVIDER), trackChanges)
                .OrderByDescending(c => c.ChargeRate).OrderByDescending(c => c.Rating)
                .AsQueryable();

            return await PagedList<User>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<User> GetByUsername(string username, bool trackChanges)
        {
            var result = await FindByCondition(c => c.UserName.Equals(username), trackChanges).FirstOrDefaultAsync();

            return result;
        }

    }
}
