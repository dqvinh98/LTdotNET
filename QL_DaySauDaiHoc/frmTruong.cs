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
    public partial class frmTruong : Form
    {
        public frmTruong()
        {
            InitializeComponent();
        }

            DataSet dsTruong = new DataSet();
            SqlDataAdapter daTruong = new SqlDataAdapter();
            DataView dvTruong = new DataView();
            int ThemSua = 0;
            
        

        void DieuKhienKhiBinhThuong()
        {
            if (MyPublics.strQuyenSD == "AllAdmin")
            {
                btnThem.Enabled = true;
                btnChinhSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
                btnChinhSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            btnLuu.Enabled = false;
            btnKhongLuu.Enabled = false;
            btnDong.Enabled = true;
            txtMaTruong.ReadOnly = true;
            txtMaTruong.BackColor = Color.White;
            txtTenTruong.ReadOnly = true;
            txtTenTruong.BackColor = Color.White;
        }

        void DieuKhienKhiThem()
        {
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            txtMaTruong.ReadOnly = false;
            txtTenTruong.ReadOnly = false;
            txtMaTruong.Clear();
            txtTenTruong.Clear();            
            txtMaTruong.Focus();

        }

        void DieuKhienKhiChinhSua()
        {
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            txtMaTruong.ReadOnly = true;
            txtTenTruong.ReadOnly = false;
            txtTenTruong.Focus();
        }

        void GanDuLieu()
        {
            if (dvTruong.Count > 0)
            {
                txtMaTruong.Text = dgvTruong[0, dgvTruong.CurrentRow.Index].Value.ToString();
                txtTenTruong.Text = dgvTruong[1, dgvTruong.CurrentRow.Index].Value.ToString();
            }
            else
            {
                txtMaTruong.Clear();
                txtTenTruong.Clear();
            }
        
        }

        void NhanDuLieu()
        {
            string strSelect = "Select * From TRUONG";
            MyPublics.OpenData(strSelect, dsTruong, "TRUONG");
        
        }
       

        private void frmTruong_Load(object sender, EventArgs e)
        {
            NhanDuLieu();
            txtMaTruong.MaxLength = 8;
            txtTenTruong.MaxLength = 50;
            dvTruong.Table = dsTruong.Tables["TRUONG"];
            dgvTruong.DataSource = dvTruong;
            dgvTruong.Width = 520;
            dgvTruong.Height = 320;
            dgvTruong.AllowUserToAddRows = false;
            dgvTruong.AllowUserToDeleteRows = false;
            dgvTruong.Columns[0].Width = 120;
            dgvTruong.Columns[0].HeaderText = "Mã Trường";
            dgvTruong.Columns[1].Width = 340;
            dgvTruong.Columns[1].HeaderText = "Tên Trường";
            dgvTruong.EditMode = DataGridViewEditMode.EditProgrammatically;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
            
        }

        private void dgvTruong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GanDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSua = 1;
            DieuKhienKhiThem();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            ThemSua = 2;
            DieuKhienKhiChinhSua();
        }

        void ThucThiLuu()
        {
            string strSql;
            if (ThemSua == 1)          
                strSql = "Insert Into TRUONG Values(@MATRUONG, @TENTRUONG)";
            
            else
                strSql = "Update TRUONG Set TENTRUONG =@TENTRUONG Where MATRUONG=@MATRUONG";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MATRUONG", txtMaTruong.Text);
            cmdCommand.Parameters.AddWithValue("@TENTRUONG", txtTenTruong.Text);
            cmdCommand.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            dsTruong.Clear();
            NhanDuLieu();
            GanDuLieu();
            ThemSua = 0;
            DieuKhienKhiBinhThuong();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if ((txtMaTruong.Text == "") || (txtTenTruong.Text == ""))
                MessageBox.Show("Lỗi nhập dữ liệu !");
            else
                if ((ThemSua == 1) && (TonTaiKhoaChinh(txtMaTruong.Text,"TRUONG")))
                {
                    MessageBox.Show("Mã trường này đã có rồi !");
                    txtMaTruong.Focus();
                }
                else
                    ThucThiLuu();
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            ThemSua = 0;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            if (TonTaiKhoaChinh(txtMaTruong.Text,"DONVI"))
                MessageBox.Show("Phải xóa đơn vị trong trường này trước !");
            else
            {
                DialogResult blnOk;
                blnOk = MessageBox.Show("Bạn có thật sự muốn xóa ?", "Xác nhận", MessageBoxButtons.YesNo);
                if( blnOk == DialogResult.Yes)
                {
                    string strDelete = "Delete TRUONG Where MATRUONG = @MATRUONG";
                    if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                        MyPublics.conMyConnection.Open();
                    SqlCommand cmdCommand = new SqlCommand(strDelete, MyPublics.conMyConnection);
                    cmdCommand.Parameters.AddWithValue("@MATRUONG", txtMaTruong.Text);
                    cmdCommand.ExecuteNonQuery();
                    MyPublics.conMyConnection.Close();
                    dgvTruong.Rows.RemoveAt(dgvTruong.CurrentRow.Index);
                    GanDuLieu();

                
                }
            }
            DieuKhienKhiBinhThuong();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool TonTaiKhoaChinh(string strMaTruong, string strTable)
        {
            bool blnRessult = false;
            try
            {
                string sqlSelect = "Select * From "+strTable+" Where MATRUONG=@MATRUONG";
                if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                    MyPublics.conMyConnection.Open();
                SqlCommand cmdCommand = new SqlCommand(sqlSelect, MyPublics.conMyConnection);
                cmdCommand.Parameters.AddWithValue("@MATRUONG", strMaTruong);
                SqlDataReader drReader = cmdCommand.ExecuteReader();
                if (drReader.HasRows)
                    blnRessult = true;
                drReader.Close();
                MyPublics.conMyConnection.Close();
            }
            catch (Exception)
            {
            }
            return blnRessult;
        }
    }
}
