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
    public partial class frmInPhieuNhapHang : Form
    {
        public frmInPhieuNhapHang(string Sophieu)
        {
            InitializeComponent();
            dsNhapHang baocao = new dsNhapHang();
            DataTable dtable = baocao.THNhapHang;
            rptPhieuNhapKho report = new rptPhieuNhapKho();
            dtable = new STOCK_INWARD_DETAILController().Report_NhapHang(Sophieu);
            report.Database.Tables["THNhapHang"].SetDataSource((DataTable)dtable);
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
