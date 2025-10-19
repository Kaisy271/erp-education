using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmDangKyHoc : Form
    {
        public frmDangKyHoc()
        {

            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ten_lop", typeof(string));
            dt.Columns.Add("ten_hoc_phan", typeof(string));
            dt.Columns.Add("so_luong", typeof(int));
            dt.Columns.Add("ho_ten", typeof(string));
            dt.Columns.Add("ten_hoc_ky", typeof(string));
            dt.Columns.Add("ngay_ket_thuc", typeof(DateTime)); 
            dt.Columns.Add("trang_thai", typeof(string));
            dt.Columns.Add("dang_ky", typeof(bool));

            dt.Rows.Add("Lập trình C++ - 001", "Lập trình C++ cơ bản", 40, "Nguyễn Văn A", "HocKy_I_2025_2026", DateTime.Parse("2026-01-10"), "Đang mở", false);
            dt.Rows.Add("Cơ sở dữ liệu - 001", "Cơ sở dữ liệu", 35, "Trần Thị B", "HocKy_I_2025_2026", DateTime.Parse("2026-02-15"), "Đang mở", true);
            dt.Rows.Add("Web API - 001", "Lập trình Web API", 30, "Lê Văn C", "HocKy_I_2025_2026", DateTime.Parse("2026-03-20"), "Chờ xếp lớp", false);
            dt.Rows.Add("Python - 001", "Lập trình Python", 45, "Phạm Thị D", "HocKy_I_2025_2026", DateTime.Parse("2026-04-25"), "Đang mở", true);
            dt.Rows.Add("Java - 002", "Lập trình Java nâng cao", 38, "Hoàng Văn E", "HocKy_I_2025_2026", DateTime.Parse("2026-05-30"), "Đang mở", false);
            dt.Rows.Add("Mobile - 001", "Lập trình di động", 25, "Vũ Thị F", "HocKy_I_2025_2026", DateTime.Parse("2026-06-05"), "Chờ xếp lớp", true);
            dt.Rows.Add("AI - 001", "Trí tuệ nhân tạo", 42, "Đặng Văn G", "HocKy_I_2025_2026", DateTime.Parse("2026-07-12"), "Đang mở", false);
            dt.Rows.Add("Machine Learning - 001", "Học máy", 33, "Lý Thị H", "HocKy_I_2025_2026", DateTime.Parse("2026-08-18"), "Đang mở", true);
            dt.Rows.Add("Network - 001", "Mạng máy tính", 28, "Mai Văn I", "HocKy_I_2025_2026", DateTime.Parse("2026-09-22"), "Chờ xếp lớp", false);
            dt.Rows.Add("Security - 001", "An toàn thông tin", 36, "Ngô Thị K", "HocKy_I_2025_2026", DateTime.Parse("2026-10-30"), "Đang mở", true);
            dt.Rows.Add("Frontend - 001", "Lập trình Frontend", 32, "Bùi Văn L", "HocKy_I_2025_2026", DateTime.Parse("2026-11-15"), "Đang mở", false);
            dgvLopHp.AutoGenerateColumns = false;
            dgvLopHp.DataSource = dt;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
