using Microsoft.EntityFrameworkCore;
using monkee_forms_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace monkee_forms_v2.Data
{
    public class MonkeeFormsDbContext : DbContext 
    {
        public DbSet<Run> Runs => Set<Run>(); 

        // once again i hate this
        private readonly string _dbPath = "monkeeforms.db";

        public static MonkeeFormsDbContext Create() => new MonkeeFormsDbContext();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Path.Combine(AppContext.BaseDirectory, _dbPath);
            optionsBuilder.UseSqlite($"Data Source={path}");
        }
    }
}
