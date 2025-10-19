using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmQuanLyKQHT : Form
    {
        public frmQuanLyKQHT()
        {
            InitializeComponent();
            this.Text = "Quản lý Kết quả học tập";
            LoadComboBox();
            LoadDiem();
        }

        private void LoadComboBox()
        {
            // Load sinh viên
            string querySV = "SELECT id_sinh_vien, ho_ten FROM Sinh_vien";
            DataTable dtSV = DatabaseSinhVienHelper.ExecuteQuery(querySV);
            cbSinhVien.DataSource = dtSV;
            cbSinhVien.DisplayMember = "ho_ten";
            cbSinhVien.ValueMember = "id_sinh_vien";
          
            // Load học phần
            string queryHP = "SELECT id_hoc_phan, ten_hoc_phan FROM Hoc_phan";
            DataTable dtHP = DatabaseSinhVienHelper.ExecuteQuery(queryHP);
            cbHocPhan.DataSource = dtHP;
            cbHocPhan.DisplayMember = "ten_hoc_phan";
            cbHocPhan.ValueMember = "id_hoc_phan";

            // Load học kỳ
            string queryHK = "SELECT id_hoc_ky FROM QLDaoTao.dbo.Hoc_ky";
            DataTable dtHk = DatabaseSinhVienHelper.ExecuteQuery(queryHK);
            cbHocKy.DataSource = dtHk;
            cbHocKy.DisplayMember = "id_hoc_ky";
            cbHocKy.ValueMember = "id_hoc_ky";
        }

        private void LoadDiem()
        {
            string query = @"
    SELECT 
        kq.id_sinh_vien,
        sv.ho_ten AS TenSinhVien,
        kq.id_hoc_phan,
        hp.ten_hoc_phan AS TenHocPhan,
        kq.hoc_ky,
        kq.diemCC,
        kq.diemGK,
        kq.diemCK,
        kq.diem_he_10,
        kq.diem_he_4,
        kq.diem_chu
    FROM Ket_qua_hoc_tap kq
    JOIN Sinh_vien sv ON kq.id_sinh_vien = sv.id_sinh_vien
    JOIN Hoc_phan hp ON kq.id_hoc_phan = hp.id_hoc_phan";

            DataTable dt = DatabaseSinhVienHelper.ExecuteQuery(query);

            // đảm bảo auto-generate
            dgvDiem.AutoGenerateColumns = true;
            dgvDiem.DataSource = dt;

            // đổi header nhưng kiểm tra tồn tại trước để tránh lỗi
            if (dgvDiem.Columns.Contains("id_sinh_vien")) dgvDiem.Columns["id_sinh_vien"].HeaderText = "Mã SV";
            if (dgvDiem.Columns.Contains("TenSinhVien")) dgvDiem.Columns["TenSinhVien"].HeaderText = "Tên sinh viên";
            if (dgvDiem.Columns.Contains("id_hoc_phan")) dgvDiem.Columns["id_hoc_phan"].HeaderText = "Mã học phần";
            if (dgvDiem.Columns.Contains("TenHocPhan")) dgvDiem.Columns["TenHocPhan"].HeaderText = "Tên học phần";
            if (dgvDiem.Columns.Contains("hoc_ky")) dgvDiem.Columns["hoc_ky"].HeaderText = "Học kỳ";
            if (dgvDiem.Columns.Contains("diemCC")) dgvDiem.Columns["diemCC"].HeaderText = "Điểm chuyên cần";
            if (dgvDiem.Columns.Contains("diemGK")) dgvDiem.Columns["diemGK"].HeaderText = "Điểm giữa kỳ";
            if (dgvDiem.Columns.Contains("diemCK")) dgvDiem.Columns["diemCK"].HeaderText = "Điểm cuối kỳ";
            if (dgvDiem.Columns.Contains("diem_he_10")) dgvDiem.Columns["diem_he_10"].HeaderText = "Điểm hệ 10";
            if (dgvDiem.Columns.Contains("diem_he_4")) dgvDiem.Columns["diem_he_4"].HeaderText = "Điểm hệ 4";
            if (dgvDiem.Columns.Contains("diem_chu")) dgvDiem.Columns["diem_chu"].HeaderText = "Điểm chữ";

            // ẩn cột id nếu muốn
            if (dgvDiem.Columns.Contains("id_sinh_vien")) dgvDiem.Columns["id_sinh_vien"].Visible = false;
            if (dgvDiem.Columns.Contains("id_hoc_phan")) dgvDiem.Columns["id_hoc_phan"].Visible = false;

            dgvDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDiem.CellFormatting += dgvDiem_CellFormatting;
        }
        private void dgvDiem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDiem.Columns[e.ColumnIndex].Name == "diem_he_10" && e.Value != null)
            {
                if (float.TryParse(e.Value.ToString(), out float diem))
                    e.Value = diem.ToString("F2"); // 2 số sau dấu phẩy
                e.FormattingApplied = true;
            }

            if (dgvDiem.Columns[e.ColumnIndex].Name == "diem_he_4" && e.Value != null)
            {
                if (float.TryParse(e.Value.ToString(), out float diem))
                    e.Value = diem.ToString("F1"); // 1 số sau dấu phẩy
                e.FormattingApplied = true;
            }

            if (dgvDiem.Columns[e.ColumnIndex].Name == "diem_chu" && e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper(); // Viết hoa
                e.FormattingApplied = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbSinhVien.SelectedValue == null || cbHocPhan.SelectedValue == null || cbHocKy.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 🔹 Lấy điểm từ form (float)
            float diemCC = (float)numDiemCC.Value;
            float diemGK = (float)numDiemGK.Value;
            float diemCK = (float)numDiemCK.Value;

          

            float diemHe10 = diemCC * 0.1f + diemGK * 0.3f + diemCK * 0.6f;
            float diemHe4;
            string diemChu;

            if (diemHe10 >= 8.5) { diemHe4 = 4.0f; diemChu = "A"; }
            else if (diemHe10 >= 8.0) { diemHe4 = 3.5f; diemChu = "B+"; }
            else if (diemHe10 >= 7.0) { diemHe4 = 3.0f; diemChu = "B"; }
            else if (diemHe10 >= 6.5) { diemHe4 = 2.5f; diemChu = "C+"; }
            else if (diemHe10 >= 5.5) { diemHe4 = 2.0f; diemChu = "C"; }
            else if (diemHe10 >= 5.0) { diemHe4 = 1.5f; diemChu = "D+"; }
            else if (diemHe10 >= 4.0) { diemHe4 = 1.0f; diemChu = "D"; }
            else { diemHe4 = 0.0f; diemChu = "F"; }

            // 🔹 Thực hiện câu lệnh SQL
            string query = @"
        INSERT INTO ket_qua_hoc_tap 
        (id_sinh_vien, id_hoc_phan, hoc_ky, diemCC, diemGK, diemCK, diem_he_10, diem_he_4, diem_chu)
        VALUES 
        (@id_sinh_vien, @id_hoc_phan, @hoc_ky, @diemCC, @diemGK, @diemCK, @diem_he_10, @diem_he_4, @diem_chu)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id_sinh_vien", cbSinhVien.SelectedValue),
        new SqlParameter("@id_hoc_phan", cbHocPhan.SelectedValue),
        new SqlParameter("@hoc_ky", cbHocKy.SelectedItem),
        new SqlParameter("@diemCC", diemCC),
        new SqlParameter("@diemGK", diemGK),
        new SqlParameter("@diemCK", diemCK),
        new SqlParameter("@diem_he_10", diemHe10),
        new SqlParameter("@diem_he_4", diemHe4),
        new SqlParameter("@diem_chu", diemChu)
            };

            int result = DatabaseSinhVienHelper.ExecuteNonQuery(query, parameters);
            if (result > 0)
            {
                MessageBox.Show("Thêm  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDiem();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDiem.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn kết quả cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy khóa chính (3 cột)
            string idSinhVien = dgvDiem.SelectedRows[0].Cells["id_sinh_vien"].Value.ToString();
            string idHocPhan = dgvDiem.SelectedRows[0].Cells["id_hoc_phan"].Value.ToString();
            string hocKy = dgvDiem.SelectedRows[0].Cells["hoc_ky"].Value.ToString();

            // Lấy giá trị điểm
            float diemCC = (float)numDiemCC.Value;
            float diemGK = (float)numDiemGK.Value;
            float diemCK = (float)numDiemCK.Value;

            // Tính hệ 10, hệ 4, điểm chữ
            float diemHe10 = diemCC * 0.1f + diemGK * 0.3f + diemCK * 0.6f;
            float diemHe4;
            string diemChu;

            if (diemHe10 >= 8.5) { diemHe4 = 4.0f; diemChu = "A"; }
            else if (diemHe10 >= 8.0) { diemHe4 = 3.5f; diemChu = "B+"; }
            else if (diemHe10 >= 7.0) { diemHe4 = 3.0f; diemChu = "B"; }
            else if (diemHe10 >= 6.5) { diemHe4 = 2.5f; diemChu = "C+"; }
            else if (diemHe10 >= 5.5) { diemHe4 = 2.0f; diemChu = "C"; }
            else if (diemHe10 >= 5.0) { diemHe4 = 1.5f; diemChu = "D+"; }
            else if (diemHe10 >= 4.0) { diemHe4 = 1.0f; diemChu = "D"; }
            else { diemHe4 = 0.0f; diemChu = "F"; }

            string query = @"
        UPDATE Ket_qua_hoc_tap
        SET diemCC=@diemCC,
            diemGK=@diemGK,
            diemCK=@diemCK,
            diem_he_10=@diem_he_10,
            diem_he_4=@diem_he_4,
            diem_chu=@diem_chu
        WHERE id_sinh_vien=@id_sinh_vien AND id_hoc_phan=@id_hoc_phan AND hoc_ky=@hoc_ky";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@diemCC", diemCC),
        new SqlParameter("@diemGK", diemGK),
        new SqlParameter("@diemCK", diemCK),
        new SqlParameter("@diem_he_10", diemHe10),
        new SqlParameter("@diem_he_4", diemHe4),
        new SqlParameter("@diem_chu", diemChu),
        new SqlParameter("@id_sinh_vien", idSinhVien),
        new SqlParameter("@id_hoc_phan", idHocPhan),
        new SqlParameter("@hoc_ky", hocKy)
            };

            int result = DatabaseSinhVienHelper.ExecuteNonQuery(query, parameters);
            if (result > 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDiem();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDiem.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn kết quả cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string idSinhVien = dgvDiem.SelectedRows[0].Cells["id_sinh_vien"].Value.ToString();
            string idHocPhan = dgvDiem.SelectedRows[0].Cells["id_hoc_phan"].Value.ToString();
            string hocKy = dgvDiem.SelectedRows[0].Cells["hoc_ky"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa kết quả này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = @"DELETE FROM ket_qua_hoc_tap WHERE id_sinh_vien=@id_sinh_vien AND id_hoc_phan=@id_hoc_phan AND hoc_ky=@hoc_ky";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@id_sinh_vien", idSinhVien),
            new SqlParameter("@id_hoc_phan", idHocPhan),
            new SqlParameter("@hoc_ky", hocKy)
                };

                int result = DatabaseSinhVienHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDiem();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDiem_SelectionChanged(object sender, EventArgs e)
        {
      
            if (dgvDiem.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDiem.SelectedRows[0];
                cbSinhVien.SelectedValue = row.Cells["id_sinh_vien"].Value.ToString();
                cbHocPhan.SelectedValue = row.Cells["id_hoc_phan"].Value.ToString();

                cbHocKy.Text = row.Cells["hoc_ky"].Value.ToString();
                numDiemCC.Value = Convert.ToDecimal(row.Cells["diemCC"].Value);
                numDiemGK.Value = Convert.ToDecimal(row.Cells["diemGK"].Value);
                numDiemCK.Value = Convert.ToDecimal(row.Cells["diemCK"].Value);
            }
        }



        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = @"
        SELECT 
            kq.id_sinh_vien,
            sv.ho_ten AS TenSinhVien,
            kq.id_hoc_phan,
            hp.ten_hoc_phan AS TenHocPhan,
            kq.hoc_ky,
            kq.diemCC,
            kq.diemGK,
            kq.diemCK,
            kq.diem_he_10,
            kq.diem_he_4,
            kq.diem_chu
        FROM Ket_qua_hoc_tap kq
        JOIN Sinh_vien sv ON kq.id_sinh_vien = sv.id_sinh_vien
        JOIN Hoc_phan hp ON kq.id_hoc_phan = hp.id_hoc_phan
        WHERE sv.ho_ten LIKE @keyword
           OR hp.ten_hoc_phan LIKE @keyword
           OR kq.hoc_ky LIKE @keyword
           OR kq.id_sinh_vien LIKE @keyword
           OR kq.id_hoc_phan LIKE @keyword";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@keyword", $"%{keyword}%")
            };

            DataTable dt = DatabaseSinhVienHelper.ExecuteQuery(query, parameters);
            dgvDiem.DataSource = dt;

            // Đổi lại tiêu đề cột (nếu muốn đồng bộ với LoadDiem)
            if (dgvDiem.Columns.Contains("id_sinh_vien")) dgvDiem.Columns["id_sinh_vien"].HeaderText = "Mã SV";
            if (dgvDiem.Columns.Contains("TenSinhVien")) dgvDiem.Columns["TenSinhVien"].HeaderText = "Tên sinh viên";
            if (dgvDiem.Columns.Contains("id_hoc_phan")) dgvDiem.Columns["id_hoc_phan"].HeaderText = "Mã học phần";
            if (dgvDiem.Columns.Contains("TenHocPhan")) dgvDiem.Columns["TenHocPhan"].HeaderText = "Tên học phần";
            if (dgvDiem.Columns.Contains("hoc_ky")) dgvDiem.Columns["hoc_ky"].HeaderText = "Học kỳ";
            if (dgvDiem.Columns.Contains("diemCC")) dgvDiem.Columns["diemCC"].HeaderText = "Điểm chuyên cần";
            if (dgvDiem.Columns.Contains("diemGK")) dgvDiem.Columns["diemGK"].HeaderText = "Điểm giữa kỳ";
            if (dgvDiem.Columns.Contains("diemCK")) dgvDiem.Columns["diemCK"].HeaderText = "Điểm cuối kỳ";
            if (dgvDiem.Columns.Contains("diem_he_10")) dgvDiem.Columns["diem_he_10"].HeaderText = "Điểm hệ 10";
            if (dgvDiem.Columns.Contains("diem_he_4")) dgvDiem.Columns["diem_he_4"].HeaderText = "Điểm hệ 4";
            if (dgvDiem.Columns.Contains("diem_chu")) dgvDiem.Columns["diem_chu"].HeaderText = "Điểm chữ";

            dgvDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDiem();
            ClearFields();
            txtTimKiem.Clear();
        }

        private void ClearFields()
        {
            if (cbSinhVien.Items.Count > 0)
                cbSinhVien.SelectedIndex = -1;
            if (cbHocPhan.Items.Count > 0)
                cbHocPhan.SelectedIndex = -1;
            if (cbHocKy.Items.Count > 0)
                cbHocKy.SelectedIndex = 0;
            numDiemCC.Value = 0;
            numDiemGK.Value = 0;
            numDiemCK.Value = 0;
        }

        private void numDiem_ValueChanged(object sender, EventArgs e)
        {
            float diemCC = (float)numDiemCC.Value;
            float diemGK = (float)numDiemGK.Value;
            float diemCK = (float)numDiemCK.Value;


            float diemHe10 = diemCC * 0.1f + diemGK * 0.3f + diemCK * 0.6f;
            float diemHe4;
            string diemChu;

            if (diemHe10 >= 8.5) { diemHe4 = 4.0f; diemChu = "A"; }
            else if (diemHe10 >= 8.0) { diemHe4 = 3.5f; diemChu = "B+"; }
            else if (diemHe10 >= 7.0) { diemHe4 = 3.0f; diemChu = "B"; }
            else if (diemHe10 >= 6.5) { diemHe4 = 2.5f; diemChu = "C+"; }
            else if (diemHe10 >= 5.5) { diemHe4 = 2.0f; diemChu = "C"; }
            else if (diemHe10 >= 5.0) { diemHe4 = 1.5f; diemChu = "D+"; }
            else if (diemHe10 >= 4.0) { diemHe4 = 1.0f; diemChu = "D"; }
            else { diemHe4 = 0.0f; diemChu = "F"; }

            // Cập nhật label
            lblDiemHe10.Text = $"Điểm hệ 10: {diemHe10:F2}";
            lblDiemHe4.Text = $"Điểm hệ 4: {diemHe4:F1}";
            lblDiemChu.Text = $"Điểm chữ: {diemChu}";
        }
    }
}