using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using MicrosoftHelper;
using SalesManager.Entity;
using System.Xml;
using System.IO;
using QuanLiBanHang.Entity;
using QuanLiBanHang.Controller;
using SalesManager.Controller;

namespace SalesManager
{
    public partial class frmThemNganhHang : DevExpress.XtraEditors.XtraForm
    {
        frmNganhHang frmnganhhang;
        NGANH_HANG objnganh = new NGANH_HANG();
        SYS_USER objuser = new SYS_USER();

        public frmThemNganhHang(frmNganhHang _frm)
        {
            InitializeComponent();
            frmnganhhang = _frm;
            txtMa.Text = SinhMaNhomHang();
            ReadXml_User();

        }
        public string MaxNganhHang()
        {
            string Trave = "";
            SqlConnection con = new SqlConnection(DataProvider.ConnectionString);
            SqlCommand sqlcmd = con.CreateCommand();
            sqlcmd.CommandText = "select max([ID_NGANH]) as ID_NGANH from [PRODUCT_NGANHHANG] where [ID_NGANH] like N'NG%'";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            //con.Open();
            da.Fill(ds, "PRODUCT_NGANHHANG");
            //con.Close();
            DataTable dt_Table = ds.Tables["PRODUCT_NGANHHANG"];
            foreach (DataRow datarow in dt_Table.Rows)
            {
                Trave = datarow["ID_NGANH"].ToString();
            }
            return Trave;
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
        public string SinhMaNhomHang()
        {
            string MaKhachHang, MaTam;
            MaKhachHang = "";
            MaTam = "";
            MaTam = MaxNganhHang();
            if (MaTam != "")
            {

                long NumberKhuVuc = long.Parse(MaTam.Substring(2, 6)) + 1;
                MaKhachHang = NumberKhuVuc.ToString();
                for (int i = NumberKhuVuc.ToString().Length; i < 6; i++)
                {
                    MaKhachHang = "0" + MaKhachHang;
                    //MessageBox.Show(MaKhuVuc);
                }
                MaKhachHang = "NG" + MaKhachHang;
            }
            else
            {
                MaKhachHang = "NG000001";
            }
            return MaKhachHang;
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objnganh.ID_NGANH = txtMa.Text;
            objnganh.TEN_NGANH = txtTen.Text;
            objnganh.DESCRIPTION = txtGhiChu.Text;
            objnganh.IsMain = true;
            objnganh.CreateBy = objuser.UserID;
            objnganh.Createdate = DateTime.Now;
            objnganh.ModifyBy = objuser.UserID;
            objnganh.ModifyDate = DateTime.Now;
            objnganh.Active = checkactive.Checked;
            rs = new NGANH_HANGController().ThemNGANHHANG(objnganh);
            if (rs < 1)
            {
                MessageBox.Show("Ngành hàng đã tồn tại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Ngành hàng mới đã được lưu", "Thông báo");
                txtGhiChu.Text = "";
                txtTen.Text = "";
                txtMa.Text = SinhMaNhomHang();
            }
            frmnganhhang.RefreshData();
        }
    }
}