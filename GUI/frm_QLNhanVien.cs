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
    public partial class frm_QLNhanVien : Form
    {
        public frm_QLNhanVien()
        {
            InitializeComponent();
        }


        

        private void frm_QLNhanVien_Load(object sender, EventArgs e)
        {
            HienThiChucVuLenCombobox();
            HienThiDSNhanVienLenDatagrid();
        }

        private void HienThiChucVuLenCombobox()
        {
            List<LoaiCV_DTO> lstChucVu = LoaiCV_BUS.LayChucVu();
            cboChucVu.DataSource = lstChucVu;
            cboChucVu.DisplayMember = "sTenCV";
            cboChucVu.ValueMember = "sMaCV";
        }

        private void HienThiDSNhanVienLenDatagrid()
        {

            //dg_col_SMaCV.DataSource = ChucVu_BUS.LayChucVu();
            //dg_col_SMaCV.DisplayMember = "STenCV";
            //dg_col_SMaCV.ValueMember = "SMaCV";


            List<NhanVien_DTO> lstNhanVien = NhanVien_BUS.LayDSNhanVien();
            dgDSNhanVien.DataSource = lstNhanVien;
            //// thứ tự các cột
            //dgDSNhanVien.Columns[0].DataPropertyName = "SMaNV";
            //dgDSNhanVien.Columns[1].DataPropertyName = "SHoLot";
            //dgDSNhanVien.Columns[2].DataPropertyName = "STen";
            //dgDSNhanVien.Columns[3].DataPropertyName = "tencv";
            //dgDSNhanVien.Columns[4].DataPropertyName = "SPhai";
            //dgDSNhanVien.Columns[5].DataPropertyName = "DtNgaySinh";


            dgDSNhanVien.Columns["sMaNV"].HeaderText = "Mã số";
            dgDSNhanVien.Columns["sMaCV"].HeaderText = "Mã CV";
            dgDSNhanVien.Columns["sTenNV"].HeaderText = "Tên";
            dgDSNhanVien.Columns["sDiaChi"].HeaderText = "Địa chỉ";
            dgDSNhanVien.Columns["sSoDT"].HeaderText = "SDT";

            dgDSNhanVien.Columns["SMaNV"].Width = 60;
            dgDSNhanVien.Columns["STenNV"].Width = 100;
            dgDSNhanVien.Columns["SMaCV"].Width = 50;
            dgDSNhanVien.Columns["sDiaChi"].Width = 100;
            dgDSNhanVien.Columns["sSoDT"].Width = 70;


            // mới bổ sung thêm
            // Hiển thị tên chức vụ tương ứng
            string tenchucvu;
            DataGridViewColumn clTenCV = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            clTenCV.CellTemplate = cell;
            clTenCV.Name = "tencv";
            clTenCV.HeaderText = "Chức vụ";
            clTenCV.Width = 150;
            dgDSNhanVien.Columns.Add(clTenCV);
            for (int i = 0; i < dgDSNhanVien.RowCount; i++)
            {
                tenchucvu = LoaiCV_BUS.LayTenChucVuTheoMa(dgDSNhanVien.Rows[i].Cells["sMaCV"].Value.ToString());
                dgDSNhanVien.Rows[i].Cells["tencv"].Value = tenchucvu;
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống 
            if (txtMaNV.Text == "" || txtTen.Text == "" || txtDiaChi.Text == "" || txtSoDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã nhân viên có độ dài chuỗi hợp lệ hay không
            if (txtMaNV.Text.Length > 5)
            {
                MessageBox.Show("Mã nhân viên tối đa 5 ký tự!");
                return;
            }
            // Kiểm tra mã nhân viên có bị trùng không
            if (NhanVien_BUS.TimNhanVienTheoMa(txtMaNV.Text) != null)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!");
                return;
            }

            NhanVien_DTO nv = new NhanVien_DTO();
            nv.sMaNV = txtMaNV.Text;           
            nv.sTenNV = txtTen.Text;
            nv.sDiaChi = txtDiaChi.Text;
            nv.sSoDT = txtSoDT.Text;
            
            nv.sMaCV = cboChucVu.SelectedValue.ToString();

            if (NhanVien_BUS.ThemNhanVien(nv) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }

            HienThiDSNhanVienLenDatagrid();
            MessageBox.Show("Đã thêm nhân viên.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // kiểm tra mã có tồn tại
            if (txtMaNV.Text == "" || NhanVien_BUS.TimNhanVienTheoMa(txtMaNV.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên!");
                return;
            }
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.sMaNV = txtMaNV.Text;
            nv.sTenNV = txtTen.Text;
            nv.sDiaChi = txtDiaChi.Text;
            nv.sSoDT = txtSoDT.Text;

            nv.sMaCV = cboChucVu.SelectedValue.ToString();

            if (NhanVien_BUS.SuaNhanVien(nv) == true)
            {
                HienThiDSNhanVienLenDatagrid();
                MessageBox.Show("Đã cập nhật thông tin nhân viên.");
            }
            else
            {
                MessageBox.Show("Không cập nhật được.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // kiểm tra mã có tồn tại
            if (txtMaNV.Text == "" || NhanVien_BUS.TimNhanVienTheoMa(txtMaNV.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên!");
                return;
            }
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.sMaNV = txtMaNV.Text;
            nv.sTenNV = txtTen.Text;
            nv.sDiaChi = txtDiaChi.Text;
            nv.sSoDT = txtSoDT.Text;

            nv.sMaCV = cboChucVu.SelectedValue.ToString();

            if (NhanVien_BUS.XoaNhanVien(nv) == true)
            {
                HienThiDSNhanVienLenDatagrid();
                MessageBox.Show("Đã xóa nhân viên.");
            }
            else
            {
                MessageBox.Show("Không xóa được.");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimNV.Text;

            List<NhanVien_DTO> lstnv = NhanVien_BUS.TimNhanVienBangTuKhoa(tukhoa);
            if (lstnv == null)
            {
                MessageBox.Show("Không tìm thấy!");
                return;
            }
            dgDSNhanVien.DataSource = lstnv;
        }

        private void dgDSNhanVien_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgDSNhanVien.SelectedRows[0];
            txtMaNV.Text = r.Cells["sMaNV"].Value.ToString();
            txtTen.Text = r.Cells["sTenNV"].Value.ToString();
            txtDiaChi.Text = r.Cells["sDiaChi"].Value.ToString();
            txtSoDT.Text = r.Cells["sSoDT"].Value.ToString();
            cboChucVu.SelectedValue = r.Cells["sMaCV"].Value;
        }    
    }
}
