using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmQuanLyNguoiDung : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["QLNguoiDungConnectionString"].ConnectionString;
        public frmQuanLyNguoiDung()
        {
            InitializeComponent();
            LoadNguoiDung();
            LoadComboBoxTimKiem();

            LoadComboBox();
        }
        #region functions

      
        private void LoadNguoiDung()
        {
            string query = @"SELECT 
            nd.id_nguoi_dung,
            nd.tai_khoan AS [Tài khoản],
            nd.mat_khau AS [Mật khẩu],
            pq.ten_quyen AS [Quyền]
            FROM dbo.Nguoi_dung nd
            INNER JOIN dbo.Phan_quyen pq ON nd.id_quyen = pq.id_quyen";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                
                dt.Columns.Add("STT", typeof(int));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                }

                
                dt.Columns["STT"].SetOrdinal(0);

                dgvNguoiDung.DataSource = dt;

                if (dgvNguoiDung.Columns.Contains("id_nguoi_dung"))
                    dgvNguoiDung.Columns["id_nguoi_dung"].Visible = false;
                dgvNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            LoadThongKe();
        }

        private void LoadComboBox()
        {
            string queryCN = "SELECT id_quyen, ten_quyen FROM dbo.Phan_quyen";
            DataTable dtCN = DatabaseNguoiDungHelper.ExecuteQuery(queryCN);
            cboRole.DataSource = dtCN;
            cboRole.DisplayMember = "ten_quyen";
            cboRole.ValueMember = "id_quyen";
        }
        private void ClearFields()
        {
            txtID.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            if (cboRole.Items.Count > 0)
                cboRole.SelectedIndex = 0;
        }
        private void LoadThongKe()
        {
            // Tổng số tài khoản
            string queryTong = "SELECT COUNT(*) FROM dbo.Nguoi_dung";
            int tong = Convert.ToInt32(DatabaseNguoiDungHelper.ExecuteScalar(queryTong));
            lblTong.Text = tong.ToString();

            // Số sinh viên
            string querySV = @"
        SELECT COUNT(*) 
        FROM dbo.Nguoi_dung nd
        INNER JOIN dbo.Phan_quyen pq ON nd.id_quyen = pq.id_quyen
        WHERE pq.ten_quyen = N'Sinh viên'";
            int soSV = Convert.ToInt32(DatabaseNguoiDungHelper.ExecuteScalar(querySV));
            lblSV.Text = soSV.ToString();

            // Số giảng viên
            string queryGV = @"
        SELECT COUNT(*) 
        FROM dbo.Nguoi_dung nd
        INNER JOIN dbo.Phan_quyen pq ON nd.id_quyen = pq.id_quyen
        WHERE pq.ten_quyen = N'Giảng viên'";
            int soGV = Convert.ToInt32(DatabaseNguoiDungHelper.ExecuteScalar(queryGV));
            lblGV.Text = soGV.ToString();

            // Khác
            string queryKhac = @"
        SELECT COUNT(*) 
        FROM dbo.Nguoi_dung nd
        INNER JOIN dbo.Phan_quyen pq ON nd.id_quyen = pq.id_quyen
        WHERE pq.ten_quyen NOT IN (N'Sinh viên', N'Giảng viên')";
            int soKhac = Convert.ToInt32(DatabaseNguoiDungHelper.ExecuteScalar(queryKhac));
            lblKhac.Text = soKhac.ToString();
        }
        private void LoadComboBoxTimKiem()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Value");
            dt.Columns.Add("Text");

            dt.Rows.Add("All", "Tất cả");
            dt.Rows.Add("Username", "Tài khoản");
            dt.Rows.Add("Role", "Quyền");

            cboTimKiem.DataSource = dt;
            cboTimKiem.DisplayMember = "Text";
            cboTimKiem.ValueMember = "Value";
            cboTimKiem.SelectedIndex = 0; // Mặc định là "Tất cả"
        }


        #endregion
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra trùng ID người dùng
                    string checkIDQuery = "SELECT COUNT(*) FROM dbo.Nguoi_dung WHERE id_nguoi_dung = N'" + txtID.Text.Trim() + "'";
                    SqlCommand cmdCheckID = new SqlCommand(checkIDQuery, conn);
                    int idCount = (int)cmdCheckID.ExecuteScalar();

                    if (idCount > 0)
                    {
                        MessageBox.Show("ID người dùng này đã tồn tại! Vui lòng nhập ID khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra trùng tài khoản
                    string checkQuery = "SELECT COUNT(*) FROM dbo.Nguoi_dung WHERE tai_khoan = N'" + txtUsername.Text.Trim() + "'";
                    SqlCommand cmdCheck = new SqlCommand(checkQuery, conn);
                    int count = (int)cmdCheck.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Tên đăng nhập này đã tồn tại! Vui lòng chọn tên khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Thêm người dùng mới
                    string query = "INSERT INTO dbo.Nguoi_dung(id_nguoi_dung, tai_khoan, mat_khau, id_quyen) " +
                                   "VALUES (N'" + txtID.Text.Trim() + "', N'" + txtUsername.Text.Trim() + "', N'" + txtPassword.Text.Trim() + "', '" + cboRole.SelectedValue.ToString() + "')";

                    SqlCommand cmdInsert = new SqlCommand(query, conn);
                    int result = cmdInsert.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNguoiDung();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Thêm người dùng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNguoiDung.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn người dùng cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboRole.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn quyền cho người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string id = txtID.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string role = cboRole.SelectedValue.ToString();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra xem người dùng có tồn tại không
                    string queryCheck = "SELECT COUNT(*) FROM dbo.Nguoi_dung WHERE id_nguoi_dung = N'" + id + "'";
                    SqlCommand cmdCheck = new SqlCommand(queryCheck, conn);
                    int count = (int)cmdCheck.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không tìm thấy người dùng cần cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Cập nhật người dùng
                    string queryUpdate = "UPDATE dbo.Nguoi_dung " +
                                         "SET tai_khoan = N'" + username + "', " +
                                         "mat_khau = N'" + password + "', " +
                                         "id_quyen = '" + role + "' " +
                                         "WHERE id_nguoi_dung = N'" + id + "'";

                    SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conn);
                    int rows = cmdUpdate.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNguoiDung();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu nào được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNguoiDung.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn người dùng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string id = dgvNguoiDung.CurrentRow.Cells["id_nguoi_dung"].Value.ToString();
                string taikhoan = dgvNguoiDung.CurrentRow.Cells["Tài khoản"].Value.ToString();

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa người dùng '{taikhoan}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query = "DELETE FROM dbo.Nguoi_dung WHERE id_nguoi_dung = '" + id + "'";
                    int result = DatabaseNguoiDungHelper.ExecuteNonQuery(query);

                    if (result > 0)
                    {
                        MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNguoiDung();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



     
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                string loaiTimKiem = cboTimKiem.SelectedValue.ToString();

                string query = @"
        SELECT 
            n.id_nguoi_dung,
            n.tai_khoan AS [Tài khoản],
            n.mat_khau AS [Mật khẩu],
            pq.ten_quyen AS [Quyền]
        FROM dbo.Nguoi_dung n
        INNER JOIN dbo.Phan_quyen pq ON n.id_quyen = pq.id_quyen
        WHERE 1=1";

                if (loaiTimKiem == "Username" && !string.IsNullOrEmpty(keyword))
                {
                    query += " AND n.tai_khoan LIKE N'%" + keyword + "%'";
                }
                else if (loaiTimKiem == "Role" && !string.IsNullOrEmpty(keyword))
                {
                    query += " AND pq.ten_quyen LIKE N'%" + keyword + "%'";
                }
                else if (loaiTimKiem == "All" && !string.IsNullOrEmpty(keyword))
                {
                    query += " AND (n.tai_khoan LIKE N'%" + keyword + "%' OR pq.ten_quyen LIKE N'%" + keyword + "%')";
                }

                DataTable dt = DatabaseNguoiDungHelper.ExecuteQuery(query);

                if (dt == null)
                {
                    MessageBox.Show("Không thể lấy dữ liệu từ cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thêm cột STT
                dt.Columns.Add("STT", typeof(int));
                for (int i = 0; i < dt.Rows.Count; i++)
                    dt.Rows[i]["STT"] = i + 1;
                dt.Columns["STT"].SetOrdinal(0);

                dgvNguoiDung.DataSource = dt;

                if (dgvNguoiDung.Columns.Contains("id_nguoi_dung"))
                    dgvNguoiDung.Columns["id_nguoi_dung"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadNguoiDung();
            ClearFields();
            txtTimKiem.Clear();
        }
                         

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Lấy form cha (frmMain_NguoiDung)
            //Form parentForm = this.ParentForm;
            var parentForm = this.ParentForm as frmMain_NguoiDung;

            // Xóa form con ra khỏi panel cha (panelMain)
            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
            }

            // Giải phóng form con
            this.Dispose();
            parentForm?.ShowBackGround();
            
        }

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtID.Text = dgvNguoiDung.Rows[e.RowIndex].Cells["id_nguoi_dung"].Value?.ToString();
                txtUsername.Text = dgvNguoiDung.Rows[e.RowIndex].Cells["Tài khoản"].Value?.ToString();
                txtPassword.Text = dgvNguoiDung.Rows[e.RowIndex].Cells["Mật khẩu"].Value?.ToString();
                cboRole.Text = dgvNguoiDung.Rows[e.RowIndex].Cells["Quyền"].Value?.ToString();
            }
        }
    }
}