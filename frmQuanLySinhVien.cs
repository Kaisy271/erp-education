using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmQuanLySinhVien : Form
    {

        public frmQuanLySinhVien()
        {
            InitializeComponent();
            this.Text = "Quản lý Thông tin Sinh viên";
            LoadComboBox();
            LoadSinhVien();
        }

        private void LoadComboBox()
        {
            try
            {
                // 🔹 Load danh sách lớp
                string queryLop = "SELECT id_lop, ten_lop FROM Lop";
                cbLop.DataSource = DatabaseSinhVienHelper.ExecuteQuery(queryLop);
                cbLop.DisplayMember = "ten_lop";
                cbLop.ValueMember = "id_lop";

                // 🔹 Load trạng thái
                cbTrangThai.Items.Clear();
                cbTrangThai.Items.Add("Đang học");
                cbTrangThai.Items.Add("Bảo lưu");
                cbTrangThai.Items.Add("Đã tốt nghiệp");
                cbTrangThai.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ComboBox: " + ex.Message);
            }
        }

        private void LoadSinhVien()
        {
            try
            {
                // Lấy dữ liệu rõ ràng (lấy ten_lop bằng JOIN, chuyển gioi_tinh thành Nam/Nữ)
                string query = @"
            SELECT sv.id_sinh_vien,
              
                   sv.ho_ten,
                   sv.ngay_sinh,
                   CASE WHEN sv.gioi_tinh = 1 THEN N'Nam' ELSE N'Nữ' END AS gioi_tinh,
                   sv.dia_chi,
                   sv.email,
                   sv.sdt,
                   sv.trang_thai,
               
                   l.ten_lop,
                   sv.id_lop
            FROM Sinh_vien sv
            LEFT JOIN Lop l ON sv.id_lop = l.id_lop
            ORDER BY sv.id_sinh_vien";

                DataTable dt = DatabaseSinhVienHelper.ExecuteQuery(query);

                if (dt == null)
                {
                    dgvSinhVien.DataSource = null;
                    return;
                }

                // Thêm cột STT và gán giá trị thứ tự (1..n)
                if (!dt.Columns.Contains("STT"))
                    dt.Columns.Add("STT", typeof(int));

                for (int i = 0; i < dt.Rows.Count; i++)
                    dt.Rows[i]["STT"] = i + 1;

                // Di chuyển cột STT lên đầu
                dt.Columns["STT"].SetOrdinal(0);

                // Bind DataTable vào DataGridView
                dgvSinhVien.DataSource = dt;

                // Hiển thị/định dạng cột
                if (dgvSinhVien.Columns.Contains("ngay_sinh")) { dgvSinhVien.Columns["ngay_sinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvSinhVien.Columns["ngay_sinh"].HeaderText = "Ngày sinh";
                }

                if (dgvSinhVien.Columns.Contains("id_sinh_vien"))
                    dgvSinhVien.Columns["id_sinh_vien"].HeaderText = "Mã sinh viên";

                if (dgvSinhVien.Columns.Contains("dia_chi"))
                    dgvSinhVien.Columns["dia_chi"].HeaderText = "Địa chỉ";

                if (dgvSinhVien.Columns.Contains("ho_ten"))
                    dgvSinhVien.Columns["ho_ten"].HeaderText = "Họ tên";

                if (dgvSinhVien.Columns.Contains("email"))
                    dgvSinhVien.Columns["email"].HeaderText = "Email";

                if (dgvSinhVien.Columns.Contains("sdt"))
                    dgvSinhVien.Columns["sdt"].HeaderText = "Số điện thoại";

                if (dgvSinhVien.Columns.Contains("trang_thai"))
                    dgvSinhVien.Columns["trang_thai"].HeaderText = "Trạng thái";

                if (dgvSinhVien.Columns.Contains("ten_lop"))
                    dgvSinhVien.Columns["ten_lop"].HeaderText = "Lớp";

                if (dgvSinhVien.Columns.Contains("gioi_tinh"))
                    dgvSinhVien.Columns["gioi_tinh"].HeaderText = "Giới tính";

                if (dgvSinhVien.Columns.Contains("STT"))
                {
                    dgvSinhVien.Columns["STT"].HeaderText = "STT";
                    dgvSinhVien.Columns["STT"].Width = 50;
                    dgvSinhVien.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // Ẩn cột id_lop nếu không muốn hiển thị mã lớp (dùng để set SelectedValue)
                if (dgvSinhVien.Columns.Contains("id_lop"))
                    dgvSinhVien.Columns["id_lop"].Visible = false;

                // Nếu muốn ẩn id_nguoi_dung: (tuỳ bạn)
                // if (dgvSinhVien.Columns.Contains("id_nguoi_dung")) dgvSinhVien.Columns["id_nguoi_dung"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadSinhVien: " + ex.Message);
            }

        }
        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Cảnh báo");
                txtMaSV.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Cảnh báo");
                txtHoTen.Focus();
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

            if (cbLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp!", "Cảnh báo");
                cbLop.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateData()) return;

                using (SqlConnection conn = DatabaseSinhVienHelper.GetConnection())
                {
                    conn.Open();
                    SqlTransaction tran = conn.BeginTransaction();

                    try
                    {
                        // 🔹 Kiểm tra trùng tài khoản (mã SV)
                        string checkUser = "SELECT COUNT(*) FROM Nguoi_dung WHERE tai_khoan = @tk";
                        SqlCommand cmdCheck = new SqlCommand(checkUser, conn, tran);
                        cmdCheck.Parameters.AddWithValue("@tk", txtMaSV.Text.Trim());
                        int exists = (int)cmdCheck.ExecuteScalar();
                        if (exists > 0)
                        {
                            MessageBox.Show("Tài khoản (mã sinh viên) đã tồn tại!");
                            tran.Rollback();
                            return;
                        }

                        // 🔹 Kiểm tra trùng số điện thoại hoặc email
                        string checkDuplicate = @"SELECT COUNT(*) 
                                          FROM Sinh_vien 
                                          WHERE sdt = @sdt OR email = @em";
                        SqlCommand cmdDup = new SqlCommand(checkDuplicate, conn, tran);
                        cmdDup.Parameters.AddWithValue("@sdt", txtSDT.Text.Trim());
                        cmdDup.Parameters.AddWithValue("@em", txtEmail.Text.Trim());
                        int dup = (int)cmdDup.ExecuteScalar();
                        if (dup > 0)
                        {
                            MessageBox.Show("Số điện thoại hoặc email đã tồn tại! Vui lòng nhập lại.");
                            tran.Rollback();
                            return;
                        }

                        // 🔹 Sinh mã ND tự động
                        string newUserId = GenerateNewId(conn, tran, "Nguoi_dung", "id_nguoi_dung", "ND");

                        // 🔹 Thêm vào bảng Nguoi_dung
                        string insertUser = @"
                    INSERT INTO Nguoi_dung (id_nguoi_dung, tai_khoan, mat_khau)
                    VALUES (@id_nguoi_dung, @tai_khoan, @mat_khau)";
                        SqlCommand cmdUser = new SqlCommand(insertUser, conn, tran);
                        cmdUser.Parameters.AddWithValue("@id_nguoi_dung", newUserId);
                        cmdUser.Parameters.AddWithValue("@tai_khoan", txtMaSV.Text.Trim());
                        cmdUser.Parameters.AddWithValue("@mat_khau", "123");
                        cmdUser.ExecuteNonQuery();

                        // 🔹 Thêm vào bảng Sinh_vien
                        string insertSV = @"
                    INSERT INTO Sinh_vien
                    (id_sinh_vien, id_nguoi_dung, ho_ten, ngay_sinh, gioi_tinh, dia_chi, email, sdt, trang_thai, id_lop)
                    VALUES (@id_sinh_vien, @id_nguoi_dung, @ho_ten, @ngay_sinh, @gioi_tinh, @dia_chi, @email, @sdt, @trang_thai, @id_lop)";
                        SqlCommand cmdSV = new SqlCommand(insertSV, conn, tran);
                        cmdSV.Parameters.AddWithValue("@id_sinh_vien", txtMaSV.Text.Trim());
                        cmdSV.Parameters.AddWithValue("@id_nguoi_dung", newUserId);
                        cmdSV.Parameters.AddWithValue("@ho_ten", txtHoTen.Text.Trim());
                        cmdSV.Parameters.AddWithValue("@ngay_sinh", dtpNgaySinh.Value);
                        cmdSV.Parameters.AddWithValue("@gioi_tinh", rbNam.Checked ? 1 : 0);
                        cmdSV.Parameters.AddWithValue("@dia_chi", txtDiaChi.Text.Trim());
                        cmdSV.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmdSV.Parameters.AddWithValue("@sdt", txtSDT.Text.Trim());
                        cmdSV.Parameters.AddWithValue("@trang_thai", cbTrangThai.Text.Trim());
                        cmdSV.Parameters.AddWithValue("@id_lop", cbLop.SelectedValue);
                        cmdSV.ExecuteNonQuery();

                        tran.Commit();
                        MessageBox.Show("Thêm sinh viên thành công!");
                        LoadSinhVien();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Lỗi thêm sinh viên: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sinh viên: " + ex.Message);
            }
        }
        private string GenerateNewId(SqlConnection conn, SqlTransaction tran, string tableName, string columnName, string prefix)
        {
            string query = $"SELECT TOP 1 {columnName} FROM {tableName} WHERE {columnName} LIKE @prefix + '%' ORDER BY {columnName} DESC";
            SqlCommand cmd = new SqlCommand(query, conn, tran);
            cmd.Parameters.AddWithValue("@prefix", prefix);
            object result = cmd.ExecuteScalar();

            int nextNumber = 1;
            if (result != null)
            {
                string lastId = result.ToString();
                if (int.TryParse(lastId.Substring(prefix.Length), out int num))
                    nextNumber = num + 1;
            }

            return prefix + nextNumber.ToString("D3");
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaSV.Text))
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần sửa!");
                    return;
                }

                if (!ValidateData()) return;

                using (SqlConnection conn = DatabaseSinhVienHelper.GetConnection())
                {
                    conn.Open();

                    // 🔹 Kiểm tra trùng SĐT hoặc Email với sinh viên khác
                    string checkDuplicate = @"
                SELECT COUNT(*) 
                FROM Sinh_vien 
                WHERE (sdt = @sdt OR email = @em) 
                  AND id_sinh_vien <> @id";
                    SqlCommand cmdCheck = new SqlCommand(checkDuplicate, conn);
                    cmdCheck.Parameters.AddWithValue("@sdt", txtSDT.Text.Trim());
                    cmdCheck.Parameters.AddWithValue("@em", txtEmail.Text.Trim());
                    cmdCheck.Parameters.AddWithValue("@id", txtMaSV.Text.Trim());
                    int dup = (int)cmdCheck.ExecuteScalar();

                    if (dup > 0)
                    {
                        MessageBox.Show("Số điện thoại hoặc email đã tồn tại ở sinh viên khác! Vui lòng nhập lại.");
                        return;
                    }

                    // 🔹 Cập nhật thông tin sinh viên
                    string query = @"
                UPDATE Sinh_vien 
                SET ho_ten = @ho_ten, 
                    ngay_sinh = @ngay_sinh, 
                    gioi_tinh = @gioi_tinh,
                    dia_chi = @dia_chi, 
                    email = @email, 
                    sdt = @sdt, 
                    trang_thai = @trang_thai, 
                    id_lop = @id_lop
                WHERE id_sinh_vien = @id_sinh_vien";

                    SqlParameter[] p = {
                new SqlParameter("@id_sinh_vien", txtMaSV.Text.Trim()),
                new SqlParameter("@ho_ten", txtHoTen.Text.Trim()),
                new SqlParameter("@ngay_sinh", dtpNgaySinh.Value),
                new SqlParameter("@gioi_tinh", rbNam.Checked ? 1 : 0),
                new SqlParameter("@dia_chi", txtDiaChi.Text.Trim()),
                new SqlParameter("@email", txtEmail.Text.Trim()),
                new SqlParameter("@sdt", txtSDT.Text.Trim()),
                new SqlParameter("@trang_thai", cbTrangThai.Text.Trim()),
                new SqlParameter("@id_lop", cbLop.SelectedValue)
            };

                    if (DatabaseSinhVienHelper.ExecuteNonQuery(query, p) > 0)
                    {
                        MessageBox.Show("Cập nhật sinh viên thành công!");
                        LoadSinhVien();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM Sinh_vien WHERE id_sinh_vien=@id_sinh_vien";
                SqlParameter[] p = { new SqlParameter("@id_sinh_vien", txtMaSV.Text) };

                if (DatabaseSinhVienHelper.ExecuteNonQuery(query, p) > 0)
                {
                    MessageBox.Show("Xóa sinh viên thành công!");
                    LoadSinhVien();
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
            string query = @"SELECT * FROM Sinh_vien 
                 WHERE id_sinh_vien LIKE @kw 
                    OR id_lop LIKE @kw 
                    OR ho_ten LIKE @kw 
                    OR trang_thai LIKE @kw";

            SqlParameter[] parameters = { new SqlParameter("@kw", "%" + keyword + "%") };
            dgvSinhVien.DataSource = DatabaseSinhVienHelper.ExecuteQuery(query, parameters);
        }



        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadSinhVien();
        }

        private void ClearFields()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            rbNam.Checked = true;
            cbTrangThai.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now;
            cbLop.SelectedIndex = 0;
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

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];

            txtMaSV.Text = row.Cells["id_sinh_vien"].Value?.ToString() ?? "";
            txtHoTen.Text = row.Cells["ho_ten"].Value?.ToString() ?? "";

            var nsVal = row.Cells["ngay_sinh"].Value;
            if (nsVal != null && nsVal != DBNull.Value && DateTime.TryParse(nsVal.ToString(), out DateTime ns))
                dtpNgaySinh.Value = ns;
            else
                dtpNgaySinh.Value = DateTime.Now;

            txtDiaChi.Text = row.Cells["dia_chi"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["email"].Value?.ToString() ?? "";
            txtSDT.Text = row.Cells["sdt"].Value?.ToString() ?? "";
            cbTrangThai.Text = row.Cells["trang_thai"].Value?.ToString() ?? "";

            if (row.Cells["id_lop"].Value != null && row.Cells["id_lop"].Value != DBNull.Value)
                cbLop.SelectedValue = row.Cells["id_lop"].Value;
            else if (row.Cells["ten_lop"].Value != null)
                cbLop.Text = row.Cells["ten_lop"].Value.ToString();

            string gt = row.Cells["gioi_tinh"].Value?.ToString() ?? "";
            rbNam.Checked = gt == "Nam";
            rbNu.Checked = gt == "Nữ";
        }
    }
}