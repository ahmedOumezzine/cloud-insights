using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cloud_Insights.BLL
{
    class BLL_GetInfo_type1
    {
        
        public static void get()
        {
            select_db_serveur();
            DAL.DAL_GetInfo.getProcessorInfo();
            DAL.DAL_GetInfo.getBaseBoardInfo();
             DAL.DAL_GetInfo.getBatteryInfo();
            DAL.DAL_GetInfo.getDiskDriveInfo();
            MessageBox.Show("f 2");

        }
        public static void select_db_serveur()
        {

            if (DAL.DBConnection.Verifier_disponible_lien(Program.Server) == "OK")
            {
                if (DAL.DAL_Composant.count() != 0)
                { DAL.DAL_Composant.local_internat(); }
                if (DAL.DAL_proprieteComposant.count() != 0)
                { DAL.DAL_proprieteComposant.local_internat(); }
            }

        }

        public static void get_15min()
        {
            select_db_serveur();

            PerformanceCounter cpuCounter = new PerformanceCounter("Processor","% Processor Time","_Total",true);
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);
 
         String CPU = Convert.ToInt32(cpuCounter.NextValue()).ToString()  ;
         String RAM = Convert.ToInt32(ramCounter.NextValue()).ToString()  ;
         if (DAL.DAL_proprieteComposant.inserpropocomposant("1111", "Processor Time", CPU, Program.iplocal))
         { MessageBox.Show(CPU); }
         if (DAL.DAL_proprieteComposant.inserpropocomposant("1100", "Memory Available MBytes", RAM, Program.iplocal))
               {      }
        }

    }
}
