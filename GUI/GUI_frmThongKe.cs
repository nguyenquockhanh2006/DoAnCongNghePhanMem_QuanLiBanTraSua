using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_frmThongKe : Form
    {
        public GUI_frmThongKe()
        {
            InitializeComponent();
        }
        string id, nbd, nkt, ntke, tongthu, tongchi;
        List<datasetThuChi> listThu = new List<datasetThuChi>();
        List<datasetThuChi> listChi = new List<datasetThuChi>();
        public void LoadParam(string id1, string nbd1, string nkt1, string ntke1, string tongthu1, string tongchi1)
        {
            id = id1;
            nbd = nbd1;
            nkt = nkt1;
            ntke = ntke1;
            tongthu = tongthu1;
            tongchi = tongchi1;
        }
        public void loadThu(List<datasetThuChi> listthu1)
        {
            listThu = listthu1;
        }
        public void loadChi(List<datasetThuChi> listchi1)
        {
            listChi = listchi1;
        }
        private void GUI_frmThongKe_Load(object sender, EventArgs e)
        {

            this.rpvThongke.RefreshReport();

            ReportParameter[] param = new ReportParameter[6];
            param[0] = new ReportParameter("idnv", id);
            param[1] = new ReportParameter("nbd", nbd);
            param[2] = new ReportParameter("nkt", nkt);
            param[3] = new ReportParameter("ntke", ntke);
            param[4] = new ReportParameter("tongthu", tongthu);
            param[5] = new ReportParameter("tongchi", tongchi);
            this.rpvThongke.LocalReport.ReportPath = "GUI_rpPhieuThongKe.rdlc";
            this.rpvThongke.LocalReport.SetParameters(param);
            ReportDataSource[] data = new ReportDataSource[2];
            data[0] = new ReportDataSource("dts1", listThu);
            data[1] = new ReportDataSource("dts2", listChi);
            this.rpvThongke.LocalReport.DataSources.Clear();
            this.rpvThongke.LocalReport.DataSources.Add(data[0]);
            this.rpvThongke.LocalReport.DataSources.Add(data[1]);
            this.rpvThongke.RefreshReport();
        }
            
        }
    
}
