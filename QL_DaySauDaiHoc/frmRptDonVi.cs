using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;


namespace QL_DaySauDaiHoc
{
    public partial class frmRptDonVi : Form
    {
        public frmRptDonVi()
        {
            InitializeComponent();
        }

        private void frmRptDonVi_Load(object sender, EventArgs e)
        {
            CrystalReportViewer crvDonVi = new CrystalReportViewer();
            rptDonVi crDonVi = new rptDonVi();
            this.WindowState = FormWindowState.Maximized;
            this.Controls.Add(crvDonVi);
            crvDonVi.Dock = DockStyle.Fill;
            TableLogOnInfo logonInfo = crDonVi.Database.Tables[0].LogOnInfo;
            logonInfo.ConnectionInfo.ServerName = MyPublics.strServer;
            logonInfo.ConnectionInfo.DatabaseName = "QL_DaySauDaiHoc";
            logonInfo.ConnectionInfo.IntegratedSecurity = false;
            logonInfo.ConnectionInfo.UserID = "TN207User";
            logonInfo.ConnectionInfo.Password = "TN207User";
            crDonVi.Database.Tables[0].ApplyLogOnInfo(logonInfo);
            crvDonVi.ReportSource = crDonVi;
        }
    }
}
