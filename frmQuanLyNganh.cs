using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmQuanLyNganh : Form
    {
        public frmQuanLyNganh()
        {
            InitializeComponent();
            LoadNganh();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            string queryKhoa = "SELECT id_khoa, ten_khoa FROM Khoa";
            DataTable dtKhoa = DatabaseDaoTaoHelper.ExecuteQuery(queryKhoa);
            cbKhoa.DataSource = dtKhoa;
            cbKhoa.DisplayMember = "ten_khoa";
            cbKhoa.ValueMember = "id_khoa";
        }

        private void LoadNganh()
        {
            string query = @"SELECT n.id_nganh, n.ten_nganh, n.thoi_gian_dao_tao, k.id_khoa, k.ten_khoa
                           FROM Nganh n
                           JOIN Khoa k ON n.id_khoa = k.id_khoa";
            DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query);
            dgvNganh.DataSource = dt;
            dt.Columns.Add("STT", typeof(int));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }
            dgvNganh.Columns["STT"].DisplayIndex = 0;
            dgvNganh.AutoGenerateColumns = false;
            dgvNganh.Columns["id_khoa"].Visible = false;
        }
        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(txtMaNganh.Text))
            {
                MessageBox.Show("Mã ngành không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenNganh.Text))
            {
                MessageBox.Show("Tên ngành không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (numThoiGian.Value <= 0)
            {
                MessageBox.Show("Thời gian đào tạo phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(CheckDuplicateKhoa(cbKhoa.SelectedValue.ToString(), txtTenNganh.Text))
            {
                MessageBox.Show("Ngành này đã tồn tại trong khoa đã chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool CheckDuplicateKhoa(string maKhoa,string tenNganh)
        {
            string query = "SELECT COUNT(*) FROM Nganh WHERE id_khoa = @MaKhoa AND ten_nganh = @TenNganh";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKhoa", maKhoa),
                new SqlParameter("@TenNganh", tenNganh)
            };
            object result = DatabaseDaoTaoHelper.ExecuteScalar(query, parameters);
            int count = Convert.ToInt32(result);
            return count > 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if(!Validate())
                {
                    return;
                }
                string query = "INSERT INTO Nganh(id_nganh,ten_nganh, thoi_gian_dao_tao, id_khoa) VALUES (@MaNganh,@TenNganh, @ThoiGianDaoTao, @MaKhoa)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@TenNganh", txtTenNganh.Text),
                new SqlParameter("@MaNganh", txtMaNganh.Text),
                new SqlParameter("@ThoiGianDaoTao", numThoiGian.Value),
                new SqlParameter("@MaKhoa", cbKhoa.SelectedValue),
                };

                int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Thêm ngành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNganh();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm ngành thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm ngành: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNganh.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ngành cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Validate())
                {
                    return;
                }
                string query = "UPDATE Nganh SET ten_nganh = @TenNganh, thoi_gian_dao_tao = @ThoiGianDaoTao, id_khoa = @MaKhoa WHERE id_nganh = @MaNganh";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@TenNganh", txtTenNganh.Text),
                new SqlParameter("@ThoiGianDaoTao", numThoiGian.Value),
                new SqlParameter("@MaKhoa", cbKhoa.SelectedValue),
                new SqlParameter("@MaNganh", dgvNganh.SelectedRows[0].Cells["id_nganh"].Value)
                };

                int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật ngành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNganh();
                }
                else
                {
                    MessageBox.Show("Cập nhật ngành thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật ngành: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNganh.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ngành cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa ngành này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query = "DELETE FROM Nganh WHERE id_nganh = @MaNganh";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                    new SqlParameter("@MaNganh", dgvNganh.SelectedRows[0].Cells["id_nganh"].Value)
                    };

                    int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa ngành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNganh();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa ngành thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa ngành: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLopHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNganh.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dgvNganh.SelectedRows[0];
                    txtMaNganh.Text = row.Cells["id_nganh"].Value?.ToString() ?? "";
                    txtTenNganh.Text = row.Cells["ten_nganh"].Value?.ToString() ?? "";
                    numThoiGian.Value = Convert.ToDecimal(row.Cells["thoi_gian_dao_tao"].Value);
                    if (row.Cells["id_khoa"].Value != null)
                        cbKhoa.SelectedValue = row.Cells["id_khoa"].Value;
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
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                string query = @"SELECT n.id_nganh, n.ten_nganh, n.thoi_gian_dao_tao, k.id_khoa, k.ten_khoa
                           FROM Nganh n
                           JOIN Khoa k ON n.id_khoa = k.id_khoa
                           WHERE n.ten_nganh LIKE @Keyword OR k.ten_khoa LIKE @Keyword";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@Keyword", $"%{keyword}%")
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadNganh();
            ClearFields();
            txtTimKiem.Clear();
        }

        private void ClearFields()
        {
            txtTenNganh.Clear();
            txtTimKiem.Clear();
            txtMaNganh.Clear();
            numThoiGian.Value = 1;
            if (cbKhoa.Items.Count > 0)
                cbKhoa.SelectedIndex = 0;
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