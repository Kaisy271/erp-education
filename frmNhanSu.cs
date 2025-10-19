using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmNhanSu : Form
    {

        public frmNhanSu()
        {
            InitializeComponent();
            this.Text = "Quản lý Thông tin Nhân sự";
            LoadComboBox();
            LoadNhanSu();
        }

        private void LoadComboBox()
        {
            try
            {
                // 🔹 Load danh sách lớp
                string queryNguoiDung = "SELECT id_nguoi_dung, tai_khoan FROM Nguoi_dung";
                cbMaND.DataSource = DatabaseNhanSuHelper.ExecuteQuery(queryNguoiDung);
                cbMaND.DisplayMember = "tai_khoan";
                cbMaND.ValueMember = "id_nguoi_dung";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ComboBox: " + ex.Message);
            }
        }
        private void LoadNhanSu()
        {
            try
            {
                // Truy vấn dữ liệu nhân sự, chuyển giới tính sang Nam/Nữ
                string query = @"
            SELECT ns.id_nhan_su,
                   ns.id_nguoi_dung,
                   ns.ho_ten,
                   ns.ngay_sinh,
                   CASE WHEN ns.gioi_tinh = 1 THEN N'Nam' ELSE N'Nữ' END AS gioi_tinh,
                   ns.dia_chi,
                   ns.sdt,
                   ns.email,
                   ns.trinh_do,
                   ns.chung_chi,
                   ns.loai_nhan_su,
                   ns.so_cmnd,
                   ns.que_quan
            FROM Nhan_su ns
            ORDER BY ns.id_nhan_su";

                DataTable dt = DatabaseNhanSuHelper.ExecuteQuery(query);

                if (dt == null)
                {
                    dgvNhanSu.DataSource = null;
                    return;
                }

                // Gán dữ liệu cho DataGridView
                dgvNhanSu.DataSource = dt;

                // Định dạng hiển thị cột
                if (dgvNhanSu.Columns.Contains("ngay_sinh"))
                {
                    dgvNhanSu.Columns["ngay_sinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvNhanSu.Columns["ngay_sinh"].HeaderText = "Ngày sinh";
                }

                if (dgvNhanSu.Columns.Contains("id_nhan_su"))
                    dgvNhanSu.Columns["id_nhan_su"].HeaderText = "Mã nhân sự";

                if (dgvNhanSu.Columns.Contains("id_nguoi_dung"))
                    dgvNhanSu.Columns["id_nguoi_dung"].HeaderText = "Mã người dùng";

                if (dgvNhanSu.Columns.Contains("ho_ten"))
                    dgvNhanSu.Columns["ho_ten"].HeaderText = "Họ tên";

                if (dgvNhanSu.Columns.Contains("gioi_tinh"))
                    dgvNhanSu.Columns["gioi_tinh"].HeaderText = "Giới tính";

                if (dgvNhanSu.Columns.Contains("dia_chi"))
                    dgvNhanSu.Columns["dia_chi"].HeaderText = "Địa chỉ";

                if (dgvNhanSu.Columns.Contains("sdt"))
                    dgvNhanSu.Columns["sdt"].HeaderText = "Số điện thoại";

                if (dgvNhanSu.Columns.Contains("email"))
                    dgvNhanSu.Columns["email"].HeaderText = "Email";

                if (dgvNhanSu.Columns.Contains("trinh_do"))
                    dgvNhanSu.Columns["trinh_do"].HeaderText = "Trình độ";

                if (dgvNhanSu.Columns.Contains("chung_chi"))
                    dgvNhanSu.Columns["chung_chi"].HeaderText = "Chứng chỉ";

                if (dgvNhanSu.Columns.Contains("loai_nhan_su"))
                    dgvNhanSu.Columns["loai_nhan_su"].HeaderText = "Loại nhân sự";

                if (dgvNhanSu.Columns.Contains("so_cmnd"))
                    dgvNhanSu.Columns["so_cmnd"].HeaderText = "Số CMND";

                if (dgvNhanSu.Columns.Contains("que_quan"))
                    dgvNhanSu.Columns["que_quan"].HeaderText = "Quê quán";

                // Ẩn id_nguoi_dung nếu không cần hiển thị
                // dgvNhanSu.Columns["id_nguoi_dung"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadNhanSu: " + ex.Message);
            }
        }


        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtMaNS.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân sự!", "Cảnh báo");
                txtMaNS.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Cảnh báo");
                txtHoTen.Focus();
                return false;
            }

            if (dtpNgaySinh.Value == null)
            {
                MessageBox.Show("Vui lòng chọn ngày sinh!", "Cảnh báo");
                dtpNgaySinh.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!", "Cảnh báo");
                txtDiaChi.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Cảnh báo");
                txtSDT.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Cảnh báo");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoCMND.Text))
            {
                MessageBox.Show("Vui lòng nhập số CMND!", "Cảnh báo");
                txtSoCMND.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtQueQuan.Text))
            {
                MessageBox.Show("Vui lòng nhập quê quán!", "Cảnh báo");
                txtQueQuan.Focus();
                return false;
            }

            return true;
        }

        private bool IsDuplicate(SqlConnection conn, string email, string soCmnd, string excludeId = null)
        {
            string query = @"
        SELECT COUNT(*) 
        FROM Nhan_su 
        WHERE (email = @Email OR so_cmnd = @SoCMND)
        " + (excludeId != null ? "AND id_nhan_su <> @ExcludeId" : "");

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@SoCMND", soCmnd);
                if (excludeId != null)
                    cmd.Parameters.AddWithValue("@ExcludeId", excludeId);

                int count = (int)cmd.ExecuteScalar();
                return count > 0; // true = có trùng
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateData()) return;

                using (SqlConnection conn = DatabaseNhanSuHelper.GetConnection())
                {
                    conn.Open();

                    // Kiểm tra trùng email hoặc số CMND
                    if (IsDuplicate(conn, txtEmail.Text.Trim(), txtSoCMND.Text.Trim()))
                    {
                        MessageBox.Show("Email hoặc số CMND đã tồn tại trong hệ thống!", "Cảnh báo");
                        return;
                    }


                    // 🔹 Tạo id_nhan_su mới (NS001, NS002, ...)
                    string newNhanSuId = GenerateNewId(conn, null, "Nhan_su", "id_nhan_su", "NS");

                    string insertNhanSu = @"
                INSERT INTO Nhan_su
                (id_nhan_su, id_nguoi_dung, ho_ten, ngay_sinh, gioi_tinh, 
                 dia_chi, sdt, email, trinh_do, chung_chi, 
                 loai_nhan_su, so_cmnd, que_quan)
                VALUES
                (@id_nhan_su, @id_nguoi_dung, @ho_ten, @ngay_sinh, @gioi_tinh, 
                 @dia_chi, @sdt, @email, @trinh_do, @chung_chi, 
                 @loai_nhan_su, @so_cmnd, @que_quan)";

                    using (SqlCommand cmd = new SqlCommand(insertNhanSu, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_nhan_su", newNhanSuId);
                        cmd.Parameters.AddWithValue("@id_nguoi_dung", cbMaND.SelectedValue);
                        cmd.Parameters.AddWithValue("@ho_ten", txtHoTen.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngay_sinh", dtpNgaySinh.Value);
                        cmd.Parameters.AddWithValue("@gioi_tinh", rbNam.Checked ? 1 : 0);
                        cmd.Parameters.AddWithValue("@dia_chi", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@sdt", txtSDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@trinh_do", txtTrinhDo.Text.Trim());
                        cmd.Parameters.AddWithValue("@chung_chi", txtChungChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@loai_nhan_su", txtLoaiNS.Text.Trim());
                        cmd.Parameters.AddWithValue("@so_cmnd", txtSoCMND.Text.Trim());
                        cmd.Parameters.AddWithValue("@que_quan", txtQueQuan.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm nhân sự thành công!", "Thông báo");
                    LoadNhanSu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nhân sự: " + ex.Message, "Lỗi");
            }
        }


        private string GenerateNewId(SqlConnection conn, SqlTransaction tran, string tableName, string columnName, string prefix)
        {
            string query = $@"
        SELECT TOP 1 {columnName}
        FROM {tableName}
        WHERE {columnName} LIKE @prefix + '%'
        ORDER BY {columnName} DESC";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (tran != null)
                    cmd.Transaction = tran;

                cmd.Parameters.AddWithValue("@prefix", prefix);

                object result = cmd.ExecuteScalar();
                int nextNumber = 1;

                if (result != null && result != DBNull.Value)
                {
                    string lastId = result.ToString();

                    // Chỉ xử lý phần số phía sau prefix (nếu có)
                    string numberPart = lastId.Length > prefix.Length
                        ? lastId.Substring(prefix.Length)
                        : "0";

                    if (int.TryParse(numberPart, out int num))
                        nextNumber = num + 1;
                }

                // D3 => 001, 002, 003
                return $"{prefix}{nextNumber:D3}";
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNS.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân sự cần sửa!", "Cảnh báo");
                    return;
                }

                if (!ValidateData()) return;

                using (SqlConnection conn = DatabaseNhanSuHelper.GetConnection())
                {
                    conn.Open();

                    // Kiểm tra trùng email hoặc số CMND (bỏ qua chính mình)
                    if (IsDuplicate(conn, txtEmail.Text.Trim(), txtSoCMND.Text.Trim(), txtMaNS.Text.Trim()))
                    {
                        MessageBox.Show("Email hoặc số CMND đã tồn tại ở nhân sự khác!", "Cảnh báo");
                        return;
                    }


                    string updateQuery = @"
                UPDATE Nhan_su
                SET id_nguoi_dung = @id_nguoi_dung,
                    ho_ten = @ho_ten,
                    ngay_sinh = @ngay_sinh,
                    gioi_tinh = @gioi_tinh,
                    dia_chi = @dia_chi,
                    sdt = @sdt,
                    email = @email,
                    trinh_do = @trinh_do,
                    chung_chi = @chung_chi,
                    loai_nhan_su = @loai_nhan_su,
                    so_cmnd = @so_cmnd,
                    que_quan = @que_quan
                WHERE id_nhan_su = @id_nhan_su";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_nhan_su", txtMaNS.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_nguoi_dung", cbMaND.SelectedValue);
                        cmd.Parameters.AddWithValue("@ho_ten", txtHoTen.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngay_sinh", dtpNgaySinh.Value);
                        cmd.Parameters.AddWithValue("@gioi_tinh", rbNam.Checked ? 1 : 0);
                        cmd.Parameters.AddWithValue("@dia_chi", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@sdt", txtSDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@trinh_do", txtTrinhDo.Text.Trim());
                        cmd.Parameters.AddWithValue("@chung_chi", txtChungChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@loai_nhan_su", txtLoaiNS.Text.Trim());
                        cmd.Parameters.AddWithValue("@so_cmnd", txtSoCMND.Text.Trim());
                        cmd.Parameters.AddWithValue("@que_quan", txtQueQuan.Text.Trim());

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Cập nhật nhân sự thành công!", "Thông báo");
                            LoadNhanSu();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân sự cần sửa!", "Thông báo");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa nhân sự: " + ex.Message, "Lỗi");
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNS.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM Sinh_vien WHERE id_sinh_vien=@id_sinh_vien";
                SqlParameter[] p = { new SqlParameter("@id_sinh_vien", txtMaNS.Text) };

                if (DatabaseNhanSuHelper.ExecuteNonQuery(query, p) > 0)
                {
                    MessageBox.Show("Xóa sinh viên thành công!");
                    LoadNhanSu();
                    ClearFields();
                }
            }
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
        SELECT * 
        FROM Nhan_su
        WHERE id_nhan_su LIKE @kw
           OR id_nguoi_dung LIKE @kw
           OR ho_ten LIKE @kw
           OR sdt LIKE @kw
           OR email LIKE @kw";

            SqlParameter[] parameters = { new SqlParameter("@kw", "%" + keyword + "%") };

            dgvNhanSu.DataSource = DatabaseNhanSuHelper.ExecuteQuery(query, parameters);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadNhanSu();
        }

        private void ClearFields()
        {
            txtMaNS.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtTrinhDo.Clear();
            txtChungChi.Clear();
            txtLoaiNS.Clear();
            txtSoCMND.Clear();
            txtQueQuan.Clear();

            if (cbMaND.Items.Count > 0)
                cbMaND.SelectedIndex = 0;

            rbNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Now;
        }


        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void frmQuanLyHocSinh_Load(object sender, EventArgs e)
        {

        }

    
        private void dgvHocSinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dgvNhanSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvNhanSu.Rows[e.RowIndex];

            txtMaNS.Text = row.Cells["id_nhan_su"].Value?.ToString() ?? "";
            cbMaND.SelectedValue = row.Cells["id_nguoi_dung"].Value?.ToString() ?? "";
            txtHoTen.Text = row.Cells["ho_ten"].Value?.ToString() ?? "";

            var nsVal = row.Cells["ngay_sinh"].Value;
            if (nsVal != null && nsVal != DBNull.Value && DateTime.TryParse(nsVal.ToString(), out DateTime ns))
                dtpNgaySinh.Value = ns;
            else
                dtpNgaySinh.Value = DateTime.Now;

            string gt = row.Cells["gioi_tinh"].Value?.ToString() ?? "";
            rbNam.Checked = gt == "1" || gt.ToLower() == "nam";
            rbNu.Checked = gt == "0" || gt.ToLower() == "nữ";

            txtDiaChi.Text = row.Cells["dia_chi"].Value?.ToString() ?? "";
            txtSDT.Text = row.Cells["sdt"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["email"].Value?.ToString() ?? "";
            txtTrinhDo.Text = row.Cells["trinh_do"].Value?.ToString() ?? "";
            txtChungChi.Text = row.Cells["chung_chi"].Value?.ToString() ?? "";
            txtLoaiNS.Text = row.Cells["loai_nhan_su"].Value?.ToString() ?? "";
            txtSoCMND.Text = row.Cells["so_cmnd"].Value?.ToString() ?? "";
            txtQueQuan.Text = row.Cells["que_quan"].Value?.ToString() ?? "";
        }

    }
}