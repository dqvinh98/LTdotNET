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
    public partial class frmRptGiangDay : Form
    {
        public frmRptGiangDay()
        {
            InitializeComponent();
        }

        private void frmRptGiangDay_Load(object sender, EventArgs e)
        {
            CrystalReportViewer crvGiangDay = new CrystalReportViewer();
            rptGiangDay crGiangDay = new rptGiangDay();
            this.WindowState = FormWindowState.Maximized;
            this.Controls.Add(crvGiangDay);
            crvGiangDay.Dock = DockStyle.Fill;
            TableLogOnInfo logonInfo = crGiangDay.Database.Tables[0].LogOnInfo;
            logonInfo.ConnectionInfo.ServerName = MyPublics.strServer;
            logonInfo.ConnectionInfo.DatabaseName = "QL_DaySauDaiHoc";
            logonInfo.ConnectionInfo.IntegratedSecurity = false;
            logonInfo.ConnectionInfo.UserID = "TN207User";
            logonInfo.ConnectionInfo.Password = "TN207User";
            crGiangDay.Database.Tables[0].ApplyLogOnInfo(logonInfo);
            crvGiangDay.ReportSource = crGiangDay;
        }
    }
}
