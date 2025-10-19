using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmXemLichCaNhan : Form
    {
        public frmXemLichCaNhan()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();

            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }

            // Giữ nguyên câu lệnh query
            string query = @"
                SELECT 
                    sv.id_sinh_vien AS [Mã sinh viên],
                    sv.ho_ten AS [Họ tên],
                    hp.ten_hoc_phan AS [Tên học phần],
                    lh.thu AS [Thứ],
                    lh.ngay_hoc AS [Ngày học],
                    lh.tiet_bat_dau AS [Tiết bắt đầu],
                    lh.so_tiet AS [Số tiết],
                    ph.id_phong AS [Mã phòng],
                    lhp.id_lop_hp AS [Mã lớp HP]
                FROM QLSinhVien.dbo.Sinh_vien sv
                JOIN QLSinhVien.dbo.Dang_ky_hoc dk ON sv.id_sinh_vien = dk.id_sinh_vien
                JOIN QLDaoTao.dbo.Lop_hoc_phan lhp ON dk.id_lop_hp = lhp.id_lop_hp
                JOIN QLDaoTao.dbo.Hoc_phan hp ON lhp.id_hoc_phan = hp.id_hoc_phan
                JOIN QLDaoTao.dbo.Lich_hoc lh ON lhp.id_lop_hp = lh.id_lop_hp
                JOIN QLDaoTao.dbo.Phong_hoc ph ON lh.id_phong = ph.id_phong
                WHERE sv.id_sinh_vien = @MaSV
                ORDER BY lh.ngay_hoc, lh.thu, lh.tiet_bat_dau";

            SqlParameter[] parameters = { new SqlParameter("@MaSV", maSV) };

            // Dữ liệu cross DB (giữ nguyên)
            DataTable data = DatabaseSinhVienHelper.ExecuteQuery(query, parameters);

            if (data == null || data.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy lịch học của sinh viên này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvLich.DataSource = null;
                return;
            }

            // Hiển thị thời khóa biểu dạng bảng Tiết × Thứ
            HienThiThoiKhoaBieu(data);
        }

        private void HienThiThoiKhoaBieu(DataTable data)
        {
            // Tạo bảng 10 tiết x 6 thứ
            DataTable tkbTable = new DataTable();

            // Cột đầu tiên là "Tiết"
            tkbTable.Columns.Add("Tiết");

            // Các cột thứ 2 → 7
            for (int thu = 2; thu <= 7; thu++)
            {
                tkbTable.Columns.Add("Thứ " + thu);
            }

            // Gán dữ liệu từng tiết
            for (int tiet = 1; tiet <= 10; tiet++)
            {
                DataRow row = tkbTable.NewRow();
                row["Tiết"] = "Tiết " + tiet;

                for (int thu = 2; thu <= 7; thu++)
                {
                    // Lấy dòng khớp tiết & thứ
                    DataRow[] rows = data.Select($"Thứ = 'Thứ {thu}' AND [Tiết bắt đầu] = {tiet}");
                    if (rows.Length > 0)
                    {
                        DataRow r = rows[0];
                        row["Thứ " + thu] = $"{r["Tên học phần"]}\nNgày: {Convert.ToDateTime(r["Ngày học"]).ToString("dd/MM/yyyy")}\nPhòng: {r["Mã phòng"]}";
                        // Nếu muốn có phòng, thêm cột `ten_phong` trong query
                    }
                    else
                    {
                        row["Thứ " + thu] = " ";
                    }
                }

                tkbTable.Rows.Add(row);
            }

            // Hiển thị ra DataGridView
            dgvLich.DataSource = tkbTable;

            dgvLich.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLich.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvLich.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvLich.RowHeadersVisible = false;
            dgvLich.RowTemplate.Height = 60;
        }

        private void dgvLich_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Không cần xử lý gì ở đây
        }
    }
}
