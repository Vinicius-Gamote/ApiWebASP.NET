using ApiWeb.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Persistence
{
    public class ApiWebContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlite(connectionString: "Data Source=user.db;Cache=Shared");

        public DbSet<User> Users { get; set; }

        public DbSet<SocialMedia> SocialMedia { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<UserPosition> UsersPositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<UserPosition>().HasKey(UP => new { UP.PositionId, UP.UserId });
        }
    }
}
