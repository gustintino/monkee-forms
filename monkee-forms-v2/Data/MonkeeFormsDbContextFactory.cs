using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monkee_forms_v2.Data
{
    public class MonkeeFormsDbContextFactory : IDesignTimeDbContextFactory<MonkeeFormsDbContext>
    { 
        public MonkeeFormsDbContext CreateDbContext(string[] args)
        {
            var dbPath = DbPath.GetDbPath();
            var options = new DbContextOptionsBuilder<MonkeeFormsDbContext>()
                .UseSqlite($"Data Source={dbPath}")
                .Options;

            return new MonkeeFormsDbContext(options);
        }
        public static MonkeeFormsDbContext Create()
        {
            var dbPath = DbPath.GetDbPath();
            var options = new DbContextOptionsBuilder<MonkeeFormsDbContext>()
                .UseSqlite($"Data Source={dbPath}")
                .Options;

            return new MonkeeFormsDbContext(options);
        }
    }
}
