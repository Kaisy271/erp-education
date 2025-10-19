using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmQuanLyLop : Form
    {
        public frmQuanLyLop()
        {
            InitializeComponent();
            LoadLopHoc();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            // Load ngành
            string queryNganh = "SELECT id_nganh, ten_nganh FROM Nganh";
            DataTable dtNganh = DatabaseDaoTaoHelper.ExecuteQuery(queryNganh);
            cboNganh.DataSource = dtNganh;
            cboNganh.DisplayMember = "ten_nganh";
            cboNganh.ValueMember = "id_nganh";

            // Load giáo viên chủ nhiệm
            string queryGV = "SELECT id_gv, ho_ten FROM Giang_vien";
            DataTable dtGV = DatabaseDaoTaoHelper.ExecuteQuery(queryGV);
            cboGvcn.DataSource = dtGV;
            cboGvcn.DisplayMember = "ho_ten";
            cboGvcn.ValueMember = "id_gv";
        }

        private void LoadLopHoc()
        {
            string query = @"SELECT l.id_lop, l.ten_lop,l.khoa_hoc, n.ten_nganh, gv.ho_ten, 
                           l.id_nganh, l.id_gv
                           FROM Lop l
                           JOIN Nganh n ON l.id_nganh = n.id_nganh
                           LEFT JOIN Giang_vien gv ON l.id_gv = gv.id_gv";
            DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query);
            dgvLopHoc.DataSource = dt;
            dt.Columns.Add("STT", typeof(int));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }
            dgvLopHoc.Columns["STT"].DisplayIndex = 0;
            dgvLopHoc.AutoGenerateColumns = false;
            dgvLopHoc.Columns["id_nganh"].Visible = false;
            dgvLopHoc.Columns["id_gv"].Visible = false;
        }
        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboNganh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn ngành!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboGvcn.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giáo viên chủ nhiệm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtKhoa_hoc.Text))
            {
                MessageBox.Show("Vui lòng nhập khóa học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            return true;
        }
        private bool CheckLopExists(string tenLop)
        {
            string query = "SELECT COUNT(*) FROM Lop WHERE ten_lop = @TenLop";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenLop", tenLop)
            };
            int count = (int)DatabaseDaoTaoHelper.ExecuteScalar(query, parameters);
            return count > 0;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Validate())
                return;
            if (CheckLopExists(txtTenLop.Text))
            {
                MessageBox.Show("Lớp học đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string query = "INSERT INTO Lop(id_lop, ten_lop, id_nganh, id_gv, khoa_hoc) VALUES (@MaLop, @TenLop, @MaNganh, @MaGV, @KhoaHoc)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@MaLop", txtTenLop.Text),
                new SqlParameter("@TenLop", txtTenLop.Text),
                new SqlParameter("@MaNganh", cboNganh.SelectedValue),
                new SqlParameter("@MaGV", cboGvcn.SelectedValue),
                new SqlParameter("@KhoaHoc", txtKhoa_hoc.Text)
                };

                int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Thêm lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLopHoc();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm lớp học thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLopHoc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Validate())
                return;
            if(txtTenLop.Text != dgvLopHoc.SelectedRows[0].Cells["ten_lop"].Value.ToString() && CheckLopExists(txtTenLop.Text))
            {
                MessageBox.Show("Lớp học đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string query = "UPDATE Lop SET ten_lop=@ten_lop, id_nganh=@id_nganh, id_gv=@id_gv, khoa_hoc = @khoa_hoc WHERE id_lop=@id_lop";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@ten_lop", txtTenLop.Text),
                new SqlParameter("@khoa_hoc", txtKhoa_hoc.Text),
                new SqlParameter("@id_nganh", cboNganh.SelectedValue),
                new SqlParameter("@id_gv", cboGvcn.SelectedValue),
                new SqlParameter("@id_lop", dgvLopHoc.SelectedRows[0].Cells["id_lop"].Value)
                };

                int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLopHoc();
                }
                else
                {
                    MessageBox.Show("Cập nhật lớp học thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLopHoc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa lớp học này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "DELETE FROM Lop WHERE id_lop=@id_lop";
                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@id_lop", dgvLopHoc.SelectedRows[0].Cells["id_lop"].Value)
                };

                int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Xóa lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLopHoc();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Xóa lớp học thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvLopHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLopHoc.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dgvLopHoc.SelectedRows[0];

                    // Xử lý tên lớp
                    txtTenLop.Text = row.Cells["ten_lop"].Value?.ToString() ?? "";
                    txtKhoa_hoc.Text = row.Cells["khoa_hoc"].Value?.ToString() ?? "";


                    // Xử lý ngành
                    if (row.Cells["id_nganh"].Value != null)
                        cboNganh.SelectedValue = row.Cells["id_nganh"].Value;

                    // Xử lý giáo viên CN
                    if (row.Cells["id_gv"].Value != null)
                        cboGvcn.SelectedValue = row.Cells["id_gv"].Value;
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
            string query = @"SELECT l.id_lop, l.ten_lop,l.khoa_hoc, n.ten_nganh, gv.ho_ten AS TenGiaoVienCN, 
                           l.id_nganh, l.id_gv
                           FROM Lop l
                           JOIN Nganh n ON l.id_nganh = n.id_nganh
                           LEFT JOIN Giang_vien gv ON l.id_gv = gv.id_gv
                           WHERE l.ten_lop LIKE @Keyword OR n.ten_nganh LIKE @Keyword OR gv.ho_ten LIKE @Keyword OR l.khoa_hoc LIKE @Keyword" ;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Keyword", $"%{keyword}%")
            };

            DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query, parameters);
            dgvLopHoc.DataSource = dt;
            dt.Columns.Add("STT", typeof(int));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }
            dgvLopHoc.Columns["STT"].DisplayIndex = 0;
            dgvLopHoc.Columns["id_nganh"].Visible = false;
            dgvLopHoc.Columns["id_gv"].Visible = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadLopHoc();
            ClearFields();
            txtTimKiem.Clear();
        }

        private void ClearFields()
        {
            txtTenLop.Clear();
            if (cboNganh.Items.Count > 0)
                cboNganh.SelectedIndex = 0;
            if (cboGvcn.Items.Count > 0)
                cboGvcn.SelectedIndex = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}