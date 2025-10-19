using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmQuanLyKhoa : Form
    {
        public frmQuanLyKhoa()
        {
            InitializeComponent();
            LoadKhoiData();
        }

        private void LoadKhoiData()
        {
            try
            {
                string query = "SELECT * FROM Khoa";
                DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query);
                dgvKhoaHoc.DataSource = dt;
                dt.Columns.Add("STT", typeof(int));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                }
                dgvKhoaHoc.Columns["STT"].DisplayIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu khối: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CheckDuplicateKhoa(string id,string tenKhoa)
        {
            string query = "SELECT COUNT(*) FROM Khoa WHERE ten_khoa = @TenKhoa and id_khoa = @MaKhoa";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenKhoa", tenKhoa),
                new SqlParameter("@MaKhoa", id)
            };
            int count = (int)DatabaseDaoTaoHelper.ExecuteScalar(query, parameters);
            return count > 0;
        }
        private bool CheckDuplicateKhoa( string tenKhoa)
        {
            string query = "SELECT COUNT(*) FROM Khoa WHERE ten_khoa = @TenKhoa ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenKhoa", tenKhoa)
            };
            int count = (int)DatabaseDaoTaoHelper.ExecuteScalar(query, parameters);
            return count > 0;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khoa!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKhoa.Focus();
                return;
            }
            if (CheckDuplicateKhoa( txtTenKhoa.Text.Trim()))
            {
                MessageBox.Show("Khoa đã tồn tại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string query = "INSERT INTO Khoa (id_khoa, ten_khoa) VALUES (@MaKhoa, @TenKhoa)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaKhoa", txtMaKhoa.Text.Trim()),
                    new SqlParameter("@TenKhoa", txtTenKhoa.Text.Trim())
                };

                int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Thêm khoa thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadKhoiData();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm khoa thất bại!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khoa: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khoa!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKhoa.Focus();
                return;
            }
            try
            {
                if (dgvKhoaHoc.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn khoa cần sửa!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTenKhoa.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khoa!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenKhoa.Focus();
                    return;
                }
                if (CheckDuplicateKhoa(dgvKhoaHoc.SelectedRows[0].Cells["id_khoa"].Value.ToString(), txtTenKhoa.Text.Trim()) || CheckDuplicateKhoa(txtTenKhoa.Text.Trim()))
                {
                    MessageBox.Show("Khoa đã tồn tại!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    string maKhoi = dgvKhoaHoc.SelectedRows[0].Cells["id_khoa"].Value.ToString();


                    string query = "UPDATE Khoa SET ten_khoa = @TenKhoa WHERE id_khoa = @MaKhoa";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
            new SqlParameter("@TenKhoa", txtTenKhoa.Text.Trim()),
            new SqlParameter("@MaKhoa", maKhoi)
                    };

                    int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật khoa thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKhoiData();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật khoa thất bại!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật khoa: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try {
                if (dgvKhoaHoc.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn khoa cần xóa!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                string maKhoi = dgvKhoaHoc.SelectedRows[0].Cells["id_khoa"].Value.ToString();
                string tenKhoi = dgvKhoaHoc.SelectedRows[0].Cells["ten_khoa"].Value.ToString();

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa khoa {tenKhoi}?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM Khoa WHERE id_khoa = @MaKhoa";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                        new SqlParameter("@MaKhoa", maKhoi)
                        };

                        int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                        if (result > 0)
                        {
                            MessageBox.Show("Xóa khoa thành công!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadKhoiData();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Xóa khoa thất bại!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa khoa: " + ex.Message,
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhoiHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhoaHoc.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvKhoaHoc.SelectedRows[0];
                txtMaKhoa.Text = row.Cells["id_khoa"].Value?.ToString() ?? "";
                txtTenKhoa.Text = row.Cells["ten_khoa"].Value?.ToString() ?? "";
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                string query = "SELECT * FROM Khoa WHERE tenKhoa LIKE @Keyword";
                SqlParameter[] parameters = new SqlParameter[]
                {
        new SqlParameter("@Keyword", $"%{keyword}%")
                };

                DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query, parameters);
                dgvKhoaHoc.DataSource = dt;
                dt.Columns.Add("STT", typeof(int));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                }
                dgvKhoaHoc.Columns["STT"].DisplayIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm khoa: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadKhoiData();
            ClearFields();
            txtTimKiem.Clear();
        }

        private void ClearFields()
        {
            txtMaKhoa.Clear(); 
            txtTenKhoa.Clear();
            dgvKhoaHoc.ClearSelection(); 
        }
     
        private void dgvKhoiHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmQuanLyKhoi_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}