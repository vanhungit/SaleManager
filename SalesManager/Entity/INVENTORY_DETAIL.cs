using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class INVENTORY_DETAIL
    {
        #region private properties
        private long _ID = 0;
        public long ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        private string _RefNo = "";
        public string RefNo
        {
            get { return _RefNo; }
            set
            {
                _RefNo = value;
            }
        }
        private DateTime _RefDate = DateTime.Now;
        public DateTime RefDate
        {
            get { return _RefDate; }
            set
            {
                _RefDate = value;
            }
        }
        private string _RefDetailNo ="";
        /// <summary>
        /// uniqueidentifier
        /// </summary>
        public string RefDetailNo
        {
            get { return _RefDetailNo; }
            set
            {
                _RefDetailNo = value;
            }
        }
        private int _RefType = 0;
        public int RefType
        {
            get { return _RefType; }
            set
            {
                _RefType = value;
            }
        }
        private int _RefStatus =0;
        public int RefStatus
        {
            get { return _RefStatus; }
            set
            {
                _RefStatus = value;
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
        private string _Stock_ID ="";
        public string Stock_ID
        {
            get { return _Stock_ID; }
            set
            {
                _Stock_ID = value;
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
        private string _Product_Name = "";
        public string Product_Name
        {
            get { return _Product_Name; }
            set
            {
                _Product_Name = value;
            }
        }
        private string _Customer_ID = "";
        public string Customer_ID
        {
            get { return _Customer_ID; }
            set
            {
                _Customer_ID = value;
            }
        }
        private string _Employee_ID = "";
        public string Employee_ID
        {
            get { return _Employee_ID; }
            set
            {
                _Employee_ID = value;
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
        private string _Unit = "";
        public string Unit
        {
            get { return _Unit; }
            set
            {
                _Unit = value;
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
        private double _Quantity = 0;
        public double Quantity
        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
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
        private double _E_Qty = 0;
        public double E_Qty
        {
            get { return _E_Qty; }
            set
            {
                _E_Qty = value;
            }
        }
        private double _E_Amt = 0;
        public double E_Amt
        {
            get { return _E_Amt; }
            set
            {
                _E_Amt = value;
            }
        }
        private string _Description = "";
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
        private string _Book_ID;
        public string Book_ID
        {
            get { return _Book_ID; }
            set
            {
                _Book_ID = value;
            }
        }
        

        
        #endregion
    }
}
