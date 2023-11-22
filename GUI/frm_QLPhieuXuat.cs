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
using DTO;

namespace GUI
{
    public partial class frm_QLPhieuXuat : Form
    {
        public frm_QLPhieuXuat()
        {
            InitializeComponent();
        }

        private void frm_QLPhieuXuat_Load(object sender, EventArgs e)
        {
            HienThiChucVuLenCombobox();
            HienThiDSNhanVienLenDatagrid();
        }

        private void HienThiChucVuLenCombobox()
        {
            List<NhanVien_DTO> lstChucVu = NhanVien_BUS.LayDSNhanVien();
            cboNV.DataSource = lstChucVu;
            cboNV.DisplayMember = "sTenNV";
            cboNV.ValueMember = "sMaNV";

            List<NhanVien_DTO> lstChucVu1 = NhanVien_BUS.LayDSNhanVien();
            cboNVTT.DataSource = lstChucVu1;
            cboNVTT.DisplayMember = "sTenNV";
            cboNVTT.ValueMember = "sMaNV";


          

            List<DaiLi_DTO> lstDaiLi = DaiLi_BUS.LayDSDaiLi();
            cboDaiLi.DataSource = lstDaiLi;
            cboDaiLi.DisplayMember = "sTenDL";
            cboDaiLi.ValueMember = "sMaDL";
        }

        private void HienThiDSNhanVienLenDatagrid()
        {

            //dg_col_SMaCV.DataSource = ChucVu_BUS.LayChucVu();
            //dg_col_SMaCV.DisplayMember = "STenCV";
            //dg_col_SMaCV.ValueMember = "SMaCV";


            List<PhieuXuat_DTO> lstNhanVien = PhieuXuat_BUS.LayDSPhieuXuat();
            dataGridView1.DataSource = lstNhanVien;
            //// thứ tự các cột
            //dgDSNhanVien.Columns[0].DataPropertyName = "SMaNV";
            //dgDSNhanVien.Columns[1].DataPropertyName = "SHoLot";
            //dgDSNhanVien.Columns[2].DataPropertyName = "STen";
            //dgDSNhanVien.Columns[3].DataPropertyName = "tencv";
            //dgDSNhanVien.Columns[4].DataPropertyName = "SPhai";
            //dgDSNhanVien.Columns[5].DataPropertyName = "DtNgaySinh";


            dataGridView1.Columns["sMaPhieu"].HeaderText = "Mã số";
            dataGridView1.Columns["sTenNgNhan"].HeaderText = "Tên Người Nhận";
            dataGridView1.Columns["sDiaChi"].HeaderText = "Địa Chỉ";
            dataGridView1.Columns["sNgayXuat"].HeaderText = "Ngày Xuất";
            dataGridView1.Columns["sTongSoTien"].HeaderText = "Tổng Số tiền";
            dataGridView1.Columns["sMaNVLap"].HeaderText = "Mã số nv lap";
            dataGridView1.Columns["sMaNVTT"].HeaderText = "Mã số nvtt";
            dataGridView1.Columns["sMaDL"].HeaderText = "Mã DL";

            dataGridView1.Columns["sMaPhieu"].Width = 60;
            dataGridView1.Columns["sTenNgNhan"].Width = 120;
            dataGridView1.Columns["sDiaChi"].Width = 120;
            dataGridView1.Columns["sNgayXuat"].Width = 100;
            dataGridView1.Columns["sTongSoTien"].Width = 90;
            dataGridView1.Columns["sMaNVLap"].Width = 90;
            dataGridView1.Columns["sMaNVTT"].Width = 90;
            dataGridView1.Columns["sMaDL"].Width = 90;


            // mới bổ sung thêm
            // Hiển thị tên chức vụ tương ứng
            string tendl;
            string tennvlap;
            string tennvtt;

            DataGridViewColumn clTenDL = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();

            DataGridViewColumn clTenNV = new DataGridViewColumn();
            DataGridViewCell cell1 = new DataGridViewTextBoxCell();

            DataGridViewColumn clTenNVTT = new DataGridViewColumn();
            DataGridViewCell cell2 = new DataGridViewTextBoxCell();

            clTenDL.CellTemplate = cell;
            clTenDL.Name = "tendl";
            clTenDL.HeaderText = "Tên Đại lí";
            clTenDL.Width = 150;

            dataGridView1.Columns.Add(clTenDL);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                tendl = DaiLi_BUS.TimDaiLiTheoMa(dataGridView1.Rows[i].Cells["sMaDL"].Value.ToString()).sTenDL;
                dataGridView1.Rows[i].Cells["tendl"].Value = tendl;
            }

            clTenNV.CellTemplate = cell1;
            clTenNV.Name = "tennv";
            clTenNV.HeaderText = "Tên NV Lâp";
            clTenNV.Width = 150;

            dataGridView1.Columns.Add(clTenNV);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                tennvlap = NhanVien_BUS.TimNhanVienTheoMa(dataGridView1.Rows[i].Cells["sMaNVLap"].Value.ToString()).sTenNV;
                dataGridView1.Rows[i].Cells["tennv"].Value = tennvlap;
            }

