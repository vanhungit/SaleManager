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
using System.Data.SqlClient;
using MicrosoftHelper;
using System.Data.OleDb;
using SalesManager.Entity;
using SalesManager.Controller;

namespace SalesManager.ImportExcel
{
    public partial class frmImportNganhHang : DevExpress.XtraEditors.XtraForm
    {
        SYS_USER objuser = new SYS_USER();
        DataTable dtable = new DataTable();
        frmNganhHang frmnganh;
        public frmImportNganhHang(frmNganhHang _frm)
        {
            InitializeComponent();
            ReadXml_User();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            dtable.Columns.Add("ID_NGANH", typeof(string));
            dtable.Columns.Add("TEN_NGANH", typeof(string));
            dtable.Columns.Add("Description", typeof(string));
            frmnganh = _frm;
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
        public bool CheckNGANH(string ID)
        {
            bool Trave = false;
            SqlConnection con = new SqlConnection(DataProvider.ConnectionString);
            SqlCommand sqlcmd = con.CreateCommand();
            sqlcmd.CommandText = "select * from PRODUCT_NGANHHANG where ID_NGANH ='" + ID + "' and Active = 'true'";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "PRODUCT_NGANHHANG");
            con.Close();
            DataTable dt_Table = ds.Tables["PRODUCT_NGANHHANG"];
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
                ProductID = datarow["MA_NGANH"].ToString();
                if ((CheckNGANH(ProductID) == false))
                {
                    try
                    {
                        i++;
                        DataRow dtrow = dtable.NewRow();
                        dtrow[0] = datarow["MA_NGANH"].ToString();
                        dtrow[1] = datarow["TEN_NGANH"].ToString();
                        dtrow[2] = datarow["GHICHU"].ToString();
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            NGANH_HANG objnganh = new NGANH_HANG();
            int rs = -1;
            if (gridView1.RowCount > 0)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    objnganh.ID_NGANH = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                    objnganh.TEN_NGANH = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                    objnganh.DESCRIPTION = gridView1.GetRowCellValue(i, gridView1.Columns[2]).ToString();
                    objnganh.CreateBy = objuser.UserID;
                    objnganh.ModifyBy = objuser.UserID;
                    objnganh.Active = true;
                    rs = new NGANH_HANGController().ThemNGANHHANG(objnganh);
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
                frmnganh.RefreshData();
            }
            else
                MessageBox.Show("Chưa có dữ liệu nhập", "Thông Báo");

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