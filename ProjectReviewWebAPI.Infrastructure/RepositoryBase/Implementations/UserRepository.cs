using Microsoft.EntityFrameworkCore;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Domain.Enums;
using ProjectReviewWebAPI.Infrastructure.Persistence;
using ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions;
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

        public async Task<IEnumerable<User>> GetAllUsers(UserRequestInputParameter parameter, bool trackChanges)
        {
            var result = FindAll(trackChanges).OrderBy(c => c.LastName).Skip((parameter.PageNumber - 1) * parameter.PageSize)
                .Take(parameter.PageSize);

            return result;
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

        public async Task<IEnumerable<User>> GetBySpecialization(UserRequestInputParameter param, Specialization specialization, bool trackChanges)
        {
           var result = await FindByCondition(c => c.Specialization.Equals(specialization), trackChanges).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<User>> GetByUserRole(UserRequestInputParameter param, UserRole role, bool trackChanges)
        {
            var result = await FindByCondition(c => c.Role.Equals(role), trackChanges).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<User>> GetByApplicationStatus(UserRequestInputParameter param, ApplicationStatus applicationStatus, bool trackChanges)
        {
            var result = await FindByCondition(c => c.ApplicationStatus.Equals(applicationStatus), trackChanges).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<User>> GetByUserType(UserRequestInputParameter param, UserType type, bool trackChanges)
        {
            var result = await FindByCondition(c => c.UserType.Equals(type), trackChanges).OrderByDescending(c => c.ChargeRate).ToListAsync();
            
            return result;
        }

        public async Task<IEnumerable<User>> GetAllProjectsByUserId(UserRequestInputParameter param, string userId, bool trackChanges)
        {
            var result = await FindByCondition(c => c.Id.Equals(userId), trackChanges).Include(c => c.Projects).ToListAsync();
            
            return result;
        }

        public async Task<User> GetUserRatingByUserId(string userId, bool trackChanges)
        {
            var result = await FindByCondition(c => c.Id.Equals(userId), trackChanges).Include(c => c.Ratings).FirstOrDefaultAsync();

            return result;

        }

        public async Task<IEnumerable<User>> GetAllServiceProvidersWithRating(UserRequestInputParameter param, bool trackChanges)
        {
            var result = await FindByCondition(c => c.UserType.Equals(UserType.SERVICE_PROVIDER), trackChanges).OrderByDescending(c => c.ChargeRate).OrderByDescending(c => c.Ratings).ToListAsync();

            return result;
        }

        public async Task<User> GetByUsername(string username, bool trackChanges)
        {
            var result = await FindByCondition(c => c.UserName.Equals(username), trackChanges).FirstOrDefaultAsync();

            return result;
        }



        /*        public async Task<PagedList<User>> GetUsersBySpecialization(UserRequestInputParameter parameter)
                {
                    var result = await _users.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize)
                        .Where(c=> c.Specialization.Equals(parameter.SearchTerm))
                        .ToListAsync();

                    var count = await _users.CountAsync();

                    return new PagedList<User>(result, count, parameter.PageNumber, parameter.PageSize);
                }


                public async Task<PagedList<User>> GetUsersByUserRole(UserRequestInputParameter parameter)
                {
                    var result = await _users.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize)
                        .Where(c=> c.Role.Equals(parameter.SearchTerm))
                        .ToListAsync();
                    var count = await _users.CountAsync();

                    return new PagedList<User>(result, count, parameter.PageNumber, parameter.PageSize);
                }

                public async Task<User> GetByUserId(string userId)
                {
                    return await _users.FindAsync(userId);
                }

                public async Task<PagedList<User>> GetByApplicationStatus(UserRequestInputParameter parameter)
                {
                    var result = await _users.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize)
                        .Where(c=> c.ApplicationStatus.Equals(parameter.SearchTerm))
                        .ToListAsync();

                    var count = await _users.CountAsync();

                    return new PagedList<User>(result, count, parameter.PageNumber, parameter.PageSize);
                }*/

    }
}
