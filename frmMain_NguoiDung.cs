using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Education_Manager.frmDangNhap;


namespace Education_Manager
{
    public partial class frmMain_NguoiDung: Form
    {   
        List<string> tenquyen;
        public frmMain_NguoiDung()
        {
            InitializeComponent();
            this.tenquyen = Global.Permissions;

        }

        // hàm load form 

        private  void LoadForm(Form frm)
        {
            panelMain.Controls.Clear();
            frm.TopLevel = false;

            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(frm);
            frm.Show();
        }

        private void MenuItemPQ_CN_Click(object sender, EventArgs e)
        {
            LoadChildForm(new frmPhanQuyen_ChucNang());

        }
        #region function

        
        private void LoadChildForm(Form childForm)
        {
            // clia
            panelMain.Controls.Clear();

            // Ch form con
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Hiển thị form con trong panel
            panelMain.Controls.Add(childForm);
            childForm.Show();
        }
        public void ShowBackGround()
        {
            panelMain.Controls.Clear();
            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Fill;
            //pb.Image = Properties.Resources.mo_hi_nh_32_trien_khai_he_thong_quan_ly_truong_hoc_xac_thuc_thong_tin_giao_vien_va_hoc_sinh_cho_phep_giao_vien_dang_nhap_bang_tai_khoan_vneid_sso_quan_ly_diem_lich_hoc_1706927508_jitfb;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            panelMain.Controls.Add(pb);

        }
        #endregion
        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadChildForm(new frmQuanLyNguoiDung());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new frmHome(); 
            this.Hide();
            frm.ShowDialog();
        }
    }
}
