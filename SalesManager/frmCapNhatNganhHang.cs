using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SalesManager.Entity;
using QuanLiBanHang.Entity;
using System.Xml;
using System.IO;
using QuanLiBanHang.Controller;
using SalesManager.Controller;

namespace SalesManager
{
    public partial class frmCapNhatNganhHang : DevExpress.XtraEditors.XtraForm
    {
        frmNganhHang frmnganhhang;
        NGANH_HANG objnganh = new NGANH_HANG();
        SYS_USER objuser = new SYS_USER();
        public frmCapNhatNganhHang(frmNganhHang _frm, NGANH_HANG _nganh)
        {
            InitializeComponent();
            frmnganhhang = _frm;
            ReadXml_User();
            objnganh = _nganh;
            txtMa.Text = objnganh.ID_NGANH;
            txtTen.Text = objnganh.TEN_NGANH;
            txtGhiChu.Text = objnganh.DESCRIPTION;
            checkactive.Checked = objnganh.Active;
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
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objnganh.TEN_NGANH= txtTen.Text;
            objnganh.DESCRIPTION = txtGhiChu.Text;
            objnganh.Active = checkactive.Checked;
            rs = new NGANH_HANGController().CapNhatNGANH_HANG(objnganh, objnganh.ID_NGANH);
            if (rs < 1)
            {
                MessageBox.Show("Cập nhật thất bại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                Close();
            }
        }
    }
}