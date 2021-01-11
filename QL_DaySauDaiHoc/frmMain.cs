using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_DaySauDaiHoc
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmDangNhap fDangNhap = new frmDangNhap(this);
            fDangNhap.ShowDialog();
            mnuDangNhap.Enabled = false;
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuDoiMK_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau fDoiMatKhau = new frmDoiMatKhau();
            fDoiMatKhau.ShowDialog();
        }

        private void mnuGiangDay_Click(object sender, EventArgs e)
        {
            frmGiangDay fGiangDay = new frmGiangDay();
            fGiangDay.ShowDialog();
        }

        private void mnuChonHK_Click(object sender, EventArgs e)
        {
            frmChonHK fChonHK = new frmChonHK();
            fChonHK.ShowDialog();
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap fDangNhap = new frmDangNhap(this);
            fDangNhap.ShowDialog();
            mnuDangNhap.Enabled = false;
            mnuInan.Enabled = true;
        }

        private void mnuThoatDangNhap_Click(object sender, EventArgs e)
        {
            DialogResult blnDongY;
            blnDongY = MessageBox.Show("Bạn thật sự muốn thoát đăng nhập ?", "Xác nhận", MessageBoxButtons.YesNo);
            if (blnDongY == DialogResult.Yes)
            {
                if (MyPublics.conMyConnection != null)
                    MyPublics.conMyConnection = null;
                mnuDuLieu.Enabled = false;
                mnuCapNhat.Enabled = false;
                mnuThoatDangNhap.Enabled = false;
                mnuDoiMK.Enabled = false;
                mnuDangNhap.Enabled = true;
                mnuInan.Enabled = false;
            }
            
        }

        private void mnuCanBo_Click(object sender, EventArgs e)
        {
            frmCanBo fCanBo = new frmCanBo();
            fCanBo.ShowDialog();
        }

        private void mnuTruong_Click(object sender, EventArgs e)
        {
            frmTruong fTruong = new frmTruong();
            fTruong.ShowDialog();
        }

        private void mnuDonVi_Click(object sender, EventArgs e)
        {
            frmDonVi fDonVi = new frmDonVi();
            fDonVi.ShowDialog();
        }

        private void mnuMonHoc_Click(object sender, EventArgs e)
        {
            frmMonHoc fMonHoc = new frmMonHoc();
            fMonHoc.ShowDialog();
        }

        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chương trình Quản lý Dạy sau đại học Version 1.0 \n\nNhóm thực hiện: Kiện - Vinh - Thịnh", "Giới Thiệu");
        }

        private void mnuRptCanBo_Click(object sender, EventArgs e)
        {
            frmRptCanBo fCanBoIn = new frmRptCanBo();
            fCanBoIn.ShowDialog();
        }

        private void mnuRptMonHoc_Click(object sender, EventArgs e)
        {
            frmRptMonHoc fMonHocIn = new frmRptMonHoc();
            fMonHocIn.ShowDialog();
        }

        private void mnuRptGiangDay_Click(object sender, EventArgs e)
        {
            frmRptGiangDay fGiangDayIn = new frmRptGiangDay();
            fGiangDayIn.ShowDialog();
        }

        private void mnuRptDonVi_Click(object sender, EventArgs e)
        {
            frmRptDonVi fDonViIn = new frmRptDonVi();
            fDonViIn.ShowDialog();
        }

        private void mnuInan_Click(object sender, EventArgs e)
        {

        }





    }
}
