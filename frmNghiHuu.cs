using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmNghiHuu : Form
    {

        public frmNghiHuu()
        {
            InitializeComponent();
            this.Text = "Quản lý Nghỉ Hưu";

            // --- Cấu hình NumericUpDown ---
            numLuongHuu.Minimum = 0;
            numLuongHuu.Maximum = 100000000;
            numLuongHuu.DecimalPlaces = 2;
            numLuongHuu.ThousandsSeparator = true;

            numNamCT.Minimum = 0;
            numNamCT.Maximum = 60;

            LoadComboBox();
            LoadNghiHuu();
        }

        private void LoadComboBox()
        {
            try
            {
                string query = "SELECT id_nhan_su, ho_ten FROM Nhan_su";
                cbMaNS.DataSource = DatabaseNhanSuHelper.ExecuteQuery(query);
                cbMaNS.DisplayMember = "ho_ten";
                cbMaNS.ValueMember = "id_nhan_su";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ComboBox: " + ex.Message);
            }
        }

        private void LoadNghiHuu()
        {
            try
            {
                string query = @"
SELECT nh.id_nghi_huu,
       nh.id_nhan_su,
       ns.ho_ten AS ten_nhan_su,
       nh.ngay_nghi_huu,
       nh.so_nam_cong_tac,
       nh.muc_luong_huu,
       nh.ghi_chu
FROM Nghi_huu nh
LEFT JOIN Nhan_su ns ON nh.id_nhan_su = ns.id_nhan_su
ORDER BY nh.id_nghi_huu";

                DataTable dt = DatabaseNhanSuHelper.ExecuteQuery(query);
                dgvNghiHuu.DataSource = dt.Rows.Count > 0 ? dt : null;

                if (dgvNghiHuu.DataSource == null) return;

                dgvNghiHuu.Columns["id_nghi_huu"].HeaderText = "Mã nghỉ hưu";
                dgvNghiHuu.Columns["id_nhan_su"].HeaderText = "Mã nhân sự";
                dgvNghiHuu.Columns["ten_nhan_su"].HeaderText = "Tên nhân sự";
                dgvNghiHuu.Columns["ngay_nghi_huu"].HeaderText = "Ngày nghỉ hưu";
                dgvNghiHuu.Columns["ngay_nghi_huu"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvNghiHuu.Columns["so_nam_cong_tac"].HeaderText = "Số năm công tác";
                dgvNghiHuu.Columns["muc_luong_huu"].HeaderText = "Mức lương hưu";
                dgvNghiHuu.Columns["muc_luong_huu"].DefaultCellStyle.Format = "N2";
                dgvNghiHuu.Columns["ghi_chu"].HeaderText = "Ghi chú";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadNghiHuu: " + ex.Message);
            }
        }

        private bool ValidateData()
        {
            if (cbMaNS.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân sự!", "Cảnh báo");
                cbMaNS.Focus();
                return false;
            }

            if (numNamCT.Value <= 0)
            {
                MessageBox.Show("Số năm công tác phải lớn hơn 0!", "Cảnh báo");
                numNamCT.Focus();
                return false;
            }

            if (numLuongHuu.Value <= 0)
            {
                MessageBox.Show("Mức lương hưu phải lớn hơn 0!", "Cảnh báo");
                numLuongHuu.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGhiChu.Text))
            {
                MessageBox.Show("Vui lòng nhập ghi chú!", "Cảnh báo");
                txtGhiChu.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateData()) return;

                using (SqlConnection conn = DatabaseNhanSuHelper.GetConnection())
                {
                    conn.Open();

                    string newId = GenerateNewId(conn, null, "Nghi_huu", "id_nghi_huu", "NH");

                    string query = @"
INSERT INTO Nghi_huu (id_nghi_huu, id_nhan_su, ngay_nghi_huu, so_nam_cong_tac, muc_luong_huu, ghi_chu)
VALUES (@id_nghi_huu, @id_nhan_su, @ngay_nghi_huu, @so_nam_cong_tac, @muc_luong_huu, @ghi_chu)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_nghi_huu", newId);
                        cmd.Parameters.AddWithValue("@id_nhan_su", cbMaNS.SelectedValue);
                        cmd.Parameters.AddWithValue("@ngay_nghi_huu", dtpNgayNH.Value);
                        cmd.Parameters.AddWithValue("@so_nam_cong_tac", (int)numNamCT.Value);
                        cmd.Parameters.AddWithValue("@muc_luong_huu", numLuongHuu.Value);
                        cmd.Parameters.AddWithValue("@ghi_chu", txtGhiChu.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm thông tin nghỉ hưu thành công!", "Thông báo");
                    LoadNghiHuu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nghỉ hưu: " + ex.Message);
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
                if (tran != null) cmd.Transaction = tran;

                cmd.Parameters.AddWithValue("@prefix", prefix);
                object result = cmd.ExecuteScalar();
                int next = 1;

                if (result != null)
                {
                    string lastId = result.ToString();
                    if (int.TryParse(lastId.Substring(prefix.Length), out int n))
                        next = n + 1;
                }

                return $"{prefix}{next:D3}";
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNH.Text))
                {
                    MessageBox.Show("Vui lòng chọn dòng cần sửa!", "Cảnh báo");
                    return;
                }

                if (!ValidateData()) return;

                using (SqlConnection conn = DatabaseNhanSuHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"
UPDATE Nghi_huu
SET id_nhan_su = @id_nhan_su,
    ngay_nghi_huu = @ngay_nghi_huu,
    so_nam_cong_tac = @so_nam_cong_tac,
    muc_luong_huu = @muc_luong_huu,
    ghi_chu = @ghi_chu
WHERE id_nghi_huu = @id_nghi_huu";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_nghi_huu", txtMaNH.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_nhan_su", cbMaNS.SelectedValue);
                        cmd.Parameters.AddWithValue("@ngay_nghi_huu", dtpNgayNH.Value);
                        cmd.Parameters.AddWithValue("@so_nam_cong_tac", (int)numNamCT.Value);
                        cmd.Parameters.AddWithValue("@muc_luong_huu", numLuongHuu.Value);
                        cmd.Parameters.AddWithValue("@ghi_chu", txtGhiChu.Text.Trim());

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Cập nhật thành công!");
                            LoadNghiHuu();
                        }
                        else
                            MessageBox.Show("Không tìm thấy dữ liệu cần sửa!");
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
            if (string.IsNullOrWhiteSpace(txtMaNH.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa bản ghi này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM Nghi_huu WHERE id_nghi_huu=@id";
                SqlParameter[] p = { new SqlParameter("@id", txtMaNH.Text) };
                if (DatabaseNhanSuHelper.ExecuteNonQuery(query, p) > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadNghiHuu();
                    ClearFields();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(kw))
            {
                MessageBox.Show("Vui lòng nhập từ khóa!");
                return;
            }

            string query = @"
SELECT * FROM Nghi_huu
WHERE id_nghi_huu LIKE @kw OR id_nhan_su LIKE @kw OR ghi_chu LIKE @kw";
            SqlParameter[] p = { new SqlParameter("@kw", "%" + kw + "%") };
            dgvNghiHuu.DataSource = DatabaseNhanSuHelper.ExecuteQuery(query, p);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadNghiHuu();
        }

        private void ClearFields()
        {
            txtMaNH.Clear();
            txtGhiChu.Clear();
            numLuongHuu.Value = 0;
            numNamCT.Value = 0;
            if (cbMaNS.Items.Count > 0)
                cbMaNS.SelectedIndex = 0;
            dtpNgayNH.Value = DateTime.Now;
        }

        private void dgvNghiHuu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgvNghiHuu.Rows[e.RowIndex];

            txtMaNH.Text = r.Cells["id_nghi_huu"].Value?.ToString() ?? "";
            cbMaNS.SelectedValue = r.Cells["id_nhan_su"].Value?.ToString() ?? "";
            txtGhiChu.Text = r.Cells["ghi_chu"].Value?.ToString() ?? "";

            if (DateTime.TryParse(r.Cells["ngay_nghi_huu"].Value?.ToString(), out DateTime ngay))
                dtpNgayNH.Value = ngay;
            else
                dtpNgayNH.Value = DateTime.Now;

            if (int.TryParse(r.Cells["so_nam_cong_tac"].Value?.ToString(), out int soNam))
                numNamCT.Value = soNam;
            else
                numNamCT.Value = 0;

            if (decimal.TryParse(r.Cells["muc_luong_huu"].Value?.ToString(), out decimal luong))
                numLuongHuu.Value = luong;
            else
                numLuongHuu.Value = 0;
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

        
    }
}