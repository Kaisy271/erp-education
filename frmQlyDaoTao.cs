using Education_Manager;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Windows.Forms;
using static Education_Manager.frmDangNhap;


namespace Education_Manager
{
    public partial class frmQlyDaoTao : Form
    {
        private string userRole;
        List<string> Permissions = Global.Permissions;

        public frmQlyDaoTao()
        {
            InitializeComponent();
            userRole = Global.CurrentUsername;
            lblWelcome.Text = $"Xin chào, {userRole}";

            // Khởi tạo timer
            timer1.Interval = 1000; // 1 giây
            timer1.Start();
        }


        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap frm = new frmDangNhap();
            frm.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHome frm = new frmHome();
            frm.Show();
        }

        private void OpenChildForm(Form childForm)
        {
            pnHome.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnHome.Controls.Add(childForm);
            childForm.Show();
            childForm.BringToFront();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }


        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            if (Permissions.Contains("QL_K"))
            {
                OpenChildForm(new frmQuanLyKhoa());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNganh_Click(object sender, EventArgs e)
        {
            if (Permissions.Contains("QL_N"))
            {
                OpenChildForm(new frmQuanLyNganh());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHocKy_Click(object sender, EventArgs e)
        {
            if (Permissions.Contains("QL_HKY"))
            {
                OpenChildForm(new frmQuanLyHocKy());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHocPhan_Click(object sender, EventArgs e)
        {
            if(Permissions.Contains("QL_HP"))
            {
                OpenChildForm(new frmQuanLyHocPhan());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLopHocPhan_Click(object sender, EventArgs e)
        {
            if (Permissions.Contains("QL_LHP"))
            {
                OpenChildForm(new frmQuanLyLopHp());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDangKyHoc_Click(object sender, EventArgs e)
        {
            if (Permissions.Contains("QL_LH"))
            {
                OpenChildForm(new frmQuanLyThoiKhoaBieu());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            if(Permissions.Contains("QL_L"))
            {
                OpenChildForm(new frmQuanLyLop());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnKeHoachHt_Click(object sender, EventArgs e)
        {
            if (Permissions.Contains("QL_TD"))
            {
                OpenChildForm(new frmQuanLyKHHT());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}