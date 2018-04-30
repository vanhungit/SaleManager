using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SalesManager
{
    public partial class UC_HienThiLuoi : UserControl
    {
        string patname = "";
        string listforcus = "";
        public UC_HienThiLuoi(string duongdan, string sheet)
        {
            InitializeComponent();
            patname = duongdan;
            listforcus = sheet;
            HienThi();
        }
        public DataTable returtable()
        {
            return ((DataTable)(gridControl1.DataSource)).Copy();
        }

        public void HienThi()
        {
            String ConString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + patname + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection ObjConnection = new OleDbConnection(ConString);
            ObjConnection.Open();
            OleDbCommand objCommand = new OleDbCommand("SELECT * FROM ["+listforcus+"]", ObjConnection);
            OleDbDataAdapter MyAdapt = new OleDbDataAdapter();
            MyAdapt.SelectCommand = objCommand;
            DataSet ds = new DataSet();
            MyAdapt.Fill(ds, "[Sheet1$]");
            ObjConnection.Close();
            DataTable dt_Table = ds.Tables["[Sheet1$]"];
            gridControl1.DataSource = dt_Table;
        }
    }
}
