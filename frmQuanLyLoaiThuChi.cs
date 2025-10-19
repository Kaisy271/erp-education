using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmQuanLyLoaiThuChi : Form
    {
        private string selected_id_loai_tc = null; // Biến lưu ID của dòng đang chọn

        public frmQuanLyLoaiThuChi()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void frmQuanLyLoaiThuChi_Load(object sender, EventArgs e)
        {
            LoadData();

            // Gán sự kiện
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnLamMoi.Click += btnLamMoi_Click;
        }

        private void LoadData()
        {
            string query = "SELECT id_loai_tc, ten_loai FROM Loai_thu_chi;";
            try
            {
                DataTable dt = DatabaseTaiChinhHelper.ExecuteQuery(query);
                dataGridView1.DataSource = dt;
                dt.Columns.Add("STT", typeof(int));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                }
                dataGridView1.Columns["STT"].DisplayIndex = 0;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                selected_id_loai_tc = row.Cells["id_loai_tc"].Value?.ToString();
                txtMaLoai.Text = selected_id_loai_tc; 
                txtTenLoai.Text = row.Cells["ten_loai"].Value?.ToString(); 
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại thu chi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO Loai_thu_chi (id_loai_tc, ten_loai) VALUES (@id, @ten)";
            string newId = "TC" + DateTime.Now.Ticks.ToString();

            SqlParameter[] parameters = {
                new SqlParameter("@id", newId),
                new SqlParameter("@ten", txtTenLoai.Text.Trim())
            };

            try
            {
                if (DatabaseTaiChinhHelper.ExecuteNonQuery(query, parameters) > 0)
                {
                    MessageBox.Show("Thêm loại thu chi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selected_id_loai_tc))
            {
                MessageBox.Show("Vui lòng chọn một mục để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Loai_thu_chi SET ten_loai = @ten WHERE id_loai_tc = @id";
            SqlParameter[] parameters = {
                new SqlParameter("@ten", txtTenLoai.Text.Trim()),
                new SqlParameter("@id", selected_id_loai_tc)
            };

            try
            {
                if (DatabaseTaiChinhHelper.ExecuteNonQuery(query, parameters) > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selected_id_loai_tc))
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "DELETE FROM Loai_thu_chi WHERE id_loai_tc = @id";
                SqlParameter[] parameters = { new SqlParameter("@id", selected_id_loai_tc) };

                try
                {
                    DatabaseTaiChinhHelper.ExecuteNonQuery(query, parameters);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = "SELECT id_loai_tc, ten_loai FROM Loai_thu_chi WHERE ten_loai LIKE @keyword OR id_loai_tc LIKE @keyword";
            SqlParameter[] parameters = { new SqlParameter("@keyword", "%" + txtTimKiem.Text.Trim() + "%") };
            try
            {
                DataTable dt = DatabaseTaiChinhHelper.ExecuteQuery(query, parameters);
                dataGridView1.DataSource = dt;
                dt.Columns.Add("STT", typeof(int));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                }
                dataGridView1.Columns["STT"].DisplayIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadData();
        }

        private void ClearFields()
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            txtTimKiem.Text = "";
            selected_id_loai_tc = null;
            dataGridView1.ClearSelection();
        }
    }
}