using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cloud_Insights
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            cout = 1;
            UUIDMachine = DAL.DAL_GetInfo.GetMotherboardID();
            iplocal = DAL.DAL_GetInfo.LocalIPAddress();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Cloud_Insights_Login());
        }

        public static string Server { get; set; }
        public static string IDComposant { get; set; }
        public static string UUIDMachine { get; set; }
        public static string iplocal { get; set; }

        public static string id { get; set; }

        public static string code { get; set; }

        public static int cout  { get; set; }
    }
}
