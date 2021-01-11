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
    public partial class frmDoiMatKhau : Form
    {
        private SqlCommand cmdCommand;
        private SqlDataReader drReader;

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            string strCB;
            txtCB.ReadOnly = true;
            strCB = MyPublics.strTaiKhoanDN;
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            string strSelect = "Select MACB, HOLOTCB, TENCB From CANBO Where MACB=@MACB";
            cmdCommand = new SqlCommand(strSelect, MyPublics.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MACB", strCB);
            drReader = cmdCommand.ExecuteReader();
            drReader.Read();
            txtCB.Text = drReader.GetString(0) + " - " + ' ' + drReader.GetString(1) + ' ' + drReader.GetString(2);
            drReader.Close();
            MyPublics.conMyConnection.Close();
            txtMKMoi.PasswordChar = '*';
            txtXacNhan.PasswordChar = '*';
        }

        private void btnChapNhan_Click(object sender, EventArgs e)
        {
            string strMK = txtMKMoi.Text;
            if ((txtMKMoi.Text == "") || (txtMKMoi.Text != txtXacNhan.Text))
                MessageBox.Show("Lỗi nhập dữ liệu!");
            else
            {
                string strSql = "Update CANBO Set MATKHAU=@MATKHAU Where MACB=@MACB";
                if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                    MyPublics.conMyConnection.Open();
                SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
                cmdCommand.Parameters.AddWithValue("@MATKHAU", strMK);
                cmdCommand.Parameters.AddWithValue("@MACB", MyPublics.strTaiKhoanDN);
                cmdCommand.ExecuteNonQuery();
                MyPublics.conMyConnection.Close();
                MessageBox.Show("Ðổi MK thành công");
                txtMKMoi.Clear();
                txtXacNhan.Clear();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
