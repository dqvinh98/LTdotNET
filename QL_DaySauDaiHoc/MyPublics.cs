using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_DaySauDaiHoc
{
    public class MyPublics
    {
        public static SqlConnection conMyConnection;
        public static string strServer, strMACB, strDonVi, strQuyenSD, strHK, strTaiKhoanDN;

        public static void ConnectDatabase()
        {
            string strConn = "Server = " + strServer + "; Database = QL_DaySauDaiHoc; Integrated Security = true";
            conMyConnection = new SqlConnection();
            conMyConnection.ConnectionString = strConn;
            try
            {
                conMyConnection.Open();
            }
            catch (Exception)
            {
            }
        }


        public static void OpenData(string strSelect, DataSet dsDatabase, string strTableName, SqlDataAdapter daDataAdapter)
        {
            try
            {
                if (conMyConnection.State == ConnectionState.Closed)
                    conMyConnection.Open();
                daDataAdapter.SelectCommand = new SqlCommand(strSelect, conMyConnection);
                SqlCommandBuilder cmbCommandBuilder = new SqlCommandBuilder(daDataAdapter);
                daDataAdapter.Fill(dsDatabase, strTableName);
                conMyConnection.Close();
            }
            catch (Exception)
            {
            }
        }

        public static void OpenData(string strSelect, DataSet dsDatabase, string strTableName)
        {
            SqlDataAdapter daDataAdapter = new SqlDataAdapter();
            try
            {
                if (conMyConnection.State == ConnectionState.Closed)
                    conMyConnection.Open();
                daDataAdapter.SelectCommand = new SqlCommand(strSelect, conMyConnection);
                daDataAdapter.Fill(dsDatabase, strTableName);
                conMyConnection.Close();
            }
            catch (Exception)
            {
            }
        }

        public static bool TonTaiKhoaChinh(string strGiaTri, string strTenTruong, string strTable)
        {
            bool blnRessult = false;
            try
            {
                string sqlSelect = "Select * From " + strTable + " Where " + strTenTruong + "='" + strGiaTri + "'";
                if (conMyConnection.State == ConnectionState.Closed)
                    conMyConnection.Open();
                SqlCommand cmdCommand = new SqlCommand(sqlSelect, conMyConnection);
                SqlDataReader drReader = cmdCommand.ExecuteReader();
                if (drReader.HasRows)
                    blnRessult = true;
                drReader.Close();
                conMyConnection.Close();
            }
            catch (Exception)
            {
            }
            return blnRessult;
        }

    }
}
