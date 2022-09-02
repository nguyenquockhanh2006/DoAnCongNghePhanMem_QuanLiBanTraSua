
namespace GUI
{
    partial class GUI_frmThongKe
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
            this.rpvThongke = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvThongke
            // 
            this.rpvThongke.Location = new System.Drawing.Point(2, -1);
            this.rpvThongke.Name = "rpvThongke";
            this.rpvThongke.ServerReport.BearerToken = null;
            this.rpvThongke.Size = new System.Drawing.Size(905, 523);
            this.rpvThongke.TabIndex = 0;
            // 
            // GUI_frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 523);
            this.Controls.Add(this.rpvThongke);
            this.Name = "GUI_frmThongKe";
            this.Text = "GUI_frmThongKe";
            this.Load += new System.EventHandler(this.GUI_frmThongKe_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvThongke;
    }
}