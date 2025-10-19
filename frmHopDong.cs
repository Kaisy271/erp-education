using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmHopDong : Form
    {

        public frmHopDong()
        {
            InitializeComponent();
            this.Text = "Quản lý Thông tin Hợp đồng";

            // Cấu hình NumericUpDown cho lương
            numLuong.Minimum = 0;
            numLuong.Maximum = 100000000; // ví dụ: 100 triệu
            numLuong.DecimalPlaces = 2;   // 2 chữ số thập phân
            numLuong.ThousandsSeparator = true; // hiển thị dấu phẩy phân tách hàng nghìn

            // Nạp dữ liệu
            LoadComboBox();
            LoadHopDong();
        }


        private void LoadComboBox()
        {
            try
            {
                // 🔹 Load danh sách lớp
                string queryNhanSu = "SELECT id_nhan_su, ho_ten FROM Nhan_Su";
                cbMaNS.DataSource = DatabaseNhanSuHelper.ExecuteQuery(queryNhanSu);
                cbMaNS.DisplayMember = "ho_ten";
                cbMaNS.ValueMember = "id_nhan_su";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ComboBox: " + ex.Message);
            }
        }
        private void LoadHopDong()
        {
            try
            {
                string query = @"
SELECT hd.id_hop_dong,
       hd.id_nhan_su,
       ns.ho_ten AS ten_nhan_su,
       hd.ten_hop_dong,
       hd.loai_hop_dong,
       hd.ngay_ky,
       hd.ngay_het_han,
       hd.muc_luong_co_ban,
       hd.trang_thai
FROM Hop_dong hd
LEFT JOIN Nhan_su ns ON hd.id_nhan_su = ns.id_nhan_su
ORDER BY hd.id_hop_dong";

                DataTable dt = DatabaseNhanSuHelper.ExecuteQuery(query);

                dgvHopDong.DataSource = (dt != null && dt.Rows.Count > 0) ? dt : null;

                if (dgvHopDong.DataSource == null)
                    return;

                // --- Định dạng hiển thị ---
                dgvHopDong.Columns["id_hop_dong"].HeaderText = "Mã hợp đồng";
                dgvHopDong.Columns["id_nhan_su"].HeaderText = "Mã nhân sự";
                dgvHopDong.Columns["ten_nhan_su"].HeaderText = "Tên nhân sự";
                dgvHopDong.Columns["ten_hop_dong"].HeaderText = "Tên hợp đồng";
                dgvHopDong.Columns["loai_hop_dong"].HeaderText = "Loại hợp đồng";

                dgvHopDong.Columns["ngay_ky"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvHopDong.Columns["ngay_ky"].HeaderText = "Ngày ký";

                dgvHopDong.Columns["ngay_het_han"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvHopDong.Columns["ngay_het_han"].HeaderText = "Ngày hết hạn";

                dgvHopDong.Columns["muc_luong_co_ban"].DefaultCellStyle.Format = "N2";
                dgvHopDong.Columns["muc_luong_co_ban"].HeaderText = "Mức lương cơ bản";

                dgvHopDong.Columns["trang_thai"].HeaderText = "Trạng thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadHopDong: " + ex.Message, "Lỗi");
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hợp đồng!", "Cảnh báo");
                txtMaHD.Focus();
                return false;
            }

            if (cbMaNS.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân sự!", "Cảnh báo");
                cbMaNS.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenHD.Text))
            {
                MessageBox.Show("Vui lòng nhập tên hợp đồng!", "Cảnh báo");
                txtTenHD.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLoaiHD.Text))
            {
                MessageBox.Show("Vui lòng nhập loại hợp đồng!", "Cảnh báo");
                txtLoaiHD.Focus();
                return false;
            }

            // Kiểm tra ngày ký & hết hạn
            if (dtpNgayKy.Value == null)
            {
                MessageBox.Show("Vui lòng chọn ngày ký!", "Cảnh báo");
                dtpNgayKy.Focus();
                return false;
            }

            if (dtpNgayHetHan.Value == null)
            {
                MessageBox.Show("Vui lòng chọn ngày hết hạn!", "Cảnh báo");
                dtpNgayHetHan.Focus();
                return false;
            }

            // --- Kiểm tra lương ---
            if (numLuong.Value <= 0)
            {
                MessageBox.Show("Mức lương cơ bản phải lớn hơn 0!", "Cảnh báo");
                numLuong.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTrangThai.Text))
            {
                MessageBox.Show("Vui lòng nhập trạng thái hợp đồng!", "Cảnh báo");
                txtTrangThai.Focus();
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

                    // 🔹 Sinh mã hợp đồng mới (HD001, HD002, ...)
                    string newHopDongId = GenerateNewId(conn, null, "Hop_dong", "id_hop_dong", "HD");

                    string insertHopDong = @"
                INSERT INTO Hop_dong
                (id_hop_dong, id_nhan_su, ten_hop_dong, loai_hop_dong, 
                 ngay_ky, ngay_het_han, muc_luong_co_ban, trang_thai)
                VALUES
                (@id_hop_dong, @id_nhan_su, @ten_hop_dong, @loai_hop_dong, 
                 @ngay_ky, @ngay_het_han, @muc_luong_co_ban, @trang_thai)";

                    using (SqlCommand cmd = new SqlCommand(insertHopDong, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_hop_dong", newHopDongId);
                        cmd.Parameters.AddWithValue("@id_nhan_su", cbMaNS.SelectedValue);
                        cmd.Parameters.AddWithValue("@ten_hop_dong", txtTenHD.Text.Trim());
                        cmd.Parameters.AddWithValue("@loai_hop_dong", txtLoaiHD.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngay_ky", dtpNgayKy.Value);
                        cmd.Parameters.AddWithValue("@ngay_het_han", dtpNgayHetHan.Value);
                        cmd.Parameters.AddWithValue("@muc_luong_co_ban", numLuong.Value);
                        cmd.Parameters.AddWithValue("@trang_thai", txtTrangThai.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHopDong();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string numberPart = lastId.Length > prefix.Length
                        ? lastId.Substring(prefix.Length)
                        : "0";

                    if (int.TryParse(numberPart, out int num))
                        nextNumber = num + 1;
                }

                return $"{prefix}{nextNumber:D3}";
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaHD.Text))
                {
                    MessageBox.Show("Vui lòng chọn hợp đồng cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateData()) return;

                using (SqlConnection conn = DatabaseNhanSuHelper.GetConnection())
                {
                    conn.Open();

                    string updateQuery = @"
                UPDATE Hop_dong
                SET id_nhan_su = @id_nhan_su,
                    ten_hop_dong = @ten_hop_dong,
                    loai_hop_dong = @loai_hop_dong,
                    ngay_ky = @ngay_ky,
                    ngay_het_han = @ngay_het_han,
                    muc_luong_co_ban = @muc_luong_co_ban,
                    trang_thai = @trang_thai
                WHERE id_hop_dong = @id_hop_dong";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_hop_dong", txtMaHD.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_nhan_su", cbMaNS.SelectedValue);
                        cmd.Parameters.AddWithValue("@ten_hop_dong", txtTenHD.Text.Trim());
                        cmd.Parameters.AddWithValue("@loai_hop_dong", txtLoaiHD.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngay_ky", dtpNgayKy.Value);
                        cmd.Parameters.AddWithValue("@ngay_het_han", dtpNgayHetHan.Value);
                        cmd.Parameters.AddWithValue("@muc_luong_co_ban", numLuong.Value);
                        cmd.Parameters.AddWithValue("@trang_thai", txtTrangThai.Text.Trim());

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Cập nhật hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadHopDong();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy hợp đồng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa hợp đồng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM Hop_dong WHERE id_hop_dong=@id_hop_dong";
                SqlParameter[] p = { new SqlParameter("@id_hop_dong", txtMaHD.Text) };

                if (DatabaseNhanSuHelper.ExecuteNonQuery(query, p) > 0)
                {
                    MessageBox.Show("Xóa hợp đồng thành công!");
                    LoadHopDong();
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

            string query = @"SELECT * FROM Hop_dong 
                             WHERE id_hop_dong LIKE @kw 
                                OR id_nhan_su LIKE @kw 
                                OR ten_hop_dong LIKE @kw 
                                OR loai_hop_dong LIKE @kw 
                                OR trang_thai LIKE @kw";

            SqlParameter[] parameters = { new SqlParameter("@kw", "%" + keyword + "%") };
            dgvHopDong.DataSource = DatabaseNhanSuHelper.ExecuteQuery(query, parameters);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadHopDong();
        }

        private void ClearFields()
        {
            txtMaHD.Clear();
            txtTenHD.Clear();
            txtLoaiHD.Clear();
            txtTrangThai.Clear();
            numLuong.Value = 0;

            if (cbMaNS.Items.Count > 0)
                cbMaNS.SelectedIndex = 0;

            dtpNgayKy.Value = DateTime.Now;
            dtpNgayHetHan.Value = DateTime.Now;
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
        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvHopDong.Rows[e.RowIndex];

            // Gán dữ liệu từ dòng được chọn
            txtMaHD.Text = row.Cells["id_hop_dong"].Value?.ToString() ?? "";
            cbMaNS.SelectedValue = row.Cells["id_nhan_su"].Value?.ToString() ?? "";
            txtTenHD.Text = row.Cells["ten_hop_dong"].Value?.ToString() ?? "";
            txtLoaiHD.Text = row.Cells["loai_hop_dong"].Value?.ToString() ?? "";

            var ngayKyVal = row.Cells["ngay_ky"].Value;
            if (ngayKyVal != null && ngayKyVal != DBNull.Value && DateTime.TryParse(ngayKyVal.ToString(), out DateTime ngayKy))
                dtpNgayKy.Value = ngayKy;
            else
                dtpNgayKy.Value = DateTime.Now;

            var ngayHetHanVal = row.Cells["ngay_het_han"].Value;
            if (ngayHetHanVal != null && ngayHetHanVal != DBNull.Value && DateTime.TryParse(ngayHetHanVal.ToString(), out DateTime ngayHH))
                dtpNgayHetHan.Value = ngayHH;
            else
                dtpNgayHetHan.Value = DateTime.Now;

            if (row.Cells["muc_luong_co_ban"].Value != null && decimal.TryParse(row.Cells["muc_luong_co_ban"].Value.ToString(), out decimal luong))
                numLuong.Value = luong;
            else
                numLuong.Value = 0;

            txtTrangThai.Text = row.Cells["trang_thai"].Value?.ToString() ?? "";
        }

    }
}