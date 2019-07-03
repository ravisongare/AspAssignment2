using AspAssignment.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace AspAssignment.Data
{
   public class AspAssignmentDbContext : DbContext
    {
        public AspAssignmentDbContext(DbContextOptions<AspAssignmentDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> comments { get; set; }


    }
}
