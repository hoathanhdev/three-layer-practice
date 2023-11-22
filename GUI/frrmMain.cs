using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frrmMain : Form
    {
        

        string hoVaTen = "";
        string vaitro = "";
        public bool succLogin = false;

        frm_QLNhanVien frmNV;
        frm_QLPhieuXuat frmPX;
        frm_QLSanPham frmSP;
        frm_QLDaiLi frmDL;
        frm_QLTK frmTK;
        frm_HTDangNhap frmDN;

        public frrmMain()
        {
            
            InitializeComponent();
        }

        private void mni_qlDL_Click(object sender, EventArgs e)
        {
            if (frmDL == null || frmDL.IsDisposed)
            {
                frmDL = new frm_QLDaiLi();
                frmDL.MdiParent = this;
                frmDL.Show();
            }
        }

       

        private void mni_qlNV_Click(object sender, EventArgs e)
        {
            if (frmNV == null || frmNV.IsDisposed)
            {
                frmNV = new frm_QLNhanVien();
                frmNV.MdiParent = this;
                frmNV.Show();
            }
        }

        private void mni_qlPX_Click(object sender, EventArgs e)
        {
            if (frmPX == null || frmPX.IsDisposed)
            {
                frmPX = new frm_QLPhieuXuat();
                frmPX.MdiParent = this;
                frmPX.Show();
            }
        }

        private void mni_qlSP_Click(object sender, EventArgs e)
        {
            if (frmSP == null || frmPX.IsDisposed)
            {
                frmSP = new frm_QLSanPham();
                frmSP.MdiParent = this;
                frmSP.Show();
            }
        }

        private void mni_qlTK_Click(object sender, EventArgs e)
        {
            if (frmTK == null || frmTK.IsDisposed)
            {
                frmTK = new frm_QLTK();
                frmTK.MdiParent = this;
                frmTK.Show();
            }
        }

        private void frrmMain_Load(object sender, EventArgs e)
        {
            LoadDN();

        }

        private void LoadDN()
        {
            frmDN = new frm_HTDangNhap();

            while (!succLogin && frmDN.DialogResult != DialogResult.Cancel)
            {
                frmDN.ShowDialog();
                this.Close();
            }
        }

        private void mni_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mni_QLDX_Click(object sender, EventArgs e)
        {
            succLogin = false;
            LoadDN();
            this.Close();
        }
    }
}
