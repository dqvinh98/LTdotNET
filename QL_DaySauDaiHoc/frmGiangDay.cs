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
    public partial class frmGiangDay : Form
    {
        DataSet dsGiangDay = new DataSet();
        SqlDataAdapter daGiangDay = new SqlDataAdapter();
        BindingSource bsGiangDay = new BindingSource();
        DataView dvGiangDay = new DataView();
        DataSet dsMonHoc = new DataSet();
        DataView dvMonHoc = new DataView();

        public frmGiangDay()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DieuKhienKhiBinhThuong()
        {
            if (dvGiangDay.Count > 0)
            {
                bsGiangDay.Position = bsGiangDay.Find("MACB", dgvGiangDay[3, 0].Value.ToString());
                dgvGiangDay.AllowUserToAddRows = false;
                dgvGiangDay.AllowUserToDeleteRows = false;
                dgvGiangDay.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
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
            cboMonHoc.Enabled = true;
            txtHK.Enabled = true;
        }

        private void DieuKhienKhiThem()
        {
            dgvGiangDay.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvGiangDay.AllowUserToAddRows = true;
            dgvGiangDay.Columns[3].ReadOnly = false;
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnDong.Enabled = false;
            cboMonHoc.Enabled = false;
            dgvGiangDay.CurrentCell = dgvGiangDay[0, dgvGiangDay.RowCount - 1];
        }

        private void DieuKhienKhiChinhSua()
        {
            dgvGiangDay.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvGiangDay.Columns[3].ReadOnly = true;
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnDong.Enabled = false;
            cboMonHoc.Enabled = false;
            dgvGiangDay.CurrentCell = dgvGiangDay[0, 0];
        }

        private void NhanDuLieu()
        {
            string strSelect = "Select Distinct MONHOC.MAMON, MONHOC.MAMON + ' - ' + TENMON As TenMonHoc From MONHOC, GIANGDAY Where MONHOC.MAMON = GIANGDAY.MAMON And HOCKY= '" + MyPublics.strHK + "'";
            MyPublics.OpenData(strSelect, dsMonHoc, "MonHoc");
            strSelect = "Select * From GIANGDAY Where HOCKY= '" + MyPublics.strHK + "'";
            MyPublics.OpenData(strSelect, dsGiangDay, "GiangDay", daGiangDay);
            bsGiangDay.DataSource = dsGiangDay;
            bsGiangDay.DataMember = "GiangDay";
            cboMonHoc.DisplayMember = "TenMonHoc";
            cboMonHoc.ValueMember = "MAMON";
            cboMonHoc.DataSource = dsMonHoc.Tables["MonHoc"];
            cboMonHoc.SelectedIndex = 0;
            dvGiangDay.Table = dsGiangDay.Tables["GiangDay"];
            dvGiangDay.RowFilter = "MAMON like '" + cboMonHoc.SelectedValue + "'";
            dvGiangDay.Sort = "MACB";
            dgvGiangDay.DataSource = dvGiangDay;
        }

        private void frmGiangDay_Load(object sender, EventArgs e)
        {
            txtHK.Text = MyPublics.strHK;
            txtHK.ReadOnly = true;
            txtHK.BackColor = Color.White;
            try
            {
                NhanDuLieu();
                
                dgvGiangDay.Width = 690;
                dgvGiangDay.Height = 250;
                dgvGiangDay.Columns[0].Width = 80;
                dgvGiangDay.Columns[0].HeaderText = "MALOP";
                dgvGiangDay.Columns[1].Width = 80;
                dgvGiangDay.Columns[1].HeaderText = "MAMON";
                dgvGiangDay.Columns[2].Width = 80;
                dgvGiangDay.Columns[2].HeaderText = "HOCKY";
                dgvGiangDay.Columns[3].Width = 80;
                dgvGiangDay.Columns[3].HeaderText = "MACB";
                dgvGiangDay.Columns[4].Width = 80;
                dgvGiangDay.Columns[4].HeaderText = "GHICHU";
                dgvGiangDay.Columns[5].Width = 90;
                dgvGiangDay.Columns[5].HeaderText = "NGAYDAY";
                dgvGiangDay.Columns[6].Width = 80;
                dgvGiangDay.Columns[6].HeaderText = "THIROI";
                dgvGiangDay.Columns[7].Width = 80;
                dgvGiangDay.Columns[7].HeaderText = "CODIEM";
                DieuKhienKhiBinhThuong();
            }
            catch (Exception)
            {
                MessageBox.Show("Chưa có dữ liệu!", "Thông báo");
                this.Close();
            }
              
        }

        private void cboMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvGiangDay.RowFilter = "MAMON like '" + cboMonHoc.SelectedValue + "'";
            dgvGiangDay.DataSource = dvGiangDay;
            DieuKhienKhiBinhThuong();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DieuKhienKhiThem();
        }

        private void dgvGiangDay_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            int intRow = dgvGiangDay.RowCount - 1;
            dgvGiangDay[1, intRow].Value = cboMonHoc.SelectedValue.ToString();
            dgvGiangDay[2, intRow].Value = MyPublics.strHK;
            dgvGiangDay[6, intRow].Value = false;
            dgvGiangDay[7, intRow].Value = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                bsGiangDay.EndEdit();
                daGiangDay.Update(dsGiangDay, "GiangDay");
                dsGiangDay.Tables["GiangDay"].AcceptChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi nhập dữ liệu!", "Thông báo");
            }
            finally
            {
                DieuKhienKhiBinhThuong();
                dsGiangDay.Clear();
                dsMonHoc.Clear();
                NhanDuLieu();
            }
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            dvGiangDay.Delete(dvGiangDay.Count - 1);
            bsGiangDay.EndEdit();
            dsGiangDay.RejectChanges();
            DieuKhienKhiBinhThuong();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            DieuKhienKhiChinhSua();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult blnDongY = MessageBox.Show("Bạn thật sự muốn xóa ?", "Xác nhận", MessageBoxButtons.YesNo);
            if (blnDongY == DialogResult.Yes)
                try
                {
                    dgvGiangDay.AllowUserToDeleteRows = true;
                    dgvGiangDay.Rows.Remove(dgvGiangDay.CurrentRow);
                    daGiangDay.Update(dsGiangDay, "GiangDay");
                    dsGiangDay.Tables["GiangDay"].AcceptChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi dữ liệu !", "Thông báo");
                    btnKhongLuu.Enabled = true;
                }
                finally
                {
                    DieuKhienKhiBinhThuong();
                }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
