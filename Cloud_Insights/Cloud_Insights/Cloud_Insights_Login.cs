using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cloud_Insights
{
    public partial class Cloud_Insights_Login : Form
    {
        public Cloud_Insights_LMachine RefToForm2 { get; set; }
        public int i = 0;
        public Cloud_Insights_Login()
        {
            InitializeComponent();
        }
        BLL.BLL_Connection a = new BLL.BLL_Connection();

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Server = txt_server.Text;
            if (a.verifier_usertechicien(txtlogin.Text, txtmotpass.Text))
            {
                //if (i==1)
                //    this.RefToForm2.Show();
                //else{
                    Cloud_Insights_LMachine machine = new Cloud_Insights_LMachine();
                 //   machine.RefToForm1 = this;
                    this.Visible = false;
                    machine.Show();
               // }
                this.Hide();
            }
        }

        private void txtserver_Validating(object sender, CancelEventArgs e)
        {
            if (!a.verifier_lien(txt_server.Text)){
                errorProvider1.SetError(txt_server, "URL invalide: le format de l'URI n'a pas pu être déterminée");
                errorProvider2.SetError(txt_server, "");
                errorProvider3.SetError(txt_server, "");
            }
            else{
                errorProvider1.SetError(txt_server, "");
                errorProvider2.SetError(txt_server, "");
                errorProvider3.SetError(txt_server, "Correct");
            }
        }

        private void Cloud_Insights_Login_Load(object sender, EventArgs e)
        {

        }
 

        private void button2_Click_1(object sender, EventArgs e)
        {
             PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
            String CPU = Convert.ToInt32(cpuCounter.NextValue()).ToString();
            MessageBox.Show(CPU);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PerformanceCounter cpuCounter;

            cpuCounter = new PerformanceCounter();

            cpuCounter.CategoryName = "Processor";

            cpuCounter.CounterName = "% Processor Time";

            cpuCounter.InstanceName = "_Total";

            // Get Current Cpu Usage

            string currentCpuUsage =           Convert.ToInt32(cpuCounter.NextValue()) + "%";
            MessageBox.Show(currentCpuUsage);
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            string DbCnnStr = @"Data Source=|DataDirectory|\db_local1.sdf";
            SqlCeConnection cnn = new SqlCeConnection(DbCnnStr);

            try
            {
                cnn.Open();
                MessageBox.Show("ce bon");
            }
            catch (Exception s) { MessageBox.Show("nn" + s.Message); }
               
        }

   
    }
    
}
