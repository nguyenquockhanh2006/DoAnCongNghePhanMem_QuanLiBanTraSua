using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using DAL;

namespace GUI
{
    public partial class GUI_frmHoaDon : Form
    {
        public GUI_frmHoaDon()
        {
            InitializeComponent();
        }
        datasetCTHD[] cthd;
        string mahoadon;
        string manhanvien;
        string ngaylap;
        string tongtrigia;
        public void loadGT(datasetCTHD[] ct, string mhd, string mnv, string nl, string ttg)
        {
            cthd = ct;
            mahoadon = mhd;
            manhanvien = mnv;
            ngaylap = nl;
            tongtrigia = ttg;
        }
        private void GUI_HoaDon_Load(object sender, EventArgs e)
        {

            this.rpvHoaDon.RefreshReport();
            try
            {
                ReportParameter[] param = new ReportParameter[4];
                param[0] = new ReportParameter("mahd", mahoadon);
                param[1] = new ReportParameter("idnv", manhanvien);
                param[2] = new ReportParameter("nl", ngaylap);
                param[3] = new ReportParameter("tong", tongtrigia);

                this.rpvHoaDon.LocalReport.ReportPath = "GUIrpHoaDon.rdlc";
                this.rpvHoaDon.LocalReport.SetParameters(param);
                var reportDataSource = new ReportDataSource("DataSet1", cthd);
                this.rpvHoaDon.LocalReport.DataSources.Clear();
                this.rpvHoaDon.LocalReport.DataSources.Add(reportDataSource);
                this.rpvHoaDon.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
