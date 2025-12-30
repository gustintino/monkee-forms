using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monkee_forms
{
    internal static class Program
    { 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var httpClient = new HttpClient();
            var apiClient = new TypeRacerApi(httpClient);


            Application.Run(new Form1(apiClient));
        }
    }
}
