using System.Drawing;
using System.Windows.Forms;

namespace Education_Manager
{
    partial class frmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinNgườiDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoLộiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnNguoiDung = new System.Windows.Forms.Button();
            this.btnThuVien = new System.Windows.Forms.Button();
            this.btnCoSoVC = new System.Windows.Forms.Button();
            this.btnTaiChinh = new System.Windows.Forms.Button();
            this.btnNhanSu = new System.Windows.Forms.Button();
            this.btnSinhVien = new System.Windows.Forms.Button();
            this.btnDaoTao = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pnHome = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.pnHome.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.thôngTinNgườiDToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hệThốngToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.hệThốngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hệThốngToolStripMenuItem.Image")));
            this.hệThốngToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(130, 32);
            this.hệThốngToolStripMenuItem.Text = "Tài Khoản";
            // 
            // thôngTinNgườiDToolStripMenuItem
            // 
            this.thôngTinNgườiDToolStripMenuItem.Name = "thôngTinNgườiDToolStripMenuItem";
            this.thôngTinNgườiDToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.thôngTinNgườiDToolStripMenuItem.Text = "Thông tin người dùng";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hướngDẫnToolStripMenuItem,
            this.thôngTinToolStripMenuItem,
            this.báoCáoLộiToolStripMenuItem});
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
            // thôngTinToolStripMenuItem
            // 
            this.thôngTinToolStripMenuItem.Name = "thôngTinToolStripMenuItem";
            this.thôngTinToolStripMenuItem.Size = new System.Drawing.Size(197, 32);
            this.thôngTinToolStripMenuItem.Text = "Liên hệ";
            // 
            // báoCáoLộiToolStripMenuItem
            // 
            this.báoCáoLộiToolStripMenuItem.Name = "báoCáoLộiToolStripMenuItem";
            this.báoCáoLộiToolStripMenuItem.Size = new System.Drawing.Size(197, 32);
            this.báoCáoLộiToolStripMenuItem.Text = "Phản hồi";
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
            this.panelSidebar.Controls.Add(this.btnNguoiDung);
            this.panelSidebar.Controls.Add(this.btnThuVien);
            this.panelSidebar.Controls.Add(this.btnCoSoVC);
            this.panelSidebar.Controls.Add(this.btnTaiChinh);
            this.panelSidebar.Controls.Add(this.btnNhanSu);
            this.panelSidebar.Controls.Add(this.btnSinhVien);
            this.panelSidebar.Controls.Add(this.btnDaoTao);
            this.panelSidebar.Controls.Add(this.btnHome);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 36);
            this.panelSidebar.Margin = new System.Windows.Forms.Padding(4);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(238, 680);
            this.panelSidebar.TabIndex = 4;
            this.panelSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSidebar_Paint);
            // 
            // btnNguoiDung
            // 
            this.btnNguoiDung.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNguoiDung.FlatAppearance.BorderSize = 0;
            this.btnNguoiDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNguoiDung.ForeColor = System.Drawing.Color.White;
            this.btnNguoiDung.Image = ((System.Drawing.Image)(resources.GetObject("btnNguoiDung.Image")));
            this.btnNguoiDung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNguoiDung.Location = new System.Drawing.Point(0, 385);
            this.btnNguoiDung.Margin = new System.Windows.Forms.Padding(4);
            this.btnNguoiDung.Name = "btnNguoiDung";
            this.btnNguoiDung.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnNguoiDung.Size = new System.Drawing.Size(238, 55);
            this.btnNguoiDung.TabIndex = 9;
            this.btnNguoiDung.Text = "Người Dùng";
            this.btnNguoiDung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNguoiDung.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNguoiDung.UseVisualStyleBackColor = true;
            this.btnNguoiDung.Click += new System.EventHandler(this.btnNguoiDung_Click);
            // 
            // btnThuVien
            // 
            this.btnThuVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThuVien.FlatAppearance.BorderSize = 0;
            this.btnThuVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThuVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThuVien.ForeColor = System.Drawing.Color.White;
            this.btnThuVien.Image = ((System.Drawing.Image)(resources.GetObject("btnThuVien.Image")));
            this.btnThuVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThuVien.Location = new System.Drawing.Point(0, 330);
            this.btnThuVien.Margin = new System.Windows.Forms.Padding(4);
            this.btnThuVien.Name = "btnThuVien";
            this.btnThuVien.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnThuVien.Size = new System.Drawing.Size(238, 55);
            this.btnThuVien.TabIndex = 7;
            this.btnThuVien.Text = "Thư Viện";
            this.btnThuVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThuVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThuVien.UseVisualStyleBackColor = true;
            this.btnThuVien.Click += new System.EventHandler(this.btnThuVien_Click);
            // 
            // btnCoSoVC
            // 
            this.btnCoSoVC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCoSoVC.FlatAppearance.BorderSize = 0;
            this.btnCoSoVC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCoSoVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCoSoVC.ForeColor = System.Drawing.Color.White;
            this.btnCoSoVC.Image = ((System.Drawing.Image)(resources.GetObject("btnCoSoVC.Image")));
            this.btnCoSoVC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCoSoVC.Location = new System.Drawing.Point(0, 275);
            this.btnCoSoVC.Margin = new System.Windows.Forms.Padding(4);
            this.btnCoSoVC.Name = "btnCoSoVC";
            this.btnCoSoVC.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnCoSoVC.Size = new System.Drawing.Size(238, 55);
            this.btnCoSoVC.TabIndex = 5;
            this.btnCoSoVC.Text = "Cơ Sở Vật Chất";
            this.btnCoSoVC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCoSoVC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCoSoVC.UseVisualStyleBackColor = true;
            this.btnCoSoVC.Click += new System.EventHandler(this.btnCoSoVC_Click);
            // 
            // btnTaiChinh
            // 
            this.btnTaiChinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaiChinh.FlatAppearance.BorderSize = 0;
            this.btnTaiChinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiChinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiChinh.ForeColor = System.Drawing.Color.White;
            this.btnTaiChinh.Image = ((System.Drawing.Image)(resources.GetObject("btnTaiChinh.Image")));
            this.btnTaiChinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiChinh.Location = new System.Drawing.Point(0, 220);
            this.btnTaiChinh.Margin = new System.Windows.Forms.Padding(4);
            this.btnTaiChinh.Name = "btnTaiChinh";
            this.btnTaiChinh.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnTaiChinh.Size = new System.Drawing.Size(238, 55);
            this.btnTaiChinh.TabIndex = 4;
            this.btnTaiChinh.Text = "Tài Chính";
            this.btnTaiChinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiChinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaiChinh.UseVisualStyleBackColor = true;
            this.btnTaiChinh.Click += new System.EventHandler(this.btnTaiChinh_Click);
            // 
            // btnNhanSu
            // 
            this.btnNhanSu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhanSu.FlatAppearance.BorderSize = 0;
            this.btnNhanSu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanSu.ForeColor = System.Drawing.Color.White;
            this.btnNhanSu.Image = ((System.Drawing.Image)(resources.GetObject("btnNhanSu.Image")));
            this.btnNhanSu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanSu.Location = new System.Drawing.Point(0, 165);
            this.btnNhanSu.Margin = new System.Windows.Forms.Padding(4);
            this.btnNhanSu.Name = "btnNhanSu";
            this.btnNhanSu.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnNhanSu.Size = new System.Drawing.Size(238, 55);
            this.btnNhanSu.TabIndex = 3;
            this.btnNhanSu.Text = "Nhân Sự";
            this.btnNhanSu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanSu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNhanSu.UseVisualStyleBackColor = true;
            // 
            // btnSinhVien
            // 
            this.btnSinhVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSinhVien.FlatAppearance.BorderSize = 0;
            this.btnSinhVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSinhVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSinhVien.ForeColor = System.Drawing.Color.White;
            this.btnSinhVien.Image = ((System.Drawing.Image)(resources.GetObject("btnSinhVien.Image")));
            this.btnSinhVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSinhVien.Location = new System.Drawing.Point(0, 110);
            this.btnSinhVien.Margin = new System.Windows.Forms.Padding(4);
            this.btnSinhVien.Name = "btnSinhVien";
            this.btnSinhVien.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnSinhVien.Size = new System.Drawing.Size(238, 55);
            this.btnSinhVien.TabIndex = 2;
            this.btnSinhVien.Text = "Sinh Viên";
            this.btnSinhVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSinhVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSinhVien.UseVisualStyleBackColor = true;
            this.btnSinhVien.Click += new System.EventHandler(this.btnSinhVien_Click);
            // 
            // btnDaoTao
            // 
            this.btnDaoTao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDaoTao.FlatAppearance.BorderSize = 0;
            this.btnDaoTao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDaoTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaoTao.ForeColor = System.Drawing.Color.White;
            this.btnDaoTao.Image = ((System.Drawing.Image)(resources.GetObject("btnDaoTao.Image")));
            this.btnDaoTao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDaoTao.Location = new System.Drawing.Point(0, 55);
            this.btnDaoTao.Margin = new System.Windows.Forms.Padding(4);
            this.btnDaoTao.Name = "btnDaoTao";
            this.btnDaoTao.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnDaoTao.Size = new System.Drawing.Size(238, 55);
            this.btnDaoTao.TabIndex = 1;
            this.btnDaoTao.Text = "Đào Tạo";
            this.btnDaoTao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDaoTao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDaoTao.UseVisualStyleBackColor = true;
            this.btnDaoTao.Click += new System.EventHandler(this.btnDaoTao_Click);
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(238, 55);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblHome);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Controls.Add(this.lblAppName);
            this.panelHeader.Controls.Add(this.pictureBoxLogo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(238, 36);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1095, 123);
            this.panelHeader.TabIndex = 5;
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(128)))), ((int)(((byte)(50)))));
            this.lblHome.Location = new System.Drawing.Point(162, 85);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(436, 25);
            this.lblHome.TabIndex = 3;
            this.lblHome.Text = "UNIVERSITY OF TRANSPORT TECHNOLOGY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(128)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(162, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "TRƯỜNG ĐẠI HỌC";
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(128)))), ((int)(((byte)(50)))));
            this.lblAppName.Location = new System.Drawing.Point(160, 39);
            this.lblAppName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(624, 39);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "CÔNG NGHỆ GIAO THÔNG VẬN TẢI";
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
            this.pnHome.Controls.Add(this.tableLayoutPanel1);
            this.pnHome.Controls.Add(this.panel1);
            this.pnHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnHome.Location = new System.Drawing.Point(238, 159);
            this.pnHome.Name = "pnHome";
            this.pnHome.Size = new System.Drawing.Size(1095, 557);
            this.pnHome.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 257F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 838F));
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox6, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 42);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1095, 515);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label18);
            this.panel7.Controls.Add(this.label19);
            this.panel7.Controls.Add(this.label20);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(260, 853);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(832, 164);
            this.panel7.TabIndex = 13;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label18.Location = new System.Drawing.Point(0, 74);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(140, 18);
            this.label18.TabIndex = 2;
            this.label18.Text = "20/09/2025 10:30:33";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label19.Location = new System.Drawing.Point(0, 94);
            this.label19.MaximumSize = new System.Drawing.Size(1440, 70);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(1411, 70);
            this.label19.TabIndex = 1;
            this.label19.Text = resources.GetString("label19.Text");
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Top;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.MaximumSize = new System.Drawing.Size(1440, 100);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(1433, 74);
            this.label20.TabIndex = 0;
            this.label20.Text = "Bế mạc khảo sát chính thức phục vụ đánh giá ngoài CTĐT trình độ thạc sĩ tại Trườn" +
    "g Đại học Công nghệ GTVT";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label15);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Controls.Add(this.label17);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(260, 683);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(832, 164);
            this.panel6.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(0, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 18);
            this.label15.TabIndex = 2;
            this.label15.Text = "23/09/2025 13:04:09";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label16.Location = new System.Drawing.Point(0, 94);
            this.label16.MaximumSize = new System.Drawing.Size(1440, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(1436, 70);
            this.label16.TabIndex = 1;
            this.label16.Text = resources.GetString("label16.Text");
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Top;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(0, 0);
            this.label17.MaximumSize = new System.Drawing.Size(1440, 100);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(1382, 74);
            this.label17.TabIndex = 0;
            this.label17.Text = "UTT có hai nhà khoa học được xếp hạng trong nhóm các nhà khoa học có ảnh hưởng lớ" +
    "n nhất toàn cầu năm 2025";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(260, 513);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(832, 164);
            this.panel5.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(0, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 18);
            this.label12.TabIndex = 2;
            this.label12.Text = "24/09/2025 16:38:34";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label13.Location = new System.Drawing.Point(0, 64);
            this.label13.MaximumSize = new System.Drawing.Size(1440, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(1418, 75);
            this.label13.TabIndex = 1;
            this.label13.Text = resources.GetString("label13.Text");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(1168, 37);
            this.label14.TabIndex = 0;
            this.label14.Text = "UTT ký kết hợp tác với Trường Đại học Xây dựng Quốc gia Moscow (MGSU)";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(260, 343);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(832, 164);
            this.panel4.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(0, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 18);
            this.label9.TabIndex = 2;
            this.label9.Text = "28/09/2025 10:12:12";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(0, 94);
            this.label10.MaximumSize = new System.Drawing.Size(1440, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(1439, 70);
            this.label10.TabIndex = 1;
            this.label10.Text = resources.GetString("label10.Text");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.MaximumSize = new System.Drawing.Size(1440, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1381, 74);
            this.label11.TabIndex = 0;
            this.label11.Text = "Trường Đại học Công nghệ GTVT tổ chức Lễ Khai giảng cao học Khóa 11.1 và Trao bằn" +
    "g Thạc sĩ đợt 2 năm 2025";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(260, 173);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(832, 164);
            this.panel3.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(0, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "28/09/2025 12:09:53";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(0, 64);
            this.label7.MaximumSize = new System.Drawing.Size(1440, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1413, 75);
            this.label7.TabIndex = 1;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.MaximumSize = new System.Drawing.Size(1440, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1431, 74);
            this.label8.TabIndex = 0;
            this.label8.Text = "Trường Đại học Công nghệ GTVT trở thành thành viên Mạng lưới Trung tâm đào tạo xu" +
    "ất sắc và tài năng về năng lượng tái tạo, hydrogen";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(251, 164);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 173);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(251, 164);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(3, 343);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(251, 164);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(3, 513);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(251, 164);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(260, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 164);
            this.panel2.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(0, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "05/10/2025 10:09:13";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(0, 64);
            this.label4.MaximumSize = new System.Drawing.Size(1440, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1412, 50);
            this.label4.TabIndex = 1;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1440, 74);
            this.label3.TabIndex = 0;
            this.label3.Text = "UTT tham gia Hội nghị Trung Quốc (Quảng Tây) – ASEAN và trở thành thành viên Trun" +
    "g tâm \r\nĐổi mới & Hợp tác về AI trong Giao thông vận tải";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(3, 683);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(251, 164);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(3, 853);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(251, 164);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 8;
            this.pictureBox6.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(128)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1095, 42);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tin Tức";
            // 
            // frmHome
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
            this.Name = "frmHome";
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
            this.pnHome.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hướngDẫnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblWelcome;
        private System.Windows.Forms.ToolStripStatusLabel lblDateTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnDaoTao;
        private System.Windows.Forms.Button btnSinhVien;
        private System.Windows.Forms.Button btnNhanSu;
        private System.Windows.Forms.Button btnTaiChinh;
        private System.Windows.Forms.Button btnCoSoVC;
        private System.Windows.Forms.Button btnThuVien;
        private System.Windows.Forms.Button btnNguoiDung;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem báoCáoLộiToolStripMenuItem;
        private ToolStripMenuItem thôngTinNgườiDToolStripMenuItem;
        private Label lblHome;
        private Label label1;
        private Panel pnHome;
        private Panel panel1;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel7;
        private Label label18;
        private Label label19;
        private Label label20;
        private Panel panel6;
        private Label label15;
        private Label label16;
        private Label label17;
        private Panel panel5;
        private Label label12;
        private Label label13;
        private Label label14;
        private Panel panel4;
        private Label label9;
        private Label label10;
        private Label label11;
        private Panel panel3;
        private Label label6;
        private Label label7;
        private Label label8;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Panel panel2;
        private Label label3;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private Label label5;
        private Label label4;
    }
}