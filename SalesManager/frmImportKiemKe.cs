using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;
using System.Data.SqlServerCe;
using System.Data.OleDb;
using QuanLiBanHang.Entity;
using SalesManager.Controller;
using SalesManager.Entity;

namespace SalesManager
{
    public partial class frmImportKiemKe : Form
    {
        PRODUCT objproduct = new PRODUCT();
        Mobile_DataTemp objmobiledata = new Mobile_DataTemp();
        Mobile_DataTempController objmobile = new Mobile_DataTempController();
        public frmImportKiemKe()
        {
            InitializeComponent();
            dtthoigian.DateTime = DateTime.Now;
            gridLookUpEdit1.Properties.DataSource = new STOCKController().STOCK_GetList();
            gridLookUpEdit1.Properties.DisplayMember = "Stock_Name";
            gridLookUpEdit1.Properties.ValueMember = "Stock_ID";
            gridLookUpEdit1.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
        }
        #region CreateExcel
        public void NhapDuLieu()
        {
            long i = 0;
            String ConString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + txtPath.Text.Trim() + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection ObjConnection = new OleDbConnection(ConString);
            ObjConnection.Open();
            OleDbCommand objCommand = new OleDbCommand("SELECT * FROM [Sheet1$]", ObjConnection);
            OleDbDataAdapter MyAdapt = new OleDbDataAdapter();
            MyAdapt.SelectCommand = objCommand;
            DataSet ds = new DataSet();
            MyAdapt.Fill(ds, "[Sheet1$]");
            ObjConnection.Close();
            DataTable dt_Table = ds.Tables["[Sheet1$]"];
            foreach (DataRow datarow in dt_Table.Rows)
            {
                objproduct = new PRODUCTController().PRODUCT_Get(datarow["Barcode"].ToString().Trim());
                objmobiledata.ID = Guid.NewGuid();
                objmobiledata.IP_Address = "0.0.0.0";
                objmobiledata.MobiName = "Offline";
                objmobiledata.Barcode = objproduct.Barcode;
                objmobiledata.ProductName = objproduct.Product_Name;
                objmobiledata.SeriNumber = "123456";
                objmobiledata.StoreName = gridLookUpEdit1View.GetRowCellDisplayText(gridLookUpEdit1View.FocusedRowHandle, "Stock_ID");
                objmobiledata.Sale_Price = objproduct.Retail_Price;
                objmobiledata.CurrentQty = double.Parse(datarow["TonCK"].ToString().Trim());
                objmobiledata.CreateDate = dtthoigian.DateTime;
                objmobile.Mobile_Temp_Data_Insert(objmobiledata);
                //InsertData(conn, datarow["Mahang"].ToString().Trim(), datarow["Tenhang"].ToString().Trim(), long.Parse(datarow["Gia"].ToString().Trim()), 0);
                i++;
                txtstatus.Text = "Đang tải " + i.ToString() + "...";
            }
            txtstatus.Text = "Đã tải " + i.ToString() + " xong...";
        }
        #endregion
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            open_File.ShowDialog();
            txtPath.Text = open_File.FileName;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                NhapDuLieu();

            }
            catch
            {
                MessageBox.Show("Nhập thất bại","Thông Báo");
            }
        }
    }
}
