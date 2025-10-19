using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmNghiViec : Form
    {

        public frmNghiViec()
        {
            InitializeComponent();
            this.Text = "Quản lý Nghỉ Việc";

            LoadComboBox();
            LoadNghiViec();
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

        private void LoadNghiViec()
        {
            try
            {
                string query = @"
SELECT nv.id_nghi_viec,
       nv.id_nhan_su,
       ns.ho_ten AS ten_nhan_su,
       nv.loai,
       nv.ngay_nghi,
       nv.ly_do,
       nv.quyet_dinh_ban_giao
FROM Nghi_viec nv
LEFT JOIN Nhan_su ns ON nv.id_nhan_su = ns.id_nhan_su
ORDER BY nv.id_nghi_viec";

                DataTable dt = DatabaseNhanSuHelper.ExecuteQuery(query);
                dgvNghiViec.DataSource = dt.Rows.Count > 0 ? dt : null;

                if (dgvNghiViec.DataSource == null) return;

                dgvNghiViec.Columns["id_nghi_viec"].HeaderText = "Mã nghỉ việc";
                dgvNghiViec.Columns["id_nhan_su"].HeaderText = "Mã nhân sự";
                dgvNghiViec.Columns["ten_nhan_su"].HeaderText = "Tên nhân sự";
                dgvNghiViec.Columns["loai"].HeaderText = "Loại nghỉ";
                dgvNghiViec.Columns["ngay_nghi"].HeaderText = "Ngày nghỉ";
                dgvNghiViec.Columns["ngay_nghi"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvNghiViec.Columns["ly_do"].HeaderText = "Lý do";
                dgvNghiViec.Columns["quyet_dinh_ban_giao"].HeaderText = "Quyết định bàn giao";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadNghiViec: " + ex.Message);
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

            if (string.IsNullOrWhiteSpace(txtLoai.Text))
            {
                MessageBox.Show("Vui lòng nhập loại nghỉ!", "Cảnh báo");
                txtLoai.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLyDo.Text))
            {
                MessageBox.Show("Vui lòng nhập lý do!", "Cảnh báo");
                txtLyDo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtQDBG.Text))
            {
                MessageBox.Show("Vui lòng nhập quyết định bàn giao!", "Cảnh báo");
                txtQDBG.Focus();
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
                    string newId = GenerateNewId(conn, null, "Nghi_viec", "id_nghi_viec", "NV");

                    string query = @"
INSERT INTO Nghi_viec (id_nghi_viec, id_nhan_su, loai, ngay_nghi, ly_do, quyet_dinh_ban_giao)
VALUES (@id_nghi_viec, @id_nhan_su, @loai, @ngay_nghi, @ly_do, @quyet_dinh_ban_giao)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_nghi_viec", newId);
                        cmd.Parameters.AddWithValue("@id_nhan_su", cbMaNS.SelectedValue);
                        cmd.Parameters.AddWithValue("@loai", txtLoai.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngay_nghi", dtpNgayNghi.Value);
                        cmd.Parameters.AddWithValue("@ly_do", txtLyDo.Text.Trim());
                        cmd.Parameters.AddWithValue("@quyet_dinh_ban_giao", txtQDBG.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm thông tin nghỉ việc thành công!", "Thông báo");
                    LoadNghiViec();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nghỉ việc: " + ex.Message);
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
                if (string.IsNullOrWhiteSpace(txtMaNVC.Text))
                {
                    MessageBox.Show("Vui lòng chọn dòng cần sửa!", "Cảnh báo");
                    return;
                }

                if (!ValidateData()) return;

                using (SqlConnection conn = DatabaseNhanSuHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"
UPDATE Nghi_viec
SET id_nhan_su = @id_nhan_su,
    loai = @loai,
    ngay_nghi = @ngay_nghi,
    ly_do = @ly_do,
    quyet_dinh_ban_giao = @quyet_dinh_ban_giao
WHERE id_nghi_viec = @id_nghi_viec";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_nghi_viec", txtMaNVC.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_nhan_su", cbMaNS.SelectedValue);
                        cmd.Parameters.AddWithValue("@loai", txtLoai.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngay_nghi", dtpNgayNghi.Value);
                        cmd.Parameters.AddWithValue("@ly_do", txtLyDo.Text.Trim());
                        cmd.Parameters.AddWithValue("@quyet_dinh_ban_giao", txtQDBG.Text.Trim());

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Cập nhật thành công!");
                            LoadNghiViec();
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
            if (string.IsNullOrWhiteSpace(txtMaNVC.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa bản ghi này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM Nghi_viec WHERE id_nghi_viec=@id";
                SqlParameter[] p = { new SqlParameter("@id", txtMaNVC.Text) };
                if (DatabaseNhanSuHelper.ExecuteNonQuery(query, p) > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadNghiViec();
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
SELECT * FROM Nghi_viec
WHERE id_nghi_viec LIKE @kw OR id_nhan_su LIKE @kw OR ly_do LIKE @kw OR loai LIKE @kw";
            SqlParameter[] p = { new SqlParameter("@kw", "%" + kw + "%") };
            dgvNghiViec.DataSource = DatabaseNhanSuHelper.ExecuteQuery(query, p);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadNghiViec();
        }

        private void ClearFields()
        {
            txtMaNVC.Clear();
            txtLoai.Clear();
            txtLyDo.Clear();
            txtQDBG.Clear();
            if (cbMaNS.Items.Count > 0)
                cbMaNS.SelectedIndex = 0;
            dtpNgayNghi.Value = DateTime.Now;
        }

        private void dgvNghiViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgvNghiViec.Rows[e.RowIndex];

            txtMaNVC.Text = r.Cells["id_nghi_viec"].Value?.ToString() ?? "";
            cbMaNS.SelectedValue = r.Cells["id_nhan_su"].Value?.ToString() ?? "";
            txtLoai.Text = r.Cells["loai"].Value?.ToString() ?? "";
            txtLyDo.Text = r.Cells["ly_do"].Value?.ToString() ?? "";
            txtQDBG.Text = r.Cells["quyet_dinh_ban_giao"].Value?.ToString() ?? "";

            if (DateTime.TryParse(r.Cells["ngay_nghi"].Value?.ToString(), out DateTime ngay))
                dtpNgayNghi.Value = ngay;
            else
                dtpNgayNghi.Value = DateTime.Now;
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