using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Diagnostics;


namespace Cloud_Insights
{
    public partial class Cloud_Insights_LMachine : Form
    {
        public Cloud_Insights_Login RefToForm1 { get; set; }
        Boolean check = true;
        public Cloud_Insights_LMachine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                BLL.BLL_Connection a = new BLL.BLL_Connection();
               if (a.verifier_usermachine(txt_idsociete.Text, txtpassword.Text, Program.UUIDMachine))
               {
                   bt_install.Enabled = true;
                   bt_authentifier.Enabled = false;
                   txt_idsociete.Enabled = txtpassword.Enabled =   false;
               } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.UseShellExecute = true;
            startInfo.Verb = "runas";
            startInfo.Arguments = "/c C:\\Windows\\Microsoft.NET\\Framework\\v2.0.50727\\InstallUtil.exe /u C:\\Users\\Ahmed\\Downloads\\MyNewService\\MyNewService\\bin\\Debug\\MyNewService.exe";
            process.StartInfo = startInfo;
            process.Start();
            MessageBox.Show("cebon ");
            bt_install.Enabled = true;
            bt_supprimer.Enabled = false;
            bt_start.Enabled = false;
            bt_stop.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.UseShellExecute = true;
            startInfo.Verb = "runas";
            startInfo.Arguments = "/c C:\\Windows\\Microsoft.NET\\Framework\\v2.0.50727\\InstallUtil.exe /i C:\\Users\\Ahmed\\Downloads\\MyNewService\\MyNewService\\bin\\Debug\\MyNewService.exe";
            process.StartInfo = startInfo;
            process.Start();
            MessageBox.Show("cebon ");
            bt_install.Enabled = false;
            bt_supprimer.Enabled = true;
            bt_start.Enabled = true;
            bt_stop.Enabled = true;
        }

 
 
  
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            check = false;

            RefToForm1.RefToForm2 = this;
            RefToForm1.i = 1;
            this.RefToForm1.Show();         
        }
 
 

        private void Cloud_Insights_LMachine_Load(object sender, EventArgs e)
        {
            try
            {
                ServiceController service = new ServiceController("MyNewService");
                 if (service.Status.ToString() == "Running")
                {
                    bt_start.Enabled = false;
                    bt_stop.Enabled = true;

                }
                else
                {
                    bt_start.Enabled = false;
                    bt_stop.Enabled = true;

                }

                bt_install.Enabled = false;
                bt_supprimer.Enabled = true;

            }
            catch(Exception ee)
            {
                bt_install.Enabled = true;
                bt_supprimer.Enabled = false;
                bt_start.Enabled = false;
                bt_stop.Enabled = false;
            }
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
 
        }

        private void bt_stop_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1");
            BLL.BLL_GetInfo_type1.get();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (DAL.DAL_proprieteComposant.inserpropocomposant("13","eee","eeee","eeee")==true)
                MessageBox.Show("eeeeff");
           }
 

        
    }
}
