using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SalesManager
{
    public partial class frmInMaVach : DevExpress.XtraEditors.XtraForm
    {
        public frmInMaVach(DataTable _dtable)
        {
            InitializeComponent();
            InMaVach mavach = new InMaVach();
            DataTable dataTable = mavach.SanPham;
            BarcodeSanPham Report = new BarcodeSanPham();
            foreach (DataRow datarow in _dtable.Rows)
            {
                DataRow drow = dataTable.NewRow();
                {
                    //drow["Barcode"] = "*";
                    drow["Barcode"] = "*" + datarow["Barcode"] + "*";
                    //drow["Barcode"] += "*";

                    drow["Product_ID"] = datarow["Product_ID"];
                    drow["Product_Name"] = datarow["Product_Name"];
                    drow["Price"] = datarow["Retail_Price"];
                    drow["Unit"] = datarow["Unit"];
                }
                dataTable.Rows.Add(drow);
            }
            Report.Database.Tables["SanPham"].SetDataSource((DataTable)dataTable);
            crystalReportViewer1.ReportSource = Report;
            crystalReportViewer1.Refresh();
        }

        private void frmInMaVach_Load(object sender, EventArgs e)
        {
            /*Barcodes barcodeDetails = new Barcodes();
            DataTable dataTable = barcodeDetails._Barcodes;

            BarcodeReport Report = new BarcodeReport();

            int blank_labels = 0;
            int numberLabel = 6;
            for (int i = 0; i < numberLabel; i++)
            {
                DataRow drow = dataTable.NewRow();
                string P_name = "DETAIL" + i.ToString();
                if (blank_labels <= i)
                {
                    //drow["Barcode"] = "*";
                    drow["Barcode"] = "*"+ P_name +"*";
                    //drow["Barcode"] += "*";

                    drow["ProductId"] = P_name;
                    drow["ProductName"] = "Details of " + i.ToString();
                    drow["Cost"] = "Rs 110" + i.ToString() + "/-";
                    drow["Code"] = "ABCDE" + i.ToString();
                    drow["ShopName"] = "Shop Name";
                }
                dataTable.Rows.Add(drow);
            }

            Report.Database.Tables["Barcodes"].SetDataSource((DataTable)dataTable);
             */
            /*InMaVach mavach = new InMaVach();
            DataTable dataTable = mavach.SanPham;
            BarcodeSanPham Report = new BarcodeSanPham();
            int blank_labels = 0;
            int numberLabel = 6;
            for (int i = 0; i < numberLabel; i++)
            {
                DataRow drow = dataTable.NewRow();
                string P_name = "DETAIL" + i.ToString();
                if (blank_labels <= i)
                {
                    //drow["Barcode"] = "*";
                    drow["Barcode"] = "*" + P_name + "*";
                    //drow["Barcode"] += "*";

                    drow["Product_ID"] = P_name;
                    drow["Product_Name"] = "Details of " + i.ToString();
                    drow["Price"] = "Rs 110" + i.ToString() + "/-";
                    drow["Unit"] = "Shop Name";
                }
                dataTable.Rows.Add(drow);
            }
            Report.Database.Tables["SanPham"].SetDataSource((DataTable)dataTable);
            crystalReportViewer1.ReportSource = Report;
            crystalReportViewer1.Refresh();
             */
        }
    }
}