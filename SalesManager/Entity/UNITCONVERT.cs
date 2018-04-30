using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class UNITCONVERT
    {
        private string _Product_ID = "";
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
        private double _UnitConvert = 0;
        public double UnitConvert
        {
            get { return _UnitConvert; }
            set
            {
                _UnitConvert = value;
            }
        }
        private string _UnitChild_ID ="";
        public string UnitChild_ID
        {
            get { return _UnitChild_ID; }
            set
            {
                _UnitChild_ID = value;
            }
        }
        
    }
}
