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
    public partial class GUI_frmLapPhieuNhap : Form
    {
        public GUI_frmLapPhieuNhap()
        {
            InitializeComponent();
        }
        NhanVien nv = new NhanVien();
        public void loadnv (NhanVien nhvi)
        {
            nv = nhvi;
        }
        private void GUI_frmLapPhieuNhap_Load(object sender, EventArgs e)
        {
            txtIdNV.Text = nv.IdNV;
            lbtru.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvNL.Rows.Clear();
            BUS_NguyenLieu bnl = new BUS_NguyenLieu();
            List<NguyenLieu> lnl = bnl.LoadList(txtTimTheoTen.Text);

            foreach(var c in lnl)
            {
                DataGridViewRow row = (DataGridViewRow)dgvNL.Rows[0].Clone();
                row.Cells[0].Value = c.MaNL.Trim();
                row.Cells[1].Value = c.TenNL.Trim();
                row.Cells[2].Value = c.DonViTinh.Value.ToString().Trim();
                row.Cells[3].Value = c.GiaNhap.Value.ToString().Trim();
                dgvNL.Rows.Add(row);
            }
        }

        private void dgvNL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvNL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lbtru.Enabled = false;
                txtSL.Text = "0";
                DataGridViewRow row = dgvNL.Rows[e.RowIndex];

                txtMaML.Text = row.Cells[0].Value.ToString();
                txtTenNL.Text = row.Cells[1].Value.ToString();
                txtGia.Text = row.Cells[3].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string tinhthanhtien()
        {
            return (decimal.Parse(txtSL.Text) * decimal.Parse(txtGia.Text)).ToString();
        }

        private void lbcong_Click(object sender, EventArgs e)
        {
            lbtru.Enabled = true;
            int sl = int.Parse(txtSL.Text);
            sl++;
            txtSL.Text = sl.ToString();
            txtThanhTien.Text = tinhthanhtien();
        }

        private void lbtru_Click(object sender, EventArgs e)
        {
            int sl = int.Parse(txtSL.Text);
            sl--;
            if (sl == 0)
                lbtru.Enabled = false;
            else
                lbtru.Enabled = true;
            txtSL.Text = sl.ToString();
            txtThanhTien.Text = tinhthanhtien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaML.Text.Trim() == "")
                MessageBox.Show("Cần chọn nguyên liệu trước khi thêm","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            else
            {
                if (txtSL.Text.Trim() == "0")
                    MessageBox.Show("Không thể thêm nguyên liệu với số lượng = 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    BUS_NguyenLieu bnl = new BUS_NguyenLieu();
                    DataGridViewRow row = (DataGridViewRow)dgvCT.Rows[0].Clone();
                    row.Cells[0].Value = STT();
                    row.Cells[1].Value = txtMaML.Text;
                    row.Cells[2].Value = txtTenNL.Text;
                    row.Cells[3].Value = txtGia.Text;
                    row.Cells[4].Value = txtSL.Text;
                    row.Cells[5].Value = txtThanhTien.Text;
                    dgvCT.Rows.Add(row);
                    txtTong.Text = tinhtongTT();
                }
            }
        }
        private string STT()
        {
            return dgvCT.Rows.Count.ToString();
        }
        public string tinhtongTT()
        {
            int n = dgvCT.Rows.Count - 1;
            decimal tong = 0;
            for (int i = 0 ; i <n ; i++)
            {
                tong += decimal.Parse(dgvCT.Rows[i].Cells[5].Value.ToString());
            }
            return tong.ToString();
        }

        private void txthuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Xác nhận hủy phiếu nhập đang lập?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(DialogResult.Yes == dr)
            {
                dgvCT.Rows.Clear();
                MessageBox.Show("Hủy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BUS_PhieuNhap bpn = new BUS_PhieuNhap();
            try
            {
                if(txtmaPN.Text.Trim() == "")
                    MessageBox.Show("Mã phiếu nhập không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (bpn.KiemTraMa(txtmaPN.Text.Trim()) == 1)
                        MessageBox.Show("Mã phiếu nhập đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        DialogResult dr = MessageBox.Show("Xác nhận lặp phiếu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(DialogResult.Yes == dr)
                        {
                            LuuPN();
                            LuuCT();
                            MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LuuPN()
        {
            PhieuNhap pn = new PhieuNhap();
            BUS_PhieuNhap bpn = new BUS_PhieuNhap();

            pn.MaPN = txtmaPN.Text;
            pn.IdNV = nv.IdNV.Trim();
            pn.NgayLap = dtpNgayLap.Value;
            pn.TriGia = decimal.Parse(txtTong.Text);

            bpn.Them(pn);
        }
        private void LuuCT()
        {
            List<CT_PhieuNhap> lctpn = new List<CT_PhieuNhap>();
            BUS_CTPhieuNhap bct = new BUS_CTPhieuNhap();
            for(int i = 0; i < dgvCT.Rows.Count - 1; i++)
            {
                CT_PhieuNhap ct = new CT_PhieuNhap();
                ct.MaPN = txtmaPN.Text.Trim();
                ct.MaNL = dgvCT.Rows[i].Cells[1].Value.ToString();
                ct.DonGia = decimal.Parse( dgvCT.Rows[i].Cells[3].Value.ToString());
                ct.SL = int.Parse(dgvCT.Rows[i].Cells[4].Value.ToString());
                ct.ThanhTien = decimal.Parse(dgvCT.Rows[i].Cells[5].Value.ToString());
                lctpn.Add(ct);
            }
            bct.Them(lctpn);
        }

    }
}
