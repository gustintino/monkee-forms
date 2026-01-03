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
        public DbSet<User> Users => Set<User>();
        public DbSet<Text> Texts => Set<Text>();

        // once again i hate this
        private readonly string _dbPath = "monkeeforms.db";

        public static MonkeeFormsDbContext Create() => new MonkeeFormsDbContext();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");
        } 
    }
}
