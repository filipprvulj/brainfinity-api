using Brainfinity.Data.Entities;
using Brainfinity.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Status> Statuses { get; set; }
        public DbSet<GradeLevel> GradeLevels { get; set; }
        public DbSet<Competition> Competitions { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Assignment> Assignments { get; set; }
        
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.SeedStatuses();
            builder.SeedGradeLevels();
            builder.SeedGrade();
        }
    }
}