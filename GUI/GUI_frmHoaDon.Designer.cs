﻿
namespace GUI
{
    partial class GUI_frmHoaDon
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
            this.rpvHoaDon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvHoaDon
            // 
            this.rpvHoaDon.Location = new System.Drawing.Point(12, 12);
            this.rpvHoaDon.Name = "rpvHoaDon";
            this.rpvHoaDon.ServerReport.BearerToken = null;
            this.rpvHoaDon.Size = new System.Drawing.Size(855, 447);
            this.rpvHoaDon.TabIndex = 0;
            // 
            // GUI_frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(886, 468);
            this.Controls.Add(this.rpvHoaDon);
            this.Name = "GUI_frmHoaDon";
            this.Text = "Hóa Đơn";
            this.Load += new System.EventHandler(this.GUI_HoaDon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvHoaDon;
    }
}