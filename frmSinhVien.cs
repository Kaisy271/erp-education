using Education_Manager;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Windows.Forms;
using static Education_Manager.frmDangNhap;


namespace Education_Manager
{
    public partial class frmSinhVien : Form
    {
        private string userRole;
        List<string> Permissions = Global.Permissions;
        public frmSinhVien()
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
            if (Permissions.Contains("QL_SV"))
            {
                OpenChildForm(new frmQuanLySinhVien());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNganh_Click(object sender, EventArgs e)
        {
            if(Permissions.Contains("QL_KQHT"))
            {
                OpenChildForm(new frmQuanLyKQHT());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTKB_Click(object sender, EventArgs e)
        {
            if (Permissions.Contains("X_LSV"))
            {
                OpenChildForm(new frmXemLichCaNhan());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if(Permissions.Contains("QL_DKH"))
            {
                OpenChildForm(new frmDangKyHoc());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}