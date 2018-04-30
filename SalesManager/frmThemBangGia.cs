using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using QuanLiBanHang.Controller;
using SalesManager.Entity;
using QuanLiBanHang.Entity;
using System.Xml;
using System.IO;
using MicrosoftHelper;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace SalesManager
{
    public partial class frmThemBangGia : Form
    {
        SYS_USER objuser = new SYS_USER();
        DataTable dtable = new DataTable();
        BANGGIA objBangGia = new BANGGIA();
        UC_BangKeTongHopBangGia frmbanggia;
        public frmThemBangGia(UC_BangKeTongHopBangGia frm)
        {
            InitializeComponent();
            InitLookUp_LoaiBang();
            ReadXml_User();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            dateBatDau.DateTime = DateTime.Now;
            dateHetHan.DateTime = DateTime.Now;
            dateNgayTao.DateTime = DateTime.Now;
            txtMaBangGia.Text = "GL" + String.Format("{0:ddMMyyyy}",dateNgayTao.DateTime);
            txtTenBangGia.Text = "Bảng Giá Lẻ " + String.Format("{0:dd/MM/yyyy}", dateNgayTao.DateTime);
            dtable.Columns.Add("PRODUCT_ID", typeof(string));
            dtable.Columns.Add("ProductName", typeof(string));
            dtable.Columns.Add("Org_Price_New", typeof(double));
            dtable.Columns.Add("Sale_Price_New", typeof(double));
            dtable.Columns.Add("Retail_Price_New", typeof(double));
            frmbanggia = frm;
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
        public void NhapLieu()
        {
            long i = 0;
            string ProductID = "";
            String ConString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + txtPathname.Text.Trim() + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection ObjConnection = new OleDbConnection(ConString);
            ObjConnection.Open();
            OleDbCommand objCommand = new OleDbCommand("SELECT * FROM [Sheet1$]", ObjConnection);
            OleDbDataAdapter MyAdapt = new OleDbDataAdapter();
            MyAdapt.SelectCommand = objCommand;
            DataSet ds = new DataSet();
            MyAdapt.Fill(ds, "[Sheet1$]");
            DataTable dt_Table = ds.Tables["[Sheet1$]"];
            ObjConnection.Close();
            objBangGia.ID = txtMaBangGia.Text;
            objBangGia.Name_ListPrice = txtTenBangGia.Text;
            objBangGia.Refdate = dateNgayTao.DateTime;
            objBangGia.RefType = int.Parse(lookUpLoaiGia.GetColumnValue("ID").ToString());
            objBangGia.StartDate = dateBatDau.DateTime;
            objBangGia.StopDate = dateHetHan.DateTime;
            objBangGia.CreateBy = objuser.UserID;
            objBangGia.Createdate = dateNgayTao.DateTime;
            objBangGia.ModifyBy = objuser.UserID;
            objBangGia.ModifyDate = dateNgayTao.DateTime;
            objBangGia.Active = chkDangDung.Checked;
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
                        dtrow[2] = datarow["GIA_MUA"].ToString();
                        dtrow[3] = datarow["GIA_SI"].ToString();
                        dtrow[4] = datarow["GIA_LE"].ToString();                       
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
        public string ThemBangGia(DataTable dtable, BANGGIA objBANGGIA)
        {
            string Trave = "0";
            try
            {


                string consString = DataProvider.ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("Table_Insert_BangGia"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tableBangGia", dtable);
                        cmd.Parameters.AddWithValue("@ID", objBANGGIA.ID);
                        cmd.Parameters.AddWithValue("@Name_ListPrice", objBANGGIA.Name_ListPrice);
                        cmd.Parameters.AddWithValue("@Refdate", objBANGGIA.Refdate);
                        cmd.Parameters.AddWithValue("@RefType", objBANGGIA.RefType);
                        cmd.Parameters.AddWithValue("@StartDate", objBANGGIA.StartDate);
                        cmd.Parameters.AddWithValue("@StopDate", objBANGGIA.StopDate);
                        cmd.Parameters.AddWithValue("@Active", objBANGGIA.Active);
                        cmd.Parameters.AddWithValue("@CreateBy", objBANGGIA.CreateBy);
                        cmd.Parameters.AddWithValue("@Createdate", objBANGGIA.Createdate);
                        cmd.Parameters.AddWithValue("@ModifyBy", objBANGGIA.ModifyBy);
                        cmd.Parameters.AddWithValue("@ModifyDate", objBANGGIA.ModifyDate);
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
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            openFile.Filter = "Import Files (.xls)|*.xls|All Files (*.*)|*.*";
            DialogResult Ketqua = openFile.ShowDialog();
            if (Ketqua == DialogResult.OK)
            {
                txtPathname.Text = openFile.FileName;
                NhapLieu();
                gridControl1.DataSource = dtable;
            }
        }

        private void dateNgayTao_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpLoaiGia.GetColumnValue("ID").ToString() == "1")
            {
                txtMaBangGia.Text = "GM" + String.Format("{0:ddMMyyyy}", dateNgayTao.DateTime);
                txtTenBangGia.Text = "Bảng Giá Mua " + String.Format("{0:dd/MM/yyyy}", dateNgayTao.DateTime);

            }
            else if (lookUpLoaiGia.GetColumnValue("ID").ToString() == "2")
            {
                txtMaBangGia.Text = "GS" + String.Format("{0:ddMMyyyy}", dateNgayTao.DateTime);
                txtTenBangGia.Text = "Bảng Giá Bán Sỉ " + String.Format("{0:dd/MM/yyyy}", dateNgayTao.DateTime);
            }
            else if (lookUpLoaiGia.GetColumnValue("ID").ToString() == "3")
            {
                txtMaBangGia.Text = "GL" + String.Format("{0:ddMMyyyy}", dateNgayTao.DateTime);
                txtTenBangGia.Text = "Bảng Giá Bán Lẻ " + String.Format("{0:dd/MM/yyyy}", dateNgayTao.DateTime);
            }

        }

        private void lookUpLoaiGia_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpLoaiGia.GetColumnValue("ID").ToString() == "1")
            {
                txtMaBangGia.Text = "GM" + String.Format("{0:ddMMyyyy}", dateNgayTao.DateTime);
                txtTenBangGia.Text = "Bảng Giá Mua " + String.Format("{0:dd/MM/yyyy}", dateNgayTao.DateTime);

            }
            else if (lookUpLoaiGia.GetColumnValue("ID").ToString() == "2")
            {
                txtMaBangGia.Text = "GS" + String.Format("{0:ddMMyyyy}", dateNgayTao.DateTime);
                txtTenBangGia.Text = "Bảng Giá Bán Sỉ " + String.Format("{0:dd/MM/yyyy}", dateNgayTao.DateTime);
            }
            else if (lookUpLoaiGia.GetColumnValue("ID").ToString() == "3")
            {
                txtMaBangGia.Text = "GL" + String.Format("{0:ddMMyyyy}", dateNgayTao.DateTime);
                txtTenBangGia.Text = "Bảng Giá Bán Lẻ " + String.Format("{0:dd/MM/yyyy}", dateNgayTao.DateTime);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Lưu Bảng Giá Này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                string TraVe = "";
                if (dtable.Rows.Count > 0)
                {
                    try
                    {
                        TraVe = ThemBangGia(dtable, objBangGia);
                        if (TraVe == "1")
                        {
                            MessageBox.Show("Lưu Dữ Liệu Thành Công!", "Thông Báo");
                            frmbanggia.Refresh();
                        }
                        else
                            MessageBox.Show(TraVe);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                    MessageBox.Show("Vui lòng import danh mục sản phẩm", "Thông Báo");
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
