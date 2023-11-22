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
    public partial class frm_QLTK : Form
    {
        public frm_QLTK()
        {
            InitializeComponent();
        }

        private void frm_QLDaiLi_Load(object sender, EventArgs e)
        {
            HienThiDSNhanVienLenDatagrid();
        }

       

        private void HienThiDSNhanVienLenDatagrid()
        {

            //dg_col_SMaCV.DataSource = ChucVu_BUS.LayChucVu();
            //dg_col_SMaCV.DisplayMember = "STenCV";
            //dg_col_SMaCV.ValueMember = "SMaCV";


            List<TaiKhoan_DTO> lstNhanVien = TaiKhoan_BUS.LayDSTaiKhoan();
            dataGridView1.DataSource = lstNhanVien;
            //// thứ tự các cột
            //dgDSNhanVien.Columns[0].DataPropertyName = "SMaNV";
            //dgDSNhanVien.Columns[1].DataPropertyName = "SHoLot";
            //dgDSNhanVien.Columns[2].DataPropertyName = "STen";
            //dgDSNhanVien.Columns[3].DataPropertyName = "tencv";
            //dgDSNhanVien.Columns[4].DataPropertyName = "SPhai";
            //dgDSNhanVien.Columns[5].DataPropertyName = "DtNgaySinh";


            dataGridView1.Columns["sMaTK"].HeaderText = "Mã số";
            dataGridView1.Columns["sUserName"].HeaderText = "Tên DN";
            dataGridView1.Columns["sMatKhau"].HeaderText = "Mật khẩu";
            dataGridView1.Columns["sEmail"].HeaderText = "Email";


            dataGridView1.Columns["sMaTK"].Width = 60;
            dataGridView1.Columns["sUserName"].Width = 140;
            dataGridView1.Columns["sMatKhau"].Width = 120;
            dataGridView1.Columns["sEmail"].Width = 140;





        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống 
            if (txtMaTK.Text == "" || txtTenDN.Text == "" || txtMK.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã nhân viên có độ dài chuỗi hợp lệ hay không
            if (txtMaTK.Text.Length > 5)
            {
                MessageBox.Show("Mã đại lí tối đa 5 ký tự!");
                return;
            }
            // Kiểm tra mã nhân viên có bị trùng không
            if (DaiLi_BUS.TimDaiLiTheoMa(txtMaTK.Text) != null)
            {
                MessageBox.Show("Mã đại lí đã tồn tại!");
                return;
            }

            TaiKhoan_DTO nv = new TaiKhoan_DTO();
            nv.sMaTK = txtMaTK.Text;
            nv.sUserName = txtTenDN.Text;
            nv.sMatKhau = txtMK.Text;
            nv.sEmail = txtEmail.Text;
            

            if (TaiKhoan_BUS.ThemTaiKhoan(nv) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }

            HienThiDSNhanVienLenDatagrid();
            MessageBox.Show("Đã thêm đại lí.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // kiểm tra mã có tồn tại
            if (txtMaTK.Text == "" || TaiKhoan_BUS.TimTaiKhoanTheoMa(txtMaTK.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên!");
                return;
            }

            TaiKhoan_DTO nv = new TaiKhoan_DTO();
            nv.sMaTK = txtMaTK.Text;
            nv.sUserName = txtTenDN.Text;
            nv.sMatKhau = txtMK.Text;
            nv.sEmail = txtEmail.Text;
 

            if (TaiKhoan_BUS.SuaTaiKhoan(nv) == true)
            {
                HienThiDSNhanVienLenDatagrid();
                MessageBox.Show("Đã cập nhật thông tin đại lí.");
            }
            else
            {
                MessageBox.Show("Không cập nhật được ! Vui lòng kiểm tra các ràng buộc !");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // kiểm tra mã có tồn tại
            if (txtMaTK.Text == "" || TaiKhoan_BUS.TimTaiKhoanTheoMa(txtMaTK.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã đại lí!");
                return;
            }
            TaiKhoan_DTO nv = new TaiKhoan_DTO();
            nv.sMaTK = txtMaTK.Text;
            nv.sUserName = txtTenDN.Text;
            nv.sMatKhau = txtMK.Text;
            nv.sEmail = txtEmail.Text;
             


            if (TaiKhoan_BUS.XoaTaiKhoan(nv) == true)
            {
                HienThiDSNhanVienLenDatagrid();
                MessageBox.Show("Đã xóa đại lí.");
            }
            else
            {
                MessageBox.Show("Không xóa được. Vui lòng kiểm tra các ràng buộc !");
            }
        }

        

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dataGridView1.SelectedRows[0];
            txtMaTK.Text = r.Cells["sMaTK"].Value.ToString();
            txtTenDN.Text = r.Cells["sUserName"].Value.ToString();
            txtMK.Text = r.Cells["sMatKhau"].Value.ToString();
            txtEmail.Text = r.Cells["sEmail"].Value.ToString();
            
        }

      
    }
}
