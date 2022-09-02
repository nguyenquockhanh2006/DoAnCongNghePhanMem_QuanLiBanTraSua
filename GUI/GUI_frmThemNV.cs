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
    public partial class GUI_frmThemNV : Form
    {
        public GUI_frmThemNV()
        {
            InitializeComponent();
        }

        private void grbThongTinNV_Enter(object sender, EventArgs e)
        {

        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Xóa thông tin?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == dr)
            {
                txtIdNV.Text = "";
                txtLuongCB.Text = "";
                txtPass.Text = "";
                txtQueQuan.Text = "";
                txtSDT.Text = "";
                cboChucVu.Text = cboChucVu.Items[0].ToString();
                cboGioiTinh.Text = cboGioiTinh.Items.ToString();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Xác nhận hủy?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == dr)
            {
                this.Close();
            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (txtIdNV.Text.Trim() == "" || txtPass.Text.Trim() == "" || txtTenNV.Text.Trim() == "" || txtQueQuan.Text.Trim() == "" || txtLuongCB.Text.Trim() == "" || txtSDT.Text.Trim() == "")
                MessageBox.Show("Thông tin không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                BUS_NhanVien bnv = new BUS_NhanVien();
                if (bnv.KT_id(txtIdNV.Text) == 1)
                    MessageBox.Show("Id nhân viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string ktpass = bnv.KT_Pass(txtPass.Text.Trim());
                    string ktsdt = bnv.KT_SDT(txtSDT.Text.Trim());
                    if (ktpass != "true")
                        MessageBox.Show("Mật khẩu phải 8 kí tự trởi lên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        if (ktsdt == "wrsl")
                            MessageBox.Show("SĐT cần 10 kí tự", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            if (ktsdt == "wrkt")
                                MessageBox.Show("SĐT chỉ cho phép chứa kí tự số", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                            {
                                NhanVien temp = new NhanVien();
                                temp.IdNV = txtIdNV.Text;
                                temp.Pass = txtPass.Text;
                                temp.TenNV = txtTenNV.Text;
                                temp.QueQuan = txtQueQuan.Text;
                                temp.SDT = txtSDT.Text;
                                temp.NgaySinh = dtpNgaySinh.Value;
                                temp.NgayVaoLam = dtpNgayVaoLam.Value;
                                temp.GioiTinh = cboGioiTinh.Text;
                                temp.ChucVu = cboChucVu.Text;
                                temp.LuongCoBan = decimal.Parse(txtLuongCB.Text);
                                DialogResult dr = MessageBox.Show("Xác nhận thêm : " +txtIdNV.Text.Trim()+" ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult.Yes == dr)
                                {
                                    bnv.ThemNV(temp);
                                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
