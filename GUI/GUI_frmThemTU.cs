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
    public partial class GUI_frmThemTU : Form
    {
        public GUI_frmThemTU()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BUS_ThucUong btu = new BUS_ThucUong();
            BUS_LoaiThucUong bltu = new BUS_LoaiThucUong();
            if (txtMaTU.Text.Trim() == "" || txtTenTU.Text.Trim() == "" || txtGiaBan.Text.Trim() == "")
                MessageBox.Show("Thông tin thức uống không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if(btu.kiemtrama(txtMaTU.Text) == 1)
                    MessageBox.Show("Mã thức uống đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    DialogResult dr = MessageBox.Show("Xác nhận thêm: " + txtMaTU.Text.Trim() + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(DialogResult.Yes == dr)
                    {
                        ThucUong temp = new ThucUong();
                        temp.MaTU = txtMaTU.Text;
                        temp.TenTU = txtTenTU.Text;
                        temp.GioiThieu = txtGioiThieu.Text;
                        temp.GiaBan = decimal.Parse(txtGiaBan.Text);
                        temp.MaLoai = bltu.SetMaLTU(cboLoai.Text);
                        btu.ThemTU(temp);
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }    
            }    
        }

        private void GUI_frmThemTU_Load(object sender, EventArgs e)
        {
            BUS_LoaiThucUong bltu = new BUS_LoaiThucUong();
            foreach(LoaiThucUong c in bltu.LoadAllList())
            {
                cboLoai.Items.Add(c.TenLoai);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Xóa thông tin?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(DialogResult.Yes == dr)
            {
                txtGiaBan.Text = "";
                txtMaTU.Text = "";
                txtTenTU.Text = "";
                txtGioiThieu.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Xác nhận hủy?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == dr)
            {
                this.Close();
            }
        }
    }
}
