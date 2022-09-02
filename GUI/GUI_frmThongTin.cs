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
    public partial class GUI_frmThongTin : Form
    {
        public GUI_frmThongTin()
        {
            InitializeComponent();
        }
        NhanVien thongtin = new NhanVien();
        public void loadtt(NhanVien nv)
        {
            this.thongtin = nv;
            BUS_NhanVien bnhanvien = new BUS_NhanVien();
            NhanVien a = bnhanvien.loadnhanvien(thongtin.IdNV.Trim());
            thongtin =  a;
        }
        private void loadform()
        {
            txtId.Text = thongtin.IdNV.Trim();
            txtPass.Text = thongtin.Pass;
            txtTen.Text = thongtin.TenNV;
            txtQueQuan.Text = thongtin.QueQuan;
            txtChucVu.Text = thongtin.ChucVu;
            txtSDT.Text = thongtin.SDT;
            txtLuongCoBan.Text = thongtin.LuongCoBan.ToString();
            if (thongtin.GioiTinh == "Nam")
                radNam.Checked = true;
            else
                radNu.Checked = true;
            dtpNgaySinh.Value = thongtin.NgaySinh.Value;
            dtpNgayVaoLam.Value = thongtin.NgayVaoLam.Value;
        }
        private void GUI_frmThongTin_Load(object sender, EventArgs e)
        {
            loadform();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                grttsv.Enabled = true;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

                
                BUS_NhanVien bnhanvien = new BUS_NhanVien();
                if(txtTen.Text.Trim() == "" || txtQueQuan.Text.Trim() == "" || txtSDT.Text.Trim() == "")
                    MessageBox.Show("Thông tin không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string s = bnhanvien.KT_SDT(txtSDT.Text);
                    if(s == "wrsl")
                        MessageBox.Show("SĐT cần 10 kí tự", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        if (s == "wrkt")
                            MessageBox.Show("SĐT chỉ chứa kí tự số", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            NhanVien temp = new NhanVien();
                            temp = thongtin;
                            temp.TenNV = txtTen.Text;
                            temp.QueQuan = txtQueQuan.Text;
                            temp.SDT = txtSDT.Text;
                            temp.NgaySinh = dtpNgaySinh.Value;
                            temp.NgayVaoLam = dtpNgayVaoLam.Value;
                            if (radNam.Checked == true)
                                temp.GioiTinh = "Nam";
                            else
                                temp.GioiTinh = "Nữ";

                            bnhanvien.SuaNV(temp);
                            DialogResult dr = MessageBox.Show("Xác nhận thay đổi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if(DialogResult.Yes == dr)
                            {
                                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grttsv.Enabled = false;
                                loadtt(temp);
                            }
                            
                        }
                    }        
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr =  MessageBox.Show("Hủy thay đổi", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(DialogResult.Yes == dr)
                {
                    loadform();
                    grttsv.Enabled = false;
                }         
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GUI_frmDoiMatKhau frm = new GUI_frmDoiMatKhau();
                frm.loadNV(thongtin);
                frm.ShowDialog();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            BUS_NhanVien bnv = new BUS_NhanVien();
            bnv.loadnhanvien(txtId.Text);
            loadtt(bnv.loadnhanvien(txtId.Text));
            loadform();
        }
    }
}
