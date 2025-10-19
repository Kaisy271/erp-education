using System;
using System.Data;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmXemThoiKhoaBieu : Form
    {
        public frmXemThoiKhoaBieu(DataTable data, string tenLop)
        {
            InitializeComponent();
            Text = "Thời khóa biểu lớp " + tenLop;
            HienThiThoiKhoaBieu(data);
        }

        //private void HienThiThoiKhoaBieu(DataTable data)
        //{
        //    // Tạo bảng 10 tiết x 6 thứ (Thứ 2 - Thứ 7)
        //    DataTable tkbTable = new DataTable();

        //    // Thêm cột tiết
        //    tkbTable.Columns.Add("Tiết");

        //    // Thêm cột các thứ
        //    for (int thu = 2; thu <= 7; thu++)
        //    {
        //        tkbTable.Columns.Add("Thứ " + thu);
        //    }

        //    // Thêm dữ liệu các tiết
        //    for (int tiet = 1; tiet <= 10; tiet++)
        //    {
        //        DataRow row = tkbTable.NewRow();
        //        row["Tiết"] = "Tiết " + tiet;

        //        for (int thu = 2; thu <= 7; thu++)
        //        {
        //            DataRow[] rows = data.Select($"Thu = 'Thứ {thu}' AND tiet_bat_dau = {tiet}");
        //            if (rows.Length > 0)
        //            {
        //                row["Thứ " + thu] = $"{rows[0]["ten_hoc_phan"]}\nGV: {rows[0]["ho_ten"]}\nPhòng: {rows[0]["ten_phong"]}";
        //            }
        //            else
        //            {
        //                row["Thứ " + thu] = " ";
        //            }
        //        }

        //        tkbTable.Rows.Add(row);
        //    }

        //    dgvTKB.DataSource = tkbTable;

        //    // Định dạng DataGridView
        //    dgvTKB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dgvTKB.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        //    dgvTKB.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //    dgvTKB.RowHeadersVisible = false;

        //    // Đặt chiều cao hàng tự động
        //    dgvTKB.RowTemplate.Height = 60;
        //}
        private void HienThiThoiKhoaBieu(DataTable data)
        {
            // Tạo bảng 10 tiết x 6 thứ (Thứ 2 - Thứ 7)
            DataTable tkbTable = new DataTable();

            // Thêm cột tiết
            tkbTable.Columns.Add("Tiết");

            // Thêm cột các thứ
            for (int thu = 2; thu <= 7; thu++)
            {
                tkbTable.Columns.Add("Thứ " + thu);
            }

            // Thêm dữ liệu các tiết
            for (int tiet = 1; tiet <= 10; tiet++)
            {
                DataRow row = tkbTable.NewRow();
                row["Tiết"] = "Tiết " + tiet;

                for (int thu = 2; thu <= 7; thu++)
                {
                    DataRow[] rows = data.Select($"Thu = 'Thứ {thu}'");
                    string cellValue = " ";
                    foreach (DataRow r in rows)
                    {
                        int tietBatDau = Convert.ToInt32(r["tiet_bat_dau"]);
                        int soTiet = Convert.ToInt32(r["so_tiet"]);

                        if (tiet >= tietBatDau && tiet < tietBatDau + soTiet)
                        {
                            cellValue = $"{r["ten_hoc_phan"]}\nGV: {r["ho_ten"]}\nPhòng: {r["ten_phong"]}";
                            break; 
                        }
                    }

                    row["Thứ " + thu] = cellValue;
                }

                tkbTable.Rows.Add(row);
            }

            dgvTKB.DataSource = tkbTable;

            // Định dạng DataGridView
            dgvTKB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTKB.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTKB.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTKB.RowHeadersVisible = false;
            dgvTKB.RowTemplate.Height = 60;
        }


        private void dgvTKB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}