using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;
namespace GUI
{
    public partial class GUI_frmGDChinh : Form
    {
        public GUI_frmGDChinh()
        {
            InitializeComponent();
        }
        int stt;
        NhanVien login = new NhanVien();

        #region public
        public void loadlogin(NhanVien nv)
        {
            login = nv;
        }
        private void Loadcbo()
        {
            BUS_LoaiThucUong ltu = new BUS_LoaiThucUong();
            cboLoai.Items.Clear();
            foreach(var c in ltu.LoadList())
            {
                cboLoai.Items.Add(c);
            }
            cboLoai.Text = cboLoai.Items[0].ToString();
        }

        private void LoadMenu()
        {
            BUS_ThucUong tu = new BUS_ThucUong();

            flpMenu.Controls.Clear();

            foreach(var c in tu.LoadTheoLoai(cboLoai.Text))
            {
                Button btn = new Button();
                btn.Text = c;
                btn.BackColor = Color.Azure;

                btn.Click += Btn_Click;

                btn.Width = 100;
                btn.Height = 100;

                flpMenu.Controls.Add(btn);
            }

        }
        private void LoadForm()
        {
            flpMenu.Controls.Clear();
            Loadcbo();
            LoadMenu();
            txtIdNV.Text = this.login.IdNV.ToString().Trim();
            if (login.ChucVu == "Quản lí")
            {
                tsmAdmin.Enabled = true;
                
            }

            else
            {
                tsmAdmin.Enabled = false;
            }
                
        }
        #endregion

