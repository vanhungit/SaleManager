using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SalesManager.Entity;
using SalesManager.Controller;
using QuanLiBanHang.Entity;
using System.Xml;
using System.IO;
using QuanLiBanHang.Controller;

namespace SalesManager
{
    public partial class frmThemKyKho : DevExpress.XtraEditors.XtraForm
    {
        SYS_USER objuser = new SYS_USER();
        frmDongKy _frm;
        public frmThemKyKho(frmDongKy frm)
        {
            InitializeComponent();
            ReadXml_User();
            dateNgayTao.DateTime = DateTime.Now;
            dateNgayDong.DateTime = DateTime.Now;
            txtMaKy.Text = "KK" + String.Format("{0:ddMMyyyy}", DateTime.Now);
            txtTenKy.Text = "Đóng Kỳ " + String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            _frm = frm;
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
        private void dateNgayDong_EditValueChanged(object sender, EventArgs e)
        {
            txtMaKy.Text = "KK" + String.Format("{0:ddMMyyyy}", dateNgayDong.DateTime);
            txtTenKy.Text = "Đóng Kỳ " + String.Format("{0:dd/MM/yyyy}", dateNgayDong.DateTime);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            KYKHO objkykho = new KYKHO();
            objkykho.ID = txtMaKy.Text;
            objkykho.KyKho_Name = txtTenKy.Text;
            objkykho.Refdate = dateNgayTao.DateTime;
            objkykho.RefType = 1;
            objkykho.RefStatus = 1;
            objkykho.EndDate = dateNgayDong.DateTime;
            objkykho.CreateBy = objuser.UserID;
            objkykho.Createdate = dateNgayTao.DateTime;
            objkykho.ModifyDate = dateNgayTao.DateTime;
            objkykho.ModifyBy = objuser.UserID;
            objkykho.Active = true;
            int rs = new KYKHOController().ThemKyKho(objkykho);
            if (rs < 1)
            {
                MessageBox.Show("Kỳ kho không được thêm", "Thông báo");
            }
            else
            {
                MessageBox.Show("Kỳ kho đã được thêm", "Thông báo");
            }
            _frm.HienThi();
        }
    }
}