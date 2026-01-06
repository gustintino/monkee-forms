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
 
        public MonkeeFormsDbContext(DbContextOptions<MonkeeFormsDbContext> options) : base(options) { } 
    }
}
