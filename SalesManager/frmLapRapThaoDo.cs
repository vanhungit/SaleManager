using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SalesManager
{
    public partial class frmLapRapThaoDo : DevExpress.XtraEditors.XtraForm
    {
        UC_BangKeTHLapRapThaoDo frmLapRap;
        public frmLapRapThaoDo()
        {
            InitializeComponent();
            groupControl1.ResetText();
            groupControl1.Text = "Danh Sách Lệnh Lắp Ráp, Tháo Dỡ";
            groupControl1.Controls.Clear();
            frmLapRap = new UC_BangKeTHLapRapThaoDo();
            frmLapRap.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmLapRap);//thêm user control vào panel
        }
    }
}