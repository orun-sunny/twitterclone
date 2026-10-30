using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence
{
    public class TwitterCloneDbContext : DbContext
    {

        public TwitterCloneDbContext(DbContextOptions <TwitterCloneDbContext>options) : base(options) 
        { 

        
        
        }
        public DbSet<User>Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TwitterCloneDbContext).Assembly);
        }
    }
}