        private void frmGDChinh_Load(object sender, EventArgs e)
        {
            LoadForm();
            
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            BUS_ThucUong tu = new BUS_ThucUong();
            ThucUong _tu = tu.LoadThucUong(btn.Text);

            txtId.Text = _tu.MaTU;
            txtTen.Text = _tu.TenTU;
            txtLoai.Text = cboLoai.Text;
            txtGia.Text = _tu.GiaBan.ToString();
            txtGT.Text = _tu.GioiThieu;
            txtSL.Text = "0";
            txtTT.Text = "0";
        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMenu();
        }
        private void tinhthanhtien()
        {
            try
            {
                int soluong = Convert.ToInt32(txtSL.Text);
                decimal gia = decimal.Parse(txtGia.Text);
                txtTT.Text = (soluong * gia).ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void tinhtonghoadon()
        {
            try
            {
                decimal tong = 0;
                for (int i = 0; i < dgvHoaDon.Rows.Count - 1; i++)
                {
                    string s = dgvHoaDon.Rows[i].Cells[5].Value.ToString().Trim();
                    decimal temp = decimal.Parse(s);
                    tong += temp;
                }
                txtTongtrigia.Text = tong.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadSTT()
        {
            if (dgvHoaDon.Rows.Count > 0)
            {
                for (int i = 0; i < dgvHoaDon.Rows.Count - 1; i++)
                {
                    dgvHoaDon.Rows[i].Cells[0].Value = (i + 1).ToString();
                }
            }
        }
        private void cong_Click(object sender, EventArgs e)
        {
            try
            {
                int soluong = Convert.ToInt32(txtSL.Text);
                soluong++;
                txtSL.Text = soluong.ToString();
                tinhthanhtien();
                tru.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void tru_Click(object sender, EventArgs e)
        {
            try
            {
                int soluong = Convert.ToInt32(txtSL.Text);
                soluong--;
                txtSL.Text = soluong.ToString();
                tinhthanhtien();
                if (soluong == 0)
                    tru.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtTen.Text = "";
            txtLoai.Text = "";
            txtGia.Text = "";
            txtGT.Text = "";
            txtSL.Text = "";
            txtTT.Text = "";
        }
        private int vtri()
        {
            int vtr = -1;
            int n = dgvHoaDon.Rows.Count - 1;
            datasetCTHD[] ctHD = new datasetCTHD[n];
            for (int i = 0; i < n; i++)
            {
                if (txtTen.Text == dgvHoaDon.Rows[i].Cells[1].Value.ToString())
                    vtr = i;
            }
            return vtr;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSL.Text == "0")
                    MessageBox.Show("Không thể thêm thức uống với số lượng bằng 0 vào hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (vtri() != -1)
                    {
                        int sl = Convert.ToInt32( dgvHoaDon.Rows[vtri()].Cells[4].Value.ToString());
                        sl += Convert.ToInt32(txtSL.Text);
                        dgvHoaDon.Rows[vtri()].Cells[4].Value = sl.ToString();
                        txtSL.Text = sl.ToString();
                        Decimal thtie = decimal.Parse(dgvHoaDon.Rows[vtri()].Cells[5].Value.ToString());
                        thtie += decimal.Parse(txtTT.Text);
                        dgvHoaDon.Rows[vtri()].Cells[5].Value = thtie.ToString();
                        tinhtonghoadon();
                        txtSL.Text = "0";
                    }
                    else
                    {
                            DataGridViewRow row = (DataGridViewRow)dgvHoaDon.Rows[0].Clone();
                            row.Cells[0].Value = dgvHoaDon.Rows.Count.ToString();
                            row.Cells[1].Value = txtTen.Text;
                            row.Cells[2].Value = txtLoai.Text;
                            row.Cells[3].Value = txtGia.Text;
                            row.Cells[4].Value = txtSL.Text;
                            row.Cells[5].Value = txtTT.Text;
                            dgvHoaDon.Rows.Add(row);
                            tinhtonghoadon();
                            txtSL.Text = "0";
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHoaDon.Rows.Count == 1)
                    dgvHoaDon.Rows.Clear();
                else
                    dgvHoaDon.Rows.RemoveAt(stt - 1);
                
                LoadSTT();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text.Trim() == "")
            {
                MessageBox.Show("Mã hóa đơn không thể trống","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                BUS_HoaDon bhd = new BUS_HoaDon();
                if (bhd.KT_MaHD(txtMaHD.Text.Trim()) == 1)
                    MessageBox.Show("Mã hóa đơn đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    int n = dgvHoaDon.Rows.Count - 1;
                    datasetCTHD[] ctHD = new datasetCTHD[n];
                    for (int i = 0; i < n; i++)
                    {
                        //DataGridViewRow row = dgv.Rows[e.RowIndex];
                        ctHD[i] = new datasetCTHD();
                        ctHD[i].stt = dgvHoaDon.Rows[i].Cells[0].Value.ToString();
                        ctHD[i].ten = dgvHoaDon.Rows[i].Cells[1].Value.ToString();
                        ctHD[i].loai = dgvHoaDon.Rows[i].Cells[2].Value.ToString();
                        ctHD[i].dg = dgvHoaDon.Rows[i].Cells[3].Value.ToString();
                        ctHD[i].sl = dgvHoaDon.Rows[i].Cells[4].Value.ToString();
                        ctHD[i].tt = dgvHoaDon.Rows[i].Cells[5].Value.ToString();
                    }
                    string mahoadon = txtMaHD.Text;
                    string manhanvien = txtIdNV.Text;
                    string ngaylap = dateTimePicker1.Text.ToString();
                    string tongtrigia = txtTongtrigia.Text;

                    ThemHD();
                    ThemCTHD();

                    GUI_frmHoaDon frm = new GUI_frmHoaDon();
                    frm.loadGT(ctHD, mahoadon, manhanvien, ngaylap, tongtrigia);
                    frm.Show();
                }
            }
            
        }

        public void ThemHD()
        {
            try
            {
                HoaDon hd = new HoaDon();
                hd.IdNV = txtIdNV.Text;
                hd.MaHD = txtMaHD.Text;
                hd.NgayLap = dateTimePicker1.Value;
                hd.TriGia = decimal.Parse(txtTongtrigia.Text);

                BUS_HoaDon bhd = new BUS_HoaDon();
                bhd.ThemHD(hd);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ThemCTHD()
        {
            try
            {
                List<CT_HoaDon> cthd = new List<CT_HoaDon>();
                int n = dgvHoaDon.Rows.Count - 1;
                BUS_ThucUong btt = new BUS_ThucUong();

                for (int i = 0; i < n; i++)
                {
                    CT_HoaDon ctHD = new CT_HoaDon();
                    ctHD = new CT_HoaDon();
                    ThucUong tu = btt.LoadThucUong(dgvHoaDon.Rows[i].Cells[1].Value.ToString());
                    ctHD.MaHD = txtMaHD.Text.Trim();
                    ctHD.MaTU = tu.MaTU.Trim();
                    ctHD.DonGia = tu.GiaBan;
                    ctHD.SL = Convert.ToInt32(dgvHoaDon.Rows[i].Cells[4].Value.ToString());
                    ctHD.ThanhTien = decimal.Parse(dgvHoaDon.Rows[i].Cells[5].Value.ToString());

                    cthd.Add(ctHD);
                }
                BUS_CTHoaDon dcthd = new BUS_CTHoaDon();
                dcthd.ThemCTHoaDon(cthd);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];
                BUS_ThucUong TU = new BUS_ThucUong();
                ThucUong ttTU = TU.LoadThucUong(row.Cells[1].Value.ToString());
                stt = Convert.ToInt32(row.Cells[0].Value.ToString());
                txtId.Text = ttTU.MaTU.ToString();
                txtTen.Text = ttTU.TenTU.ToString();
                txtLoai.Text = ttTU.LoaiThucUong.TenLoai.ToString();
                txtGia.Text = ttTU.GiaBan.ToString();
                txtGT.Text = ttTU.GioiThieu.ToString();

                txtSL.Text = row.Cells[4].Value.ToString();
                txtTT.Text = row.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chếĐộXemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Xác nhận thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(DialogResult.Yes == dr)
            {
                Application.Exit();
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void tsmAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                GUI_frmAdmin frm = new GUI_frmAdmin();
                frm.loadnv(login);
                frm.Show();
                this.Hide();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Xác nhận đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == dr)
            {
                GUI_frmDangNhap frm = new GUI_frmDangNhap();
                frm.Show();
                this.Hide();
            }
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GUI_frmThongTin frm = new GUI_frmThongTin();
                frm.loadtt(login);
                frm.ShowDialog();
                

                // this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {

        }
    }
}
