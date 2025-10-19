using System.Drawing;
using System.Windows.Forms;

namespace Education_Manager
{
    partial class frmQuanLyTaiChinh
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyTaiChinh));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lienHeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phanHoiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnPhieuThu = new System.Windows.Forms.Button();
            this.btnLoaiThuChi = new System.Windows.Forms.Button();
            this.btnHocPhiNganh = new System.Windows.Forms.Button();
            this.btnHocPhiSV = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pnHome = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(128)))), ((int)(((byte)(50)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.trợGiúpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1333, 36);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hệThốngToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.hệThốngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hệThốngToolStripMenuItem.Image")));
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(133, 32);
            this.hệThốngToolStripMenuItem.Text = "Trang Chủ";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(187, 32);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(187, 32);
            this.thoátToolStripMenuItem.Text = "Quay lại";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hướngDẫnToolStripMenuItem,
            this.lienHeToolStripMenuItem,
            this.phanHoiToolStripMenuItem});
            this.trợGiúpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trợGiúpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.trợGiúpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("trợGiúpToolStripMenuItem.Image")));
            this.trợGiúpToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(118, 32);
            this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // hướngDẫnToolStripMenuItem
            // 
            this.hướngDẫnToolStripMenuItem.Name = "hướngDẫnToolStripMenuItem";
            this.hướngDẫnToolStripMenuItem.Size = new System.Drawing.Size(197, 32);
            this.hướngDẫnToolStripMenuItem.Text = "Hướng dẫn";
            // 
            // lienHeToolStripMenuItem
            // 
            this.lienHeToolStripMenuItem.Name = "lienHeToolStripMenuItem";
            this.lienHeToolStripMenuItem.Size = new System.Drawing.Size(197, 32);
            this.lienHeToolStripMenuItem.Text = "Liên hệ";
            // 
            // phanHoiToolStripMenuItem
            // 
            this.phanHoiToolStripMenuItem.Name = "phanHoiToolStripMenuItem";
            this.phanHoiToolStripMenuItem.Size = new System.Drawing.Size(197, 32);
            this.phanHoiToolStripMenuItem.Text = "Phản hồi";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblWelcome,
            this.toolStripStatusLabel1,
            this.lblDateTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 716);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1333, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblWelcome
            // 
            this.lblWelcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(128)))), ((int)(((byte)(50)))));
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(0, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(128)))), ((int)(((byte)(50)))));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1313, 16);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // lblDateTime
            // 
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(0, 16);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panelSidebar.Controls.Add(this.btnPhieuThu);
            this.panelSidebar.Controls.Add(this.btnLoaiThuChi);
            this.panelSidebar.Controls.Add(this.btnHocPhiNganh);
            this.panelSidebar.Controls.Add(this.btnHocPhiSV);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 36);
            this.panelSidebar.Margin = new System.Windows.Forms.Padding(4);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(293, 680);
            this.panelSidebar.TabIndex = 4;
            this.panelSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSidebar_Paint);
            // 
            // btnPhieuThu
            // 
            this.btnPhieuThu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhieuThu.FlatAppearance.BorderSize = 0;
            this.btnPhieuThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhieuThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhieuThu.ForeColor = System.Drawing.Color.White;
            this.btnPhieuThu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhieuThu.Location = new System.Drawing.Point(0, 165);
            this.btnPhieuThu.Margin = new System.Windows.Forms.Padding(4);
            this.btnPhieuThu.Name = "btnPhieuThu";
            this.btnPhieuThu.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnPhieuThu.Size = new System.Drawing.Size(293, 55);
            this.btnPhieuThu.TabIndex = 3;
            this.btnPhieuThu.Text = "Quản Lý Phiếu Thu";
            this.btnPhieuThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhieuThu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPhieuThu.UseVisualStyleBackColor = true;
            this.btnPhieuThu.Click += new System.EventHandler(this.btnHocPhan_Click);
            // 
            // btnLoaiThuChi
            // 
            this.btnLoaiThuChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoaiThuChi.FlatAppearance.BorderSize = 0;
            this.btnLoaiThuChi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoaiThuChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoaiThuChi.ForeColor = System.Drawing.Color.White;
            this.btnLoaiThuChi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoaiThuChi.Location = new System.Drawing.Point(0, 110);
            this.btnLoaiThuChi.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoaiThuChi.Name = "btnLoaiThuChi";
            this.btnLoaiThuChi.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnLoaiThuChi.Size = new System.Drawing.Size(293, 55);
            this.btnLoaiThuChi.TabIndex = 2;
            this.btnLoaiThuChi.Text = "Quản Lý Loại Thu Chi";
            this.btnLoaiThuChi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoaiThuChi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoaiThuChi.UseVisualStyleBackColor = true;
            this.btnLoaiThuChi.Click += new System.EventHandler(this.btnHocKy_Click);
            // 
            // btnHocPhiNganh
            // 
            this.btnHocPhiNganh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHocPhiNganh.FlatAppearance.BorderSize = 0;
            this.btnHocPhiNganh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocPhiNganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHocPhiNganh.ForeColor = System.Drawing.Color.White;
            this.btnHocPhiNganh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhiNganh.Location = new System.Drawing.Point(0, 55);
            this.btnHocPhiNganh.Margin = new System.Windows.Forms.Padding(4);
            this.btnHocPhiNganh.Name = "btnHocPhiNganh";
            this.btnHocPhiNganh.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnHocPhiNganh.Size = new System.Drawing.Size(293, 55);
            this.btnHocPhiNganh.TabIndex = 1;
            this.btnHocPhiNganh.Text = "Quản Lý Học Phí Ngành";
            this.btnHocPhiNganh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhiNganh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHocPhiNganh.UseVisualStyleBackColor = true;
            this.btnHocPhiNganh.Click += new System.EventHandler(this.btnNganh_Click);
            // 
            // btnHocPhiSV
            // 
            this.btnHocPhiSV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHocPhiSV.FlatAppearance.BorderSize = 0;
            this.btnHocPhiSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocPhiSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHocPhiSV.ForeColor = System.Drawing.Color.White;
            this.btnHocPhiSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhiSV.Location = new System.Drawing.Point(0, 0);
            this.btnHocPhiSV.Margin = new System.Windows.Forms.Padding(4);
            this.btnHocPhiSV.Name = "btnHocPhiSV";
            this.btnHocPhiSV.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnHocPhiSV.Size = new System.Drawing.Size(293, 55);
            this.btnHocPhiSV.TabIndex = 0;
            this.btnHocPhiSV.Text = "Quản Lý Học Phí Sinh Viên";
            this.btnHocPhiSV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhiSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHocPhiSV.UseVisualStyleBackColor = true;
            this.btnHocPhiSV.Click += new System.EventHandler(this.btnKhoa_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblAppName);
            this.panelHeader.Controls.Add(this.pictureBoxLogo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(293, 36);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1040, 123);
            this.panelHeader.TabIndex = 5;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(128)))), ((int)(((byte)(50)))));
            this.lblAppName.Location = new System.Drawing.Point(210, 38);
            this.lblAppName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(365, 39);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "QUẢN LÝ TÀI CHÍNH";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(148, 123);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // pnHome
            // 
            this.pnHome.AutoSize = true;
            this.pnHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnHome.Location = new System.Drawing.Point(293, 159);
            this.pnHome.Name = "pnHome";
            this.pnHome.Size = new System.Drawing.Size(1040, 557);
            this.pnHome.TabIndex = 9;
            // 
            // frmQuanLyTaiChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1333, 738);
            this.ControlBox = false;
            this.Controls.Add(this.pnHome);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQuanLyTaiChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hướngDẫnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lienHeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblWelcome;
        private System.Windows.Forms.ToolStripStatusLabel lblDateTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnHocPhiSV;
        private System.Windows.Forms.Button btnHocPhiNganh;
        private System.Windows.Forms.Button btnLoaiThuChi;
        private System.Windows.Forms.Button btnPhieuThu;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem phanHoiToolStripMenuItem;
        private Panel pnHome;
        private PictureBox pictureBoxLogo;
    }
}