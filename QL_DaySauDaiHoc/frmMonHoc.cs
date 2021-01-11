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
    public partial class frmMonHoc : Form
    {
        DataSet dsMonHoc = new DataSet();
        SqlDataAdapter daMonHoc = new SqlDataAdapter();
        BindingSource bsMonHoc = new BindingSource();
        bool blnThem = false;

        public frmMonHoc()
        {
            InitializeComponent();
        }

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
            txtMaMon.ReadOnly = true;
            txtMaMon.BackColor = Color.White;
            txtTenMon.ReadOnly = true;
            txtTenMon.BackColor = Color.White;
            txtTinChi.ReadOnly = true;
            txtTinChi.BackColor = Color.White;
            txtMMTD.ReadOnly = true;
            txtMMTD.BackColor = Color.White;
            txtTMTA.ReadOnly = true;
            txtTMTA.BackColor = Color.White;
        }

        void DieuKhienKhiThem()
        {
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtMaMon.ReadOnly = false;
            txtTenMon.ReadOnly = false;
            txtTinChi.ReadOnly = false;
            txtTMTA.ReadOnly = false;
            txtMMTD.ReadOnly = false;
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtTinChi.Clear();
            txtMMTD.Clear();
            txtTMTA.Clear();
            txtMaMon.Focus();
        }

        void DieuKhienKhiChinhSua()
        {
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtTenMon.ReadOnly = false;
            txtTinChi.ReadOnly = false;
            txtTMTA.ReadOnly = false;
            txtMMTD.ReadOnly = false;
            chkMonChung.Enabled = true;
            txtTenMon.Focus();
        }

        void GanDuLieu()
        {
            txtMaMon.DataBindings.Add(new Binding("Text", bsMonHoc, "MAMON"));
            txtTenMon.DataBindings.Add(new Binding("Text", bsMonHoc, "TENMON"));
            txtTinChi.DataBindings.Add(new Binding("Text", bsMonHoc, "TINCHI"));
            txtMMTD.DataBindings.Add(new Binding("Text", bsMonHoc, "MAMONTUONGDUONG"));
            txtTMTA.DataBindings.Add(new Binding("Text", bsMonHoc, "TENMONTIENGANH"));
            chkMonChung.DataBindings.Add(new Binding("Checked", bsMonHoc, "MONCHUNG"));
            
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            string strSelect = "Select * From MONHOC";
            MyPublics.OpenData(strSelect, dsMonHoc, "MONHOC", daMonHoc);
            bsMonHoc.DataSource = dsMonHoc;
            bsMonHoc.DataMember = "MONHOC";
            GanDuLieu();
            dgvMonHoc.DataSource = dsMonHoc;
            dgvMonHoc.DataMember = "MONHOC";
            dgvMonHoc.Width =850;
            dgvMonHoc.Height = 190;
            dgvMonHoc.Columns[0].Width = 100;
            dgvMonHoc.Columns[0].HeaderText = "Mã Môn";
            dgvMonHoc.Columns[1].Width = 250;
            dgvMonHoc.Columns[1].HeaderText = "Tên Môn";
            dgvMonHoc.Columns[2].Width = 90;
            dgvMonHoc.Columns[2].HeaderText = "Môn Chung";
            dgvMonHoc.Columns[3].Width = 90;
            dgvMonHoc.Columns[3].HeaderText = "Tín Chỉ";
            dgvMonHoc.Columns[4].Width = 90;
            dgvMonHoc.Columns[4].HeaderText = "Mã Môn Tương Đương";
            dgvMonHoc.Columns[5].Width = 180;
            dgvMonHoc.Columns[5].HeaderText = "Tên Môn Tiếng Anh";
            dgvMonHoc.AllowUserToAddRows = false;
            dgvMonHoc.AllowUserToDeleteRows = false;
            dgvMonHoc.EditMode = DataGridViewEditMode.EditProgrammatically;
            DieuKhienKhiBinhThuong();



            DieuKhienKhiBinhThuong();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            blnThem = true;
            bsMonHoc.AddNew();
            DieuKhienKhiThem();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            DieuKhienKhiChinhSua();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int khoa;
            if ((txtMaMon.Text == "") || (txtTenMon.Text == "") || (!int.TryParse(txtTinChi.Text, out khoa)) || (khoa <= 0))
            {
                MessageBox.Show("Lỗi nhập dữ liệu!");
            }
            else
                if((blnThem) && (MyPublics.TonTaiKhoaChinh(txtMaMon.Text,"MAMON", "MONHOC")))
                {
                    MessageBox.Show("Mã môn này dã có rồi !");
                    txtMaMon.Focus();                    
                }
                else
                {
                    bsMonHoc.EndEdit();
                    daMonHoc.Update(dsMonHoc, "MONHOC");
                    dsMonHoc.AcceptChanges();
                    blnThem = false;
                    DieuKhienKhiBinhThuong();       
                }
            if (chkMonChung.Checked)
            {
                bsMonHoc.EndEdit();
                daMonHoc.Update(dsMonHoc, "MONHOC");
                dsMonHoc.AcceptChanges();
                blnThem = false;
                DieuKhienKhiBinhThuong();
            }
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            bsMonHoc.EndEdit();
            dsMonHoc.RejectChanges();
            blnThem = false;
            DieuKhienKhiBinhThuong();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MyPublics.TonTaiKhoaChinh(txtMaMon.Text, "MAMON", "GIANGDAY"))
                MessageBox.Show("Phải xóa mã môn thuộc giảng dạy trước");
            else
            {
                DialogResult blnDongY;
                blnDongY = MessageBox.Show("Bạn có thật sự muốn xóa?","Xác nhận",MessageBoxButtons.YesNo);
                if (blnDongY == DialogResult.Yes)
                {
                    bsMonHoc.RemoveCurrent();
                    daMonHoc.Update(dsMonHoc, "MONHOC");
                    dsMonHoc.AcceptChanges();
                }
            }
            DieuKhienKhiBinhThuong();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bsMonHoc.Position = dgvMonHoc.CurrentRow.Index;
        }

    }
}
