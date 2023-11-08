using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProjectReviewWebAPI.Infrastructure.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData
                (
                new Project
                {
                    Id = "c9d4c053-49b6-410c-bc78-2d54a9991870",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    CoverImage = "urlImage",
                    ProjectName = "House_Project",
                    ProjectDescription = "To build a house.",
                    ProjectOwnerId = "b9d4c053-49b6-410c-uj78-2d54a9991819",
                    Category = Category.PROOFREADING
                },

                new Project
                {
                    Id = "c9d4c053-49b6-410c-bc78-2d54a99911123",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    CoverImage = "urlImage",
                    ProjectName = "School_Project",
                    ProjectDescription = "To build a school.",
                    ProjectOwnerId = "c9d4c053-49b6-410c-bc78-2d54a97890",
                    Category = Category.EDIT
                }
                ); ;
        }

    }
}
