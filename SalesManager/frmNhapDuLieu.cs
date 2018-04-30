using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalesManager
{
    public partial class frmNhapDuLieu : Form
    {
        public frmNhapDuLieu()
        {
            InitializeComponent();
        }
         int curentform = 1;
        UC_ImportFile frmimportfile;
        UC_NhapFileDuLieu frmnhapfiledulieu;
        UC_HienThiLuoi frmhienthiluoi;
        UC_KetThucNhap frmketthucnhap;
        #region Step 1
         int checktuychon = 0;
         int checkkhuvuc = 0;
        #endregion
        #region step 2
         string pathname = "";
         string[] Listsheet = new string[100];
         string listforcus = "";
        #endregion
        #region step 3
         DataTable d_table = new DataTable();
        #endregion
        private void frmNhapDuLieu_Load(object sender, EventArgs e)
        {
            chkchon.Enabled = false;
            simpleButton3.Enabled = false;
            groupControl1.ResetText();
            groupControl1.Controls.Clear();
            frmimportfile = new UC_ImportFile(this,checktuychon,checkkhuvuc);
            frmimportfile.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmimportfile);//thêm user control vào panel
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (curentform == 1)
            {
                checktuychon = frmimportfile.returnchecktuychon();
                checkkhuvuc = frmimportfile.returncheckkhuvuc();
            }
            if (curentform == 2)
            {
                pathname = frmnhapfiledulieu.Pathname();
                Listsheet = frmnhapfiledulieu.List_Sheet();
                listforcus = frmnhapfiledulieu.List_focus();
            }
            if (curentform == 3)
            {
                d_table = frmhienthiluoi.returtable();
            }
            curentform++;
            if (curentform > 4)
                curentform = 4;
            if (curentform == 2)
            {
                chkchon.Enabled = true;
                simpleButton3.Enabled = true;
                groupControl1.ResetText();
                groupControl1.Controls.Clear();
                frmnhapfiledulieu = new UC_NhapFileDuLieu(this, pathname, Listsheet);
                frmnhapfiledulieu.Dock = DockStyle.Fill;
                groupControl1.Controls.Add(frmnhapfiledulieu);//thêm user control vào panel
            }
            if (curentform == 3)
            {
                chkchon.Enabled = true;
                simpleButton3.Enabled = true;
                groupControl1.ResetText();
                groupControl1.Controls.Clear();
                frmhienthiluoi = new UC_HienThiLuoi(pathname,listforcus);
                frmhienthiluoi.Dock = DockStyle.Fill;
                groupControl1.Controls.Add(frmhienthiluoi);//thêm user control vào panel
            }
            if (curentform == 4)
            {
                chkchon.Enabled = true;
                simpleButton3.Enabled = true;
                groupControl1.ResetText();
                groupControl1.Controls.Clear();
                frmketthucnhap = new UC_KetThucNhap(d_table,checktuychon,checkkhuvuc);
                frmketthucnhap.Dock = DockStyle.Fill;
                groupControl1.Controls.Add(frmketthucnhap);//thêm user control vào panel
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (curentform == 2)
            {
                pathname = frmnhapfiledulieu.Pathname();
                Listsheet = frmnhapfiledulieu.List_Sheet();
                listforcus = frmnhapfiledulieu.List_focus();
            }
            curentform--;
            if (curentform < 1)
                curentform = 1;
            if (curentform == 3)
            {
                chkchon.Enabled = true;
                simpleButton3.Enabled = true;
                groupControl1.ResetText();
                groupControl1.Controls.Clear();
                frmhienthiluoi = new UC_HienThiLuoi(pathname, listforcus);
                frmhienthiluoi.Dock = DockStyle.Fill;
                groupControl1.Controls.Add(frmhienthiluoi);//thêm user control vào panel
            }
            if (curentform == 2)
            {
                chkchon.Enabled = true;
                simpleButton3.Enabled = true;
                groupControl1.ResetText();
                groupControl1.Controls.Clear();
                frmnhapfiledulieu = new UC_NhapFileDuLieu(this, pathname, Listsheet);
                frmnhapfiledulieu.Dock = DockStyle.Fill;
                groupControl1.Controls.Add(frmnhapfiledulieu);//thêm user control vào panel
            }
            if (curentform == 1)
            {
                chkchon.Enabled = false;
                simpleButton3.Enabled = false;
                groupControl1.ResetText();
                groupControl1.Controls.Clear();
                frmimportfile = new UC_ImportFile(this, checktuychon, checkkhuvuc);
                frmimportfile.Dock = DockStyle.Fill;
                groupControl1.Controls.Add(frmimportfile);//thêm user control vào panel
            }
        }
    }
}