            clTenNVTT.CellTemplate = cell2;
            clTenNVTT.Name = "tennv1";
            clTenNVTT.HeaderText = "Tên NV TT";
            clTenNVTT.Width = 150;

            dataGridView1.Columns.Add(clTenNVTT);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                tennvtt = NhanVien_BUS.TimNhanVienTheoMa(dataGridView1.Rows[i].Cells["sMaNVTT"].Value.ToString()).sTenNV;
                dataGridView1.Rows[i].Cells["tennv1"].Value = tennvtt;
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống 
            if (txtMaPX.Text == "" || txtDiaChi.Text == "" || txtNgN.Text == "" || txtSoTien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã nhân viên có độ dài chuỗi hợp lệ hay không
            if (txtMaPX.Text.Length > 5)
            {
                MessageBox.Show("Mã phiếu tối đa 5 ký tự!");
                return;
            }
            // Kiểm tra mã nhân viên có bị trùng không
            if (PhieuXuat_BUS.TimPhieuXuatTheoMa(txtMaPX.Text) != null)
            {
                MessageBox.Show("Mã phiếu đã tồn tại!");
                return;
            }

            PhieuXuat_DTO nv = new PhieuXuat_DTO();
            nv.sMaPhieu = txtMaPX.Text;
            nv.sDiaChi = txtDiaChi.Text;
            nv.sTenNgNhan = txtNgN.Text;
            nv.sNgayXuat = DateTime.Parse(txtNgayXuat.Text);

            nv.sMaDL = cboDaiLi.SelectedValue.ToString();
            nv.sMaNVLap = cboNV.SelectedValue.ToString();
            nv.sMaNVTT = cboNVTT.SelectedValue.ToString();

            if (PhieuXuat_BUS.ThemPhieuXuat(nv) == false)
            {
                MessageBox.Show("Có lỗi xảy ra ! Không thêm được.");
                return;
            }

            HienThiDSNhanVienLenDatagrid();
            MessageBox.Show("Đã thêm nhân viên.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // kiểm tra mã có tồn tại
            if (txtMaPX.Text == "" || PhieuXuat_BUS.TimPhieuXuatTheoMa(txtMaPX.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã phiếu!");
                return;
            }
            PhieuXuat_DTO nv = new PhieuXuat_DTO();
            nv.sMaPhieu = txtMaPX.Text;
            nv.sDiaChi = txtDiaChi.Text;
            nv.sTenNgNhan = txtNgN.Text;
            nv.sNgayXuat = DateTime.Parse(txtNgayXuat.Text);
            nv.sTongSoTien = float.Parse(txtSoTien.Text);

            nv.sMaDL = cboDaiLi.SelectedValue.ToString();
            nv.sMaNVLap = cboNV.SelectedValue.ToString();
            nv.sMaNVTT = cboNVTT.SelectedValue.ToString();

            if (PhieuXuat_BUS.SuaPhieuXuat(nv) == true)
            {
                HienThiDSNhanVienLenDatagrid();
                MessageBox.Show("Đã cập nhật thông tin phiếu xuất.");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra ! Không cập nhật được.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // kiểm tra mã có tồn tại
            if (txtMaPX.Text == "" || PhieuXuat_BUS.TimPhieuXuatTheoMa(txtMaPX.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã phiếu xuất!");
                return;
            }
            PhieuXuat_DTO nv = new PhieuXuat_DTO();
            nv.sMaPhieu = txtMaPX.Text;
            nv.sDiaChi = txtDiaChi.Text;
            nv.sTenNgNhan = txtNgN.Text;
            nv.sNgayXuat = DateTime.Parse(txtNgayXuat.Text);

            nv.sMaDL = cboDaiLi.SelectedValue.ToString();
            nv.sMaNVLap = cboNV.SelectedValue.ToString();
            nv.sMaNVTT = cboNVTT.SelectedValue.ToString();

            if (PhieuXuat_BUS.XoaPhieuXuat(nv) == true)
            {
                HienThiDSNhanVienLenDatagrid();
                MessageBox.Show("Đã xóa phiếu xuất.");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra ! Không xóa được.");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimPX.Text;

            List<PhieuXuat_DTO> lstnv = PhieuXuat_BUS.TimPhieuXuatBangTuKhoa(tukhoa);
            if (lstnv == null)
            {
                MessageBox.Show("Không tìm thấy!");
                return;
            }
            dataGridView1.DataSource = lstnv;
        }

        private void dgDSNhanVien_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dataGridView1.SelectedRows[0];
            txtMaPX.Text = r.Cells["sMaPhieu"].Value.ToString();
            txtDiaChi.Text = r.Cells["sDiaChi"].Value.ToString();
            txtNgN.Text = r.Cells["sTenNgNhan"].Value.ToString();
            txtNgayXuat.Text = r.Cells["sNgayXuat"].Value.ToString();
            txtSoTien.Text = r.Cells["sTongSoTien"].Value.ToString();

            cboDaiLi.SelectedValue = r.Cells["sMaDL"].Value;
            cboNV.SelectedValue = r.Cells["sMaNVLap"].Value;
            cboNVTT.SelectedValue = r.Cells["sMaNVTT"].Value;
        }

        private void btnXemCT_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;

        }
    }
}
