using System.Drawing;
using System.Windows.Forms;

namespace Education_Manager
{
    partial class frmQlyNhanSu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQlyNhanSu));
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
            this.btnLuongCheDo = new System.Windows.Forms.Button();
            this.btnDaoTaoBoiDuong = new System.Windows.Forms.Button();
            this.btnKhenThuongKyLuat = new System.Windows.Forms.Button();
            this.btnChamCong = new System.Windows.Forms.Button();
            this.btnNghiHuu = new System.Windows.Forms.Button();
            this.btnNghiViec = new System.Windows.Forms.Button();
            this.btnHopDong = new System.Windows.Forms.Button();
            this.btnNhanSu = new System.Windows.Forms.Button();
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
            this.menuStrip1.Size = new System.Drawing.Size(1333, 29);
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
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(113, 25);
            this.hệThốngToolStripMenuItem.Text = "Trang Chủ";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
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
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(100, 25);
            this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // hướngDẫnToolStripMenuItem
            // 
            this.hướngDẫnToolStripMenuItem.Name = "hướngDẫnToolStripMenuItem";
            this.hướngDẫnToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.hướngDẫnToolStripMenuItem.Text = "Hướng dẫn";
            // 
            // lienHeToolStripMenuItem
            // 
            this.lienHeToolStripMenuItem.Name = "lienHeToolStripMenuItem";
            this.lienHeToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.lienHeToolStripMenuItem.Text = "Liên hệ";
            // 
            // phanHoiToolStripMenuItem
            // 
            this.phanHoiToolStripMenuItem.Name = "phanHoiToolStripMenuItem";
            this.phanHoiToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
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
            this.lblWelcome.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(128)))), ((int)(((byte)(50)))));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1313, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // lblDateTime
            // 
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panelSidebar.Controls.Add(this.btnLuongCheDo);
            this.panelSidebar.Controls.Add(this.btnDaoTaoBoiDuong);
            this.panelSidebar.Controls.Add(this.btnKhenThuongKyLuat);
            this.panelSidebar.Controls.Add(this.btnChamCong);
            this.panelSidebar.Controls.Add(this.btnNghiHuu);
            this.panelSidebar.Controls.Add(this.btnNghiViec);
            this.panelSidebar.Controls.Add(this.btnHopDong);
            this.panelSidebar.Controls.Add(this.btnNhanSu);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 29);
            this.panelSidebar.Margin = new System.Windows.Forms.Padding(4);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(293, 687);
            this.panelSidebar.TabIndex = 4;
            this.panelSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSidebar_Paint);
            // 
            // btnLuongCheDo
            // 
            this.btnLuongCheDo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLuongCheDo.FlatAppearance.BorderSize = 0;
            this.btnLuongCheDo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuongCheDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuongCheDo.ForeColor = System.Drawing.Color.White;
            this.btnLuongCheDo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuongCheDo.Location = new System.Drawing.Point(0, 385);
            this.btnLuongCheDo.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuongCheDo.Name = "btnLuongCheDo";
            this.btnLuongCheDo.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnLuongCheDo.Size = new System.Drawing.Size(293, 55);
            this.btnLuongCheDo.TabIndex = 7;
            this.btnLuongCheDo.Text = "Lương Chế Độ";
            this.btnLuongCheDo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuongCheDo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuongCheDo.UseVisualStyleBackColor = true;
            this.btnLuongCheDo.Click += new System.EventHandler(this.btnLuongCheDo_Click);
            // 
            // btnDaoTaoBoiDuong
            // 
            this.btnDaoTaoBoiDuong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDaoTaoBoiDuong.FlatAppearance.BorderSize = 0;
            this.btnDaoTaoBoiDuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDaoTaoBoiDuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaoTaoBoiDuong.ForeColor = System.Drawing.Color.White;
            this.btnDaoTaoBoiDuong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDaoTaoBoiDuong.Location = new System.Drawing.Point(0, 330);
            this.btnDaoTaoBoiDuong.Margin = new System.Windows.Forms.Padding(4);
            this.btnDaoTaoBoiDuong.Name = "btnDaoTaoBoiDuong";
            this.btnDaoTaoBoiDuong.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnDaoTaoBoiDuong.Size = new System.Drawing.Size(293, 55);
            this.btnDaoTaoBoiDuong.TabIndex = 6;
            this.btnDaoTaoBoiDuong.Text = "Đào Tạo Bồi Dưỡng";
            this.btnDaoTaoBoiDuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDaoTaoBoiDuong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDaoTaoBoiDuong.UseVisualStyleBackColor = true;
            this.btnDaoTaoBoiDuong.Click += new System.EventHandler(this.btnDaoTaoBoiDuong_Click);
            // 
            // btnKhenThuongKyLuat
            // 
            this.btnKhenThuongKyLuat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhenThuongKyLuat.FlatAppearance.BorderSize = 0;
            this.btnKhenThuongKyLuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhenThuongKyLuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhenThuongKyLuat.ForeColor = System.Drawing.Color.White;
            this.btnKhenThuongKyLuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhenThuongKyLuat.Location = new System.Drawing.Point(0, 275);
            this.btnKhenThuongKyLuat.Margin = new System.Windows.Forms.Padding(4);
            this.btnKhenThuongKyLuat.Name = "btnKhenThuongKyLuat";
            this.btnKhenThuongKyLuat.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnKhenThuongKyLuat.Size = new System.Drawing.Size(293, 55);
            this.btnKhenThuongKyLuat.TabIndex = 5;
            this.btnKhenThuongKyLuat.Text = "Khen Thưởng Kỷ Luật";
            this.btnKhenThuongKyLuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhenThuongKyLuat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKhenThuongKyLuat.UseVisualStyleBackColor = true;
            this.btnKhenThuongKyLuat.Click += new System.EventHandler(this.btnKhenThuongKyLuat_Click);
            // 
            // btnChamCong
            // 
            this.btnChamCong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChamCong.FlatAppearance.BorderSize = 0;
            this.btnChamCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChamCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChamCong.ForeColor = System.Drawing.Color.White;
            this.btnChamCong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChamCong.Location = new System.Drawing.Point(0, 220);
            this.btnChamCong.Margin = new System.Windows.Forms.Padding(4);
            this.btnChamCong.Name = "btnChamCong";
            this.btnChamCong.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnChamCong.Size = new System.Drawing.Size(293, 55);
            this.btnChamCong.TabIndex = 4;
            this.btnChamCong.Text = "Chấm Công";
            this.btnChamCong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChamCong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChamCong.UseVisualStyleBackColor = true;
            this.btnChamCong.Click += new System.EventHandler(this.btnChamCong_Click);
            // 
            // btnNghiHuu
            // 
            this.btnNghiHuu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNghiHuu.FlatAppearance.BorderSize = 0;
            this.btnNghiHuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNghiHuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNghiHuu.ForeColor = System.Drawing.Color.White;
            this.btnNghiHuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNghiHuu.Location = new System.Drawing.Point(0, 165);
            this.btnNghiHuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnNghiHuu.Name = "btnNghiHuu";
            this.btnNghiHuu.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnNghiHuu.Size = new System.Drawing.Size(293, 55);
            this.btnNghiHuu.TabIndex = 3;
            this.btnNghiHuu.Text = "Nghỉ Hưu";
            this.btnNghiHuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNghiHuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNghiHuu.UseVisualStyleBackColor = true;
            this.btnNghiHuu.Click += new System.EventHandler(this.btnNghiHuu_Click);
            // 
            // btnNghiViec
            // 
            this.btnNghiViec.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNghiViec.FlatAppearance.BorderSize = 0;
            this.btnNghiViec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNghiViec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNghiViec.ForeColor = System.Drawing.Color.White;
            this.btnNghiViec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNghiViec.Location = new System.Drawing.Point(0, 110);
            this.btnNghiViec.Margin = new System.Windows.Forms.Padding(4);
            this.btnNghiViec.Name = "btnNghiViec";
            this.btnNghiViec.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnNghiViec.Size = new System.Drawing.Size(293, 55);
            this.btnNghiViec.TabIndex = 2;
            this.btnNghiViec.Text = "Nghỉ Việc";
            this.btnNghiViec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNghiViec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNghiViec.UseVisualStyleBackColor = true;
            this.btnNghiViec.Click += new System.EventHandler(this.btnNghiViec_Click);
            // 
            // btnHopDong
            // 
            this.btnHopDong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHopDong.FlatAppearance.BorderSize = 0;
            this.btnHopDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHopDong.ForeColor = System.Drawing.Color.White;
            this.btnHopDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHopDong.Location = new System.Drawing.Point(0, 55);
            this.btnHopDong.Margin = new System.Windows.Forms.Padding(4);
            this.btnHopDong.Name = "btnHopDong";
            this.btnHopDong.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnHopDong.Size = new System.Drawing.Size(293, 55);
            this.btnHopDong.TabIndex = 1;
            this.btnHopDong.Text = "Hợp đồng";
            this.btnHopDong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHopDong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHopDong.UseVisualStyleBackColor = true;
            this.btnHopDong.Click += new System.EventHandler(this.btnHopDong_Click);
            // 
            // btnNhanSu
            // 
            this.btnNhanSu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhanSu.FlatAppearance.BorderSize = 0;
            this.btnNhanSu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanSu.ForeColor = System.Drawing.Color.White;
            this.btnNhanSu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanSu.Location = new System.Drawing.Point(0, 0);
            this.btnNhanSu.Margin = new System.Windows.Forms.Padding(4);
            this.btnNhanSu.Name = "btnNhanSu";
            this.btnNhanSu.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnNhanSu.Size = new System.Drawing.Size(293, 55);
            this.btnNhanSu.TabIndex = 0;
            this.btnNhanSu.Text = "Nhân Sự";
            this.btnNhanSu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanSu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNhanSu.UseVisualStyleBackColor = true;
            this.btnNhanSu.Click += new System.EventHandler(this.btnNhanSu_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblAppName);
            this.panelHeader.Controls.Add(this.pictureBoxLogo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(293, 29);
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
            this.lblAppName.Size = new System.Drawing.Size(277, 31);
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
            this.pnHome.Location = new System.Drawing.Point(293, 152);
            this.pnHome.Name = "pnHome";
            this.pnHome.Size = new System.Drawing.Size(1040, 564);
            this.pnHome.TabIndex = 9;
            // 
            // frmQlyNhanSu
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
            this.Name = "frmQlyNhanSu";
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
        private System.Windows.Forms.Button btnNhanSu;
        private System.Windows.Forms.Button btnHopDong;
        private System.Windows.Forms.Button btnNghiViec;
        private System.Windows.Forms.Button btnNghiHuu;
        private System.Windows.Forms.Button btnChamCong;
        private System.Windows.Forms.Button btnKhenThuongKyLuat;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem phanHoiToolStripMenuItem;
        private Panel pnHome;
        private PictureBox pictureBoxLogo;
        private Button btnDaoTaoBoiDuong;
        private Button btnLuongCheDo;
    }
}