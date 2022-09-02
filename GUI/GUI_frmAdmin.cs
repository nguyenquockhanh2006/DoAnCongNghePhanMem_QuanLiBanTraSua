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
    public partial class GUI_frmAdmin : Form
    {
        public GUI_frmAdmin()
        {
            InitializeComponent();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
        //
        NhanVien nv = new NhanVien();
        public void loadnv(NhanVien nhvi)
        {
            nv = nhvi;
        }
        public void loaddgvNhanVien()
        {
            BUS_NhanVien bnv = new BUS_NhanVien();
            List<NhanVien> lnv = new List<NhanVien>();
            dgvNhanVien.Rows.Clear();
            lnv = bnv.LoadAllList(cboTKNV.Text, txtDK.Text);
            foreach (NhanVien c in lnv)
            {
                DataGridViewRow row = (DataGridViewRow)dgvNhanVien.Rows[0].Clone();
                row.Cells[0].Value = c.IdNV;
                row.Cells[1].Value = c.Pass;
                row.Cells[2].Value = c.TenNV;
                row.Cells[3].Value = c.GioiTinh;
                row.Cells[4].Value = c.NgaySinh.Value;
                row.Cells[5].Value = c.QueQuan;
                row.Cells[6].Value = c.NgayVaoLam.Value;
                row.Cells[7].Value = c.ChucVu;
                row.Cells[8].Value = c.LuongCoBan;
                row.Cells[9].Value = c.SDT;
                dgvNhanVien.Rows.Add(row);
            }
        }
        private void GUI_frmAdmin_Load(object sender, EventArgs e)
        {
            Loadf();
        }
        public void Loadf()
        {
            cboTimKiemTheo.Text = cboTimKiemTheo.Items[0].ToString();
            txtTimTUTen.Visible = true;
            cboTimTULoai.Visible = false;
            dgvThucUong.Rows.Clear();
            LoadCboLoai();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            loaddgvNhanVien();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtIdNV.Text = row.Cells[0].Value.ToString();
                txtPass.Text = row.Cells[1].Value.ToString();
                txtTenNV.Text = row.Cells[2].Value.ToString();
                cboGioiTinh.Text = row.Cells[3].Value.ToString();
                dtpNgaySinh.Value = DateTime.Parse(row.Cells[4].Value.ToString());
                txtQueQuan.Text = row.Cells[5].Value.ToString();
                dtpNgayVaoLam.Value = DateTime.Parse(row.Cells[6].Value.ToString());
                cboChucVu.Text = row.Cells[7].Value.ToString();
                txtLuongCB.Text = row.Cells[8].Value.ToString();
                txtSDT.Text = row.Cells[9].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            try
            {


                BUS_NhanVien bnhanvien = new BUS_NhanVien();
                if (txtTenNV.Text.Trim() == "" || txtQueQuan.Text.Trim() == "" || txtSDT.Text.Trim() == "" || txtLuongCB.Text.Trim() == "" || txtPass.Text.Trim() == "")
                    MessageBox.Show("Thông tin không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string s = bnhanvien.KT_SDT(txtSDT.Text);
                    if (s == "wrsl")
                        MessageBox.Show("SĐT cần 10 kí tự", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        if (s == "wrkt")
                            MessageBox.Show("SĐT chỉ cho phép chứa kí tự số", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            string s1 = bnhanvien.KT_Pass(txtPass.Text.Trim());
                            if (s1 != "true")
                                MessageBox.Show("Mật khẩu phải 8 kí tự trởi lên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                                DialogResult dr = MessageBox.Show("Xác nhận thay đổi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult.Yes == dr)
                                {
                                    bnhanvien.SuaNVAdmin(temp);
                                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    loaddgvNhanVien();
                                }
                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (txtIdNV.Text.Trim() == "")
            {
                MessageBox.Show("Cần lựa chọn tài khoản trước khi xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Xác nhận xóa " + txtIdNV.Text.Trim(), "Yêu cầu xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == dr)
                {
                    DAL_NhanVien dnv = new DAL_NhanVien();
                    dnv.XoaNV(txtIdNV.Text.Trim());
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgvTongHoaDon.Rows.Clear();
            BUS_HoaDon bhd = new BUS_HoaDon();
            List<HoaDon> listHD = new List<HoaDon>();

            listHD = bhd.LoadHoaDon(dtpNBD.Value, dtpNKT.Value);

            foreach (HoaDon c in listHD)
            {
                DataGridViewRow row = (DataGridViewRow)dgvTongHoaDon.Rows[0].Clone();
                row.Cells[0].Value = c.MaHD;
                row.Cells[1].Value = c.IdNV;
                row.Cells[2].Value = c.NgayLap.Value;
                row.Cells[3].Value = c.TriGia.Value;

                dgvTongHoaDon.Rows.Add(row);
            }
            txtTong.Text = thanhTien(listHD);

            dgvPN.Rows.Clear();
            BUS_PhieuNhap bpn = new BUS_PhieuNhap();
            List<PhieuNhap> listPN = new List<PhieuNhap>();
            listPN = bpn.LoadPNDK(dtpNBD.Value, dtpNKT.Value);
            foreach (PhieuNhap c in listPN)
            {
                DataGridViewRow row = (DataGridViewRow)dgvPN.Rows[0].Clone();
                row.Cells[0].Value = c.IdNV;
                row.Cells[1].Value = c.IdNV;
                row.Cells[2].Value = c.NgayLap.Value;
                row.Cells[3].Value = c.TriGia.Value;

                dgvPN.Rows.Add(row);
            }
            txtTongPN.Text = thanhTien(listPN);
        }
        private string thanhTien(List<HoaDon> lhd)
        {
            decimal s = 0;
            foreach (HoaDon c in lhd)
            {
                s += c.TriGia.Value;
            }

            return s.ToString();
        }
        private string thanhTien(List<PhieuNhap> lhd)
        {
            decimal s = 0;
            foreach (PhieuNhap c in lhd)
            {
                s += c.TriGia.Value;
            }

            return s.ToString();
        }
        private void dgvTongHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tsmHome_Click(object sender, EventArgs e)
        {
            GUI_frmGDChinh frm = new GUI_frmGDChinh();
            frm.loadlogin(nv);
            frm.Show();
            this.Hide();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GUI_frmThongTin frm = new GUI_frmThongTin();
                frm.loadtt(nv);
                frm.ShowDialog();


                // this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Xác nhận đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == dr)
            {
                GUI_frmDangNhap frm = new GUI_frmDangNhap();
                frm.Show();
                this.Hide();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Xác nhận thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == dr)
            {
                Application.Exit();
            }
        }

        private void btnLamMoiNV_Click(object sender, EventArgs e)
        {
            loaddgvNhanVien();
        }

        private void txtTimTUTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            BUS_ThucUong btu = new BUS_ThucUong();
            List<ThucUong> ltu = new List<ThucUong>();
            dgvThucUong.Rows.Clear();
            if (cboTimKiemTheo.Text == "Tên")
                ltu = btu.LoadListTU(cboTimKiemTheo.Text, txtTimTUTen.Text);
            else
                ltu = btu.LoadListTU(cboTimKiemTheo.Text, cboTimTULoai.Text);
            foreach (ThucUong c in ltu)
            {
                DataGridViewRow row = (DataGridViewRow)dgvThucUong.Rows[0].Clone();
                row.Cells[0].Value = c.MaTU;
                row.Cells[1].Value = c.MaLoai;
                row.Cells[2].Value = c.TenTU;
                row.Cells[3].Value = c.GioiThieu;
                row.Cells[4].Value = c.GiaBan.Value;
                dgvThucUong.Rows.Add(row);
            }
        }

        private void cboTimKiemTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTimKiemTheo.Text.Trim() == "Tên")
            {
                txtTimTUTen.Visible = true;
                cboTimTULoai.Visible = false;
            }
            else
            {
                txtTimTUTen.Visible = false;
                cboTimTULoai.Visible = true;
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            LoadSauSua();
        }

        private void dgvThucUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvThucUong.Rows[e.RowIndex];
                string s = row.Cells[0].Value.ToString().Trim();
                BUS_ThucUong btu = new BUS_ThucUong();
                ThucUong tu = btu.LoadThucUongT(s);
                txtMaTU.Text = tu.MaTU.ToString();
                txtTenTU.Text = tu.TenTU;
                cboLoai.Text = tu.LoaiThucUong.TenLoai;
                txtGioiThieu.Text = tu.GioiThieu;
                txtGiaBan.Text = tu.GiaBan.Value.ToString();
                txtMLoai.Text = tu.LoaiThucUong.MaLoai;
                txtTenLoai.Text = tu.LoaiThucUong.TenLoai;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadCboLoai()
        {
            BUS_LoaiThucUong bltu = new BUS_LoaiThucUong();
            List<LoaiThucUong> ltu = new List<LoaiThucUong>();
            ltu = bltu.LoadAllList();
            foreach (var c in ltu)
            {
                cboLoai.Items.Add(c.TenLoai);
                cboTimTULoai.Items.Add(c.TenLoai);
            }
        }

        private void btnSuaTU_Click(object sender, EventArgs e)
        {
            BUS_ThucUong btu = new BUS_ThucUong();
            ThucUong tu = new ThucUong();
            if (txtMaTU.Text == "")
                MessageBox.Show("Vui lòng chọn thức uống để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (txtTenTU.Text.Trim() == "" || txtGioiThieu.Text.Trim() == "" || txtGiaBan.Text.Trim() == "")
                    MessageBox.Show("Thông tin không thể để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    tu.MaTU = txtMaTU.Text.Trim();
                    tu.TenTU = txtTenTU.Text;
                    tu.GioiThieu = txtGioiThieu.Text;
                    tu.GiaBan = decimal.Parse(txtGiaBan.Text);
                    BUS_LoaiThucUong bltu = new BUS_LoaiThucUong();
                    string s = bltu.SetMaLTU(cboLoai.Text.Trim());
                    tu.MaLoai = s.ToString().Trim();
                    DialogResult dr = MessageBox.Show("Xác nhận thay đổi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == dr)
                    {
                        btu.SuaThucUong(tu);
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSauSua();
                    }
                }
            }
        }
        private void LoadSauSua()
        {
            BUS_ThucUong btu = new BUS_ThucUong();
            List<ThucUong> ltu = new List<ThucUong>();
            dgvThucUong.Rows.Clear();
            if (cboTimKiemTheo.Text == "Tên")
                ltu = btu.LoadListTU(cboTimKiemTheo.Text, txtTimTUTen.Text);
            else
                ltu = btu.LoadListTU(cboTimKiemTheo.Text, cboTimTULoai.Text);
            foreach (ThucUong c in ltu)
            {
                DataGridViewRow row = (DataGridViewRow)dgvThucUong.Rows[0].Clone();
                row.Cells[0].Value = c.MaTU;
                row.Cells[1].Value = c.MaLoai;
                row.Cells[2].Value = c.TenTU;
                row.Cells[3].Value = c.GioiThieu;
                row.Cells[4].Value = c.GiaBan.Value;
                dgvThucUong.Rows.Add(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BUS_LoaiThucUong bltu = new BUS_LoaiThucUong();
            if (txtMLoai.Text.Trim() == "" || txtTenLoai.Text.Trim() == "")
                MessageBox.Show("Thông tin không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (bltu.KT_MaLTU(txtMLoai.Text.Trim()) == 1)
                    MessageBox.Show("Mã thức uống :" + txtMLoai.Text.Trim() + " đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    DialogResult dr = MessageBox.Show("Xác nhận thêm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == dr)
                    {
                        LoaiThucUong ltu = new LoaiThucUong();
                        ltu.MaLoai = txtMLoai.Text.Trim();
                        ltu.TenLoai = txtTenLoai.Text;
                        bltu.Them(ltu);
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            BUS_LoaiThucUong bltu = new BUS_LoaiThucUong();
            if (txtMLoai.Text.Trim() == "")
                MessageBox.Show("Mã loại không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DialogResult dr = MessageBox.Show("Xác nhận thêm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == dr)
                {
                    LoaiThucUong ltu = new LoaiThucUong();
                    ltu.MaLoai = txtMLoai.Text.Trim();
                    ltu.TenLoai = txtTenLoai.Text;
                    bltu.Xoa(ltu);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            BUS_LoaiThucUong bltu = new BUS_LoaiThucUong();
            if (txtMLoai.Text.Trim() == "" || txtTenLoai.Text.Trim() == "")
                MessageBox.Show("Thông tin không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (bltu.KT_MaLTU(txtMLoai.Text.Trim()) == 0)
                    MessageBox.Show("Mã thức uống :" + txtMLoai.Text.Trim() + " không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    DialogResult dr = MessageBox.Show("Xác nhận Sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == dr)
                    {
                        LoaiThucUong ltu = new LoaiThucUong();
                        ltu.MaLoai = txtMLoai.Text.Trim();
                        ltu.TenLoai = txtTenLoai.Text;
                        bltu.Sua(ltu);
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
        }

        private void btnXoaTU_Click(object sender, EventArgs e)
        {
            try
            {
                BUS_LoaiThucUong bltu = new BUS_LoaiThucUong();
                if (txtMLoai.Text.Trim() == "")
                    MessageBox.Show("Mã thức uống cần xóa không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    DialogResult dr = MessageBox.Show("Xác nhận Xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == dr)
                    {
                        LoaiThucUong ltu = new LoaiThucUong();
                        ltu.MaLoai = txtMLoai.Text.Trim();
                        ltu.TenLoai = txtTenLoai.Text;
                        bltu.Xoa(ltu);
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimNL_Click(object sender, EventArgs e)
        {
            LoadDgv();
        }
        private void LoadDgv()
        {
            dgvNL.Rows.Clear();
            BUS_NguyenLieu bnl = new BUS_NguyenLieu();
            List<NguyenLieu> lnl = bnl.LoadList(cboTimNL.Text, txtDKTimNL.Text);
            foreach (var c in lnl)
            {
                DataGridViewRow row = (DataGridViewRow)dgvNL.Rows[0].Clone();
                row.Cells[0].Value = c.MaNL.Trim();
                row.Cells[1].Value = c.TenNL.Trim();
                row.Cells[2].Value = c.DonViTinh.Value.ToString().Trim();
                row.Cells[3].Value = c.GiaNhap.Value.ToString().Trim();
                dgvNL.Rows.Add(row);
            }
        }
        private void btnThemTU_Click(object sender, EventArgs e)
        {
            GUI_frmThemTU frm = new GUI_frmThemTU();
            frm.ShowDialog();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            GUI_frmThemNV frm = new GUI_frmThemNV();
            frm.ShowDialog();
        }

        private void btnThemNL_Click(object sender, EventArgs e)
        {
            BUS_NguyenLieu bnl = new BUS_NguyenLieu();
            if (txtMaNL.Text.Trim() == "" || txtTenNL.Text.Trim() == "" || txtDVT.Text.Trim() == "" || txtGiaNhap.Text.Trim() == "")
                MessageBox.Show("Thông tin không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (bnl.KTMa(txtMaNL.Text.Trim()) == 1)
                    MessageBox.Show("Id đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (bnl.KTdvt(txtDVT.Text.Trim()) == 0)
                        MessageBox.Show("Đơn vị tính phải là số tự nhiên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        DialogResult dr = MessageBox.Show("Xác nhân thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult.Yes == dr)
                        {
                            NguyenLieu nl = new NguyenLieu();
                            nl.MaNL = txtMaNL.Text.Trim();
                            nl.TenNL = txtTenNL.Text;
                            nl.DonViTinh = int.Parse(txtDVT.Text);
                            nl.GiaNhap = decimal.Parse(txtGiaNhap.Text.Trim());
                            bnl.Them(nl);
                            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDgv();
                        }
                    }
                }
            }
        }

        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            BUS_NguyenLieu bnl = new BUS_NguyenLieu();
            if (txtMaNL.Text.Trim() == "")
                MessageBox.Show("Mã nguyên liệu không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (bnl.KTMa(txtMaNL.Text.Trim()) == 0)
                    MessageBox.Show("Mã nguyên liệu đã nhập không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    DialogResult dr = MessageBox.Show("Xác nhân Xóa " + txtMaNL.Text.Trim() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == dr)
                    {

                        NguyenLieu nl = new NguyenLieu();
                        nl.MaNL = txtMaNL.Text.Trim();
                        bnl.Xoa(nl);
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDgv();
                    }
                }
            }
        }

        private void btnSuaNL_Click(object sender, EventArgs e)
        {
            BUS_NguyenLieu bnl = new BUS_NguyenLieu();
            if (txtMaNL.Text.Trim() == "" || txtTenNL.Text.Trim() == "" || txtDVT.Text.Trim() == "" || txtGiaNhap.Text.Trim() == "")
                MessageBox.Show("Thông tin không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (bnl.KTMa(txtMaNL.Text.Trim()) == 0)
                    MessageBox.Show("Id không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (bnl.KTdvt(txtDVT.Text.Trim()) == 0)
                        MessageBox.Show("Đơn vị tính phải là số tự nhiên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        DialogResult dr = MessageBox.Show("Xác nhân sửa " + txtMaNL.Text.Trim() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult.Yes == dr)
                        {

                            NguyenLieu nl = new NguyenLieu();
                            nl.MaNL = txtMaNL.Text.Trim();
                            nl.TenNL = txtTenNL.Text;
                            nl.DonViTinh = int.Parse(txtDVT.Text);
                            nl.GiaNhap = decimal.Parse(txtGiaNhap.Text.Trim());
                            bnl.Sua(nl);
                            MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDgv(); 
                        }
                    }
                }
            }
        }

        private void dgvNL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvNL.Rows[e.RowIndex];

                txtMaNL.Text = row.Cells[0].Value.ToString();
                txtTenNL.Text = row.Cells[1].Value.ToString();
                txtDVT.Text = row.Cells[2].Value.ToString();
                txtGiaNhap.Text = row.Cells[3].Value.ToString();
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLapPN_Click(object sender, EventArgs e)
        {
            GUI_frmLapPhieuNhap frm = new GUI_frmLapPhieuNhap();
            frm.loadnv(nv);
            frm.ShowDialog();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            
            GUI_frmThongKe frm = new GUI_frmThongKe();
            frm.LoadParam(nv.IdNV.Trim(), dtpNBD.Text,dtpNKT.Text, dtpNgKT.Text, txtTong.Text,txtTongPN.Text);
            List<datasetThuChi> thu = new List<datasetThuChi>();
            List<datasetThuChi> chi = new List<datasetThuChi>();
            
            for(int i =0; i < dgvTongHoaDon.Rows.Count - 1; i++)
            {
                datasetThuChi temp = new datasetThuChi();
                temp.stt = (i+1).ToString();
                temp.mahd = dgvTongHoaDon.Rows[i].Cells[0].Value.ToString();
                temp.id = dgvTongHoaDon.Rows[i].Cells[1].Value.ToString();
                temp.ngaylap = dgvTongHoaDon.Rows[i].Cells[2].Value.ToString();
                temp.trigia = dgvTongHoaDon.Rows[i].Cells[3].Value.ToString();
                thu.Add(temp);
            }
            frm.loadThu(thu);
            for(int i = 0; i < dgvPN.Rows.Count - 1; i++)
            {
                datasetThuChi temp = new datasetThuChi();
                temp.stt = (i + 1).ToString();
                temp.mahd = dgvPN.Rows[i].Cells[0].Value.ToString();
                temp.id = dgvPN.Rows[i].Cells[1].Value.ToString();
                temp.ngaylap = dgvPN.Rows[i].Cells[2].Value.ToString();
                temp.trigia = dgvPN.Rows[i].Cells[3].Value.ToString();
                chi.Add(temp);
            }
            frm.loadChi(chi);

            frm.ShowDialog();
        }
    }
}

