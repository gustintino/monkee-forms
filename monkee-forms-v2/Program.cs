using monkee_forms_v2.Data;

namespace monkee_forms_v2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var httpClient = new HttpClient();
            var apiClient = new TypeRacerApi(httpClient);

            using var db = MonkeeFormsDbContext.Create();
            db.Database.EnsureCreated();

            Application.Run(new Form1(apiClient)); 
        }
    }
}