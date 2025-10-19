using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace Education_Manager
{
    public partial class frmPhanQuyen_ChucNang : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["QLNguoiDungConnectionString"].ConnectionString;

        public frmPhanQuyen_ChucNang()
        {
            InitializeComponent();
            LoadChucNang();
            LoadComboBox();
            LoadComboBoxTimKiem();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
          
            var parentForm = this.ParentForm as frmMain_NguoiDung;


         
            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
            }

            this.Dispose();
            parentForm?.ShowBackGround();

        }
        private void LoadChucNang()
        {
            string query = @"SELECT qcn.id_quyen, qcn.id_chuc_nang,
                q.ten_quyen AS [Phân quyền],
                cn.ten_chuc_nang AS [Chức năng]
                FROM dbo.Quyen_chucnang qcn
                INNER JOIN dbo.Phan_quyen q ON qcn.id_quyen = q.id_quyen
                INNER JOIN dbo.Chuc_nang cn ON qcn.id_chuc_nang = cn.id_chuc_nang";

           using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);


                dt.Columns.Add("STT", typeof(int));


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                }


                dgvQ_CN.DataSource = dt;
            }


            dgvQ_CN.Columns["id_quyen"].Visible = false;
            dgvQ_CN.Columns["id_chuc_nang"].Visible = false;


            dgvQ_CN.Columns["STT"].DisplayIndex = 0;


            dgvQ_CN.Columns["STT"].HeaderText = "STT";
            dgvQ_CN.Columns["Phân quyền"].HeaderText = "Phân quyền";
            dgvQ_CN.Columns["Chức năng"].HeaderText = "Chức năng";

            dgvQ_CN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        #region functions



        private void LoadComboBox()
        {
            string queryCN = "SELECT id_chuc_nang, ten_chuc_nang FROM Chuc_nang";
            DataTable dtCN = DatabaseNguoiDungHelper.ExecuteQuery(queryCN);
            cboCN.DataSource = dtCN;
            cboCN.DisplayMember = "ten_chuc_nang";
            cboCN.ValueMember = "id_chuc_nang";

            string queryPQ = "select id_quyen, ten_quyen FROM Phan_quyen";
            DataTable dtPQ = DatabaseNguoiDungHelper.ExecuteQuery(queryPQ);
            cboPQ.DataSource = dtPQ;
            cboPQ.DisplayMember = "ten_quyen";
            cboPQ.ValueMember = "id_quyen";
        }
        private void LoadComboBoxTimKiem()
        {
            cboTimKiem.Items.Clear();
            cboTimKiem.Items.Add("All");
            cboTimKiem.Items.Add("Tên phân quyền");
            cboTimKiem.Items.Add("Tên chức năng");
            cboTimKiem.SelectedIndex = 0; // mặc định chọn "All"
        }
        private void ClearFields()
        {
            if (cboCN.Items.Count > 0)
                cboCN.SelectedIndex = 0;
            if (cboPQ.Items.Count > 0)
                cboPQ.SelectedIndex = 0;
        }
        #endregion

        #region events


        private void dgvQ_CN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cboPQ.Text = dgvQ_CN.Rows[e.RowIndex].Cells["Phân quyền"].Value?.ToString();
                cboCN.Text = dgvQ_CN.Rows[e.RowIndex].Cells["Chức năng"].Value?.ToString();
            }
        }




        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (cboPQ.SelectedValue == null || cboCN.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Phân quyền và Chức năng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idQuyen = cboPQ.SelectedValue.ToString();
            string idChucNang = cboCN.SelectedValue.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // ⚡ Kiểm tra trùng quyền - chức năng
                string queryCheck = "SELECT COUNT(*) FROM dbo.Quyen_chucnang " +
                                    "WHERE id_quyen = '" + idQuyen + "' AND id_chuc_nang = '" + idChucNang + "'";
                SqlCommand cmdCheck = new SqlCommand(queryCheck, conn);
                int count = (int)cmdCheck.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Quyền này đã được gán chức năng này rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                string queryThem = "INSERT INTO dbo.Quyen_chucnang(id_quyen, id_chuc_nang) " +
                                     "VALUES ('" + idQuyen + "', '" + idChucNang + "')";
                SqlCommand cmdInsert = new SqlCommand(queryThem, conn);
                int result = cmdInsert.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadChucNang();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cboPQ.SelectedIndex = -1;
            cboCN.SelectedIndex = -1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboCN.SelectedValue == null || cboPQ.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn Quyền và Chức năng cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy quyền và chức năng mới
                string quyenmoi = cboPQ.SelectedValue.ToString();
                string cnmoi = cboCN.SelectedValue.ToString();

                // Lấy chức năng cũ từ dòng đang chọn trong DataGridView
                string tencncu = dgvQ_CN.CurrentRow.Cells["Chức năng"].Value.ToString();
                string idcncu = "";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Lấy id_chuc_nang cũ dựa theo tên chức năng trong bảng Chuc_nang
                    string queryGetOldCN = "SELECT id_chuc_nang FROM dbo.Chuc_nang WHERE ten_chuc_nang = N'" + tencncu + "'";
                    SqlCommand cmdGetOld = new SqlCommand(queryGetOldCN, conn);
                    object result = cmdGetOld.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Không tìm thấy chức năng cũ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    idcncu = result.ToString();

                    // Kiểm tra trùng khóa trước khi cập nhật
                    string queryCheck = "SELECT COUNT(*) FROM dbo.Quyen_chucnang WHERE id_quyen = '" + quyenmoi + "' AND id_chuc_nang = '" + cnmoi + "'";
                    SqlCommand cmdCheck = new SqlCommand(queryCheck, conn);
                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Quyền này đã có chức năng này rồi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Cập nhật
                    string queryUpdate = "UPDATE dbo.Quyen_chucnang " +
                                         "SET id_chuc_nang = '" + cnmoi + "' " +
                                         "WHERE id_quyen = '" + quyenmoi + "' AND id_chuc_nang = '" + idcncu + "'";

                    SqlCommand cmdsua = new SqlCommand(queryUpdate, conn);
                    int rows = cmdsua.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadChucNang();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu nào được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvQ_CN.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa quyền - chức năng này?",
                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            // ⚠️ Kiểm tra và lấy id_quyen, id_chuc_nang từ DataGridView
            object idQuyenCell = dgvQ_CN.CurrentRow.Cells["id_quyen"].Value;
            object idChucNangCell = dgvQ_CN.CurrentRow.Cells["id_chuc_nang"].Value;

            if (idQuyenCell == null || idChucNangCell == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string id_quyen = idQuyenCell.ToString();
            string id_chucnang = idChucNangCell.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // ⚡ Nối chuỗi, nhưng đảm bảo dùng giá trị chuẩn từ DataGridView (tránh lỗi null)
                string queryXoa = "DELETE FROM dbo.Quyen_chucnang " +
                                  "WHERE id_quyen = '" + id_quyen + "' AND id_chuc_nang = '" + id_chucnang + "'";

                SqlCommand cmd = new SqlCommand(queryXoa, conn);
                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadChucNang(); // làm mới lại DataGridView
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu nào bị xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim();
                string luaChon = (cboTimKiem.SelectedItem ?? "All").ToString();

                string baseQuery = @"
            SELECT qcn.id_quyen, qcn.id_chuc_nang,
                   q.ten_quyen AS [Phân quyền],
                   cn.ten_chuc_nang AS [Chức năng]
            FROM dbo.Quyen_chucnang qcn
            INNER JOIN dbo.Phan_quyen q ON qcn.id_quyen = q.id_quyen
            INNER JOIN dbo.Chuc_nang cn ON qcn.id_chuc_nang = cn.id_chuc_nang
            WHERE 1=1";

                string query = baseQuery;

                // Build filter tùy chọn (chỉ nối chuỗi, giống yêu cầu)
                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    if (luaChon == "Tên phân quyền")
                    {
                        query += " AND q.ten_quyen LIKE N'%" + tuKhoa.Replace("'", "''") + "%'";
                    }
                    else if (luaChon == "Tên chức năng")
                    {
                        query += " AND cn.ten_chuc_nang LIKE N'%" + tuKhoa.Replace("'", "''") + "%'";
                    }
                    else // All
                    {
                        query += " AND (q.ten_quyen LIKE N'%" + tuKhoa.Replace("'", "''") + "%' OR cn.ten_chuc_nang LIKE N'%" + tuKhoa.Replace("'", "''") + "%')";
                    }
                }
                // nếu tuKhoa rỗng và chọn All thì sẽ load hết (query = baseQuery)

                DataTable dt;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        dt = new DataTable();
                        da.Fill(dt);
                    }
                }

                // Kiểm tra an toàn nếu dt null (trong thực tế da.Fill sẽ tạo DataTable rỗng chứ không null,
                // nhưng phòng trường hợp DatabaseNguoiDungHelper hoặc khác trả về null)
                if (dt == null)
                {
                    MessageBox.Show("Không thể lấy dữ liệu từ cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thêm cột STT và đẩy lên đầu
                if (!dt.Columns.Contains("STT"))
                    dt.Columns.Add("STT", typeof(int));

                for (int i = 0; i < dt.Rows.Count; i++)
                    dt.Rows[i]["STT"] = i + 1;

                dt.Columns["STT"].SetOrdinal(0);

                dgvQ_CN.DataSource = dt;

                // Ẩn 2 cột id nếu có
                if (dgvQ_CN.Columns.Contains("id_quyen"))
                    dgvQ_CN.Columns["id_quyen"].Visible = false;
                if (dgvQ_CN.Columns.Contains("id_chuc_nang"))
                    dgvQ_CN.Columns["id_chuc_nang"].Visible = false;

                // Thiết lập header, căn chỉnh, autosize
                if (dgvQ_CN.Columns.Contains("STT")) dgvQ_CN.Columns["STT"].HeaderText = "STT";
                if (dgvQ_CN.Columns.Contains("Phân quyền")) dgvQ_CN.Columns["Phân quyền"].HeaderText = "Phân quyền";
                if (dgvQ_CN.Columns.Contains("Chức năng")) dgvQ_CN.Columns["Chức năng"].HeaderText = "Chức năng";

                dgvQ_CN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTimKiem.SelectedItem.ToString() == "All")
            {
                LoadChucNang(); // Hàm bạn đã có sẵn để load toàn bộ dữ liệu
                txtTimKiem.Clear();
            }
        }
        #endregion
    }
}
