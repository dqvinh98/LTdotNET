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
    public partial class frmDonVi : Form
    {
        public frmDonVi()
        {
            InitializeComponent();
        }
        DataSet dsDonVi = new DataSet();
        DataSet dsTruong = new DataSet();
        SqlDataAdapter daDonVi = new SqlDataAdapter();
        BindingSource bsDonVi = new BindingSource();
        DataView dvDonVi = new DataView();
        int ViTriTruong, ThemSua = 0;

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
                if ((MyPublics.strQuyenSD == "Admin") && (MyPublics.strDonVi == txtMaDonVi.Text))
                {
                    btnThem.Enabled = false;
                    btnChinhSua.Enabled = true;
                    btnXoa.Enabled = false;
                }
                else
                {
                    btnThem.Enabled = false;
                    btnChinhSua.Enabled = false;
                    btnXoa.Enabled = false;
                }           
            }
            btnLuu.Enabled = false;
            btnKhongLuu.Enabled = false;
            btnDong.Enabled = true;
            txtMaDonVi.ReadOnly = true;
            txtMaDonVi.BackColor = Color.White;
            cboMaTruong.Enabled = true;
            txtTenDonVi.ReadOnly = true;
            txtTenDonVi.BackColor = Color.White;
            
            
        }

        void DieuKhienKhiThem()
        {
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            txtTenDonVi.ReadOnly = false;
            txtMaDonVi.ReadOnly = false;
            txtMaDonVi.Clear();
            txtTenDonVi.Clear();
            cboMaTruong.Enabled = true;            
            txtMaDonVi.Focus();

        }

        void DieuKhienKhiChinhSua()
        {
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            txtTenDonVi.ReadOnly = false;
            txtMaDonVi.ReadOnly = true;
            txtTenDonVi.Focus();

 
        }

        void GanDuLieu()
        {
            if (dvDonVi.Count > 0)
            {
                txtMaDonVi.Text = dgvDonVi[0, dgvDonVi.CurrentRow.Index].Value.ToString();
                txtTenDonVi.Text = dgvDonVi[1, dgvDonVi.CurrentRow.Index].Value.ToString();
                cboMaTruong.SelectedIndex = cboMaTruong.FindString(dgvDonVi[2, dgvDonVi.CurrentRow.Index].Value.ToString());
                
            }
            else
            {
                txtMaDonVi.Clear();
                txtTenDonVi.Clear();
                
                //cboMaTruong.SelectedIndex = -1;
            }
        }
        void NhanDuLieu()
        {
            string strSelect = "Select * From DONVI";
            MyPublics.OpenData(strSelect, dsDonVi, "DONVI");
        }         

        

        private void frmDonVi_Load(object sender, EventArgs e)
        {
            string strSelect = "Select Distinct MATRUONG, MATRUONG + ' - ' + TENTRUONG As TenTruong FROM TRUONG";
            MyPublics.OpenData(strSelect, dsTruong, "Truong"); 
            cboMaTruong.DataSource = dsTruong.Tables["Truong"];
            cboMaTruong.DisplayMember= "TenTruong";
            cboMaTruong.ValueMember = "MATRUONG";
            txtMaDonVi.MaxLength = 8;
            txtTenDonVi.MaxLength = 40;
            NhanDuLieu();
            dvDonVi.Table = dsDonVi.Tables["DONVI"];
            //dvDonVi.RowFilter = "MATRUONG like '" + cboMaTruong.SelectedValue + "'";      
            dgvDonVi.DataSource = dvDonVi;
            dgvDonVi.Width = 440;
            dgvDonVi.Height = 190;
            dgvDonVi.AllowUserToAddRows = false;
            dgvDonVi.AllowUserToDeleteRows = false;
            dgvDonVi.Columns[0].Width = 95;
            dgvDonVi.Columns[0].HeaderText = "Mã Đơn Vị";
            dgvDonVi.Columns[1].Width = 190;
            dgvDonVi.Columns[1].HeaderText = "Tên Đơn Vị";
            dgvDonVi.Columns[2].Width = 95;
            dgvDonVi.Columns[2].HeaderText = "Mã Trường";
            dgvDonVi.EditMode = DataGridViewEditMode.EditProgrammatically;
            //dgvDonVi.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dgvDonVi_CellFormatting);
            GanDuLieu();   
            DieuKhienKhiBinhThuong();
            


        }

       
        

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSua = 1;
            DieuKhienKhiThem();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            ThemSua = 2;
            ViTriTruong = cboMaTruong.SelectedIndex;
            DieuKhienKhiChinhSua();

        }
        void ThucThiLuu()
        {
            string strSql, strMaTruong = cboMaTruong.SelectedText;
            if (ThemSua == 1)
                strSql = "Insert Into DONVI Values (@MADV, @TENDV, @MATRUONG)";
            else
                strSql = "Update DONVI Set  TENDV = @TENDV, MATRUONG = @MATRUONG where MADV = @MADV";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MADV", txtMaDonVi.Text);
            cmdCommand.Parameters.AddWithValue("@TENDV", txtTenDonVi.Text);
            cmdCommand.Parameters.AddWithValue("@MATRUONG", cboMaTruong.SelectedValue.ToString());
            cmdCommand.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            dsDonVi.Clear();
            NhanDuLieu();
            GanDuLieu();
            ThemSua = 0;
            DieuKhienKhiBinhThuong();
        }

        

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if ((txtMaDonVi.Text == "") || (txtTenDonVi.Text == "") || (cboMaTruong.SelectedIndex == -1))
                MessageBox.Show("Lỗi nhập dữ liệu !");
            else
                if ((ThemSua == 1) && (MyPublics.TonTaiKhoaChinh(txtMaDonVi.Text, "MADV", "DONVI")))
                {
                    MessageBox.Show("Mã đơn vị này đã có rồi !");
                    txtMaDonVi.Focus();
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
            if (MyPublics.TonTaiKhoaChinh(txtMaDonVi.Text, "MADV", "CANBO"))
                MessageBox.Show("Phải xóa cán bộ trong đơn vị này trước !");
            else
            {
                DialogResult blnDongY;
                blnDongY = MessageBox.Show("Bạn thật sự muốn xóa ?", "Xác nhận xóa!", MessageBoxButtons.YesNo);
                if (blnDongY == DialogResult.Yes)
                {
                    string strDelete = "Delete DONVI Where MADV = @MADV";
                    if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                        MyPublics.conMyConnection.Open();
                    SqlCommand cmdCommand = new SqlCommand(strDelete, MyPublics.conMyConnection);
                    cmdCommand.Parameters.AddWithValue("@MADV", txtMaDonVi.Text);
                    cmdCommand.ExecuteNonQuery();
                    MyPublics.conMyConnection.Close();
                    dgvDonVi.Rows.RemoveAt(dgvDonVi.CurrentRow.Index);
                    GanDuLieu();
                }

            }
            DieuKhienKhiBinhThuong();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDonVi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }



       
    }
}
