using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace QuanLiBanHang.Entity
{
    public class PRODUCT_TYPE
    {
        #region private properties
        private int _Product_Type_ID = 0;
        public int Product_Type_ID
        {
            get { return _Product_Type_ID; }
            set
            {
                _Product_Type_ID = value;
            }
        }
        private string _Product_Name = "";
        public string Product_Name
        {
            get { return _Product_Name; }
            set
            {
                _Product_Name = value;
            }
        }
        
        #endregion
    }
}
