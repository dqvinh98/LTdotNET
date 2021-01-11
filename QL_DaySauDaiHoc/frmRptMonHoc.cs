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
    public partial class frmRptMonHoc : Form
    {
        public frmRptMonHoc()
        {
            InitializeComponent();
        }

        private void frmRptMonHoc_Load(object sender, EventArgs e)
        {
            CrystalReportViewer crvMonHoc = new CrystalReportViewer();
            rptMonHoc crMonHoc = new rptMonHoc();
            this.WindowState = FormWindowState.Maximized;
            this.Controls.Add(crvMonHoc);
            crvMonHoc.Dock = DockStyle.Fill;
            TableLogOnInfo logonInfo = crMonHoc.Database.Tables[0].LogOnInfo;
            logonInfo.ConnectionInfo.ServerName = MyPublics.strServer;
            logonInfo.ConnectionInfo.DatabaseName = "QL_DaySauDaiHoc";
            logonInfo.ConnectionInfo.IntegratedSecurity = false;
            logonInfo.ConnectionInfo.UserID = "TN207User";
            logonInfo.ConnectionInfo.Password = "TN207User";
            crMonHoc.Database.Tables[0].ApplyLogOnInfo(logonInfo);
            crvMonHoc.ReportSource = crMonHoc;
        }
    }
}
