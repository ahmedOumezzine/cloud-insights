namespace Cloud_Insights
{
    partial class Cloud_Insights_LMachine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cloud_Insights_LMachine));
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.bt_authentifier = new System.Windows.Forms.Button();
            this.bt_install = new System.Windows.Forms.Button();
            this.bt_supprimer = new System.Windows.Forms.Button();
            this.txt_idsociete = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.bt_stop = new System.Windows.Forms.Button();
            this.bt_start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(352, 174);
            this.txtpassword.Multiline = true;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(157, 24);
            this.txtpassword.TabIndex = 8;
            // 
            // bt_authentifier
            // 
            this.bt_authentifier.Image = global::Cloud_Insights.Properties.Resources.validation;
            this.bt_authentifier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_authentifier.Location = new System.Drawing.Point(374, 204);
            this.bt_authentifier.Name = "bt_authentifier";
            this.bt_authentifier.Size = new System.Drawing.Size(115, 31);
            this.bt_authentifier.TabIndex = 10;
            this.bt_authentifier.Text = "S\'authentifier";
            this.bt_authentifier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_authentifier.UseVisualStyleBackColor = true;
            this.bt_authentifier.Click += new System.EventHandler(this.button1_Click);
            // 
            // bt_install
            // 
            this.bt_install.Location = new System.Drawing.Point(90, 292);
            this.bt_install.Name = "bt_install";
            this.bt_install.Size = new System.Drawing.Size(76, 34);
            this.bt_install.TabIndex = 11;
            this.bt_install.Text = "Install service";
            this.bt_install.UseVisualStyleBackColor = true;
            this.bt_install.Click += new System.EventHandler(this.button2_Click);
            // 
            // bt_supprimer
            // 
            this.bt_supprimer.Location = new System.Drawing.Point(179, 292);
            this.bt_supprimer.Name = "bt_supprimer";
            this.bt_supprimer.Size = new System.Drawing.Size(76, 34);
            this.bt_supprimer.TabIndex = 12;
            this.bt_supprimer.Text = "supprimer service";
            this.bt_supprimer.UseVisualStyleBackColor = true;
            this.bt_supprimer.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_idsociete
            // 
            this.txt_idsociete.Location = new System.Drawing.Point(353, 141);
            this.txt_idsociete.Multiline = true;
            this.txt_idsociete.Name = "txt_idsociete";
            this.txt_idsociete.Size = new System.Drawing.Size(157, 27);
            this.txt_idsociete.TabIndex = 14;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // bt_stop
            // 
            this.bt_stop.Location = new System.Drawing.Point(469, 292);
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.Size = new System.Drawing.Size(76, 34);
            this.bt_stop.TabIndex = 16;
            this.bt_stop.Text = "Stop service";
            this.bt_stop.UseVisualStyleBackColor = true;
            this.bt_stop.Click += new System.EventHandler(this.bt_stop_Click);
            // 
            // bt_start
            // 
            this.bt_start.Location = new System.Drawing.Point(379, 292);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(76, 34);
            this.bt_start.TabIndex = 15;
            this.bt_start.Text = "Start service";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // Cloud_Insights_LMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(634, 412);
            this.Controls.Add(this.bt_stop);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.txt_idsociete);
            this.Controls.Add(this.bt_supprimer);
            this.Controls.Add(this.bt_install);
            this.Controls.Add(this.bt_authentifier);
            this.Controls.Add(this.txtpassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Cloud_Insights_LMachine";
            this.Text = "Cloud_Insights_LMachine";
            this.Load += new System.EventHandler(this.Cloud_Insights_LMachine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Button bt_authentifier;
        private System.Windows.Forms.Button bt_install;
        private System.Windows.Forms.Button bt_supprimer;
        private System.Windows.Forms.TextBox txt_idsociete;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button bt_stop;
        private System.Windows.Forms.Button bt_start;
    }
}