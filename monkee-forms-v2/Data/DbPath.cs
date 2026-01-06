using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monkee_forms_v2.Data
{
    public class DbPath
    {
        public static string GetProjectRoot()
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);

            while (dir != null && !dir.EnumerateFiles("*.csproj").Any())
                dir = dir.Parent;

            if (dir == null)
                throw new DirectoryNotFoundException("Could not find project root (.csproj)");

            return dir.FullName;
        }

        public static string GetDbPath()
        {
            var projectRoot = GetProjectRoot();
            var dataDir = Path.Combine(projectRoot, "Data");

            Directory.CreateDirectory(dataDir);

            return Path.Combine(dataDir, "monkee.db");
        }
    }
}
