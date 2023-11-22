namespace GUI
{
    partial class frrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_QLDX = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_Thoat = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcQuảnLíToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_qlDL = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_qlNV = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_qlPX = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_qlSP = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_qlTK = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêBáoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTen = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.danhMụcQuảnLíToolStripMenuItem,
            this.thốngKêBáoCáoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mni_QLDX,
            this.mni_Thoat});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.hệThốngToolStripMenuItem.Text = "&Hệ thống";
            // 
            // mni_QLDX
            // 
            this.mni_QLDX.Name = "mni_QLDX";
            this.mni_QLDX.Size = new System.Drawing.Size(180, 22);
            this.mni_QLDX.Text = "Đăng &Xuất";
            this.mni_QLDX.Click += new System.EventHandler(this.mni_QLDX_Click);
            // 
            // mni_Thoat
            // 
            this.mni_Thoat.Name = "mni_Thoat";
            this.mni_Thoat.Size = new System.Drawing.Size(180, 22);
            this.mni_Thoat.Text = "&Thoát";
            this.mni_Thoat.Click += new System.EventHandler(this.mni_Thoat_Click);
            // 
            // danhMụcQuảnLíToolStripMenuItem
            // 
            this.danhMụcQuảnLíToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mni_qlDL,
            this.mni_qlNV,
            this.mni_qlPX,
            this.mni_qlSP,
            this.mni_qlTK});
            this.danhMụcQuảnLíToolStripMenuItem.Name = "danhMụcQuảnLíToolStripMenuItem";
            this.danhMụcQuảnLíToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.danhMụcQuảnLíToolStripMenuItem.Text = "&Danh mục quản lí";
            // 
            // mni_qlDL
            // 
            this.mni_qlDL.Name = "mni_qlDL";
            this.mni_qlDL.Size = new System.Drawing.Size(172, 22);
            this.mni_qlDL.Text = "Quản lí Đại &Lí";
            this.mni_qlDL.Click += new System.EventHandler(this.mni_qlDL_Click);
            // 
            // mni_qlNV
            // 
            this.mni_qlNV.Name = "mni_qlNV";
            this.mni_qlNV.Size = new System.Drawing.Size(172, 22);
            this.mni_qlNV.Text = "Quản lí Nhân &Viên";
            this.mni_qlNV.Click += new System.EventHandler(this.mni_qlNV_Click);
            // 
            // mni_qlPX
            // 
            this.mni_qlPX.Name = "mni_qlPX";
            this.mni_qlPX.Size = new System.Drawing.Size(172, 22);
            this.mni_qlPX.Text = "Quản lí Phiếu &Xuất";
            this.mni_qlPX.Click += new System.EventHandler(this.mni_qlPX_Click);
            // 
            // mni_qlSP
            // 
            this.mni_qlSP.Name = "mni_qlSP";
            this.mni_qlSP.Size = new System.Drawing.Size(172, 22);
            this.mni_qlSP.Text = "Quản lí &Sản Phẩm";
            this.mni_qlSP.Click += new System.EventHandler(this.mni_qlSP_Click);
            // 
            // mni_qlTK
            // 
            this.mni_qlTK.Name = "mni_qlTK";
            this.mni_qlTK.Size = new System.Drawing.Size(172, 22);
            this.mni_qlTK.Text = "Quản lí &Tài Khoản";
            this.mni_qlTK.Click += new System.EventHandler(this.mni_qlTK_Click);
            // 
            // thốngKêBáoCáoToolStripMenuItem
            // 
            this.thốngKêBáoCáoToolStripMenuItem.Name = "thốngKêBáoCáoToolStripMenuItem";
            this.thốngKêBáoCáoToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.thốngKêBáoCáoToolStripMenuItem.Text = "Đổi &MK";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTen});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTen
            // 
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(10, 17);
            this.lblTen.Text = " ";
            // 
            // frrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lí cửa hàng nước giải khác";
            this.Load += new System.EventHandler(this.frrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mni_QLDX;
        private System.Windows.Forms.ToolStripMenuItem mni_Thoat;
        private System.Windows.Forms.ToolStripMenuItem danhMụcQuảnLíToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mni_qlDL;
        private System.Windows.Forms.ToolStripMenuItem mni_qlNV;
        private System.Windows.Forms.ToolStripMenuItem thốngKêBáoCáoToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem mni_qlPX;
        private System.Windows.Forms.ToolStripMenuItem mni_qlSP;
        private System.Windows.Forms.ToolStripMenuItem mni_qlTK;
        public System.Windows.Forms.ToolStripStatusLabel lblTen;
    }
}

