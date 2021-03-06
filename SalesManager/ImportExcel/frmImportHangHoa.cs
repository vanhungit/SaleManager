using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLiBanHang.Entity;
using System.Xml;
using System.IO;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;
using System.Data.SqlClient;
using System.Data.OleDb;
using MicrosoftHelper;
using SalesManager.Controller;

namespace SalesManager.ImportExcel
{
    public partial class frmImportHangHoa : DevExpress.XtraEditors.XtraForm
    {
        SYS_USER objuser = new SYS_USER();
        DataTable dtable = new DataTable();
        frmHangHoa frmhanghoa;
        public frmImportHangHoa(frmHangHoa _frm)
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            InitLookUp_KhoHang();
            InitLookUp_PhanLoai();
            dtable.Columns.Add("Product_ID", typeof(string));
            dtable.Columns.Add("Product_Name", typeof(string));
            dtable.Columns.Add("Barcode", typeof(string));
            dtable.Columns.Add("Unit", typeof(string));
            dtable.Columns.Add("Product_Group_ID", typeof(string));
            dtable.Columns.Add("TEN_NGANH", typeof(string));
            dtable.Columns.Add("Org_Price", typeof(string));
            dtable.Columns.Add("Sale_Price", typeof(string));
            dtable.Columns.Add("Retail_Price", typeof(string));
            frmhanghoa = _frm;
        }
        public void ReadXml_User()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            FileStream fs = new FileStream("account.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("account");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                //xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                //if (xmlnode[i].ChildNodes.Item(2).InnerText.Trim() == "True")
                {
                    objuser = new SYS_USERController().SYS_USER_Get_By_UserName(xmlnode[i].ChildNodes.Item(0).InnerText.Trim());
                }
            }
            fs.Close();
        }
        private void InitLookUp_KhoHang()
        {
            // Specify the data source to display in the dropdown.
            lookUpKho.Properties.DataSource = new STOCKController().STOCK_GetList();
            // The field providing the editor's display text.
            lookUpKho.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            lookUpKho.Properties.ValueMember = "Stock_ID";
            lookUpKho.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpKho.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpKho.Properties.AutoSearchColumnIndex = 1;
            lookUpKho.EditValue = new STOCKController().STOCK_Top1().Stock_ID;
        }
        private void InitLookUp_PhanLoai()
        {
            // Specify the data source to display in the dropdown.
            lookphanloai.Properties.DataSource = new PRODUCT_TYPEController().PRODUCT_TYPE_GetList();
            // The field providing the editor's display text.
            lookphanloai.Properties.DisplayMember = "Product_Name";
            // The field matching the edit value.
            lookphanloai.Properties.ValueMember = "Product_Type_ID";
            lookphanloai.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookphanloai.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookphanloai.Properties.AutoSearchColumnIndex = 1;
            lookphanloai.EditValue = 0;
        }
        public bool CheckProduct(string ProductID)
        {
            bool Trave = false;
            SqlConnection con = new SqlConnection(DataProvider.ConnectionString);
            SqlCommand sqlcmd = con.CreateCommand();
            sqlcmd.CommandText = "select * from Product where Product_ID ='" + ProductID + "' and Active = 'true'";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Product");
            con.Close();
            DataTable dt_Table = ds.Tables["Product"];
            foreach (DataRow datarow in dt_Table.Rows)
            {
                Trave = true;
            }
            return Trave;
        }
        public string GetMaNhom(string TenNhom)
        {
            string Trave = "";
            SqlConnection con = new SqlConnection(DataProvider.ConnectionString);
            SqlCommand sqlcmd = con.CreateCommand();
            sqlcmd.CommandText = "select * from PRODUCT_GROUP where ProductGroup_Name =N'" + TenNhom + "' and Active = 'true'";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            //con.Open();
            da.Fill(ds, "PRODUCT_GROUP");
            //con.Close();
            DataTable dt_Table = ds.Tables["PRODUCT_GROUP"];
            foreach (DataRow datarow in dt_Table.Rows)
            {
                Trave = datarow["ProductGroup_ID"].ToString();
            }
            return Trave;
        }
        public string GetMaDonVi(string TenDonVi)
        {
            string Trave = "";
            SqlConnection con = new SqlConnection(DataProvider.ConnectionString);
            SqlCommand sqlcmd = con.CreateCommand();
            sqlcmd.CommandText = "select * from UNIT where Unit_Name =N'" + TenDonVi + "' and Active = 'true'";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            //con.Open();
            da.Fill(ds, "UNIT");
            //con.Close();
            DataTable dt_Table = ds.Tables["UNIT"];
            foreach (DataRow datarow in dt_Table.Rows)
            {
                Trave = datarow["Unit_ID"].ToString();
            }
            return Trave;
        }
        public void NhapLieu()
        {
            long i = 0;
            string ProductID = "";

            String ConString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + txtPathName.Text.Trim() + ";" + "Extended Properties=Excel 8.0;";
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
                ProductID = datarow["MA_HANG"].ToString();
                if ((CheckProduct(ProductID) == false))
                {
                    try
                    {
                        i++;
                        DataRow dtrow = dtable.NewRow();
                        dtrow[0] = datarow["MA_HANG"].ToString();
                        dtrow[1] = (datarow["TEN_HANG"].ToString());
                        dtrow[2] = datarow["MA_VACH"].ToString();
                        dtrow[3] = GetMaDonVi(datarow["DONVI"].ToString());
                        dtrow[4] = GetMaNhom(datarow["NHOM"].ToString());
                        dtrow[5] = datarow["NGANH"].ToString();
                        dtrow[6] = datarow["GIA_MUA"].ToString();
                        dtrow[7] = datarow["GIA_SI"].ToString();
                        dtrow[8] = datarow["GIA_LE"].ToString();
                        dtable.Rows.Add(dtrow);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thất Bại thứ " + ex.ToString(), "Thông Báo");
                    }

                }
                else
                {
                    MessageBox.Show("Lỗi không tồn tại dữ liệu dòng thứ " + i + ": " + ProductID);
                    DialogResult KetQua = MessageBox.Show("Bạn Nhấn [Yes] để tiếp tục hoặc [No] để thoát ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (KetQua == DialogResult.No)
                    {
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            PRODUCT objproduct = new PRODUCT();
            int rs = -1;
            if (gridView1.RowCount > 0)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    objproduct.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                    objproduct.Product_Name = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                    objproduct.Barcode = gridView1.GetRowCellValue(i, gridView1.Columns[2]).ToString();
                    objproduct.Unit = gridView1.GetRowCellValue(i, gridView1.Columns[3]).ToString();
                    objproduct.Product_Group_ID = gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString();
                    objproduct.Org_Price = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString());
                    objproduct.Sale_Price = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString());
                    objproduct.Retail_Price = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString());
                    objproduct.Provider_ID = lookUpKho.GetColumnValue("Stock_ID").ToString();
                    objproduct.Product_Type_ID = int.Parse(lookphanloai.GetColumnValue("Product_Type_ID").ToString());
                    objproduct.Active = true;
                    rs = new PRODUCTController().PRODUCT_Insert(objproduct);
                    if (rs == -1)
                    {
                        MessageBox.Show("Lưu Thất Bại", "Thông Báo");
                        break;
                    }
                }
                if (rs > -1)
                {
                    MessageBox.Show("Lưu Thành công", "Thông Báo");
                }
                else
                {
                    MessageBox.Show("Lưu Thất bại", "Thông Báo");

                }
                frmhanghoa.RefreshData();
            }
            else
                MessageBox.Show("Chưa có dữ liệu nhập", "Thông Báo");

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            openFile.Filter = "Import Files (.xls)|*.xls|All Files (*.*)|*.*";
            DialogResult Ketqua = openFile.ShowDialog();
            if (Ketqua == DialogResult.OK)
            {
                txtPathName.Text = openFile.FileName;
                NhapLieu();
                gridControl1.DataSource = dtable;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
        }
    }
}