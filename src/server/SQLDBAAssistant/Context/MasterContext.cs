using Microsoft.EntityFrameworkCore;
using SQLDBAAssistant.Models.SQLiteModels;

namespace SQLDBAAssistant.Context
{
    public class MasterContext : DbContext
    { 
        protected readonly IConfiguration _configuration;
        public MasterContext(IConfiguration config)
        {
            _configuration = config;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("SQLiteConnection"));
        }

        public DbSet<Query> Queries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Connect> Connects { get; set; }
    }
}
