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
    public partial class frmCanBo : Form
    {
        DataSet dsCanBo = new DataSet();
        DataSet dsDonVi = new DataSet();
        DataView dvCanBo = new DataView();
        DataSet dsQuyenSD = new DataSet();
        SqlDataAdapter daCanBo = new SqlDataAdapter();
        BindingSource bsCanBo = new BindingSource();

        int ViTriDonVi, ThemSua = 0;

        public frmCanBo()
        {
            InitializeComponent();
        }

        private void DieuKhienKhiBinhThuong()
        {
            if (MyPublics.strQuyenSD == "AllAdmin")
            {
                btnThem.Enabled = true;
                btnChinhSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            else
            {
                if (MyPublics.strQuyenSD == "Admin" && MyPublics.strDonVi == cboDV.SelectedValue.ToString())
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
            txtMaNganh.ReadOnly = true;
            txtMaNganh.BackColor = Color.White;
            txtHoLotCB.ReadOnly = true;
            txtHoLotCB.BackColor = Color.White;
            txtTenCB.ReadOnly = true;
            txtTenCB.BackColor = Color.White;
            txtMaCB.ReadOnly = true;
            txtMaCB.BackColor = Color.White;
        }

        private void DieuKhienKhiThem()
        {
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtMaNganh.ReadOnly = false;
            txtHoLotCB.ReadOnly = false;
            txtTenCB.ReadOnly = false;
            txtMaCB.ReadOnly = false;
            txtMaNganh.Clear();
            txtHoLotCB.Clear();
            txtTenCB.Clear();
            txtMaCB.Clear();
            cboQuyenSD.SelectedIndex = 0;
        }

       private void DieuKhienKhiChinhSua()
        {
            btnChinhSua.Enabled = false;
            btnDong.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnKhongLuu.Enabled = true;
            btnLuu.Enabled = true;
            txtHoLotCB.ReadOnly = false;
            txtTenCB.ReadOnly = false;
            txtMaNganh.ReadOnly = false;
            if (MyPublics.strQuyenSD == "Admin" && MyPublics.strDonVi == cboDV.SelectedValue.ToString())
                cboQuyenSD.Enabled = false;

        }

        private void NhanDuLieu()
        {
            string strSelect = "Select * From CANBO";
            MyPublics.OpenData(strSelect, dsCanBo, "CANBO");
        }

       private void GanDuLieu()
        {
            dvCanBo.RowFilter = "MADV like '" + cboDV.SelectedValue + "'";
            if (dvCanBo.Count > 0)
            {
                txtMaCB.Text = dgvCanBo[0, dgvCanBo.CurrentRow.Index].Value.ToString();
                txtHoLotCB.Text = dgvCanBo[1, dgvCanBo.CurrentRow.Index].Value.ToString();
                txtTenCB.Text = dgvCanBo[2, dgvCanBo.CurrentRow.Index].Value.ToString();
                txtMaNganh.Text = dgvCanBo[7, dgvCanBo.CurrentRow.Index].Value.ToString();
                if (dgvCanBo[3, dgvCanBo.CurrentRow.Index].Value.ToString() == "")
                {
                    dtpNSCB.Format = DateTimePickerFormat.Custom;
                    dtpNSCB.CustomFormat = " ";  
                }
                else
                {
                    dtpNSCB.CustomFormat = "";
                    dtpNSCB.Value = DateTime.Parse(dgvCanBo[3, dgvCanBo.CurrentRow.Index].Value.ToString());
                }
                if (bool.Parse(dgvCanBo[4, dgvCanBo.CurrentRow.Index].Value.ToString()) == true)
                    rdoNam.Checked = true;
                else
                    rdoNu.Checked = true;
                cboQuyenSD.SelectedIndex = cboQuyenSD.FindString(dgvCanBo[8, dgvCanBo.CurrentRow.Index].Value.ToString());
            }

                else
                {
                    txtHoLotCB.Clear();
                    txtMaCB.Clear();
                    txtTenCB.Clear();
                    txtMaNganh.Clear();
                    rdoNam.Checked=true;
                    dtpNSCB.Value = DateTime.Today;
                    cboQuyenSD.SelectedIndex=-1;
                }
            
            }
      
        private void frmCanBo_Load(object sender, EventArgs e)
        {
            string strSelect = "Select Distinct MADV, MADV + ' - ' + TENDV + ' - ' + TENTRUONG As TenDonVi From DONVI, TRUONG Where DONVI.MATRUONG=TRUONG.MATRUONG";
            MyPublics.OpenData(strSelect, dsDonVi, "DONVI");
            cboDV.DataSource = dsDonVi.Tables["DONVI"];
            cboDV.ValueMember = "MADV";
            cboDV.DisplayMember = "TenDonVi";
            dsQuyenSD.Tables.Add("DSQUYENSD");
            dsQuyenSD.Tables["DSQUYENSD"].Columns.Add("QUYENSD");
            dsQuyenSD.Tables["DSQUYENSD"].Rows.Add("User");
            dsQuyenSD.Tables["DSQUYENSD"].Rows.Add("Admin");
            dsQuyenSD.Tables["DSQUYENSD"].Rows.Add("AllAdmin");
            cboQuyenSD.DataSource = dsQuyenSD;
            cboQuyenSD.DisplayMember = "DSQUYENSD.QUYENSD";
            cboQuyenSD.ValueMember = "DSQUYENSD.QUYENSD";
            NhanDuLieu();
            dvCanBo.Table = dsCanBo.Tables["CANBO"];
            dvCanBo.RowFilter = "MADV like '" + cboDV.SelectedValue + "'";
            dgvCanBo.DataSource = dvCanBo; 
            dgvCanBo.Width = 780;
            dgvCanBo.Height = 190;
            dgvCanBo.AllowUserToAddRows = false;
            dgvCanBo.AllowUserToDeleteRows = false;
            dgvCanBo.Columns[0].Width = 60;
            dgvCanBo.Columns[0].HeaderText = "Mã CB";
            dgvCanBo.Columns[1].Width = 120;
            dgvCanBo.Columns[1].HeaderText = "Họ lót CB";
            dgvCanBo.Columns[2].Width = 80;
            dgvCanBo.Columns[2].HeaderText = "Tên";
            dgvCanBo.Columns[3].Width = 100;
            dgvCanBo.Columns[3].HeaderText = "NSCB";
            dgvCanBo.Columns[4].Width = 60;
            dgvCanBo.Columns[4].HeaderText = "Phái";
            dgvCanBo.Columns[5].Width = 70;
            dgvCanBo.Columns[5].HeaderText = "Mã ĐV";
            dgvCanBo.Columns[6].Width = 80;
            dgvCanBo.Columns[6].HeaderText = "Mật khẩu";
            dgvCanBo.Columns[7].Width = 70;
            dgvCanBo.Columns[7].HeaderText = "Mã ngành";
            dgvCanBo.Columns[8].Width = 80;
            dgvCanBo.Columns[8].HeaderText = "Quyền SD";
            dgvCanBo.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvCanBo.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dgvCanBo_CellFormatting);
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }

        private void dgvCanBo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (e.Value != null)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
        }

        private void dgvCanBo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GanDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSua = 1;
            txtMaNganh.Focus();
            DieuKhienKhiThem();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            ThemSua = 2;
            ViTriDonVi = cboDV.SelectedIndex;
            DieuKhienKhiChinhSua();
        }

        private void ThucThiLuu()
        {
            string strSql, strMatKhau, strPhai = "True";
            if (ThemSua == 1)
            {
                strSql = "Insert Into CANBO Values(@MACB, @HOLOTCB, @TENCB, @NSCB, @PHAICB, @MADV, @MATKHAU, @MANGANH, @QUYENSD)";
            }
            else
                strSql = "Update CANBO Set HOLOTCB = @HOLOTCB, TENCB = @TENCB, NSCB = @NSCB, PHAICB = @PHAICB, MADV = @MADV, MANGANH = @MANGANH, QUYENSD = @QUYENSD Where MACB = @MACB";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MACB", txtMaCB.Text);
            cmdCommand.Parameters.AddWithValue("@HOLOTCB", txtHoLotCB.Text);
            cmdCommand.Parameters.AddWithValue("@TENCB", txtTenCB.Text);
            if (rdoNu.Checked)
                strPhai = "False";
            cmdCommand.Parameters.AddWithValue("@PHAICB", strPhai);
            if (dtpNSCB.CustomFormat == " ")
                cmdCommand.Parameters.AddWithValue("@NSCB", DBNull.Value);
            else
                cmdCommand.Parameters.AddWithValue("@NSCB", dtpNSCB.Value);
            cmdCommand.Parameters.AddWithValue("@MADV", cboDV.SelectedValue.ToString());
            if (ThemSua == 1)
            {
                strMatKhau = txtMaCB.Text;
                cmdCommand.Parameters.AddWithValue("@MATKHAU", strMatKhau);
            }
            cmdCommand.Parameters.AddWithValue("@MANGANH", txtMaNganh.Text);
            cmdCommand.Parameters.AddWithValue("@QUYENSD", cboQuyenSD.SelectedValue.ToString());
            cmdCommand.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            dsCanBo.Clear();
            NhanDuLieu();
            GanDuLieu();
            ThemSua = 0;
            DieuKhienKhiBinhThuong();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if ((txtMaCB.Text == "") || (txtHoLotCB.Text == "") || (txtTenCB.Text == "") || (cboDV.SelectedIndex == -1))
                MessageBox.Show("Lỗi nhập dữ liệu !");
            else
                if ((ThemSua == 1) && (MyPublics.TonTaiKhoaChinh(txtMaCB.Text, "MACB", "CANBO")))
                {
                    MessageBox.Show("Mã cán bộ này đã có rồi!");
                    txtMaCB.Focus();
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
            if(MyPublics.TonTaiKhoaChinh(txtMaCB.Text, "MACB", "GIANGDAY"))

                MessageBox.Show("Phải xóa cán bộ ở giảng dạy trước !");
                else
    {
       DialogResult blnDongY;
        blnDongY = MessageBox.Show("Bạn có thật sự muốn xóa?","Xác nhận",MessageBoxButtons.YesNo);
        if (blnDongY == DialogResult.Yes)
        {
            string strDelete = "Delete CANBO Where MACB = @MACB";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdCommand = new SqlCommand(strDelete, MyPublics.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MACB", txtMaCB.Text);
            cmdCommand.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            dgvCanBo.Rows.RemoveAt(dgvCanBo.CurrentRow.Index);
            GanDuLieu();
        }
    }
            DieuKhienKhiBinhThuong();
        }
        
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboDV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if ((cboDV.SelectedIndex != -1) && (ThemSua == 0))
            {
                dvCanBo.RowFilter = "MADV like '" + cboDV.SelectedValue + "'";
                dgvCanBo.DataSource = dvCanBo;
                GanDuLieu();
                DieuKhienKhiBinhThuong();
            }
        }

        private void dtpNSCB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                dtpNSCB.Format = DateTimePickerFormat.Custom;
                dtpNSCB.CustomFormat = " ";
            }
        }

        private void dtpNSCB_ValueChanged(object sender, EventArgs e)
        {
            dtpNSCB.CustomFormat = "";
        }
    }
}
