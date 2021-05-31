using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnasNewsWebAPI.Models;

namespace WarnasNewsWebAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }

        public DbSet<News> News { get; set; }

        public DbSet<Log> Logs { get; set; }
    }
}
