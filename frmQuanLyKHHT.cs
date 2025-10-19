using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmQuanLyKHHT : Form
    {
        public frmQuanLyKHHT()
        {
            InitializeComponent();
            LoadMonHoc();
            LoadComboBox();
            LoadCboHocPhan();
        }
        private void LoadComboBox()
        {
            // Load ngành
            string queryNganh = "SELECT id_nganh, ten_nganh FROM Nganh";
            DataTable dtNganh = DatabaseDaoTaoHelper.ExecuteQuery(queryNganh);
            cboNganh.DataSource = dtNganh;
            cboNganh.DisplayMember = "ten_nganh";
            cboNganh.ValueMember = "id_nganh";

            
            // Load học kỳ
            string queryHocKy = "SELECT id_hoc_ky, ten_hoc_ky FROM Hoc_ky";
            DataTable dtHocKy = DatabaseDaoTaoHelper.ExecuteQuery(queryHocKy);
            cboHocKy.DataSource = dtHocKy;
            cboHocKy.DisplayMember = "ten_hoc_ky";
            cboHocKy.ValueMember = "id_hoc_ky";


        }
        private void LoadCboHocPhan()
        {
            // Load học phần
            string queryHocPhan = "SELECT id_hoc_phan, ten_hoc_phan FROM Hoc_phan WHERE id_nganh = @idNganh";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idNganh", cboNganh.SelectedValue)
            };
            DataTable dtHocPhan = DatabaseDaoTaoHelper.ExecuteQuery(queryHocPhan, parameters);
            cboHocPhan.DataSource = dtHocPhan;
            cboHocPhan.DisplayMember = "ten_hoc_phan";
            cboHocPhan.ValueMember = "id_hoc_phan";
        }

        private void LoadMonHoc()
        {
            string query = @"SELECT kh.id_ke_hoach, kh.id_hoc_phan, hp.ten_hoc_phan, n.ten_nganh,kh.id_hoc_ky, hk.ten_hoc_ky, 
                           kh.id_nganh, hp.so_tin_chi, hp.loai_hoc_phan
                           FROM Ke_hoach_ht kh
                           JOIN Nganh n ON kh.id_nganh = n.id_nganh
                           JOIN Hoc_phan hp ON hp.id_hoc_phan = kh.id_hoc_phan
                            JOIN Hoc_ky hk ON hk.id_hoc_ky = kh.id_hoc_ky";
            DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query);
            dgvHocPhan.AutoGenerateColumns = false;
            dgvHocPhan.DataSource = dt;
            dt.Columns.Add("STT", typeof(int));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }
            dgvHocPhan.Columns["STT"].DisplayIndex = 0;
        }
        private bool CheckDuplicate(string maHocPhan, string maNganh)
        {
            string query = @"SELECT COUNT(*) FROM Ke_hoach_ht 
                             WHERE id_hoc_phan = @MaHocPhan 
                             AND id_nganh = @MaNganh";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHocPhan", maHocPhan),
                new SqlParameter("@MaNganh", maNganh)
            };
            object result = DatabaseDaoTaoHelper.ExecuteScalar(query, parameters);
            int count = (result != null) ? Convert.ToInt32(result) : 0;
            return count > 0;
        }
        private bool CheckDuplicateHocKy(string id,string newid)
        {

             string query = @"SELECT id_hoc_ky FROM Ke_hoach_ht 
                             WHERE id_ke_hoach = @MaKH";

            SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@MaKH", id)
            };
            object result = DatabaseDaoTaoHelper.ExecuteScalar(query, parameters);
            string existingHocKy = (result != null) ? result.ToString() : "";
            return existingHocKy == newid;

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(cboHocPhan.SelectedIndex == -1 || cboHocKy.SelectedIndex == -1 || cboNganh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CheckDuplicate(cboHocPhan.SelectedValue.ToString(), cboNganh.SelectedValue.ToString()))
            {
                MessageBox.Show("Học phần này đã tồn tại trong kế hoạch học tập của ngành!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string query = @"INSERT INTO Ke_hoach_ht(id_ke_hoach,id_hoc_phan, id_hoc_ky, id_nganh) 
                             VALUES (@MaKH, @MaHocPhan, @MaHocKy, @MaNganh)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@MaKH", Guid.NewGuid().ToString()),
                new SqlParameter("@MaHocPhan", cboHocPhan.SelectedValue),
                new SqlParameter("@MaHocKy", cboHocKy.SelectedValue),
                new SqlParameter("@MaNganh", cboNganh.SelectedValue)
                };

                int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Thêm tiến độ học tập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMonHoc();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm tiến độ học tập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tiến độ học tập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvHocPhan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn tiến độ học tập cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cboHocPhan.SelectedIndex == -1 || cboHocKy.SelectedIndex == -1 || cboNganh.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (CheckDuplicate(cboHocPhan.SelectedValue.ToString(), cboNganh.SelectedValue.ToString()) &&
                    CheckDuplicateHocKy(dgvHocPhan.SelectedRows[0].Cells["id_ke_hoach"].Value.ToString(), cboHocKy.SelectedValue.ToString()))
                {
                    MessageBox.Show("Học phần này đã tồn tại trong kế hoạch học tập của ngành!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string query = @"UPDATE Ke_hoach_ht 
                             SET id_hoc_phan = @MaHocPhan, id_hoc_ky = @MaHocKy, id_nganh = @MaNganh
                             WHERE id_ke_hoach = @MaKH";
                SqlParameter[] parameters = new SqlParameter[]
                    {
                new SqlParameter("@MaKH", dgvHocPhan.SelectedRows[0].Cells["id_ke_hoach"].Value),
                new SqlParameter("@MaHocPhan", cboHocPhan.SelectedValue),
                new SqlParameter("@MaHocKy", cboHocKy.SelectedValue),
                new SqlParameter("@MaNganh", cboNganh.SelectedValue)
                };

                int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật tiến độ học tập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMonHoc();
                }
                else
                {
                    MessageBox.Show("Cập nhật tiến độ học tập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tiến độ học tập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHocPhan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn tiến độ học tập cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa tiến độ học tập này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query = "DELETE FROM Ke_hoach_ht WHERE id_ke_hoach = @MaKH";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                    new SqlParameter("@MaKH", dgvHocPhan.SelectedRows[0].Cells["id_ke_hoach"].Value)
                    };

                    int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMonHoc();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tiến độ học tập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMonHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHocPhan.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvHocPhan.SelectedRows[0];
                cboHocPhan.SelectedValue = row.Cells["id_hoc_phan"].Value;
                cboHocKy.SelectedValue = row.Cells["id_hoc_ky"].Value;
                cboNganh.SelectedValue = row.Cells["id_nganh"].Value;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string query = @"SELECT kh.id_hoc_phan, hp.ten_hoc_phan, n.ten_nganh,kh.id_hoc_ky, hk.ten_hoc_ky, 
                           kh.id_nganh, hp.so_tin_chi, hp.loai_hoc_phan, hp.dieu_kien 
                           FROM Ke_hoach_ht kh
                           JOIN Nganh n ON kh.id_nganh = n.id_nganh
                           JOIN Hoc_phan hp ON hp.id_hoc_phan = kh.id_hoc_phan
                            JOIN Hoc_ky hk ON hk.id_hoc_ky = kh.id_hoc_ky
                           WHERE hk.ten_hoc_ky LIKE @Keyword OR n.ten_nganh LIKE @Keyword";
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadMonHoc();
            ClearFields();
            txtTimKiem.Clear();
        }

        private void ClearFields()
        {
            cboHocPhan.SelectedIndex = -1;
            cboHocKy.SelectedIndex = -1;
            cboNganh.SelectedIndex = -1;

        }

        private void cboNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboHocPhan.SelectedIndex = -1;
            LoadCboHocPhan();

        }
    }
}