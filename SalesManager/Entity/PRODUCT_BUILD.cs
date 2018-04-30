using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class PRODUCT_BUILD
    {
        #region private properties
        private string _ProductID = "";
        public string ProductID
        {
            get { return _ProductID; }
            set
            {
                _ProductID = value;
            }
        }
        private string _BuildID = "";
        public string BuildID
        {
            get { return _BuildID; }
            set
            {
                _BuildID = value;
            }
        }
        private double _Quantity = 0;
        public double Quantity
        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
            }
        }
        private double _Price = 0;
        public double Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
            }
        }
        private double _Amount =0;
        public double Amount
        {
            get { return _Amount; }
            set
            {
                _Amount = value;
            }
        }
        
        
        #endregion
    }
}
