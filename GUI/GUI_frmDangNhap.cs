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
    public partial class GUI_frmDangNhap : Form
    {
        public GUI_frmDangNhap()
        {
            InitializeComponent();
        }
        
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtTK.Text = "";
            txtMK.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Xác nhận thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(DialogResult.Yes == dr)
            {
                Application.Exit();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(txtTK.Text.Trim() == "" || txtMK.Text.Trim() == "")
                MessageBox.Show("Thông tin đăng nhập không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                BUS_DangNhap dn = new BUS_DangNhap();
                string s = dn.KTDangNhap(txtTK.Text.Trim(), txtMK.Text.Trim());
                if (s == "true")
                {
                    GUI_frmGDChinh frm = new GUI_frmGDChinh();
                    NhanVien nv = new NhanVien();
                    BUS_NhanVien BNV = new BUS_NhanVien();
                    nv = BNV.loadnhanvien(txtTK.Text);
                    
                    frm.loadlogin(nv);
                    frm.Show();
                    this.Hide();
                }
                if (s == "wrongid")
                    MessageBox.Show("Không tìm thấy tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (s == "wrongpass")
                    MessageBox.Show("Sai mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GUI_frmDangNhap_Load(object sender, EventArgs e)
        {

        }
        //NV_hienhanh = dangNhap.login();
    }
}
