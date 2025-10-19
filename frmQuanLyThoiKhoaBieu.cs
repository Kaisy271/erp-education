using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmQuanLyThoiKhoaBieu : Form
    {
        public frmQuanLyThoiKhoaBieu()
        {
            InitializeComponent();
            LoadComboBox();
            LoadThoiKhoaBieu();
        }

        private void LoadComboBox()
        {
            // Load lớp học
            string queryLop = "SELECT id_lop_hp, ten_lop FROM Lop_hoc_phan";
            DataTable dtLop = DatabaseDaoTaoHelper.ExecuteQuery(queryLop);
            cbLopHoc.DataSource = dtLop;
            cbLopHoc.DisplayMember = "ten_lop";
            cbLopHoc.ValueMember = "id_lop_hp";

            // Load phong hoc
            string queryGV = "SELECT id_phong, ten_phong FROM Phong_hoc";
            DataTable dtGV = DatabaseDaoTaoHelper.ExecuteQuery(queryGV);
            cboPhongHoc.DataSource = dtGV;
            cboPhongHoc.DisplayMember = "ten_phong";
            cboPhongHoc.ValueMember = "id_phong";

            // Load thứ
            cbThu.Items.AddRange(new object[] { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7" });
            cbThu.SelectedIndex = 0;

            // Load tiết
            for (int i = 1; i <= 10; i++)
            {
                cbTiet.Items.Add(i);
            }
            cbTiet.SelectedIndex = 0;
            //Load so buoi
            for (int i = 1; i <= 4; i++)
            {
                cboSoBuoi.Items.Add(i);
            }
            cboSoBuoi.SelectedIndex = 0;
            //Load so tiet
            for (int i = 1; i <= 4; i++)
            {
                cboSoTiet.Items.Add(i);
            }
            cboSoTiet.SelectedIndex = 0;
        }

        private void LoadThoiKhoaBieu()
        {
            //string query = @"SELECT t.MaTKB, l.TenLop, 
            //               CASE t.Thu 
            //                   WHEN 2 THEN 'Thứ 2' 
            //                   WHEN 3 THEN 'Thứ 3' 
            //                   WHEN 4 THEN 'Thứ 4' 
            //                   WHEN 5 THEN 'Thứ 5' 
            //                   WHEN 6 THEN 'Thứ 6' 
            //                   WHEN 7 THEN 'Thứ 7' 
            //                   ELSE 'Chủ nhật' 
            //               END AS Thu,
            //               t.Tiet, m.TenMonHoc, g.HoTen AS TenGiaoVien, t.PhongHoc,
            //               t.MaLop, t.MaMonHoc, t.MaGiaoVien, t.Thu AS ThuSo
            //               FROM ThoiKhoaBieu t
            //               JOIN LopHoc l ON t.MaLop = l.MaLop
            //               JOIN MonHoc m ON t.MaMonHoc = m.MaMonHoc
            //               JOIN GiaoVien g ON t.MaGiaoVien = g.MaGiaoVien
            //               ORDER BY l.TenLop, t.Thu, t.Tiet";
            string query = @"SELECT 
                            lh.id_lich_hoc,
                            lh.id_lop_hp,
                            lhp.ten_lop,
                            hp.ten_hoc_phan,
                            lh.id_phong,
                            ph.ten_phong,
                            lh.thu,
                            lh.tiet_bat_dau,
                            lh.so_tiet,
                            lh.tiet_bat_dau + lh.so_tiet - 1 as tiet_ket_thuc,
                            lh.tuan_hoc,
                            lh.ngay_hoc,
                            lhp.id_gv,
                            gv.ho_ten,
                            lhp.trang_thai as trang_thai_lop
                        FROM Lich_hoc lh
                        INNER JOIN Lop_hoc_phan lhp ON lh.id_lop_hp = lhp.id_lop_hp
                        INNER JOIN Hoc_phan hp ON lhp.id_hoc_phan = hp.id_hoc_phan
                        LEFT JOIN Phong_hoc ph ON lh.id_phong = ph.id_phong
                        LEFT JOIN Giang_vien gv ON lhp.id_gv = gv.id_gv
                        ORDER BY 
                            CASE lh.thu
                                WHEN N'Thứ 2' THEN 2
                                WHEN N'Thứ 3' THEN 3
                                WHEN N'Thứ 4' THEN 4
                                WHEN N'Thứ 5' THEN 5
                                WHEN N'Thứ 6' THEN 6
                                WHEN N'Thứ 7' THEN 7
                                WHEN N'Chủ nhật' THEN 8
                                ELSE 9
                            END,
                            lh.tiet_bat_dau";

            DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query);
            dgvThoiKhoaBieu.AutoGenerateColumns = false;
            dgvThoiKhoaBieu.DataSource = dt;

            dt.Columns.Add("STT", typeof(int));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }
            dgvThoiKhoaBieu.Columns["STT"].DisplayIndex = 0;

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbLopHoc.SelectedValue == null || cboSoTiet.SelectedItem == null || cbTiet.SelectedItem == null || cbThu.SelectedItem == null || cboPhongHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                string input = Interaction.InputBox("Vui lòng nhập số tuần học:", "Nhập số tuần học", "15");
                if (int.TryParse(input, out int so_tuan_hoc) && so_tuan_hoc > 0)
                {
                    try
                    {
                        string query = @"EXEC sp_TaoLichHoc 
                                @id_lop_hp,
                                @id_phong,
                                @thu,       
                                @tiet_bat_dau,
                                @so_tiet,   
                                @tuan_hoc";

                        SqlParameter[] parameters = new SqlParameter[]
                            {
                            new SqlParameter("@id_lop_hp", cbLopHoc.SelectedValue),
                            new SqlParameter("@id_phong", cboPhongHoc.SelectedValue),
                            new SqlParameter("@thu", cbThu.SelectedItem),
                            new SqlParameter("@tiet_bat_dau", cbTiet.SelectedItem),
                            new SqlParameter("@so_tiet", cboSoTiet.SelectedItem),
                            new SqlParameter("@tuan_hoc", so_tuan_hoc)
                            };
                        int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                        if (result > 0)
                        {
                            MessageBox.Show("Thêm lịch học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadThoiKhoaBieu();
                        }
                        else
                        {
                            MessageBox.Show("Thêm lịch học thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm lịch học: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Số tuần học không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng sửa thời khóa biểu đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThoiKhoaBieu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch học cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var selectedRow = dgvThoiKhoaBieu.SelectedRows[0];
            var idLichHoc = selectedRow.Cells["id_lich_hoc"].Value;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa lịch học này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            string query = "DELETE FROM Lich_hoc WHERE id_lich_hoc = @id_lich_hoc";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id_lich_hoc", idLichHoc)
            };
            int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
            if (result > 0)
            {
                MessageBox.Show("Xóa lịch học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadThoiKhoaBieu();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Xóa lịch học thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvThoiKhoaBieu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvThoiKhoaBieu.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvThoiKhoaBieu.SelectedRows[0];

                // Lớp học
                if (row.Cells["id_lop_hp"].Value != null)
                    cbLopHoc.SelectedValue = row.Cells["id_lop_hp"].Value;

                // Thứ
                if (row.Cells["thu"].Value != null)
                {
                    var thu = row.Cells["thu"].Value;
                    cbThu.SelectedItem = thu ;
                }

                // Tiết
                if (row.Cells["tiet_bat_dau"].Value != null)
                    cbTiet.SelectedItem = row.Cells["tiet_bat_dau"].Value;

                // Số tiết
                if (row.Cells["so_tiet"].Value != null)
                    cboSoTiet.SelectedItem = row.Cells["so_tiet"].Value;

                // Phòng học
                if (row.Cells["id_phong"].Value != null)
                    cboPhongHoc.SelectedValue = row.Cells["id_phong"].Value;

                // Số buổi
                if (row.Cells["tiet_ket_thuc"].Value != null)
                    cboSoBuoi.SelectedItem = Convert.ToInt64(row.Cells["tiet_ket_thuc"].Value) - Convert.ToInt64(row.Cells["tiet_bat_dau"].Value);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string query = @"SELECT 
                            lh.id_phong,
                            ph.ten_phong,
                            lh.thu,
                            COUNT(*) as so_lich,
                            SUM(lh.so_tiet) as tong_so_tiet
                        FROM Lich_hoc lh
                        LEFT JOIN Phong_hoc ph ON lh.id_phong = ph.id_phong
                        GROUP BY lh.id_phong, ph.ten_phong, lh.thu
                        ORDER BY lh.id_phong, 
                            CASE lh.thu
                                WHEN N'Thứ 2' THEN 2
                                WHEN N'Thứ 3' THEN 3
                                WHEN N'Thứ 4' THEN 4
                                WHEN N'Thứ 5' THEN 5
                                WHEN N'Thứ 6' THEN 6
                                WHEN N'Thứ 7' THEN 7
                                WHEN N'Chủ nhật' THEN 8
                                ELSE 9
                            END";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Keyword", $"%{keyword}%")
            };

            DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query, parameters);
            dgvThoiKhoaBieu.AutoGenerateColumns = false;
            dgvThoiKhoaBieu.DataSource = dt;
            dt.Columns.Add("STT", typeof(int));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }
            dgvThoiKhoaBieu.Columns["STT"].DisplayIndex = 0;


        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadThoiKhoaBieu();
            ClearFields();
            txtTimKiem.Clear();
        }

        private void ClearFields()
        {
            if (cbLopHoc.Items.Count > 0)
                cbLopHoc.SelectedIndex = 0;
            if (cbThu.Items.Count > 0)
                cbThu.SelectedIndex = 0;
            if (cbTiet.Items.Count > 0)
                cbTiet.SelectedIndex = 0;
            if (cboSoTiet.Items.Count > 0)
                cboSoTiet.SelectedIndex = 0;
            if (cboPhongHoc.Items.Count > 0)
                cboPhongHoc.SelectedIndex = 0;
            
        }

        private void btnXemTKB_Click(object sender, EventArgs e)
        {
            if (cbLopHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var maLop = cbLopHoc.SelectedValue.ToString();
            XemThoiKhoaBieu(maLop);
        }

        private void XemThoiKhoaBieu(string maLop)
        {
            string query = @"SELECT 
                                    lh.thu,
                                    lh.tiet_bat_dau,
                                    lh.so_tiet,
                                    lhp.ten_lop,
                                    hp.ten_hoc_phan,
                                    lh.id_phong,
									ph.ten_phong,
                                    gv.ho_ten
                                FROM Lich_hoc lh
                                INNER JOIN Lop_hoc_phan lhp ON lh.id_lop_hp = lhp.id_lop_hp
                                INNER JOIN Hoc_phan hp ON lhp.id_hoc_phan = hp.id_hoc_phan
								INNER JOIN Phong_hoc ph ON lh.id_phong = ph.id_phong
                                LEFT JOIN Giang_vien gv ON lhp.id_gv = gv.id_gv
                                WHERE lhp.id_lop_hp = @MaLop 
                                ORDER BY 
                                    CASE lh.thu
                                        WHEN N'Thứ 2' THEN 2
                                        WHEN N'Thứ 3' THEN 3
                                        WHEN N'Thứ 4' THEN 4
                                        WHEN N'Thứ 5' THEN 5
                                        WHEN N'Thứ 6' THEN 6
                                        WHEN N'Thứ 7' THEN 7
                                        ELSE 8
                                    END,
                                    lh.tiet_bat_dau;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLop", maLop)
            };

            DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query, parameters);

            // Tạo form hiển thị thời khóa biểu dạng bảng
            frmXemThoiKhoaBieu frm = new frmXemThoiKhoaBieu(dt, cbLopHoc.Text);
            frm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThemAuto_Click(object sender, EventArgs e)
        {
            if (cbLopHoc.SelectedValue == null || cboSoTiet.SelectedItem == null || cboSoBuoi.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn lớp học phần, số tiết, số buổi/ tuần để tạo lịch tự động!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
              
                string input = Interaction.InputBox("Vui lòng nhập số tuần học:", "Nhập số tuần học", "15");
                if (int.TryParse(input, out int so_tuan_hoc) && so_tuan_hoc > 0)
                {
                    if (MessageBox.Show($"Bạn có chắc chắn muốn tạo thời khóa biểu tự động cho lớp học phần {cbLopHoc.Text} với {cboSoTiet.SelectedItem} tiết/buổi và {cboSoBuoi.SelectedItem} buổi/tuần?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    try
                    {
                        string query = @"EXEC sp_TuDongXepLich 
                                @id_lop_hp ,
                                @so_tiet,   
                                @so_buoi_trong_tuan,
                                @so_tuan";
                        SqlParameter[] parameters = new SqlParameter[]
                            {
                    new SqlParameter("@id_lop_hp", cbLopHoc.SelectedValue),
                    new SqlParameter("@so_tiet", cboSoTiet.SelectedItem),
                    new SqlParameter("@so_buoi_trong_tuan", cboSoBuoi.SelectedItem),
                    new SqlParameter("@so_tuan", so_tuan_hoc)
                        };
                        int result = DatabaseDaoTaoHelper.ExecuteNonQuery(query, parameters);
                        if (result > 0)
                        {
                            MessageBox.Show("Thêm tự động thời khóa biểu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadThoiKhoaBieu();
                        }
                        else
                        {
                            MessageBox.Show("Thêm tự động thời khóa biểu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm tự động thời khóa biểu: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Số tuần học không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                
            }
                
        }
    }
}