using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmBaoCaoHocKy : Form
    {
        public frmBaoCaoHocKy()
        {
            InitializeComponent();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            // Load học kỳ
            cbHocKy.Items.Add("1");
            cbHocKy.Items.Add("2");
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (cbHocKy.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn học kỳ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = @"SELECT l.MaLop, l.TenLop, 
                          COUNT(h.MaHocSinh) AS SiSo,
                          AVG(d.DiemTB) AS DiemTBLop,
                          SUM(CASE WHEN d.DiemTB >= 5 THEN 1 ELSE 0 END) AS SoDat,
                          SUM(CASE WHEN d.DiemTB < 5 THEN 1 ELSE 0 END) AS SoKhongDat
                          FROM LopHoc l
                          LEFT JOIN HocSinh h ON l.MaLop = h.MaLop
                          LEFT JOIN Diem d ON h.MaHocSinh = d.MaHocSinh AND d.HocKy = @HocKy
                          GROUP BY l.MaLop, l.TenLop";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@HocKy", cbHocKy.SelectedItem)
            };

            DataTable dt = DatabaseDaoTaoHelper.ExecuteQuery(query, parameters);
            dgvBaoCao.DataSource = dt;

            // Tổng hợp toàn trường
            if (dt.Rows.Count > 0)
            {
                int tongSiSo = 0;
                int tongDat = 0;
                int tongKhongDat = 0;
                decimal tongDiemTB = 0;

                foreach (DataRow row in dt.Rows)
                {
                    tongSiSo += Convert.ToInt32(row["SiSo"]);
                    tongDat += Convert.ToInt32(row["SoDat"]);
                    tongKhongDat += Convert.ToInt32(row["SoKhongDat"]);
                    if (row["DiemTBLop"] != DBNull.Value)
                    {
                        tongDiemTB += Convert.ToDecimal(row["DiemTBLop"]);
                    }
                }

                decimal diemTBToanTruong = tongSiSo > 0 ? tongDiemTB / dt.Rows.Count : 0;
                decimal tyLeDat = tongSiSo > 0 ? (decimal)tongDat / tongSiSo * 100 : 0;

                lblTongSiSo.Text = $"Tổng sĩ số: {tongSiSo}";
                lblTongDat.Text = $"Tổng đạt: {tongDat}";
                lblTongKhongDat.Text = $"Tổng không đạt: {tongKhongDat}";
                lblDiemTBToanTruong.Text = $"Điểm TB toàn trường: {diemTBToanTruong.ToString("0.00")}";
                lblTyLeDat.Text = $"Tỷ lệ đạt: {tyLeDat.ToString("0.00")}%";
            }
        }
    }
}