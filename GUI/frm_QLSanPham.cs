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
    public partial class frm_QLSanPham : Form
    {
        public frm_QLSanPham()
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
            List<LoaiSP_DTO> lstChucVu = LoaiSP_BUS.LayChucVu();
            cboLoaiSP.DataSource = lstChucVu;
            cboLoaiSP.DisplayMember = "sTenLoai";
            cboLoaiSP.ValueMember = "sMaLoai";
        }

        private void HienThiDSNhanVienLenDatagrid()
        {

            //dg_col_SMaCV.DataSource = ChucVu_BUS.LayChucVu();
            //dg_col_SMaCV.DisplayMember = "STenCV";
            //dg_col_SMaCV.ValueMember = "SMaCV";


            List<SanPham_DTO> lstNhanVien = SanPham_BUS.LayDSSanPham();
            dgDSNhanVien.DataSource = lstNhanVien;
            //// thứ tự các cột
            //dgDSNhanVien.Columns[0].DataPropertyName = "SMaNV";
            //dgDSNhanVien.Columns[1].DataPropertyName = "SHoLot";
            //dgDSNhanVien.Columns[2].DataPropertyName = "STen";
            //dgDSNhanVien.Columns[3].DataPropertyName = "tencv";
            //dgDSNhanVien.Columns[4].DataPropertyName = "SPhai";
            //dgDSNhanVien.Columns[5].DataPropertyName = "DtNgaySinh";


            dgDSNhanVien.Columns["sMaSP"].HeaderText = "Mã số";
            dgDSNhanVien.Columns["SMaLoai"].HeaderText = "Mã Loai";
            dgDSNhanVien.Columns["sTenSP"].HeaderText = "Tên SP";
            dgDSNhanVien.Columns["sSoLuongCo"].HeaderText = "Số lượng có";
            dgDSNhanVien.Columns["sDonGia"].HeaderText = "Đơn giá";

            dgDSNhanVien.Columns["SMaSP"].Width = 60;
            dgDSNhanVien.Columns["STenSP"].Width = 100;
            dgDSNhanVien.Columns["SMaLoai"].Width = 50;
            dgDSNhanVien.Columns["sSoLuongCo"].Width = 100;
            dgDSNhanVien.Columns["sDonGia"].Width = 70;


            // mới bổ sung thêm
            // Hiển thị tên chức vụ tương ứng
            string tenchucvu;
            DataGridViewColumn clTenCV = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            clTenCV.CellTemplate = cell;
            clTenCV.Name = "tenloai";
            clTenCV.HeaderText = "Tên loại";
            clTenCV.Width = 150;
            dgDSNhanVien.Columns.Add(clTenCV);
            for (int i = 0; i < dgDSNhanVien.RowCount; i++)
            {
                tenchucvu = LoaiCV_BUS.LayTenChucVuTheoMa(dgDSNhanVien.Rows[i].Cells["sMaLoai"].Value.ToString());
                dgDSNhanVien.Rows[i].Cells["tenloai"].Value = tenchucvu;
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống 
            if (txtMaSP.Text == "" || txtTen.Text == "" || txtSoLuong.Text == "" || txtDonGia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã nhân viên có độ dài chuỗi hợp lệ hay không
            if (txtMaSP.Text.Length > 5)
            {
                MessageBox.Show("Mã sản phẩm tối đa 5 ký tự!");
                return;
            }
            // Kiểm tra mã nhân viên có bị trùng không
            if (SanPham_BUS.TimSanPhamTheoMa(txtMaSP.Text) != null)
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại!");
                return;
            }

            SanPham_DTO nv = new SanPham_DTO();
            nv.sMaSP = txtMaSP.Text;
            nv.sTenSP = txtTen.Text;
            nv.sSoLuongCo = Int32.Parse(txtSoLuong.Text);
            nv.sDonGia = float.Parse(txtDonGia.Text);
            
            nv.sMaloai= cboLoaiSP.SelectedValue.ToString();

            if (SanPham_BUS.ThemSanPham(nv) == false)
            {
                MessageBox.Show("Có lỗi xảy ra ! Không thêm được.");
                return;
            }

            HienThiDSNhanVienLenDatagrid();
            MessageBox.Show("Đã thêm sản phẩm.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // kiểm tra mã có tồn tại
            if (txtMaSP.Text == "" || SanPham_BUS.TimSanPhamTheoMa(txtMaSP.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã sản phẩm");
                return;
            }
            SanPham_DTO nv = new SanPham_DTO();
            nv.sMaSP = txtMaSP.Text;
            nv.sTenSP = txtTen.Text;
            nv.sSoLuongCo = Int32.Parse(txtSoLuong.Text);
            nv.sDonGia = float.Parse(txtDonGia.Text);

            nv.sMaloai = cboLoaiSP.SelectedValue.ToString();

            if (SanPham_BUS.SuaSanPham(nv) == true)
            {
                HienThiDSNhanVienLenDatagrid();
                MessageBox.Show("Đã cập nhật thông tin sản phẩm.");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra ! Không cập nhật được.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // kiểm tra mã có tồn tại
            if (txtMaSP.Text == "" || SanPham_BUS.TimSanPhamTheoMa(txtMaSP.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã sản phẩm !");
                return;
            }
            SanPham_DTO nv = new SanPham_DTO();
            nv.sMaSP = txtMaSP.Text;
            nv.sTenSP = txtTen.Text;
            nv.sSoLuongCo = Int32.Parse(txtSoLuong.Text);
            nv.sDonGia = float.Parse(txtDonGia.Text);

            nv.sMaloai = cboLoaiSP.SelectedValue.ToString();

            if (SanPham_BUS.XoaSanPham(nv) == true)
            {
                HienThiDSNhanVienLenDatagrid();
                MessageBox.Show("Đã xóa sản phẩm.");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra ! Không xóa được.");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimSP.Text;

            List<SanPham_DTO> lstnv = SanPham_BUS.TimSanPhamBangTuKhoa(tukhoa);
            if (lstnv == null)
            {
                MessageBox.Show("Có lỗi xảy ra ! Không tìm thấy!");
                return;
            }
            dgDSNhanVien.DataSource = lstnv;
        }

        private void dgDSNhanVien_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgDSNhanVien.SelectedRows[0];
            txtMaSP.Text = r.Cells["sMaSP"].Value.ToString();
            txtTen.Text = r.Cells["sTenSP"].Value.ToString();
            txtSoLuong.Text = r.Cells["sSoLuongCo"].Value.ToString();
            txtDonGia.Text = r.Cells["sDonGia"].Value.ToString();
            cboLoaiSP.SelectedValue = r.Cells["sMaLoai"].Value;
        }    
    }
}
