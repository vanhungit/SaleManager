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
using QuanLiBanHang.Entity;
using SalesManager.Entity;
using SalesManager.Controller;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using MicrosoftHelper;
using System.Data.OleDb;
namespace SalesManager
{
    public partial class frmThemKhuyenMai : Form
    {
        SYS_USER objuser = new SYS_USER();
        PROMOTION objpromotion = new PROMOTION();
        PROMOTION_DETAIL objpromotiondetail = new PROMOTION_DETAIL();
        DataTable dtable = new DataTable();
        frmKhuyenMai frmkhuyenmai;
        public frmThemKhuyenMai(frmKhuyenMai _frm)
        {
            InitializeComponent();
            InitLookUp_LoaiBang();
            ReadXml_User();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            dateBatDau.DateTime = DateTime.Now;
            dateHetHan.DateTime = DateTime.Now;
            dtCreateDate.DateTime = DateTime.Now;
            dtable.Columns.Add("PRODUCT_ID", typeof(string));
            dtable.Columns.Add("ProductName", typeof(string));
            dtable.Columns.Add("ProductGroup_ID", typeof(string));
            dtable.Columns.Add("DiscountPercent", typeof(double));
            txtMaKM.Text = "KL" + String.Format("{0:ddMMyyyy}", dtCreateDate.DateTime);
            txtTenKM.Text = "Khuyến Mãi " + String.Format("{0:dd/MM/yyyy}", dtCreateDate.DateTime);
            frmkhuyenmai = _frm;
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
        private void InitLookUp_LoaiBang()
        {
            // Specify the data source to display in the dropdown.
            lookUpLoaiGia.Properties.DataSource = new BANGGIAController().LoaiBangGia();
            // The field providing the editor's display text.
            lookUpLoaiGia.Properties.DisplayMember = "TEN_LOAI";
            // The field matching the edit value.
            lookUpLoaiGia.Properties.ValueMember = "ID";
            lookUpLoaiGia.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpLoaiGia.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpLoaiGia.Properties.AutoSearchColumnIndex = 1;
            lookUpLoaiGia.EditValue = "3";
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
            objpromotion.ID = txtMaKM.Text;
            objpromotion.Name_Promotion = txtTenKM.Text;
            objpromotion.Refdate = dtCreateDate.DateTime;
            objpromotion.RefType = int.Parse(lookUpLoaiGia.GetColumnValue("ID").ToString());
            objpromotion.StartDate = dateBatDau.DateTime;
            objpromotion.StopDate = dateHetHan.DateTime;
            objpromotion.CreateBy = objuser.UserID;
            objpromotion.Createdate = dtCreateDate.DateTime;
            objpromotion.ModifyBy = objuser.UserID;
            objpromotion.ModifyDate = dtCreateDate.DateTime;
            objpromotion.Active = false;
            foreach (DataRow datarow in dt_Table.Rows)
            {
                ProductID = datarow["MA_HANG"].ToString();
                if ((CheckProduct(ProductID) == true))
                {
                    try
                    {
                        i++;
                        DataRow dtrow = dtable.NewRow();
                        dtrow[0] = datarow["MA_HANG"].ToString();
                        dtrow[1] = datarow["TEN_HANG"].ToString();
                        dtrow[2] = datarow["NHOM"].ToString();
                        dtrow[3] = datarow["CHIET_KHAU"].ToString();
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
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objpromotion.ID = txtMaKM.Text;
            rs = new PROMOTIONController().PROMOTION_Insert(objpromotion);
            if (gridView1.RowCount > 0)
            {
                for (int i = 0; i < gridView1.RowCount ; i++)
                {
                    int rsstockdetail = -1;
                    objpromotiondetail.ID = Guid.NewGuid();
                    objpromotiondetail.ProductGroup_ID = gridView1.GetRowCellValue(i, gridView1.Columns[2]).ToString();
                    objpromotiondetail.Promotion_ID = txtMaKM.Text;
                    objpromotiondetail.PRODUCT_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                    objpromotiondetail.ProductName = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                    objpromotiondetail.DiscountPercent = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[3]).ToString());
                    objpromotiondetail.CreateBy = objuser.UserID;
                    objpromotiondetail.Createdate = dtCreateDate.DateTime;
                    objpromotiondetail.ModifyBy = objuser.UserID;
                    objpromotiondetail.ModifyDate = dtCreateDate.DateTime;
                    objpromotiondetail.Active = true;
                    rsstockdetail = new PROMOTION_DETAILController().PROMOTION_DETAIL_Insert(objpromotiondetail);
                    if (rsstockdetail == -1)
                    {
                        MessageBox.Show("Lưu Thất Bại", "Thông Báo");
                        break;
                    }
                }
            }
            else
                MessageBox.Show("Chưa nhập hàng hóa", "Thông Báo");
            if (rs > -1)
            {
                MessageBox.Show("Lưu Thành công", "Thông Báo");
            }
            else
            {
                MessageBox.Show("Lưu Thất bại", "Thông Báo");

            }
            frmkhuyenmai.RefreshLuoi();
        }

        public bool CheckProduct(string ProductID)
        {
            bool Trave = false;
            SqlConnection con = new SqlConnection(DataProvider.ConnectionString);
            SqlCommand sqlcmd = con.CreateCommand();
            sqlcmd.CommandText = "select * from PRODUCT where Product_ID ='" + ProductID + "' and Active = 'true'";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "PRODUCT");
            con.Close();
            DataTable dt_Table = ds.Tables["PRODUCT"];
            foreach (DataRow datarow in dt_Table.Rows)
            {
                Trave = true;
            }
            return Trave;
        }
        private void simpleButton3_Click(object sender, EventArgs e)
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
