using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesManager.Entity;
using System.IO;

namespace SalesManager
{
    public partial class frmHienThiCheckPrice : Form
    {
        CheckPrice objcheckprice = new CheckPrice();
        public frmHienThiCheckPrice(CheckPrice objcheck)
        {
            InitializeComponent();
            objcheckprice = objcheck;
            MemoryStream fs1 = new MemoryStream(objcheck.CameraImage, true);
            if (fs1.Length != 1)
            {
                pictureEdit1.Image = Image.FromStream(fs1);
                pictureEdit1.Refresh();
            }
            MemoryStream fs2 = new MemoryStream(objcheck.Signature, true);
            if (fs2.Length != 1)
            {
                pictureEdit2.Image = Image.FromStream(fs2);
                pictureEdit2.Refresh();
            }
            txtIP.Text = objcheck.IP_Address;
            txtSeriNum.Text = objcheck.SeriNum;
            txtBarcode.Text = objcheck.BarcodeNew;
            txtName.Text = objcheck.NameNew;
            txtUnit.Text = objcheck.UnitNew;
            txtPrice.Text = objcheck.SalePriceNew.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
