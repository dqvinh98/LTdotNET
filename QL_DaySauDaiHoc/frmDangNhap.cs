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

namespace QL_DaySauDaiHoc
{
    public partial class frmDangNhap : Form
    {
        int intSoLanDangNhap;
        private frmMain fMain;

        public frmDangNhap()
        {
            InitializeComponent();
        }

        public frmDangNhap(frmMain fm)
            : this()
        {
            fMain = fm;
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            intSoLanDangNhap = 0;
            /*txtMayChu.Text = "localhost";
            txtMaCB.Text = "abc";
            txtMatKhau.Text = "abc";*/
            txtMatKhau.PasswordChar = '*';
            //txtMaCB.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlCommand cmdCommand;
            SqlDataReader drReader;
            string sqlSelect, strPasswordSV;
            MyPublics.strServer = txtMayChu.Text;
            try
            {
                MyPublics.ConnectDatabase();
                if (MyPublics.conMyConnection.State == ConnectionState.Open)
                {
                    MyPublics.strMACB = txtMaCB.Text;
                    strPasswordSV = txtMatKhau.Text;
                    sqlSelect = "Select MADV, QUYENSD From CANBO Where MACB=@MACB And MATKHAU=@MATKHAU";
                    cmdCommand = new SqlCommand(sqlSelect, MyPublics.conMyConnection);
                    cmdCommand.Parameters.AddWithValue("@MACB", txtMaCB.Text);
                    cmdCommand.Parameters.AddWithValue("@MatKhau", strPasswordSV);
                    drReader = cmdCommand.ExecuteReader();
                    if (drReader.HasRows)
                    {
                        drReader.Read();
                        MyPublics.strDonVi = drReader.GetString(0);
                        MyPublics.strQuyenSD = drReader.GetString(1);
                        MyPublics.strTaiKhoanDN = txtMaCB.Text;
                        drReader.Close();
                        fMain.mnuDuLieu.Enabled = true;
                        fMain.mnuCapNhat.Enabled = true;
                        fMain.mnuDangNhap.Enabled = true;
                        fMain.mnuDoiMK.Enabled = true;
                        fMain.mnuThoatDangNhap.Enabled = true;
                        MessageBox.Show("Ðăng nhập thành công", "Thông báo");
                        MyPublics.conMyConnection.Close();
                        this.Close();
                    }
                    else
                        if (intSoLanDangNhap < 2)
                        {
                            MessageBox.Show("Mã CB hoặc mật khẩu sai!", "Thông báo");
                            intSoLanDangNhap++;
                            txtMaCB.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi đăng nhập, Form sẽ đóng!", "Thông báo");
                            MyPublics.conMyConnection.Close();
                            fMain.mnuDuLieu.Enabled = false;
                            fMain.mnuCapNhat.Enabled = false;
                            fMain.mnuDoiMK.Enabled = false;
                            fMain.mnuThoatDangNhap.Enabled = false;
                            this.Close();
                        }
                }
                else
                {
                    MessageBox.Show("Kết nối không thành công", "Thông báo");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi thực hiện kết nối", "Thông báo");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MyPublics.conMyConnection != null)
                MyPublics.conMyConnection = null;
            fMain.mnuDuLieu.Enabled = false;
            fMain.mnuCapNhat.Enabled = false;
            fMain.mnuDoiMK.Enabled = false;
            fMain.mnuThoatDangNhap.Enabled = false;
            fMain.mnuInan.Enabled = false;
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
