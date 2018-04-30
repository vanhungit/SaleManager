using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesManager.Report;
using QuanLiBanHang.Controller;

namespace SalesManager
{
    public partial class frmInPhieuXuatHang : Form
    {
        public frmInPhieuXuatHang()
        {
            InitializeComponent();
            dsXuatHang baocao = new dsXuatHang();
            DataTable dtable = baocao.THXuatHang;
            rptPhieuXuatKho report = new rptPhieuXuatKho();
            dtable = new STOCK_OUTWARD_DETAILController().Report_XuatHang("BH_admin_000026");
            report.Database.Tables["THXuatHang"].SetDataSource((DataTable)dtable);
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
