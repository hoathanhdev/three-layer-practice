using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace GUI
{
    public partial class frm_HTDangNhap : Form
    {
        frrmMain frmMain = new frrmMain();
        SqlConnection con;
        public frm_HTDangNhap()
        {
            InitializeComponent();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "") { MessageBox.Show("Tên đăng nhập không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);txtUsername.Focus();  }
            else if (txtPassword.Text.Trim() == "") { MessageBox.Show("Mật khẩu không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); txtPassword.Focus(); }
            else
            {
                string sTruyVan = string.Format("SELECT * FROM taikhoan WHERE username = '{0}' AND password = '{1}'",txtUsername.Text,txtPassword.Text);
                con = DataProvider.MoKetNoi();
                DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); txtUsername.Focus();

                }

                TaiKhoan_DTO dl = new TaiKhoan_DTO();
                dl.sMaTK = dt.Rows[0]["matk"].ToString();
                dl.sUserName = dt.Rows[0]["username"].ToString();
                dl.sMatKhau = dt.Rows[0]["password"].ToString();
                dl.sEmail = dt.Rows[0]["email"].ToString();


                DataProvider.DongKetNoi(con);
                frmMain.lblTen.Text = dl.sUserName;
                frmMain.succLogin = true;
              
                frmMain.ShowDialog();
                this.Close();



            }
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
