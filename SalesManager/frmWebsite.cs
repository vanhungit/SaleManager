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
    public partial class frmWebsite : DevExpress.XtraEditors.XtraForm
    {
        public frmWebsite()
        {
            InitializeComponent();
            webBrowser1.StatusTextChanged += new EventHandler(webBrowser1_StatusTextChanged);
        }
        string currentAddress = "";
        int tc = 0;
        private void GoToItem(string address)
        {
            if (address == null) return;
            if (currentAddress != address)
            {
                eAddress.EditValue = address;
                webBrowser1.Navigate(address);
            }
        }
        private void webBrowser1_StatusTextChanged(object sender, EventArgs e)
        {
            iText.Caption = webBrowser1.StatusText;
        }
       
        bool CorrectAddress(string name)
        {
            string[] names = new string[] { "javascript:" };
            foreach (string s in names)
                if (name.IndexOf(s) == 0) return false;
            return true;
        }
        void InitHomePage()
        {
            //GoToItem("www.google.com.vn");
        }

        private void frmWebsite_Load(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(InitHomePage));
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BeginInvoke(new MethodInvoker(InitHomePage));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tc++ > 10)
            {
                timer1.Stop();
                //barManager1.SelectLink(null);
            }
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            string s = e.Url.AbsoluteUri;
            if (CorrectAddress(s))
            {
                eAddress.EditValue = s;
                currentAddress = s;
                //AddNewItem(s);
            }
        }


    }
}