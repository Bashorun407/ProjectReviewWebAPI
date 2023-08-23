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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbSet<User> _users;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _users = context.Set<User>();
        }

        public async Task<PagedList<User>> GetAllUsers(UserRequestInputParameter parameter)
        {
            var result = await _users.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize).ToListAsync();
            var count = await _users.CountAsync();

            return new PagedList<User>(result, count, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _users.Where(c=> c.Email.Contains(email, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefaultAsync()  ;
        }

        public async Task<User> GetById(string id)
        {
            return await _users.FindAsync(id);
        }

        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _users.Where(c=> c.PhoneNumber.Equals(phoneNumber)).FirstOrDefaultAsync();
        }

        public async Task<PagedList<User>> GetUsersBySpecialization(UserRequestInputParameter parameter)
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
        }

    }
}
