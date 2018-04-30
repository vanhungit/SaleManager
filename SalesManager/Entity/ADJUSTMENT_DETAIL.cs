using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class ADJUSTMENT_DETAIL
    {
        #region private properties
        private Guid _ID = Guid.NewGuid();
        /// <summary>
        /// uniqueidentifier
        /// </summary>
        public Guid ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        private string _Adjustment_ID = "";
        public string Adjustment_ID
        {
            get { return _Adjustment_ID; }
            set
            {
                _Adjustment_ID = value;
            }
        }
        private string _Product_ID = "";
        public string Product_ID
        {
            get { return _Product_ID; }
            set
            {
                _Product_ID = value;
            }
        }
        private string _Product_Name="";
        public string Product_Name
        {
            get { return _Product_Name; }
            set { _Product_Name = value; }
        }
        private string _Stock_ID = "";
        public string Stock_ID
        {
            get { return _Stock_ID; }
            set
            {
                _Stock_ID = value;
            }
        }
        private string _Unit = "";
        public string Unit
        {
            get { return _Unit; }
            set
            {
                _Unit = value;
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
        private double _Width = 0;
        public double Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        private double _Height = 0;
        public double Height
        {
            get { return _Height; }
            set
            {
                _Height = value;
            }
        }
        private string _Orgin = "";
        public string Orgin
        {
            get { return _Orgin; }
            set
            {
                _Orgin = value;
            }
        }
        private double _CurrentQty = 0;
        public double CurrentQty
        {
            get { return _CurrentQty; }
            set
            {
                _CurrentQty = value;
            }
        }
        private double _NewQty = 0;
        public double NewQty
        {
            get { return _NewQty; }
            set
            {
                _NewQty = value;
            }
        }
        private double _QtyDiff = 0;
        public double QtyDiff
        {
            get { return _QtyDiff; }
            set
            {
                _QtyDiff = value;
            }
        }
        private double _UnitPrice = 0;
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set
            {
                _UnitPrice = value;
            }
        }
        private double _Amount = 0;
        public double Amount
        {
            get { return _Amount; }
            set
            {
                _Amount = value;
            }
        }
        private double _QtyConvert = 0;
        public double QtyConvert
        {
            get { return _QtyConvert; }
            set
            {
                _QtyConvert = value;
            }
        }
        private long _StoreID = 0;
        public long StoreID
        {
            get { return _StoreID; }
            set
            {
                _StoreID = value;
            }
        }
        private string _Batch = "";
        public string Batch
        {
            get { return _Batch; }
            set
            {
                _Batch = value;
            }
        }
        private string _Serial ="";
        public string Serial
        {
            get { return _Serial; }
            set
            {
                _Serial = value;
            }
        }
        private string _Location = "";
        public string Location
        {
            get { return _Location; }
            set
            {
                _Location = value;
            }
        }
        private string _Description ="";
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
            }
        }
        private long _Sorted = 0;
        public long Sorted
        {
            get { return _Sorted; }
            set
            {
                _Sorted = value;
            }
        }
           
        #endregion
    }
}
