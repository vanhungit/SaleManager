using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace QuanLiBanHang.Entity
{
    public class PRODUCT_UNIT
    {
        private string _Product_ID ="";
        public string Product_ID
        {
            get { return _Product_ID; }
            set
            {
                _Product_ID = value;
            }
        }
        private string _Unit_ID = "";
        public string Unit_ID
        {
            get { return _Unit_ID; }
            set
            {
                _Unit_ID = value;
            }
        }
        private string _UnitConvert_ID ="";
        public string UnitConvert_ID
        {
            get { return _UnitConvert_ID; }
            set
            {
                _UnitConvert_ID = value;
            }
        }
        private double _UnitConvert =0;
        public double UnitConvert
        {
            get { return _UnitConvert; }
            set
            {
                _UnitConvert = value;
            }
        }
        private long _Sorted =0;
        public long Sorted
        {
            get { return _Sorted; }
            set
            {
                _Sorted = value;
            }
        }
        
    }
}
