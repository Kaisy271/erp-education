using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmQuanLyHocPhan : Form
    {
        public frmQuanLyHocPhan()
        {
            InitializeComponent();
            LoadMonHoc();
            LoadComboBox();
        }
        private void LoadComboBox()
        {
            try
            {
                // Load ngành
                string queryNganh = "SELECT id_nganh, ten_nganh FROM Nganh";
                DataTable dtNganh = DatabaseDaoTaoHelper.ExecuteQuery(queryNganh);
                cboNganh.DataSource = dtNganh;
                cboNganh.DisplayMember = "ten_nganh";
                cboNganh.ValueMember = "id_nganh";

                // Load loại học phần
                DataTable dt = new DataTable();
                dt.Columns.Add("Value", typeof(string));
                dt.Columns.Add("Text", typeof(string));
                dt.Rows.Add("Bắt buộc", "Bắt buộc");
                dt.Rows.Add("Tự chọn", "Tự chọn");
                cboLoaiHp.DataSource = dt;
                cboLoaiHp.DisplayMember = "Text";
                cboLoaiHp.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu cho combobox: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMonHoc()
        {
            try
            {
                string query = @"SELECT l.id_hoc_phan, l.ten_hoc_phan, n.ten_nganh,l.so_tin_chi, l.loai_hoc_phan, l.dieu_kien,
                           l.id_nganh 
                           FROM Hoc_phan l
                           JOIN Nganh n ON l.id_nganh = n.id_nganh";
                DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query);
                dgvHocPhan.DataSource = dt;
                dt.Columns.Add("STT", typeof(int));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                }
                dgvHocPhan.Columns["STT"].DisplayIndex = 0;
                dgvHocPhan.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu học phần: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtTenHocPhan.Text))
            {
                MessageBox.Show("Vui lòng nhập tên học phần!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboLoaiHp.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại học phần!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboNganh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn ngành!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (numSoTinChi.Value <= 0 || numSoTinChi.Value > 15)
            {
                MessageBox.Show("Số tín chỉ không nằm trong khoảng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(cboLoaiHp.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại học phần!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(CheckDuplicateNganh(cboNganh.SelectedValue.ToString(), txtTenHocPhan.Text))
            {
                MessageBox.Show("Học phần này đã tồn tại trong ngành đã chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool CheckDuplicateNganh(string maNganh, string tenHocPhan)
        {
            string query = "SELECT COUNT(*) FROM Hoc_phan WHERE id_nganh = @MaNganh AND ten_hoc_phan = @TenHocPhan";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNganh", maNganh),
                new SqlParameter("@TenHocPhan", tenHocPhan)
            };
            object result = DatabaseDaoTaoHelper.ExecuteScalar(query, parameters);
            int count = (result != null) ? Convert.ToInt32(result) : 0;
            return count > 0;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                {
                    return;
                }

                string query = "INSERT INTO Hoc_phan(id_hoc_phan, ten_hoc_phan, so_tin_chi, loai_hoc_phan, dieu_kien, id_nganh) VALUES (@MaHocPhan, @TenHocPhan, @SoTinChi, @LoaiHocPhan, @DieuKien, @MaNganh)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@MaHocPhan", txtMaHp.Text),
                new SqlParameter("@TenHocPhan", txtTenHocPhan.Text),
                new SqlParameter("@SoTinChi", numSoTinChi.Value),
                new SqlParameter("@LoaiHocPhan", cboLoaiHp.SelectedValue),
                new SqlParameter("@DieuKien", txtDieuKien.Text),
                new SqlParameter("@MaNganh", cboNganh.SelectedValue)
                };

                int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Thêm học phần thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMonHoc();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm học phần thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm học phần: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHocPhan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn học phần cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!ValidateInputs())
                {
                    return;
                }
                string query = "UPDATE Hoc_phan SET ten_hoc_phan = @TenHocPhan, so_tin_chi = @SoTinChi, loai_hoc_phan = @LoaiHocPhan, dieu_kien = @DieuKien, id_nganh = @MaNganh WHERE id_hoc_phan = @MaHocPhan";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@MaHocPhan", dgvHocPhan.SelectedRows[0].Cells["id_hoc_phan"].Value.ToString()),
                new SqlParameter("@TenHocPhan", txtTenHocPhan.Text),
                new SqlParameter("@SoTinChi", numSoTinChi.Value),
                new SqlParameter("@LoaiHocPhan", cboLoaiHp.SelectedValue),
                new SqlParameter("@DieuKien", txtDieuKien.Text),
                new SqlParameter("@MaNganh", cboNganh.SelectedValue)
                };

                int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật học phần thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMonHoc();
                }
                else
                {
                    MessageBox.Show("Cập nhật học phần thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật học phần: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHocPhan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn học phần cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa học phần này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query = "DELETE FROM Hoc_phan WHERE id_hoc_phan = @MaHocPhan";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                    new SqlParameter("@MaHocPhan", dgvHocPhan.SelectedRows[0].Cells["id_hoc_phan"].Value)
                    };

                    int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa học phần thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMonHoc();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa học phần thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa học phần: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMonHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHocPhan.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvHocPhan.SelectedRows[0];
                txtTenHocPhan.Text = row.Cells["ten_hoc_phan"].Value.ToString();
                txtMaHp.Text = row.Cells["id_hoc_phan"].Value.ToString();
                numSoTinChi.Value = Convert.ToInt32(row.Cells["so_tin_chi"].Value);
                cboLoaiHp.SelectedValue = row.Cells["loai_hoc_phan"].Value.ToString();
                txtDieuKien.Text = row.Cells["dieu_kien"].Value.ToString();
                cboNganh.SelectedValue = row.Cells["id_nganh"].Value.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                string query = "SELECT * FROM Hoc_phan WHERE ten_hoc_phan LIKE @Keyword";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@Keyword", $"%{keyword}%")
                };

                DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query, parameters);
                dgvHocPhan.DataSource = dt;
                dt.Columns.Add("STT", typeof(int));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                }
                dgvHocPhan.Columns["STT"].DisplayIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm học phần: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadMonHoc();
            ClearFields();
            txtTimKiem.Clear();
        }

        private void ClearFields()
        {
            txtTenHocPhan.Clear();
            txtMaHp.Clear();
            txtDieuKien.Clear();
            numSoTinChi.Value = 1;
            cboLoaiHp.SelectedIndex = -1;
            cboNganh.SelectedIndex = -1;

        }
    }
}