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
    public partial class UC_NhapFileDuLieu : UserControl
    {
        public UC_NhapFileDuLieu(frmNhapDuLieu frm, string name,string[] list)
        {
            InitializeComponent();
            txtPathName.Text = name;
            listBoxControl1.DataSource = list;
        }
        public string Pathname()
        {
            return txtPathName.Text;
        }
        public String[] List_Sheet()
        {
            return GetExcelSheetNames(txtPathName.Text);
        }
        public string List_focus()
        {
            if (txtPathName.Text != "")
                return listBoxControl1.SelectedItem.ToString();
            else
                return "";
        }
        private String[] GetExcelSheetNames(string excelFile)
        {
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;

            try
            {
                // Connection String. Change the excel file to the file you
                // will search.
                String connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                    "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
                // Create connection object by using the preceding connection string.
                objConn = new OleDbConnection(connString);
                // Open connection with the database.
                objConn.Open();
                // Get the data table containg the schema guid.
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dt == null)
                {
                    return null;
                }

                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;

                // Add the sheet name to the string array.
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }

                // Loop through all of the sheets if you want too...
                for (int j = 0; j < excelSheets.Length; j++)
                {
                    // Query each excel sheet.
                }

                return excelSheets;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                // Clean up.
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }
        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFile.Filter = "Text files (*.xls)|*.xls";
            OpenFile.ShowDialog();
            txtPathName.Text = OpenFile.FileName;
            if (txtPathName.Text != "")
            {
                if (listBoxControl1.Items.Count > 0)
                {
                    int dem = listBoxControl1.Items.Count;
                    for (int i = dem - 1; i < 0; i--)
                    {
                        listBoxControl1.Items.RemoveAt(i);
                    }
                }
                string[] test = new string[GetExcelSheetNames(txtPathName.Text).Length];
                listBoxControl1.DataSource = GetExcelSheetNames(txtPathName.Text);
                //test = GetExcelSheetNames(txtPathName.Text);
                //for (int i = 0; i < GetExcelSheetNames(txtPathName.Text).Length; i++)
                //{
                //    listBoxControl1.Items.Add(test[i]);
                //}
            }

        }
    }
}
