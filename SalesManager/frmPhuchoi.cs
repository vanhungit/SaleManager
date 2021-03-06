using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLiBanHang.Controller;
using QuanLiBanHang.Entity;
using System.Data.SqlClient;
using MicrosoftHelper;
namespace SalesManager
{
    public partial class frmPhuchoi : DevExpress.XtraEditors.XtraForm
    {
        SYS_LOG _sys_log = new SYS_LOG();
        public frmPhuchoi()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string pathname = "";
            pathname = txtLink.Text.Trim() + @"\" + txtTaptin.Text.Trim() + ".bak";
            SqlConnection con = new SqlConnection(DataProvider.ConnectionString);
            con.Open();
            SqlCommand cmd_insert = con.CreateCommand();
            cmd_insert.CommandText = "USE master " +
                                      "RESTORE DATABASE [SaleExample] " +
                                      "FROM DISK = '" + pathname + "'";
            try
            {
                cmd_insert.ExecuteNonQuery();
                con.Close();
                _sys_log.MChine = "COMPUTER";
                _sys_log.IP = "COMPUTER";
                _sys_log.UserID = "US000001";
                _sys_log.Created = DateTime.Now;
                _sys_log.Action_Name = "Phục Hồi";
                _sys_log.Description = "Phục Hồi Cơ Sở Dữ Liệu Hệ Thống -" + pathname;
                _sys_log.Module = "Cơ Sở Dữ Liệu";
                _sys_log.Reference = txtLink.Text.Trim() + "," + "SaleExample";
                _sys_log.Active = true;
                SYS_LOGController insertlog = new SYS_LOGController();
                insertlog.SYS_LOG_Insert(_sys_log);
                MessageBox.Show("Phục hồi dữ liệu thành công!!", "Thông báo");

            }
            catch
            {
                MessageBox.Show("Phục hồi dữ liệu thất bại!!", "Thông báo");
            }
        }
    }
}