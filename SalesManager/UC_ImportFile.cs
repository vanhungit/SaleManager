using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalesManager
{
    public partial class UC_ImportFile : UserControl
    {
        public UC_ImportFile(frmNhapDuLieu frm, int tuychon,int khuvuc)
        {
            InitializeComponent();
            radioGroup1.SelectedIndex = tuychon;
            radioGroup2.SelectedIndex = khuvuc;
        }
        public int returnchecktuychon()
        {
            return radioGroup1.SelectedIndex;
        }
        public int returncheckkhuvuc()
        {
            return radioGroup2.SelectedIndex;
        }
    }
}
