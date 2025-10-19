using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmQuanLyLopHp : Form
    {
        public frmQuanLyLopHp()
        {
            InitializeComponent();
            LoadLopHocPhan();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            // Load gv
            string queryHS = "SELECT id_gv, ho_ten FROM Giang_vien";
            DataTable dtHS = DatabaseDaoTaoHelper.ExecuteQuery(queryHS);
            cboGiangVien.DataSource = dtHS;
            cboGiangVien.DisplayMember = "ho_ten";
            cboGiangVien.ValueMember = "id_gv";

            // Load trạng thái
            cboTrangThai.Items.Add("Chờ xếp lớp");
            cboTrangThai.Items.Add("Đang mở");
            cboTrangThai.Items.Add("Hoàn thành");

            // Load học kỳ
            string queryHK = "SELECT id_hoc_ky,ten_hoc_ky FROM Hoc_ky ";
            DataTable dtHk = DatabaseDaoTaoHelper.ExecuteQuery(queryHK);
            cbHocKy.DataSource = dtHk;
            cbHocKy.DisplayMember = "ten_hoc_ky";
            cbHocKy.ValueMember = "id_hoc_ky";

            //Load học phần
            string queryHP = "SELECT id_hoc_phan,ten_hoc_phan FROM Hoc_phan ";
            DataTable dtHp = DatabaseDaoTaoHelper.ExecuteQuery(queryHP);
            cboHocPhan.DataSource = dtHp;
            cboHocPhan.DisplayMember = "ten_hoc_phan";
            cboHocPhan.ValueMember = "id_hoc_phan";

            //Load ngành
            string queryNganh = "SELECT id_nganh,ten_nganh FROM Nganh ";
            DataTable dtNganh = DatabaseDaoTaoHelper.ExecuteQuery(queryNganh);
            cboNganh.DataSource = dtNganh;
            cboNganh.DisplayMember = "ten_nganh";
            cboNganh.ValueMember = "id_nganh";
        }

        private void LoadLopHocPhan()
        {
            string query = "SELECT \r\n    lhp.id_lop_hp,\r\n    lhp.id_hoc_phan,\r\n    hp.ten_hoc_phan,\r\n    lhp.ten_lop,\r\n    lhp.so_luong,\r\n    lhp.id_gv,\r\n    gv.ho_ten,\r\n    lhp.id_hoc_ky,\r\n    lhp.ngay_ket_thuc,\r\n    lhp.trang_thai,\r\n    COUNT(dk.id_dang_ky) as so_sv_da_dang_ky,\r\n    (lhp.so_luong - COUNT(dk.id_dang_ky)) as so_cho_trong\r\nFROM Lop_hoc_phan lhp\r\nLEFT JOIN Hoc_phan hp ON lhp.id_hoc_phan = hp.id_hoc_phan\r\nLEFT JOIN Giang_vien gv ON lhp.id_gv = gv.id_gv\r\nLEFT JOIN Dang_ky_hoc dk ON lhp.id_lop_hp = dk.id_lop_hp\r\nGROUP BY \r\n    lhp.id_lop_hp, lhp.id_hoc_phan, hp.ten_hoc_phan, lhp.ten_lop,\r\n    lhp.so_luong, lhp.id_gv, gv.ho_ten, lhp.id_hoc_ky,\r\n    lhp.ngay_ket_thuc, lhp.trang_thai\r\nORDER BY lhp.id_hoc_ky, lhp.trang_thai, lhp.id_lop_hp ";
            DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query);
            dgvLopHp.AutoGenerateColumns = false;
            dgvLopHp.DataSource = dt;
            dt.Columns.Add("STT", typeof(int));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }
            dgvLopHp.Columns["STT"].DisplayIndex = 0;
        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboHocPhan.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn học phần!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbHocKy.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn học kỳ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(numSoLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if (dtpNgayKetThuc.Value <= DateTime.Now)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(cboGiangVien.SelectedItem == null) {
                MessageBox.Show("Vui lòng chọn giảng viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private bool CheckValidate()
        {
            if (!ValidateInputs())
            {
                return false;
            }
            // Kiểm tra trùng tên lớp học phần trong cùng học kỳ
            string queryCheck = "SELECT COUNT(*) FROM Lop_hoc_phan WHERE ten_lop = @ten_lop AND id_hoc_ky = @id_hoc_ky";
            SqlParameter[] parametersCheck = new SqlParameter[]
            {
                new SqlParameter("@ten_lop", txtTenLop.Text),
                new SqlParameter("@id_hoc_ky", cbHocKy.SelectedValue)
            };
            int count = (int)DatabaseDaoTaoHelper.ExecuteScalar(queryCheck, parametersCheck);
            if (count > 0)
            {
                MessageBox.Show("Tên lớp học phần đã tồn tại trong học kỳ này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Kiểm tra số lớp tối đa của giảng viên và chuyên ngành
            string queryGv = "SELECT gv.so_lop_toi_da, gv.chuyen_nganh FROM Giang_vien gv WHERE gv.id_gv = @id_gv";
            SqlParameter[] parametersGv = new SqlParameter[]
            {
                new SqlParameter("@id_gv", cboGiangVien.SelectedValue)
            };
            DataTable dtGv = DatabaseDaoTaoHelper.ExecuteQuery(queryGv, parametersGv);
            int soLopToiDa = Convert.ToInt32(dtGv.Rows[0]["so_lop_toi_da"]);
            if(soLopToiDa <= 0) {
                MessageBox.Show("Giảng viên đạt tối đa số lớp có thể dạy!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string chuyenNganh = dtGv.Rows[0]["chuyen_nganh"].ToString();
            if(chuyenNganh != cboNganh.SelectedValue)
            {
                MessageBox.Show("Giảng viên không thuộc chuyên ngành này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if(CheckValidate() == false)
                {
                    return;
                }

                string query = "EXEC sp_TaoLopHocPhan_ThuCong\r\n    @id_lop_hp ,\r\n    @id_hoc_phan ,\r\n    @ten_lop ,\r\n    @so_luong ,\r\n    @id_gv ,\r\n    @id_hoc_ky ,\r\n    @ngay_ket_thuc ,\r\n    @trang_thai  ";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@id_lop_hp", Guid.NewGuid().ToString()),
                new SqlParameter("@id_hoc_phan", cboHocPhan.SelectedValue),
                new SqlParameter("@ten_lop", txtTenLop.Text),
                new SqlParameter("@so_luong", (int)numSoLuong.Value),
                new SqlParameter("@id_gv", cboGiangVien.SelectedValue ?? (object)DBNull.Value),
                new SqlParameter("@id_hoc_ky", cbHocKy.SelectedValue),
                new SqlParameter("@ngay_ket_thuc", dtpNgayKetThuc.Value),
                new SqlParameter("@trang_thai", cboTrangThai.SelectedItem ?? "Chờ xếp lớp")
                };

                int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Thêm lớp học phần thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLopHocPhan();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm lớp học phần thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm lớp học phần: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLopHp.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn lớp học phần cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(ValidateInputs() == false)
                {
                    return;
                }
                string query = @"UPDATE Lop_hoc_phan SET 
                            so_luong=@so_luong,
                            ngay_ket_thuc=@ngay_ket_thuc,
                            trang_thai=@trang_thai
                            WHERE id_lop_hp=@id_lop_hp";
                SqlParameter[] parameters = new SqlParameter[]
                    {
                new SqlParameter("@id_lop_hp", dgvLopHp.SelectedRows[0].Cells["id_lop_hp"].Value),
                new SqlParameter("@so_luong", (int)numSoLuong.Value),
                new SqlParameter("@ngay_ket_thuc", dtpNgayKetThuc.Value),
                new SqlParameter("@trang_thai", cboTrangThai.SelectedItem ?? "Chờ xếp lớp")
                };
                int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật số sinh viên, trạng thái, ngày kết thúc lớp học phần thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLopHocPhan();
                }
                else
                {
                    MessageBox.Show("Cập nhật lớp học phần thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật lớp học phần: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLopHp.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn lớp học phần cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa lớp học phần này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query = "DELETE FROM Lop_hoc_phan WHERE id_lop_hp = @id_lop_hp";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                    new SqlParameter("@id_lop_hp", dgvLopHp.SelectedRows[0].Cells["id_lop_hp"].Value)
                    };

                    int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa lớp học phần thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLopHocPhan();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa lớp học phần thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa lớp học phần: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhenThuong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLopHp.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvLopHp.SelectedRows[0];
                txtTenLop.Text = row.Cells["ten_lop"].Value.ToString();
                numSoLuong.Value = Convert.ToInt32(row.Cells["so_luong"].Value);
                cboGiangVien.SelectedValue = row.Cells["id_gv"].Value;
                cbHocKy.SelectedValue = row.Cells["id_hoc_ky"].Value;
                dtpNgayKetThuc.Value = Convert.ToDateTime(row.Cells["ngay_ket_thuc"].Value);
                cboTrangThai.SelectedItem = row.Cells["trang_thai"].Value.ToString();
                cboHocPhan.SelectedValue = row.Cells["id_hoc_phan"].Value;

            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                string query = @"SELECT * 
                          FROM Lop_hoc_phan lhp
                          JOIN Hoc_phan h ON lhp.id_hoc_phan = h.id_hoc_phan
                          WHERE lhp.ten_lop LIKE @Keyword OR h.ten_hoc_phan LIKE @Keyword";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@Keyword", $"%{keyword}%")
                };

                DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query, parameters);
                dgvLopHp.DataSource = dt;
                dt.Columns.Add("STT", typeof(int));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                }
                dgvLopHp.Columns["STT"].DisplayIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadLopHocPhan();
            ClearFields();
            txtTimKiem.Clear();
        }

        private void ClearFields()
        {
            if (cboGiangVien.Items.Count > 0)
                cboGiangVien.SelectedIndex = 0;
            if (cbHocKy.Items.Count > 0)
                cbHocKy.SelectedIndex = 0;
            txtTenLop.Clear();
            numSoLuong.Value = 1;
            if (cboTrangThai.Items.Count > 0)
                cboTrangThai.SelectedIndex = 0;
            if (cboHocPhan.Items.Count > 0)
                cboHocPhan.SelectedIndex = 0;
            dtpNgayKetThuc.Value = DateTime.Now;
        }

        private void btnThemAuTo_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboNganh.SelectedValue == null || cbHocKy.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn ngành và học kỳ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string queryHp = "EXEC sp_TaoLopHocPhan @id_hoc_ky , @id_nganh";
                string queryDK = "EXEC sp_TaoDangKyHocTuDong @id_hoc_ky , @id_nganh";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@id_hoc_ky", cbHocKy.SelectedValue),
                new SqlParameter("@id_nganh", cboNganh.SelectedValue)
                };
                SqlParameter[] parameter = new SqlParameter[]
                {
                new SqlParameter("@id_hoc_ky", cbHocKy.SelectedValue),
                new SqlParameter("@id_nganh", cboNganh.SelectedValue)
                };

                int result = DatabaseDaoTaoHelper.ExecuteNonQuery(queryHp, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Thêm lớp học phần thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int results = DatabaseDaoTaoHelper.ExecuteNonQuery(queryDK, parameter);
                    LoadLopHocPhan();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm lớp học phần thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm lớp học phần: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}