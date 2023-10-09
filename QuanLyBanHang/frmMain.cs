using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        //Phần phân quyền
        void PhanQuyen()
        {
            if(Const.TaiKhoan.LoaiTaiKhoan == false)
            {
                mnuChatLieu.Enabled = false;
                mnuHangHoa.Enabled = false;
                mnuNhanVien.Enabled = false;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            PhanQuyen();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Functions.Disconnect();
            Application.Exit();
        }

        private void mnuChatLieu_Click(object sender, EventArgs e)
        {
            frmDMChatLieu frm = new frmDMChatLieu();
            frm.ShowDialog();
        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            frmDMHangHoa frm = new frmDMHangHoa();
           // frm.MdiParent = this;
            frm.Show();
        }

        

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            frmDMNhanVien frm = new frmDMNhanVien();
            frm.Show();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            frmDMKhachHang frm = new frmDMKhachHang();
            frm.Show();
        }

        

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frm = new frmHoaDonBan();
            frm.Show();
        }

        

        //Phần đăng xuất
        public bool isThoat = true;
        public event EventHandler DangXuat;
        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DangXuat(this, new EventArgs());
            /*isThoat = false;
            this.Close();
            frmDangNhap frm = new frmDangNhap();
            frm.Show();*/
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(isThoat)
            {
                Functions.Disconnect();
                Application.Exit();
            }
        }

        
    }
}
