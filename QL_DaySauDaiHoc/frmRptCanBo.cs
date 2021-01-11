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
    public partial class frmRptCanBo : Form
    {
        public frmRptCanBo()
        {
            InitializeComponent();
        }

        private void frmRptCanBo_Load(object sender, EventArgs e)
        {
            CrystalReportViewer crvCanBo = new CrystalReportViewer();
            rptCanBo crCanBo = new rptCanBo();
            this.WindowState = FormWindowState.Maximized;
            this.Controls.Add(crvCanBo);
            crvCanBo.Dock = DockStyle.Fill;
            TableLogOnInfo logonInfo = crCanBo.Database.Tables[0].LogOnInfo;
            logonInfo.ConnectionInfo.ServerName = MyPublics.strServer;
            logonInfo.ConnectionInfo.DatabaseName = "QL_DaySauDaiHoc";
            logonInfo.ConnectionInfo.IntegratedSecurity = false;
            logonInfo.ConnectionInfo.UserID = "TN207User";
            logonInfo.ConnectionInfo.Password = "TN207User";
            crCanBo.Database.Tables[0].ApplyLogOnInfo(logonInfo);
            crvCanBo.ReportSource = crCanBo;
        }
    }
}
