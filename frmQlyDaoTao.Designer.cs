using System.Drawing;
using System.Windows.Forms;

namespace Education_Manager
{
    partial class frmQlyDaoTao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQlyDaoTao));
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
            this.btnKeHoachHt = new System.Windows.Forms.Button();
            this.btnLop = new System.Windows.Forms.Button();
            this.btnDangKyHoc = new System.Windows.Forms.Button();
            this.btnLopHocPhan = new System.Windows.Forms.Button();
            this.btnHocPhan = new System.Windows.Forms.Button();
            this.btnHocKy = new System.Windows.Forms.Button();
            this.btnNganh = new System.Windows.Forms.Button();
            this.btnKhoa = new System.Windows.Forms.Button();
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
            this.panelSidebar.Controls.Add(this.btnKeHoachHt);
            this.panelSidebar.Controls.Add(this.btnLop);
            this.panelSidebar.Controls.Add(this.btnDangKyHoc);
            this.panelSidebar.Controls.Add(this.btnLopHocPhan);
            this.panelSidebar.Controls.Add(this.btnHocPhan);
            this.panelSidebar.Controls.Add(this.btnHocKy);
            this.panelSidebar.Controls.Add(this.btnNganh);
            this.panelSidebar.Controls.Add(this.btnKhoa);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 36);
            this.panelSidebar.Margin = new System.Windows.Forms.Padding(4);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(293, 680);
            this.panelSidebar.TabIndex = 4;
            this.panelSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSidebar_Paint);
            // 
            // btnKeHoachHt
            // 
            this.btnKeHoachHt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKeHoachHt.FlatAppearance.BorderSize = 0;
            this.btnKeHoachHt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeHoachHt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeHoachHt.ForeColor = System.Drawing.Color.White;
            this.btnKeHoachHt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKeHoachHt.Location = new System.Drawing.Point(0, 385);
            this.btnKeHoachHt.Margin = new System.Windows.Forms.Padding(4);
            this.btnKeHoachHt.Name = "btnKeHoachHt";
            this.btnKeHoachHt.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnKeHoachHt.Size = new System.Drawing.Size(293, 55);
            this.btnKeHoachHt.TabIndex = 7;
            this.btnKeHoachHt.Text = "Quản Lý Tiến Độ Học Tập";
            this.btnKeHoachHt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKeHoachHt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKeHoachHt.UseVisualStyleBackColor = true;
            this.btnKeHoachHt.Click += new System.EventHandler(this.btnKeHoachHt_Click);
            // 
            // btnLop
            // 
            this.btnLop.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLop.FlatAppearance.BorderSize = 0;
            this.btnLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLop.ForeColor = System.Drawing.Color.White;
            this.btnLop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLop.Location = new System.Drawing.Point(0, 330);
            this.btnLop.Margin = new System.Windows.Forms.Padding(4);
            this.btnLop.Name = "btnLop";
            this.btnLop.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnLop.Size = new System.Drawing.Size(293, 55);
            this.btnLop.TabIndex = 6;
            this.btnLop.Text = "Quản Lý Lớp";
            this.btnLop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLop.UseVisualStyleBackColor = true;
            this.btnLop.Click += new System.EventHandler(this.btnLop_Click);
            // 
            // btnDangKyHoc
            // 
            this.btnDangKyHoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDangKyHoc.FlatAppearance.BorderSize = 0;
            this.btnDangKyHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKyHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKyHoc.ForeColor = System.Drawing.Color.White;
            this.btnDangKyHoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangKyHoc.Location = new System.Drawing.Point(0, 275);
            this.btnDangKyHoc.Margin = new System.Windows.Forms.Padding(4);
            this.btnDangKyHoc.Name = "btnDangKyHoc";
            this.btnDangKyHoc.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnDangKyHoc.Size = new System.Drawing.Size(293, 55);
            this.btnDangKyHoc.TabIndex = 5;
            this.btnDangKyHoc.Text = "Quản Lý Thời Khóa Biểu";
            this.btnDangKyHoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangKyHoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDangKyHoc.UseVisualStyleBackColor = true;
            this.btnDangKyHoc.Click += new System.EventHandler(this.btnDangKyHoc_Click);
            // 
            // btnLopHocPhan
            // 
            this.btnLopHocPhan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLopHocPhan.FlatAppearance.BorderSize = 0;
            this.btnLopHocPhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLopHocPhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLopHocPhan.ForeColor = System.Drawing.Color.White;
            this.btnLopHocPhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLopHocPhan.Location = new System.Drawing.Point(0, 220);
            this.btnLopHocPhan.Margin = new System.Windows.Forms.Padding(4);
            this.btnLopHocPhan.Name = "btnLopHocPhan";
            this.btnLopHocPhan.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnLopHocPhan.Size = new System.Drawing.Size(293, 55);
            this.btnLopHocPhan.TabIndex = 4;
            this.btnLopHocPhan.Text = "Quản Lý Lớp Học Phần";
            this.btnLopHocPhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLopHocPhan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLopHocPhan.UseVisualStyleBackColor = true;
            this.btnLopHocPhan.Click += new System.EventHandler(this.btnLopHocPhan_Click);
            // 
            // btnHocPhan
            // 
            this.btnHocPhan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHocPhan.FlatAppearance.BorderSize = 0;
            this.btnHocPhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocPhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHocPhan.ForeColor = System.Drawing.Color.White;
            this.btnHocPhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhan.Location = new System.Drawing.Point(0, 165);
            this.btnHocPhan.Margin = new System.Windows.Forms.Padding(4);
            this.btnHocPhan.Name = "btnHocPhan";
            this.btnHocPhan.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnHocPhan.Size = new System.Drawing.Size(293, 55);
            this.btnHocPhan.TabIndex = 3;
            this.btnHocPhan.Text = "Quản Lý Học Phần";
            this.btnHocPhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHocPhan.UseVisualStyleBackColor = true;
            this.btnHocPhan.Click += new System.EventHandler(this.btnHocPhan_Click);
            // 
            // btnHocKy
            // 
            this.btnHocKy.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHocKy.FlatAppearance.BorderSize = 0;
            this.btnHocKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHocKy.ForeColor = System.Drawing.Color.White;
            this.btnHocKy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocKy.Location = new System.Drawing.Point(0, 110);
            this.btnHocKy.Margin = new System.Windows.Forms.Padding(4);
            this.btnHocKy.Name = "btnHocKy";
            this.btnHocKy.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnHocKy.Size = new System.Drawing.Size(293, 55);
            this.btnHocKy.TabIndex = 2;
            this.btnHocKy.Text = "Quản Lý Học Kỳ";
            this.btnHocKy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocKy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHocKy.UseVisualStyleBackColor = true;
            this.btnHocKy.Click += new System.EventHandler(this.btnHocKy_Click);
            // 
            // btnNganh
            // 
            this.btnNganh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNganh.FlatAppearance.BorderSize = 0;
            this.btnNganh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNganh.ForeColor = System.Drawing.Color.White;
            this.btnNganh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNganh.Location = new System.Drawing.Point(0, 55);
            this.btnNganh.Margin = new System.Windows.Forms.Padding(4);
            this.btnNganh.Name = "btnNganh";
            this.btnNganh.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnNganh.Size = new System.Drawing.Size(293, 55);
            this.btnNganh.TabIndex = 1;
            this.btnNganh.Text = "Quản Lý Ngành";
            this.btnNganh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNganh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNganh.UseVisualStyleBackColor = true;
            this.btnNganh.Click += new System.EventHandler(this.btnNganh_Click);
            // 
            // btnKhoa
            // 
            this.btnKhoa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhoa.FlatAppearance.BorderSize = 0;
            this.btnKhoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhoa.ForeColor = System.Drawing.Color.White;
            this.btnKhoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhoa.Location = new System.Drawing.Point(0, 0);
            this.btnKhoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnKhoa.Size = new System.Drawing.Size(293, 55);
            this.btnKhoa.TabIndex = 0;
            this.btnKhoa.Text = "Quản Lý Khoa";
            this.btnKhoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKhoa.UseVisualStyleBackColor = true;
            this.btnKhoa.Click += new System.EventHandler(this.btnKhoa_Click);
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
            this.lblAppName.Size = new System.Drawing.Size(343, 39);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "QUẢN LÝ ĐÀO TẠO";
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
            // frmQlyDaoTao
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
            this.Name = "frmQlyDaoTao";
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
        private System.Windows.Forms.Button btnKhoa;
        private System.Windows.Forms.Button btnNganh;
        private System.Windows.Forms.Button btnHocKy;
        private System.Windows.Forms.Button btnHocPhan;
        private System.Windows.Forms.Button btnLopHocPhan;
        private System.Windows.Forms.Button btnDangKyHoc;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem phanHoiToolStripMenuItem;
        private Panel pnHome;
        private PictureBox pictureBoxLogo;
        private Button btnLop;
        private Button btnKeHoachHt;
    }
}