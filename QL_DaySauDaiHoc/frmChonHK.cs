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
    public partial class frmChonHK : Form
    {
        DataSet dsHK = new DataSet();

        public frmChonHK()
        {
            InitializeComponent();
        }

        private void frmChonHK_Load(object sender, EventArgs e)
        {
            string strSelect = "Select Distinct HOCKY From GIANGDAY";
            MyPublics.OpenData(strSelect, dsHK, "HocKy");
            cboHK.DataSource = dsHK.Tables["HocKy"];
            cboHK.DisplayMember = "HOCKY";
            cboHK.ValueMember = "HOCKY";
            cboHK.SelectedIndex = 0;
        }

        private void btnChapNhan_Click(object sender, EventArgs e)
        {
            MyPublics.strHK = cboHK.SelectedValue.ToString();
            this.Close();
            frmGiangDay fGiangDay = new frmGiangDay();
            fGiangDay.ShowDialog();
        }
    }
}
