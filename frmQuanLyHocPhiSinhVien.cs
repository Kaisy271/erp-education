using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmQuanLyHocPhiSinhVien : Form
    {
        private string selected_id_hoc_phi_sv = null; // Biến để lưu ID của dòng đang chọn

        public frmQuanLyHocPhiSinhVien()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.SizeGripStyle = SizeGripStyle.Hide;
        }

        private void frmQuanLyTaiChinh_Load(object sender, EventArgs e)
        {
            LoadData();
            LoaiComboBox();
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnLamMoi.Click += btnLamMoi_Click;
        }

        private void LoaiComboBox()
        {
            string query = @"SELECT id_hoc_ky,ten_hoc_ky FROM QLDaoTao.dbo.Hoc_ky";
            try
            {
                DataTable dt = DatabaseTaiChinhHelper.ExecuteQuery(query);
                cbHocKy.DataSource = dt;
                cbHocKy.DisplayMember = "ten_hoc_ky";
                cbHocKy.ValueMember = "ten_hoc_ky";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học kỳ: " + ex.Message);
            }
        }

        private void LoadData()
        {
            // Thêm id_hoc_phi_sv và ho_ten vào câu truy vấn
            string query = @"
                SELECT 
                    hp.id_hoc_phi_sv, 
                    hp.id_sinh_vien, 
                    sv.ho_ten, 
                    hp.hoc_ky, 
                    hp.tong_so_tin_chi, 
                    hp.tong_so_tien, 
                    hp.trang_thai 
                FROM Hoc_phi_sv hp
                JOIN Sinh_vien sv ON hp.id_sinh_vien = sv.id_sinh_vien";
            try
            {
                DataTable dt = DatabaseTaiChinhHelper.ExecuteQuery(query);
                dataGridView1.AutoGenerateColumns = false;
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
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        // Hiển thị thông tin của dòng được chọn lên các control
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                selected_id_hoc_phi_sv = row.Cells["id_hoc_phi_sv"].Value?.ToString();
                txtMaSV.Text = row.Cells["id_sinh_vien"].Value?.ToString();
                cbHocKy.Text = row.Cells["hoc_ky"].Value?.ToString();
                numTinChi.Value = Convert.ToInt32(row.Cells["tong_so_tin_chi"].Value);
                txtSoTien.Text = Convert.ToString(row.Cells["tong_so_tien"].Value);
                cboTrangThai.Text = row.Cells["trang_thai"].Value?.ToString();
            }
        }

        // Nút Thêm (Chỉ hiển thị thông báo)
        private void btnThem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đã được tự động hóa. Để thêm học phí, bạn cần thực hiện đăng ký học phần cho sinh viên.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút Sửa (Chỉ cho phép sửa TRẠNG THÁI)
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selected_id_hoc_phi_sv))
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật trạng thái.");
                return;
            }

            string query = "UPDATE Hoc_phi_sv SET trang_thai = @trang_thai WHERE id_hoc_phi_sv = @id";

            SqlParameter[] parameters = {
                new SqlParameter("@trang_thai", cboTrangThai.SelectedValue),
                new SqlParameter("@id", selected_id_hoc_phi_sv)
            };

            try
            {
                int result = DatabaseTaiChinhHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật trạng thái thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bản ghi để cập nhật.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật trạng thái: " + ex.Message);
            }
        }

        // Nút Xóa (Chỉ hiển thị thông báo)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đã được tự động hóa. Để xóa học phí, bạn cần hủy đăng ký học phần cho sinh viên.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút Tìm kiếm (Theo mã hoặc họ tên sinh viên)
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT 
                    hp.id_hoc_phi_sv, 
                    hp.id_sinh_vien, 
                    sv.ho_ten, 
                    hp.hoc_ky, 
                    hp.tong_so_tin_chi, 
                    hp.tong_so_tien, 
                    hp.trang_thai 
                FROM Hoc_phi_sv hp
                JOIN Sinh_vien sv ON hp.id_sinh_vien = sv.id_sinh_vien
                WHERE hp.id_sinh_vien LIKE @keyword OR sv.ho_ten LIKE @keyword";

            SqlParameter[] parameters = {
                new SqlParameter("@keyword", "%" + txtTimKiem.Text + "%")
            };

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
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        // Nút Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSV.Text = "";
            cbHocKy.SelectedIndex = -1;
            numTinChi.Value = 0;
            txtSoTien.Text = "";
            cboTrangThai.SelectedIndex = -1;
            txtTimKiem.Text = "";
            selected_id_hoc_phi_sv = null;
            LoadData();
        }
    }
}