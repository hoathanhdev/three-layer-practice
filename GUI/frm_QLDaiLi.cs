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
    public partial class frm_QLDaiLi : Form
    {
        public frm_QLDaiLi()
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


            List<DaiLi_DTO> lstNhanVien = DaiLi_BUS.LayDSDaiLi();
            dataGridView1.DataSource = lstNhanVien;
            //// thứ tự các cột
            //dgDSNhanVien.Columns[0].DataPropertyName = "SMaNV";
            //dgDSNhanVien.Columns[1].DataPropertyName = "SHoLot";
            //dgDSNhanVien.Columns[2].DataPropertyName = "STen";
            //dgDSNhanVien.Columns[3].DataPropertyName = "tencv";
            //dgDSNhanVien.Columns[4].DataPropertyName = "SPhai";
            //dgDSNhanVien.Columns[5].DataPropertyName = "DtNgaySinh";


            dataGridView1.Columns["sMaDL"].HeaderText = "Mã số";
            dataGridView1.Columns["sTenDL"].HeaderText = "Tên Đại Lí";
            dataGridView1.Columns["sDiaChi"].HeaderText = "Địa Chỉ";
            dataGridView1.Columns["sSoDT"].HeaderText = "Số DT";
            dataGridView1.Columns["sSoTienNo"].HeaderText = "Số tiền nợ";

            dataGridView1.Columns["sMaDL"].Width = 60;
            dataGridView1.Columns["sTenDL"].Width = 120;
            dataGridView1.Columns["sDiaChi"].Width = 140;
            dataGridView1.Columns["sSoDT"].Width = 80;
            dataGridView1.Columns["sSoTienNo"].Width =80;



            

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống 
            if (txtMaDL.Text == "" || txtTenDL.Text == "" || txtSoDT.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã nhân viên có độ dài chuỗi hợp lệ hay không
            if (txtMaDL.Text.Length > 5)
            {
                MessageBox.Show("Mã đại lí tối đa 5 ký tự!");
                return;
            }
            // Kiểm tra mã nhân viên có bị trùng không
            if (DaiLi_BUS.TimDaiLiTheoMa(txtMaDL.Text) != null)
            {
                MessageBox.Show("Mã đại lí đã tồn tại!");
                return;
            }

            DaiLi_DTO nv = new DaiLi_DTO();
            nv.sMaDL = txtMaDL.Text;
            nv.sTenDL = txtTenDL.Text;
            nv.sSoDT = txtSoDT.Text;
            nv.sDiaChi = txtDiaChi.Text;
            nv.sSoTienNo = Int32.Parse(txtSoTienNo.Text);
            

            if (DaiLi_BUS.ThemDaiLi(nv) == false)
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
            if (txtMaDL.Text == "" || DaiLi_BUS.TimDaiLiTheoMa(txtMaDL.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã đại lí!");
                return;
            }

            DaiLi_DTO nv = new DaiLi_DTO();
            nv.sMaDL = txtMaDL.Text;
            nv.sTenDL = txtTenDL.Text;
            nv.sSoDT = txtSoDT.Text;
            nv.sDiaChi = txtDiaChi.Text;
            nv.sSoTienNo = Int32.Parse(txtSoTienNo.Text);

            if (DaiLi_BUS.SuaDaiLi(nv) == true)
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
            if (txtMaDL.Text == "" || DaiLi_BUS.TimDaiLiTheoMa(txtMaDL.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã đại lí!");
                return;
            }
            DaiLi_DTO nv = new DaiLi_DTO();
            nv.sMaDL = txtMaDL.Text;
            nv.sTenDL = txtTenDL.Text;
            nv.sSoDT = txtSoDT.Text;
            nv.sDiaChi = txtDiaChi.Text;
            nv.sSoTienNo = Int32.Parse(txtSoTienNo.Text);


            if (DaiLi_BUS.XoaDaiLi(nv) == true)
            {
                HienThiDSNhanVienLenDatagrid();
                MessageBox.Show("Đã xóa đại lí.");
            }
            else
            {
                MessageBox.Show("Không xóa được. Vui lòng kiểm tra các ràng buộc !");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimDL.Text;

            List<DaiLi_DTO> lstnv = DaiLi_BUS.TimDaiLiBangTuKhoa(tukhoa);
            if (lstnv == null)
            {
                MessageBox.Show("Không tìm thấy!");
                return;
            }
            dataGridView1.DataSource = lstnv;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dataGridView1.SelectedRows[0];
            txtMaDL.Text = r.Cells["sMaDL"].Value.ToString();
            txtTenDL.Text = r.Cells["sTenDL"].Value.ToString();
            txtSoDT.Text = r.Cells["sSoDT"].Value.ToString();
            txtDiaChi.Text = r.Cells["sDiaChi"].Value.ToString();
            txtSoTienNo.Text = r.Cells["sSoTienNo"].Value.ToString();
        }

      
    }
}
