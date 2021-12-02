using ApiWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Data
{
    public class ApiWebContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlite(connectionString: "Data Source=user.db;Cache=Shared");

        public DbSet<User> User { get; set; }
    }
}
