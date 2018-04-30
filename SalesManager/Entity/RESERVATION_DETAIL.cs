using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManager.Entity
{
    public class RESERVATION_DETAIL
    {
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
        private string _Reservation_ID = "";
        /// <summary>
        /// Mã 
        /// </summary>
        public string Reservation_ID
        {
            get { return _Reservation_ID; }
            set
            {
                _Reservation_ID = value;
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
        private string _ProductName = "";
        public string ProductName
        {
            get { return _ProductName; }
            set
            {
                _ProductName = value;
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
        private string _OutStock = "";
        public string OutStock
        {
            get { return _OutStock; }
            set
            {
                _OutStock = value;
            }
        }
        private string _OutStockName = "";
        public string OutStockName
        {
            get { return _OutStockName; }
            set
            {
                _OutStockName = value;
            }
        }
        private string _LocationOut = "";
        public string LocationOut
        {
            get { return _LocationOut; }
            set
            {
                _LocationOut = value;
            }
        }
        private int _StatusOut = 0;
        public int StatusOut
        {
            get { return _StatusOut; }
            set
            {
                _StatusOut = value;
            }
        }
        private string _InStock = "";
        public string InStock
        {
            get { return _InStock; }
            set
            {
                _InStock = value;
            }
        }
        private string _InStockName = "";
        public string InStockName
        {
            get { return _InStockName; }
            set
            {
                _InStockName = value;
            }
        }
        private string _LocationIn = "";
        public string LocationIn
        {
            get { return _LocationIn; }
            set
            {
                _LocationIn = value;
            }
        }
        private int _StatusIn = 0;
        public int StatusIn
        {
            get { return _StatusIn; }
            set
            {
                _StatusIn = value;
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
        private string _Serial = "";
        public string Serial
        {
            get { return _Serial; }
            set
            {
                _Serial = value;
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
        private bool _Active = false;
        public bool Active
        {
            get { return _Active; }
            set
            {
                _Active = value;
            }
        }
    }
}
