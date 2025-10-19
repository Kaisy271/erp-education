using Education_Manager;
using System;
using System.Data.SqlTypes;
using System.Windows.Forms;
using static Education_Manager.frmDangNhap;


namespace Education_Manager
{
    public partial class frmHome : Form
    {

        public frmHome()
        {
            InitializeComponent();
            lblWelcome.Text = $"Xin chào, {Global.CurrentUsername}";

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
            Application.Exit();
        }

        private void OpenChildForm(Form childForm)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            childForm.MdiParent = this;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
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


        private void btnHome_Click(object sender, EventArgs e)
        {
            pnHome.Visible = true;
            lblHome.Visible = true;
        }

       

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDaoTao_Click(object sender, EventArgs e)
        {
            if(Global.CurrentRoleName == "Quản trị hệ thống" || Global.CurrentRoleName == "Quản lý đào tạo")
            {
                this.Hide();
                frmQlyDaoTao frm = new frmQlyDaoTao();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNguoiDung_Click(object sender, EventArgs e)
        {
            if(Global.CurrentRoleName == "Quản trị hệ thống")
            {
                this.Hide();
                frmMain_NguoiDung frm = new frmMain_NguoiDung();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            if (Global.CurrentRoleName == "Quản trị hệ thống" || Global.CurrentRoleName == "Quản lý đào tạo" || Global.CurrentRoleName == "Giảng viên" || Global.CurrentRoleName == "Giáo vụ" || Global.CurrentRoleName== "Sinh viên")
            {
                this.Hide();
                frmSinhVien frm = new frmSinhVien();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTaiChinh_Click(object sender, EventArgs e)
        {
            if (Global.CurrentRoleName == "Quản trị hệ thống" || Global.CurrentRoleName == "Kế toán")
            {
                this.Hide();
                frmQuanLyTaiChinh frm = new frmQuanLyTaiChinh();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCoSoVC_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng hiện đang nâng cấp");
            btnCoSoVC.Enabled = false;
        }

        private void btnThuVien_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng hiện đang nâng cấp");
            btnThuVien.Enabled = false;
        }
    }
}