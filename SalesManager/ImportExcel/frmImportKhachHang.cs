using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using QuanLiBanHang.Controller;
using QuanLiBanHang.Entity;
using System.Data.SqlClient;
using MicrosoftHelper;
using System.Data.OleDb;

namespace SalesManager.ImportExcel
{
    public partial class frmImportKhachHang : DevExpress.XtraEditors.XtraForm
    {
        SYS_USER objuser = new SYS_USER();
        DataTable dtable = new DataTable();
        frm_KhachHang frmkhachhang;
        public frmImportKhachHang(frm_KhachHang _frm)
        {
            InitializeComponent();
            InitLookUp();
            InitLookLoai();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            dtable.Columns.Add("Customer_ID", typeof(string));
            dtable.Columns.Add("CustomerName", typeof(string));
            dtable.Columns.Add("CustomerAddress", typeof(string));
            dtable.Columns.Add("Tax", typeof(string));
            dtable.Columns.Add("Tel", typeof(string));
            dtable.Columns.Add("Contact", typeof(string));
            frmkhachhang = _frm;
        }
        private void InitLookUp()
        {
            // Specify the data source to display in the dropdown.
            lookUpNhom.Properties.DataSource = new CUSTOMER_GROUPController().LayDSCUSTOMER_GROUP();
            // The field providing the editor's display text.
            lookUpNhom.Properties.DisplayMember = "Customer_Group_Name";
            // The field matching the edit value.
            lookUpNhom.Properties.ValueMember = "Customer_Group_ID";
            lookUpNhom.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpNhom.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpNhom.Properties.AutoSearchColumnIndex = 1;
            //lookUpNhom.EditValue = lookUpNhom.Properties.GetDataSourceValue("Customer_Group_ID", 1);
            lookUpNhom.EditValue = new CUSTOMER_GROUPController().CUSTOMER_GROUP_Top1().Customer_Group_ID;

        }
        private void InitLookLoai()
        {
            // Specify the data source to display in the dropdown.
            lookUpLoaiKhach.Properties.DataSource = new CUSTOMER_GROUPController().LayDSLoaiKhachHang();
            // The field providing the editor's display text.
            lookUpLoaiKhach.Properties.DisplayMember = "Customer_Type_Name";
            // The field matching the edit value.
            lookUpLoaiKhach.Properties.ValueMember = "Customer_Type_ID";
            lookUpLoaiKhach.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpLoaiKhach.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpLoaiKhach.Properties.AutoSearchColumnIndex = 1;
            lookUpLoaiKhach.EditValue = "KHTX";
            //lookUpLoaiKhach.EditValue = new CUSTOMER_GROUPController().CUSTOMER_GROUP_Top1().Customer_Group_ID;

        }
        public bool CheckKhachHang(string ID)
        {
            bool Trave = false;
            SqlConnection con = new SqlConnection(DataProvider.ConnectionString);
            SqlCommand sqlcmd = con.CreateCommand();
            sqlcmd.CommandText = "select * from CUSTOMER where Customer_ID ='" + ID + "' and Active = 'true'";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            //con.Open();
            da.Fill(ds, "CUSTOMER");
            //con.Close();
            DataTable dt_Table = ds.Tables["CUSTOMER"];
            foreach (DataRow datarow in dt_Table.Rows)
            {
                Trave = true;
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
            DataTable dt_Table = ds.Tables["[Sheet1$]"];
            ObjConnection.Close();

            foreach (DataRow datarow in dt_Table.Rows)
            {
                ProductID = datarow["MA_KHACH"].ToString();
                if ((CheckKhachHang(ProductID) == false))
                {
                    try
                    {
                        i++;
                        DataRow dtrow = dtable.NewRow();
                        dtrow[0] = datarow["MA_KHACH"].ToString();
                        dtrow[1] = datarow["TEN_KHACH"].ToString();
                        dtrow[2] = datarow["DIA_CHI"].ToString();
                        dtrow[3] = datarow["MST"].ToString();
                        dtrow[4] = datarow["DIEN_THOAI"].ToString();
                        dtrow[5] = datarow["LIEN_HE"].ToString();
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            CUSTOMER objnganh = new CUSTOMER();
            int rs = -1;
            if (gridView1.RowCount > 0)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    objnganh.Customer_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                    objnganh.CustomerName = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                    objnganh.CustomerAddress = gridView1.GetRowCellValue(i, gridView1.Columns[2]).ToString();
                    objnganh.Tax = gridView1.GetRowCellValue(i, gridView1.Columns[3]).ToString();
                    objnganh.Tel = gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString();
                    objnganh.Contact = gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString();
                    objnganh.Customer_Group_ID = lookUpNhom.GetColumnValue("Customer_Group_ID").ToString();
                    objnganh.Customer_Type_ID = lookUpLoaiKhach.GetColumnValue("Customer_Type_ID").ToString();
                    objnganh.Active = true;
                    rs = new CUSTOMERController().ThemCUSTOMER(objnganh);
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
                frmkhachhang.RefreshData();
            }
            else
                MessageBox.Show("Chưa có dữ liệu nhập", "Thông Báo");

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