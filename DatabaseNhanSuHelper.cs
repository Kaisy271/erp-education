using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Manager
{
    public class DatabaseNhanSuHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["QLNhanSuConnectionString"].ConnectionString;

        // Phương thức này không cần thay đổi.
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ExecuteQuery: {ex.Message}");
                // Nếu là ứng dụng WinForms, bạn nên dùng MessageBox.Show(ex.Message);
                return null;
            }
            return dt;
        }

        // Tối ưu hóa: Thêm khối try-catch để bắt lỗi kết nối/thực thi SQL.
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ExecuteNonQuery: {ex.Message}");
                // Ném lại lỗi để code gọi có thể thông báo cho người dùng
                throw;
            }
            return result;
        }

        // Tối ưu hóa: Thêm khối try-catch để bắt lỗi kết nối/thực thi SQL.
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object result = null;
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    result = cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ExecuteScalar: {ex.Message}");
                throw;
            }
            return result;
        }
    }
}
