using Microsoft.EntityFrameworkCore;
using MonkLab_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace MonkLab_Test.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<SentMessage> SentMessages { get; set; }
       
    }
}
