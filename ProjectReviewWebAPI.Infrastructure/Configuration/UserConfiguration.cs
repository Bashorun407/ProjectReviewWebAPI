using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectReviewWebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProjectReviewWebAPI.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
                (
                new User
                {
                    Id = "b9d4c053-49b6-410c-uj78-2d54a9991819",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    FirstName = "Adedayo",
                    LastName = "Banji",
                    UserName = "Adex",
                    Email = "adex@gmail.com",
                    PasswordHash = "adex1234",

    },

                new User
                {
                    Id = "c9d4c053-49b6-410c-bc78-2d54a97890",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    FirstName = "Boboye",
                    LastName = "Adelani",
                    UserName = "Bobson",
                    Email = "bobson@gmail.com",
                    PasswordHash = "bobo1234",
                }
                );
        }

    }
}
