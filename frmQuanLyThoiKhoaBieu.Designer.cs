namespace Education_Manager
{
    partial class frmQuanLyThoiKhoaBieu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnXemTKB = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvThoiKhoaBieu = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_lich_hoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_lop_hp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_lop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_hoc_phan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_phong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_phong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiet_bat_dau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.so_tiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiet_ket_thuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ho_ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboSoBuoi = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboPhongHoc = new System.Windows.Forms.ComboBox();
            this.cboSoTiet = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTiet = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbThu = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLopHoc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThemAuto = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThoiKhoaBieu)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(128)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 62);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ THỜI KHÓA BIỂU";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(800, 62);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 676);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThemAuto);
            this.groupBox1.Controls.Add(this.btnLamMoi);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 505);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(400, 171);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(293, 31);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(80, 74);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(200, 31);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 74);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(107, 31);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 74);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(13, 31);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 74);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXemTKB);
            this.groupBox2.Controls.Add(this.txtTimKiem);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(400, 185);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // btnXemTKB
            // 
            this.btnXemTKB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnXemTKB.FlatAppearance.BorderSize = 0;
            this.btnXemTKB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemTKB.ForeColor = System.Drawing.Color.White;
            this.btnXemTKB.Location = new System.Drawing.Point(13, 123);
            this.btnXemTKB.Margin = new System.Windows.Forms.Padding(4);
            this.btnXemTKB.Name = "btnXemTKB";
            this.btnXemTKB.Size = new System.Drawing.Size(373, 37);
            this.btnXemTKB.TabIndex = 3;
            this.btnXemTKB.Text = "Xem thời khóa biểu lớp";
            this.btnXemTKB.UseVisualStyleBackColor = false;
            this.btnXemTKB.Click += new System.EventHandler(this.btnXemTKB_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(13, 62);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(239, 26);
            this.txtTimKiem.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 37);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Nhập tên phòng học";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(267, 49);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(107, 37);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvThoiKhoaBieu);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 62);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 676);
            this.panel3.TabIndex = 2;
            // 
            // dgvThoiKhoaBieu
            // 
            this.dgvThoiKhoaBieu.AllowUserToAddRows = false;
            this.dgvThoiKhoaBieu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvThoiKhoaBieu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvThoiKhoaBieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThoiKhoaBieu.BackgroundColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThoiKhoaBieu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvThoiKhoaBieu.ColumnHeadersHeight = 30;
            this.dgvThoiKhoaBieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.id_lich_hoc,
            this.id_lop_hp,
            this.ten_lop,
            this.ten_hoc_phan,
            this.id_phong,
            this.ten_phong,
            this.thu,
            this.tiet_bat_dau,
            this.so_tiet,
            this.tiet_ket_thuc,
            this.ho_ten});
            this.dgvThoiKhoaBieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThoiKhoaBieu.EnableHeadersVisualStyles = false;
            this.dgvThoiKhoaBieu.Location = new System.Drawing.Point(0, 185);
            this.dgvThoiKhoaBieu.Margin = new System.Windows.Forms.Padding(4);
            this.dgvThoiKhoaBieu.MultiSelect = false;
            this.dgvThoiKhoaBieu.Name = "dgvThoiKhoaBieu";
            this.dgvThoiKhoaBieu.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThoiKhoaBieu.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvThoiKhoaBieu.RowHeadersVisible = false;
            this.dgvThoiKhoaBieu.RowHeadersWidth = 51;
            this.dgvThoiKhoaBieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThoiKhoaBieu.Size = new System.Drawing.Size(800, 491);
            this.dgvThoiKhoaBieu.TabIndex = 1;
            this.dgvThoiKhoaBieu.SelectionChanged += new System.EventHandler(this.dgvThoiKhoaBieu_SelectionChanged);
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // id_lich_hoc
            // 
            this.id_lich_hoc.DataPropertyName = "id_lich_hoc";
            this.id_lich_hoc.HeaderText = "id_lich_hoc";
            this.id_lich_hoc.MinimumWidth = 6;
            this.id_lich_hoc.Name = "id_lich_hoc";
            this.id_lich_hoc.ReadOnly = true;
            this.id_lich_hoc.Visible = false;
            // 
            // id_lop_hp
            // 
            this.id_lop_hp.DataPropertyName = "id_lop_hp";
            this.id_lop_hp.HeaderText = "id_lop_hp";
            this.id_lop_hp.MinimumWidth = 6;
            this.id_lop_hp.Name = "id_lop_hp";
            this.id_lop_hp.ReadOnly = true;
            this.id_lop_hp.Visible = false;
            // 
            // ten_lop
            // 
            this.ten_lop.DataPropertyName = "ten_lop";
            this.ten_lop.HeaderText = "Lớp học phần";
            this.ten_lop.MinimumWidth = 6;
            this.ten_lop.Name = "ten_lop";
            this.ten_lop.ReadOnly = true;
            // 
            // ten_hoc_phan
            // 
            this.ten_hoc_phan.DataPropertyName = "ten_hoc_phan";
            this.ten_hoc_phan.HeaderText = "Học phần";
            this.ten_hoc_phan.MinimumWidth = 6;
            this.ten_hoc_phan.Name = "ten_hoc_phan";
            this.ten_hoc_phan.ReadOnly = true;
            // 
            // id_phong
            // 
            this.id_phong.DataPropertyName = "id_phong";
            this.id_phong.HeaderText = "id_phong";
            this.id_phong.MinimumWidth = 6;
            this.id_phong.Name = "id_phong";
            this.id_phong.ReadOnly = true;
            this.id_phong.Visible = false;
            // 
            // ten_phong
            // 
            this.ten_phong.DataPropertyName = "ten_phong";
            this.ten_phong.HeaderText = "Phòng";
            this.ten_phong.MinimumWidth = 6;
            this.ten_phong.Name = "ten_phong";
            this.ten_phong.ReadOnly = true;
            // 
            // thu
            // 
            this.thu.DataPropertyName = "thu";
            this.thu.HeaderText = "Thứ";
            this.thu.MinimumWidth = 6;
            this.thu.Name = "thu";
            this.thu.ReadOnly = true;
            // 
            // tiet_bat_dau
            // 
            this.tiet_bat_dau.DataPropertyName = "tiet_bat_dau";
            this.tiet_bat_dau.HeaderText = "Tiết bắt đầu";
            this.tiet_bat_dau.MinimumWidth = 6;
            this.tiet_bat_dau.Name = "tiet_bat_dau";
            this.tiet_bat_dau.ReadOnly = true;
            // 
            // so_tiet
            // 
            this.so_tiet.DataPropertyName = "so_tiet";
            this.so_tiet.HeaderText = "so_tiet";
            this.so_tiet.MinimumWidth = 6;
            this.so_tiet.Name = "so_tiet";
            this.so_tiet.ReadOnly = true;
            this.so_tiet.Visible = false;
            // 
            // tiet_ket_thuc
            // 
            this.tiet_ket_thuc.DataPropertyName = "tiet_ket_thuc";
            this.tiet_ket_thuc.HeaderText = "Tiết kết thúc";
            this.tiet_ket_thuc.MinimumWidth = 6;
            this.tiet_ket_thuc.Name = "tiet_ket_thuc";
            this.tiet_ket_thuc.ReadOnly = true;
            // 
            // ho_ten
            // 
            this.ho_ten.DataPropertyName = "ho_ten";
            this.ho_ten.HeaderText = "Giảng viên";
            this.ho_ten.MinimumWidth = 6;
            this.ho_ten.Name = "ho_ten";
            this.ho_ten.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboSoBuoi);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cboPhongHoc);
            this.groupBox3.Controls.Add(this.cboSoTiet);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbTiet);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cbThu);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cbLopHoc);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(800, 185);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin thời khóa biểu";
            // 
            // cboSoBuoi
            // 
            this.cboSoBuoi.FormattingEnabled = true;
            this.cboSoBuoi.Location = new System.Drawing.Point(400, 112);
            this.cboSoBuoi.Margin = new System.Windows.Forms.Padding(4);
            this.cboSoBuoi.Name = "cboSoBuoi";
            this.cboSoBuoi.Size = new System.Drawing.Size(115, 28);
            this.cboSoBuoi.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(400, 87);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Số buổi/tuần";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 87);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Phòng học:";
            // 
            // cboPhongHoc
            // 
            this.cboPhongHoc.FormattingEnabled = true;
            this.cboPhongHoc.Location = new System.Drawing.Point(27, 111);
            this.cboPhongHoc.Margin = new System.Windows.Forms.Padding(4);
            this.cboPhongHoc.Name = "cboPhongHoc";
            this.cboPhongHoc.Size = new System.Drawing.Size(172, 28);
            this.cboPhongHoc.TabIndex = 9;
            // 
            // cboSoTiet
            // 
            this.cboSoTiet.FormattingEnabled = true;
            this.cboSoTiet.Location = new System.Drawing.Point(600, 112);
            this.cboSoTiet.Margin = new System.Windows.Forms.Padding(4);
            this.cboSoTiet.Name = "cboSoTiet";
            this.cboSoTiet.Size = new System.Drawing.Size(115, 28);
            this.cboSoTiet.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(600, 87);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Số tiết:";
            // 
            // cbTiet
            // 
            this.cbTiet.FormattingEnabled = true;
            this.cbTiet.Location = new System.Drawing.Point(600, 49);
            this.cbTiet.Margin = new System.Windows.Forms.Padding(4);
            this.cbTiet.Name = "cbTiet";
            this.cbTiet.Size = new System.Drawing.Size(172, 28);
            this.cbTiet.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(600, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tiết bắt đầu";
            // 
            // cbThu
            // 
            this.cbThu.FormattingEnabled = true;
            this.cbThu.Location = new System.Drawing.Point(400, 49);
            this.cbThu.Margin = new System.Windows.Forms.Padding(4);
            this.cbThu.Name = "cbThu";
            this.cbThu.Size = new System.Drawing.Size(172, 28);
            this.cbThu.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thứ:";
            // 
            // cbLopHoc
            // 
            this.cbLopHoc.FormattingEnabled = true;
            this.cbLopHoc.Location = new System.Drawing.Point(27, 49);
            this.cbLopHoc.Margin = new System.Windows.Forms.Padding(4);
            this.cbLopHoc.Name = "cbLopHoc";
            this.cbLopHoc.Size = new System.Drawing.Size(332, 28);
            this.cbLopHoc.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lớp học:";
            // 
            // btnThemAuto
            // 
            this.btnThemAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThemAuto.FlatAppearance.BorderSize = 0;
            this.btnThemAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemAuto.ForeColor = System.Drawing.Color.White;
            this.btnThemAuto.Location = new System.Drawing.Point(13, 121);
            this.btnThemAuto.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemAuto.Name = "btnThemAuto";
            this.btnThemAuto.Size = new System.Drawing.Size(373, 37);
            this.btnThemAuto.TabIndex = 4;
            this.btnThemAuto.Text = "Tạo Lịch Tự Động";
            this.btnThemAuto.UseVisualStyleBackColor = false;
            this.btnThemAuto.Click += new System.EventHandler(this.btnThemAuto_Click);
            // 
            // frmQuanLyThoiKhoaBieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 738);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQuanLyThoiKhoaBieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Thời khóa biểu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThoiKhoaBieu)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvThoiKhoaBieu;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboPhongHoc;
        private System.Windows.Forms.ComboBox cboSoTiet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTiet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbThu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLopHoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnXemTKB;
        private System.Windows.Forms.ComboBox cboSoBuoi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_lich_hoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_lop_hp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_lop;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_hoc_phan;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_phong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_phong;
        private System.Windows.Forms.DataGridViewTextBoxColumn thu;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiet_bat_dau;
        private System.Windows.Forms.DataGridViewTextBoxColumn so_tiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiet_ket_thuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ho_ten;
        private System.Windows.Forms.Button btnThemAuto;
    }
}