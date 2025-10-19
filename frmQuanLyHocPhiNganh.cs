using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmQuanLyHocPhiNganh : Form
    {
        // Biến để lưu ID của dòng đang được chọn trong DataGridView
        private string selected_id_hoc_phi_nganh = null;

        public frmQuanLyHocPhiNganh()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void frmQuanLyHocPhiNganh_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu cho các ComboBox trước
            LoadComboBoxes();
            // Tải dữ liệu chính cho DataGridView
            LoadData();

            // Gán các sự kiện cho nút bấm và DataGridView
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnLamMoi.Click += btnLamMoi_Click;

        }

        // Tải dữ liệu cho ComboBox Ngành và Học kỳ
        private void LoadComboBoxes()
        {
            try
            {
                // Load danh sách Ngành vào ComboBox Ngành (tên control là cbHocKy)
                cbNganh.DataSource = DatabaseTaiChinhHelper.ExecuteQuery("SELECT id_nganh, ten_nganh FROM Nganh");
                cbNganh.DisplayMember = "ten_nganh";
                cbNganh.ValueMember = "id_nganh";

                // Load danh sách các học kỳ duy nhất từ bảng Lop_hoc_phan
                // Đây là cách tốt để đảm bảo chỉ có các học kỳ hợp lệ
                cboHocKy.DataSource = DatabaseTaiChinhHelper.ExecuteQuery("SELECT DISTINCT id_hoc_ky FROM Lop_hoc_phan");
                cboHocKy.DisplayMember = "id_hoc_ky";
                cboHocKy.ValueMember = "id_hoc_ky";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách Ngành/Học kỳ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tải và hiển thị dữ liệu học phí ngành
        private void LoadData()
        {
            string query = @"
                SELECT 
                    hpn.id_hoc_phi_nganh, 
                    hpn.id_nganh, 
                    n.ten_nganh, 
                    hpn.id_hoc_ky, 
                    hpn.so_tien 
                FROM 
                    Hoc_phi_nganh hpn
                JOIN 
                    Nganh n ON hpn.id_nganh = n.id_nganh;";
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
                MessageBox.Show("Lỗi khi tải dữ liệu học phí ngành: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện khi người dùng chọn một dòng khác trong DataGridView
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                selected_id_hoc_phi_nganh = row.Cells["id_hoc_phi_nganh"].Value?.ToString();
                // Hiển thị dữ liệu từ dòng được chọn lên các control
                txtMaNganh.Text = selected_id_hoc_phi_nganh;
                cbNganh.SelectedValue = row.Cells["id_nganh"].Value;
                cboHocKy.SelectedValue = row.Cells["id_hoc_ky"].Value;
                txtSoTien.Text = Convert.ToString(row.Cells["so_tien"].Value);
            }
        }

        // Xử lý sự kiện nút "Thêm"
        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Hoc_phi_nganh (id_hoc_phi_nganh, id_nganh, id_hoc_ky, so_tien) VALUES (@id, @id_nganh, @id_hoc_ky, @so_tien)";

            SqlParameter[] parameters = {
                new SqlParameter("@id", txtMaNganh.Text),
                new SqlParameter("@id_nganh", cbNganh.SelectedValue),
                new SqlParameter("@id_hoc_ky", cboHocKy.SelectedValue),
                new SqlParameter("@so_tien", Convert.ToDecimal(txtSoTien.Text))
            };

            try
            {
                if (DatabaseTaiChinhHelper.ExecuteNonQuery(query, parameters) > 0)
                {
                    MessageBox.Show("Thêm học phí ngành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện nút "Sửa"
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selected_id_hoc_phi_nganh))
            {
                MessageBox.Show("Vui lòng chọn một mục để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Hoc_phi_nganh SET id_nganh = @id_nganh, id_hoc_ky = @id_hoc_ky, so_tien = @so_tien WHERE id_hoc_phi_nganh = @id";
            SqlParameter[] parameters = {
                new SqlParameter("@id_nganh", cbNganh.SelectedValue),
                new SqlParameter("@id_hoc_ky", cboHocKy.SelectedValue),
                new SqlParameter("@so_tien", Convert.ToDecimal(txtSoTien.Text)),
                new SqlParameter("@id", selected_id_hoc_phi_nganh)
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

        // Xử lý sự kiện nút "Xóa"
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selected_id_hoc_phi_nganh))
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "DELETE FROM Hoc_phi_nganh WHERE id_hoc_phi_nganh = @id";
                SqlParameter[] parameters = { new SqlParameter("@id", selected_id_hoc_phi_nganh) };

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

        // Xử lý sự kiện nút "Tìm kiếm"
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT hpn.*, n.ten_nganh 
                FROM Hoc_phi_nganh hpn
                JOIN Nganh n ON hpn.id_nganh = n.id_nganh
                WHERE n.ten_nganh LIKE @keyword OR hpn.id_hoc_ky LIKE @keyword";

            SqlParameter[] parameters = { new SqlParameter("@keyword", "%" + txtTimKiem.Text.Trim() + "%") };

            try
            {
                DataTable dt = DatabaseTaiChinhHelper.ExecuteQuery(query, parameters);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện nút "Làm mới"
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadData();
        }

        // Phương thức dọn dẹp các control nhập liệu
        private void ClearFields()
        {
            txtMaNganh.Text = "";
            txtTimKiem.Text = "";
            if (cbNganh.Items.Count > 0) cbNganh.SelectedIndex = 0;
            if (cboHocKy.Items.Count > 0) cboHocKy.SelectedIndex = 0;
            txtSoTien.Text = "";
            selected_id_hoc_phi_nganh = null;
            dataGridView1.ClearSelection();
        }
    }
}