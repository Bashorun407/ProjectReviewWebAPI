using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Comment>()
                .HasKey(c => c.Id);
            builder.Entity<Project>()
                .HasKey(p => p.Id);
            builder.Entity<Rating>()
                .HasKey(r => r.Id);
            builder.Entity<Transaction>()
                .HasKey(t => t.Id);
            builder.Entity<User>()
                .HasKey(u => u.Id);

            builder.Entity<Project>()
                .HasOne(p => p.User)
                .WithMany(p => p.Projects)
                .HasForeignKey(p => p.ProjectOwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Project>()
                .HasOne(p => p.ProjectCommencementDetail)
                .WithOne(p => p.Project)
                .HasForeignKey<Project>(p => p.ProjectCommencementDetail)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProjectCommencementDetail>()
                .HasOne(p => p.Project)
                .WithOne(p => p.ProjectCommencementDetail)
                .HasForeignKey<Project>(p => p.ProjectOwnerId);

            builder.Entity<Rating>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Rating);

            builder.Entity<User>()
                .HasOne(u => u.Rating)
                .WithMany(r => r.Users)
                .HasForeignKey(r => r.UserId);

            builder.Entity<User>()
                .HasMany(u => u.Projects)
                .WithOne(p => p.User);
                

            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new ProjectConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<ProfilePhoto> ProfilePhotos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
