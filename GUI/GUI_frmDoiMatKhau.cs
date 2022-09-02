using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;
namespace GUI
{
    public partial class GUI_frmDoiMatKhau : Form
    {
        public GUI_frmDoiMatKhau()
        {
            InitializeComponent();
        }
        NhanVien nv = new NhanVien();
        public void loadNV(NhanVien nhanVien)
        {
            nv = nhanVien;
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(txtMKC.Text.Trim() == "" || txtMKM.Text.Trim() == "" || txtXNMKM.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtMKC.Text.Trim() != nv.Pass.Trim())
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if(txtMKM.Text.Trim() != txtXNMKM.Text.Trim())
                    {
                        MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không giống nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        BUS_NhanVien bnv = new BUS_NhanVien();
                        string ketqua = bnv.KT_Pass(txtMKM.Text);
                        if(ketqua == "true")
                        {
                            DialogResult dr = MessageBox.Show("Xác nhận thay đổi mật khẩu thành: "+txtMKM.Text,"Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if(DialogResult.Yes == dr)
                            {
                                nv.Pass = txtMKM.Text.Trim();
                                bnv.SuaPass(nv);
                                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu cần có 8 kí kí tự trởi lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }    
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Xác nhận đóng!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(DialogResult.Yes == dr)
            {
                this.Close();
            }
        }
    }
}
