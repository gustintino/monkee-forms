using monkee_forms_v2.Api.TypeRacerApi;
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
            ApplicationConfiguration.Initialize();

            var httpClient = new HttpClient();
            var apiClient = new TypeRacerApi(httpClient);

            using var db = MonkeeFormsDbContextFactory.Create();
            db.Database.EnsureCreated();

            Application.Run(new Form1(apiClient)); 
        }
    }
}