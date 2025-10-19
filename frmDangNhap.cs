using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Education_Manager
{
    public partial class frmDangNhap : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["QLNguoiDungConnectionString"].ConnectionString;

        public frmDangNhap()
        {
            InitializeComponent();
           
        }

        public static class Global
        {
            public static List<string> Permissions = new List<string>();
            public static string CurrentRoleId = "";
            public static string CurrentRoleName = "";
            public static string CurrentUsername = "";
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
           
        }

        private void LoadPermissions(string idQuyen)
        {
            Global.Permissions.Clear();
            Global.CurrentRoleId = idQuyen;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id_chuc_nang FROM Quyen_chucnang WHERE id_quyen = @id_quyen";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_quyen", idQuyen);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Global.Permissions.Add(reader["id_chuc_nang"].ToString());
                }
                conn.Close();
            }
        }
        private string LayTenQuyen(string id_quyen)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ten_quyen FROM dbo.Phan_quyen WHERE id_quyen = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id_quyen);
                conn.Open();

                object result = cmd.ExecuteScalar();
                conn.Close();

                return result?.ToString() ?? "";
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtUsername.Text.Trim();
            string matKhau = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT id_quyen FROM dbo.Nguoi_dung WHERE tai_khoan = @ten AND mat_khau = @matkhau";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ten", tenDangNhap);
                    cmd.Parameters.AddWithValue("@matkhau", matKhau);
                    conn.Open();

                    object quyenObj = cmd.ExecuteScalar();

                    if (quyenObj != null)
                    {
                        string id_quyen = quyenObj.ToString();

                        // Lấy tên quyền & nạp danh sách chức năng
                        string tenQuyen = LayTenQuyen(id_quyen);
                        LoadPermissions(id_quyen);

                        // Ghi nhớ thông tin user hiện tại
                        Global.CurrentRoleName = tenQuyen;
                        Global.CurrentUsername = tenDangNhap;

                        // Mở form chính
                        this.Hide();
                        frmHome frm = new frmHome();
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
        }

       

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Chức năng hiện đang nâng cấp");
            linkLabel1.LinkColor = Color.Gray;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
