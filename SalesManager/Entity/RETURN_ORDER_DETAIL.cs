using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManager.Entity
{
    public class RETURN_ORDER_DETAIL
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
        private string _Return_ID = "";
        /// <summary>
        /// Mã đơn hàng trả
        /// </summary>
        public string Return_ID
        {
            get { return _Return_ID; }
            set
            {
                _Return_ID = value;
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
        private int _Vat = 0;
        public int Vat
        {
            get { return _Vat; }
            set
            {
                _Vat = value;
            }
        }
        private double _VatAmount = 0;
        public double VatAmount
        {
            get { return _VatAmount; }
            set
            {
                _VatAmount = value;
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
        private double _QtyConvert = 0;
        public double QtyConvert
        {
            get { return _QtyConvert; }
            set
            {
                _QtyConvert = value;
            }
        }
        private double _DiscountRate = 0;
        public double DiscountRate
        {
            get { return _DiscountRate; }
            set
            {
                _DiscountRate = value;
            }
        }
        private double _Discount = 0;
        public double Discount
        {
            get { return _Discount; }
            set
            {
                _Discount = value;
            }
        }
        private double _Charge = 0;
        public double Charge
        {
            get { return _Charge; }
            set
            {
                _Charge = value;
            }
        }
        private DateTime _Limit = DateTime.Now;
        public DateTime Limit
        {
            get { return _Limit; }
            set
            {
                _Limit = value;
            }
        }
        private double _Width = 0;
        public double Width
        {
            get { return _Width; }
            set
            {
                _Width = value;
            }
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
        private string _Size = "";
        public string Size
        {
            get { return _Size; }
            set
            {
                _Size = value;
            }
        }
        private string _Color = "";
        public string Color
        {
            get { return _Color; }
            set
            {
                _Color = value;
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
        private string _ChassyNo = "";
        public string ChassyNo
        {
            get { return _ChassyNo; }
            set
            {
                _ChassyNo = value;
            }
        }
        private string _IME = "";
        public string IME
        {
            get { return _IME; }
            set
            {
                _IME = value;
            }
        }
        //private string _Location = "";
        //public string Location
        //{
        //    get { return _Location; }
        //    set
        //    {
        //        _Location = value;
        //    }
        //}
        private long _StoreID = 0;
        public long StoreID
        {
            get { return _StoreID; }
            set
            {
                _StoreID = value;
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
