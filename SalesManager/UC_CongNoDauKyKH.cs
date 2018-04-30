using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;
using System.Xml;
using System.IO;
using QuanLiBanHang.Entity;
using System.Data.SqlClient;
using MicrosoftHelper;
using DevExpress.XtraEditors;

namespace SalesManager
{
    public partial class UC_CongNoDauKyKH : UserControl
    {
        DataTable dtable = new DataTable();
        SYS_USER objuser = new SYS_USER();
        frmSoDuDauKy frmsodudauky;
        public UC_CongNoDauKyKH(frmSoDuDauKy _frm)
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            gridLookUpEdit1.Properties.DataSource = GetCUSTOMER_GROUP();
            gridLookUpEdit1.Properties.DisplayMember = "Customer_Group_Name";
            gridLookUpEdit1.Properties.ValueMember = "Customer_Group_ID";
            gridLookUpEdit1.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            gridControl1.DataSource = CUSTOMER_DEBT_GetListInit(gridLookUpEdit1View.GetFocusedRowCellDisplayText("Customer_Group_ID"));
            frmsodudauky = _frm;

        }
        public DataTable GetCUSTOMER_GROUP()
        {
            SqlConnection con = new SqlConnection(DataProvider.ConnectionString);
            SqlCommand sqlcmd = con.CreateCommand();
            sqlcmd.CommandText = "exec CUSTOMER_GROUP_GetList";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            //con.Open();
            da.Fill(ds, "CUSTOMER_GROUP");
            //con.Close();
            DataTable dt_Table = ds.Tables["CUSTOMER_GROUP"];
            DataRow dtrow = dt_Table.NewRow();
            dtrow["Customer_Group_ID"] = "All";
            dtrow["Customer_Group_Name"] = "Tất Cả";
            dt_Table.Rows.Add(dtrow);
            return dt_Table;
        }
        public DataTable CUSTOMER_DEBT_GetListInit(string Khuvuc)
        {
            SqlConnection con = new SqlConnection(DataProvider.ConnectionString);
            SqlCommand sqlcmd = con.CreateCommand();
            sqlcmd.CommandText = "exec CUSTOMER_DEBT_GetListInit @Customer_Group_ID=N'" + Khuvuc + "'";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            //con.Open();
            da.Fill(ds, "CUSTOMER_GROUP");
            //con.Close();
            DataTable dt_Table = ds.Tables["CUSTOMER_GROUP"];
            return dt_Table;
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
        public string XoaNoDK(string ID)
        {
            string Trave = "0";
            try
            {


                string consString = DataProvider.ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteDebtInit"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@RefID", ID);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                Trave = "1";
            }
            catch (Exception ex)
            {
                Trave = ex.ToString();
            }
            return Trave;
        }
        public string ThemCongKH(string SOID, string ID_Provider, double Amount, string User)
        {
            string Trave = "0";
            try
            {


                string consString = DataProvider.ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("CUSTOMER_DEBT_Update"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@ID", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@RefID", SOID);
                        cmd.Parameters.AddWithValue("@RefOrgNo", "");
                        cmd.Parameters.AddWithValue("@RefType", 31);
                        cmd.Parameters.AddWithValue("@RefStatus", 1);
                        cmd.Parameters.AddWithValue("@PaymentMethod", new Guid("11111111-1111-1111-1111-111111111111"));
                        cmd.Parameters.AddWithValue("@CustomerID", ID_Provider);
                        cmd.Parameters.AddWithValue("@ProductID", "");
                        cmd.Parameters.AddWithValue("@ProductName", "");
                        cmd.Parameters.AddWithValue("@CurrencyID", "VND");
                        cmd.Parameters.AddWithValue("@ExchangeRate", 1);
                        cmd.Parameters.AddWithValue("@TermID", "CN");
                        cmd.Parameters.AddWithValue("@RefDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@DueDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Quantity", 0);
                        cmd.Parameters.AddWithValue("@ReQuantity", 0);
                        cmd.Parameters.AddWithValue("@Amount", Amount);
                        cmd.Parameters.AddWithValue("@Discount", 0);
                        cmd.Parameters.AddWithValue("@Payment", 0);
                        cmd.Parameters.AddWithValue("@Balance", 0);
                        cmd.Parameters.AddWithValue("@FAmount", 0);
                        cmd.Parameters.AddWithValue("@FPayment", 0);
                        cmd.Parameters.AddWithValue("@FBalance", 0);
                        cmd.Parameters.AddWithValue("@FDiscount", 0);
                        cmd.Parameters.AddWithValue("@IsChanged", 0);
                        cmd.Parameters.AddWithValue("@IsPublic", 1);
                        cmd.Parameters.AddWithValue("@CreatedBy", User);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ModifiedBy", User);
                        cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@OwnerID", User);
                        cmd.Parameters.AddWithValue("@Description", "(Số Dư Đầu Kỳ)");
                        cmd.Parameters.AddWithValue("@Sorted", 0);
                        cmd.Parameters.AddWithValue("@Active", 1);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                Trave = "1";
            }
            catch (Exception ex)
            {
                Trave = ex.ToString();
            }
            return Trave;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = CUSTOMER_DEBT_GetListInit(gridLookUpEdit1View.GetFocusedRowCellDisplayText("Customer_Group_ID"));
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["ID"], new Guid("11111111-1111-1111-1111-111111111111"));

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if ((gridView1.GetRowCellValue(i, gridView1.Columns["ID"]).ToString() == "11111111-1111-1111-1111-111111111111") && (gridView1.GetRowCellValue(i, gridView1.Columns["Amount"]).ToString() !=""))
                        {
                            XoaNoDK("NDK" + gridView1.GetRowCellValue(i, gridView1.Columns["Customer_ID"]).ToString());
                            ThemCongKH("NDK" + gridView1.GetRowCellValue(i, gridView1.Columns["Customer_ID"]).ToString(), gridView1.GetRowCellValue(i, gridView1.Columns["Customer_ID"]).ToString(), double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns["Amount"]).ToString()), objuser.UserID);
                        }
                    }
                    XtraMessageBox.Show("Nhập Thành Công", "Thông Báo");

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                XtraMessageBox.Show("Chưa nhập hàng hóa", "Thông Báo");
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

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frmsodudauky.Close();
        }
    }
}
