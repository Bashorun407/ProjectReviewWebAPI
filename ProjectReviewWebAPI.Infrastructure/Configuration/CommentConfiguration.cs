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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData
                (
                new Comment
                {
                    Id = "c9d4c053-49b6-410c-bc78-2d54a9991870",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    UserId = "c9d4c053-49b6-410c-bc78-2d54a97890",
                    Comments = "How is it going?",


                },

                new Comment
                {
                    Id = "3d490a70-94ce-4d15-9494-5248280c2ce3",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    UserId = "b9d4c053-49b6-410c-uj78-2d54a9991819",
                    Comments = "It's going great!",
                }
                ) ;
        }

    }
}
