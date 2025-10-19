using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Education_Manager.frmDangNhap;

namespace Education_Manager
{
    public partial class frmQuanLyPhieuThu : Form
    {
        private string selected_id_phieu_thu = null; // Biến lưu ID phiếu thu

        public frmQuanLyPhieuThu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void frmQuanLyPhieuThu_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadData();

            // Gán sự kiện
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnLamMoi.Click += btnLamMoi_Click;
        }

        private void LoadComboBoxes()
        {
            // Load Sinh viên
            cboSinhVien.DataSource = DatabaseTaiChinhHelper.ExecuteQuery("SELECT id_sinh_vien, ho_ten FROM Sinh_vien");
            cboSinhVien.DisplayMember = "ho_ten";
            cboSinhVien.ValueMember = "id_sinh_vien";

            // Load Loại thu chi
            cboLoaiThuChi.DataSource = DatabaseTaiChinhHelper.ExecuteQuery("SELECT id_loai_tc, ten_loai FROM Loai_thu_chi");
            cboLoaiThuChi.DisplayMember = "ten_loai";
            cboLoaiThuChi.ValueMember = "id_loai_tc";
            // Load Học kỳ
            cboHocKy.DataSource = DatabaseTaiChinhHelper.ExecuteQuery(@"SELECT id_hoc_ky, ten_hoc_ky 
                                                                FROM QLDaoTao.dbo.Hoc_ky");
            cboHocKy.DisplayMember = "ten_hoc_ky";
            cboHocKy.ValueMember = "id_hoc_ky";
            // Load Người dùng (Người lập phiếu)
            cboNguoiLapPhieu.DataSource = DatabaseTaiChinhHelper.ExecuteQuery(@"SELECT 
            nd_taichinh.id_nguoi_dung,
            ns.ho_ten AS ten_nhan_su
	        FROM QLNhanSu.dbo.Nhan_su ns
	        LEFT JOIN Nguoi_dung ns_ndung ON ns_ndung.id_nguoi_dung = ns.id_nguoi_dung
	        LEFT JOIN QLTaiChinh.dbo.Nguoi_dung nd_taichinh ON nd_taichinh.id_nguoi_dung = ns_ndung.id_nguoi_dung");
            cboNguoiLapPhieu.DisplayMember = "ten_nhan_su";
            cboNguoiLapPhieu.ValueMember = "id_nguoi_dung";
        }

        private void LoadData()
        {
            string query = @"
                  SELECT 
                    pt.id_phieu_thu,
	                pt.id_hoc_ky,
                    pt.so_tien,
	                pt.id_loai_tc,
	                pt.id_sinh_vien,
                    pt.id_nguoi_dung,
	                sv.ho_ten,
	                ltc.ten_loai,
                    pt.ngay_thu,
                    ns.ho_ten AS ten_nhan_su
                FROM QLTaiChinh.dbo.Phieu_thu pt
                JOIN Loai_thu_chi ltc ON ltc.id_loai_tc = pt.id_loai_tc
                JOIN Sinh_vien sv ON sv.id_sinh_vien = pt.id_sinh_vien
                LEFT JOIN QLTaiChinh.dbo.Nguoi_dung nd_taichinh
                    ON pt.id_nguoi_dung = nd_taichinh.id_nguoi_dung
                LEFT JOIN QLNguoiDung.dbo.Nguoi_dung nd_nguoidung
                    ON nd_taichinh.id_nguoi_dung = nd_nguoidung.id_nguoi_dung
                LEFT JOIN QLNguoiDung.dbo.Nhan_su ns
                    ON nd_nguoidung.id_nguoi_dung = ns.id_nguoi_dung;";
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
                MessageBox.Show("Lỗi khi tải dữ liệu phiếu thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                selected_id_phieu_thu = row.Cells["id_phieu_thu"].Value?.ToString();
                txtMaPhieuThu.Text = selected_id_phieu_thu; 
                dtpNgayLap.Value = Convert.ToDateTime(row.Cells["ngay_thu"].Value);
                txtSoTien.Text = Convert.ToString(row.Cells["so_tien"].Value);
                cboHocKy.SelectedValue = row.Cells["id_hoc_ky"].Value;
                // Chọn đúng item trong ComboBox
                cboSinhVien.SelectedValue = row.Cells["id_sinh_vien"].Value;
                cboLoaiThuChi.SelectedValue = row.Cells["id_loai_tc"].Value;
                cboNguoiLapPhieu.SelectedValue = row.Cells["id_nguoi_dung"].Value;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = @"
                INSERT INTO Phieu_thu (id_phieu_thu, id_sinh_vien, id_loai_tc, id_nguoi_dung, so_tien,id_hoc_ky, ngay_thu) 
                VALUES (@id_phieu, @id_sv, @id_loai, @id_user, @so_tien,@id_hoc_ky, @ngay_thu)";
            SqlParameter[] parameters = {
                new SqlParameter("@id_phieu", txtMaPhieuThu.Text),
                new SqlParameter("@id_sv", cboSinhVien.SelectedValue),
                new SqlParameter("@id_loai", cboLoaiThuChi.SelectedValue),
                new SqlParameter("@id_user", cboNguoiLapPhieu.SelectedValue),
                new SqlParameter("@so_tien", Convert.ToDecimal(txtSoTien.Text)),
                new SqlParameter("@id_hoc_ky", cboHocKy.SelectedValue),
                new SqlParameter("@ngay_thu", dtpNgayLap.Value)
            };
            try
            {
                if (DatabaseTaiChinhHelper.ExecuteNonQuery(query, parameters) > 0)
                {
                    MessageBox.Show("Thêm phiếu thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phiếu thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(!Global.Permissions.Contains("QL_PT"))
            {
                MessageBox.Show("Bạn không có quyền sửa phiếu thu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(selected_id_phieu_thu))
            {
                MessageBox.Show("Vui lòng chọn một phiếu thu để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
                UPDATE Phieu_thu SET 
                    id_sinh_vien = @id_sv, 
                    id_loai_tc = @id_loai, 
                    id_nguoi_dung = @id_user, 
                    so_tien = @so_tien, 
                    id_hoc_ky = @id_hoc_ky,
                    ngay_thu = @ngay_thu
                WHERE id_phieu_thu = @id_phieu";

            SqlParameter[] parameters = {
                new SqlParameter("@id_phieu", selected_id_phieu_thu),
                new SqlParameter("@id_sv", cboSinhVien.SelectedValue),
                new SqlParameter("@id_loai", cboLoaiThuChi.SelectedValue),
                new SqlParameter("@id_user", cboNguoiLapPhieu.SelectedValue),
                new SqlParameter("@so_tien", Convert.ToDecimal(txtSoTien.Text)),
                new SqlParameter("@id_hoc_ky", cboHocKy.SelectedValue),
                new SqlParameter("@ngay_thu", dtpNgayLap.Value)
            };
            try
            {
                if (DatabaseTaiChinhHelper.ExecuteNonQuery(query, parameters) > 0)
                {
                    MessageBox.Show("Cập nhật phiếu thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật phiếu thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!Global.Permissions.Contains("QL_PT"))
            {
                MessageBox.Show("Bạn không có quyền sửa phiếu thu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(selected_id_phieu_thu))
            {
                MessageBox.Show("Vui lòng chọn một phiếu thu để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu thu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "DELETE FROM Phieu_thu WHERE id_phieu_thu = @id_phieu";
                SqlParameter[] parameters = { new SqlParameter("@id_phieu", selected_id_phieu_thu) };

                try
                {
                    DatabaseTaiChinhHelper.ExecuteNonQuery(query, parameters);
                    MessageBox.Show("Xóa phiếu thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa phiếu thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = @"
                  SELECT 
                    pt.id_phieu_thu,
                    pt.id_hoc_ky,
                    pt.so_tien,
                    pt.id_loai_tc,
                    pt.id_sinh_vien,
                    sv.ho_ten,
                    ltc.ten_loai,
                    pt.ngay_thu,
                    ns.ho_ten AS ten_nhan_su
                FROM QLTaiChinh.dbo.Phieu_thu pt
                JOIN Loai_thu_chi ltc ON ltc.id_loai_tc = pt.id_loai_tc
                JOIN Sinh_vien sv ON sv.id_sinh_vien = pt.id_sinh_vien
                LEFT JOIN QLTaiChinh.dbo.Nguoi_dung nd_taichinh
                    ON pt.id_nguoi_dung = nd_taichinh.id_nguoi_dung
                LEFT JOIN QLNguoiDung.dbo.Nguoi_dung nd_nguoidung
                    ON nd_taichinh.id_nguoi_dung = nd_nguoidung.id_nguoi_dung
                LEFT JOIN QLNguoiDung.dbo.Nhan_su ns
                    ON nd_nguoidung.id_nguoi_dung = ns.id_nguoi_dung
                WHERE  sv.id_sinh_vien LIKE @keyword";

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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadData();
        }

        private void ClearFields()
        {
            txtMaPhieuThu.Text = "";
            dtpNgayLap.Value = DateTime.Now;
            txtSoTien.Text = "";
            cboLoaiThuChi.SelectedIndex = -1;
            cboNguoiLapPhieu.SelectedIndex = -1;
            cboHocKy.SelectedIndex = -1;
            cboSinhVien.SelectedIndex = -1;
            txtTimKiem.Text = "";
            selected_id_phieu_thu = null;
            dataGridView1.ClearSelection();
        }
    }
}