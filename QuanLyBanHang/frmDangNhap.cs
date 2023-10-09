using QuanLyBanHang.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmDangNhap : Form
    {
        List<TaiKhoan> listTaiKhoan = DanhSachTaiKhoan.Instance.ListTaiKhoan;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(KiemTraDangNhap(txtTaiKhoan.Text, txtMatKhau.Text))
            {
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
                frm.DangXuat += Frm_DangXuat;
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu", "Lỗi");
                txtTaiKhoan.Focus();
            }
            
        }

        private void Frm_DangXuat(object sender, EventArgs e)
        {
            (sender as frmMain).isThoat = false;
            (sender as frmMain).Close();
            this.Show();
        }

        bool KiemTraDangNhap(string tentaikhoan, string matkhau)
        {
            for (int i = 0; i < listTaiKhoan.Count; i++)
            {
                if(tentaikhoan == listTaiKhoan[i].TenTaiKhoan && matkhau == listTaiKhoan[i].MatKhau)
                {
                    Const.TaiKhoan = listTaiKhoan[i];
                    return true;
                }
            }
            return false;
        }
    }
}
