namespace Education_Manager
{
    partial class frmDangKyHoc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvLopHp = new System.Windows.Forms.DataGridView();
            this.ten_lop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_hoc_phan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.so_luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ho_ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_hoc_ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngay_ket_thuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trang_thai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dang_ky = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(128)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1418, 83);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐĂNG KÝ HỌC";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtMaSV);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(1047, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 655);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(50, 574);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(261, 46);
            this.button2.TabIndex = 3;
            this.button2.Text = "Xác nhân đăng ký";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(62, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(261, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "Xem danh sách lớp";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(26, 59);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(313, 27);
            this.txtMaSV.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhập tên học phần";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvLopHp);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1047, 655);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Lớp Học Phần ";
            // 
            // dgvLopHp
            // 
            this.dgvLopHp.AllowUserToAddRows = false;
            this.dgvLopHp.AllowUserToDeleteRows = false;
            this.dgvLopHp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLopHp.BackgroundColor = System.Drawing.Color.White;
            this.dgvLopHp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLopHp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ten_lop,
            this.ten_hoc_phan,
            this.so_luong,
            this.ho_ten,
            this.ten_hoc_ky,
            this.ngay_ket_thuc,
            this.trang_thai,
            this.dang_ky});
            this.dgvLopHp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLopHp.GridColor = System.Drawing.Color.White;
            this.dgvLopHp.Location = new System.Drawing.Point(3, 23);
            this.dgvLopHp.MultiSelect = false;
            this.dgvLopHp.Name = "dgvLopHp";
            this.dgvLopHp.RowHeadersVisible = false;
            this.dgvLopHp.RowHeadersWidth = 51;
            this.dgvLopHp.RowTemplate.Height = 24;
            this.dgvLopHp.Size = new System.Drawing.Size(1041, 629);
            this.dgvLopHp.TabIndex = 0;
            // 
            // ten_lop
            // 
            this.ten_lop.DataPropertyName = "ten_lop";
            this.ten_lop.HeaderText = "Lớp Học Phần";
            this.ten_lop.MinimumWidth = 6;
            this.ten_lop.Name = "ten_lop";
            // 
            // ten_hoc_phan
            // 
            this.ten_hoc_phan.DataPropertyName = "ten_hoc_phan";
            this.ten_hoc_phan.HeaderText = "Học Phần";
            this.ten_hoc_phan.MinimumWidth = 6;
            this.ten_hoc_phan.Name = "ten_hoc_phan";
            // 
            // so_luong
            // 
            this.so_luong.DataPropertyName = "so_luong";
            this.so_luong.HeaderText = "Số Sinh Viên";
            this.so_luong.MinimumWidth = 6;
            this.so_luong.Name = "so_luong";
            // 
            // ho_ten
            // 
            this.ho_ten.DataPropertyName = "ho_ten";
            this.ho_ten.HeaderText = "Giảng Viên";
            this.ho_ten.MinimumWidth = 6;
            this.ho_ten.Name = "ho_ten";
            // 
            // ten_hoc_ky
            // 
            this.ten_hoc_ky.DataPropertyName = "ten_hoc_ky";
            this.ten_hoc_ky.HeaderText = "Học Kỳ";
            this.ten_hoc_ky.MinimumWidth = 6;
            this.ten_hoc_ky.Name = "ten_hoc_ky";
            // 
            // ngay_ket_thuc
            // 
            this.ngay_ket_thuc.DataPropertyName = "ngay_ket_thuc";
            this.ngay_ket_thuc.HeaderText = "Ngày Kết Thúc";
            this.ngay_ket_thuc.MinimumWidth = 6;
            this.ngay_ket_thuc.Name = "ngay_ket_thuc";
            // 
            // trang_thai
            // 
            this.trang_thai.DataPropertyName = "trang_thai";
            this.trang_thai.HeaderText = "Trạng Thái";
            this.trang_thai.MinimumWidth = 6;
            this.trang_thai.Name = "trang_thai";
            // 
            // dang_ky
            // 
            this.dang_ky.DataPropertyName = "dang_ky";
            this.dang_ky.HeaderText = "Đăng Ký";
            this.dang_ky.MinimumWidth = 6;
            this.dang_ky.Name = "dang_ky";
            // 
            // frmDangKyHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 738);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDangKyHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Xem lịch cá nhân";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvLopHp;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_lop;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_hoc_phan;
        private System.Windows.Forms.DataGridViewTextBoxColumn so_luong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ho_ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_hoc_ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngay_ket_thuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn trang_thai;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dang_ky;
    }
}