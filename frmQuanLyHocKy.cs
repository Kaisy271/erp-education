using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmQuanLyHocKy : Form
    {
        public frmQuanLyHocKy()
        {
            InitializeComponent();
            LoadNganh();
        }
        private void LoadNganh()
        {
            string query = @"SELECT *
                           FROM Hoc_ky ";
            DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query);
            dgvNganh.DataSource = dt;
            dt.Columns.Add("STT", typeof(int));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }
            dgvNganh.Columns["STT"].DisplayIndex = 0;
            dgvNganh.AutoGenerateColumns = false;
        }
        private bool KiemTraNgayThang(string id,DateTime ngayBatDau, DateTime ngayKetThuc, out string msg)
        {
            
            msg = string.Empty;

            if (ngayBatDau >= ngayKetThuc)
            {
                msg = "Ngày bắt đầu phải nhỏ hơn ngày kết thúc.";
                return false;
            }

            string query = "SELECT id_hoc_ky, ngay_bat_dau, ngay_ket_thuc FROM Hoc_ky";
            DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                string maHocKy = row["id_hoc_ky"].ToString();

                if (!string.IsNullOrEmpty(id) && maHocKy == id)
                    continue;

                DateTime existStart = Convert.ToDateTime(row["ngay_bat_dau"]);
                DateTime existEnd = Convert.ToDateTime(row["ngay_ket_thuc"]);

                bool biTrung = ngayBatDau <= existEnd && ngayKetThuc >= existStart;
                if (biTrung)
                {
                    msg = $"Khoảng thời gian này bị trùng với học kỳ từ {existStart:dd/MM/yyyy} đến {existEnd:dd/MM/yyyy}.";
                    return false;
                }
            }

            return true;

        }
        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtTenHocKy.Text) || string.IsNullOrEmpty(txtMaHocKy.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var check = KiemTraNgayThang(txtMaHocKy.Text, dtpBatDau.Value, dtpKetThuc.Value, out string msg);
            if (!check)
            {
                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                {
                    return;
                }
                string query = "INSERT INTO Hoc_ky(id_hoc_ky,ten_hoc_ky, ngay_bat_dau, ngay_ket_thuc) VALUES (@MaHocKy,@TenHocKy, @NgayBatDau, @NgayKetThuc)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@TenHocKy", txtTenHocKy.Text),
                new SqlParameter("@MaHocKy", txtMaHocKy.Text),
                new SqlParameter("@NgayBatDau", dtpBatDau.Value),
                new SqlParameter("@NgayKetThuc", dtpKetThuc.Value),
                };

                int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Thêm học kỳ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNganh();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm học kỳ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm học kỳ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                {
                    return;
                }
                if (dgvNganh.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn học kỳ cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query = "UPDATE Hoc_ky SET ten_hoc_ky = @TenHocKy, ngay_bat_dau = @NgayBatDau, ngay_ket_thuc = @NgayKetThuc WHERE id_hoc_ky = @MaHocKy";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@TenHocKy", txtTenHocKy.Text),
                new SqlParameter("@MaHocKy", txtMaHocKy.Text),
                new SqlParameter("@NgayBatDau", dtpBatDau.Value),
                new SqlParameter("@NgayKetThuc", dtpKetThuc.Value),
                };

                int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật học kỳ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNganh();
                }
                else
                {
                    MessageBox.Show("Cập nhật học kỳ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật học kỳ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNganh.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn học kỳ cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa ngành này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query = "DELETE FROM Hoc_ky WHERE id_hoc_ky = @MaHocKy";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                    new SqlParameter("@MaHocKy", dgvNganh.SelectedRows[0].Cells["id_nganh"].Value)
                    };

                    int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa học kỳ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNganh();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa học kỳ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa học kỳ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLopHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNganh.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dgvNganh.SelectedRows[0];
                    txtMaHocKy.Text = row.Cells["id_hoc_ky"].Value?.ToString() ?? "";
                    txtTenHocKy.Text = row.Cells["ten_hoc_ky"].Value?.ToString() ?? "";
                    dtpBatDau.Value = Convert.ToDateTime(row.Cells["ngay_bat_dau"].Value);
                    dtpKetThuc.Value = Convert.ToDateTime(row.Cells["ngay_ket_thuc"].Value);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string query = @"
                SELECT *
                FROM Hoc_ky
                WHERE id_hoc_ky LIKE @keyword OR ten_hoc_ky LIKE @keyword";
            SqlParameter[] parameters = {
                new SqlParameter("@keyword", "%" + keyword + "%")
            };

            DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query, parameters);
            dgvNganh.DataSource = dt;
            dt.Columns.Add("STT", typeof(int));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }
            dgvNganh.Columns["STT"].DisplayIndex = 0;
            dgvNganh.Columns["id_khoa"].Visible = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadNganh();
            ClearFields();
            txtTimKiem.Clear();
        }

        private void ClearFields()
        {
            txtTenHocKy.Clear();
            txtMaHocKy.Clear();
            dtpBatDau.Value = DateTime.Now;
            dtpKetThuc.Value = DateTime.Now;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void frmQuanLyLop_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}