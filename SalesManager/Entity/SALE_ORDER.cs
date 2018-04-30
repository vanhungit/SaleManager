using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManager.Entity
{
    public class SALE_ORDER
    {
        private string _ID = "";
        public string ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
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
        private string _Ref_OrgNo = "";
        public string Ref_OrgNo
        {
            get { return _Ref_OrgNo; }
            set
            {
                _Ref_OrgNo = value;
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
        private int _RefStatus = 0;
        public int RefStatus
        {
            get { return _RefStatus; }
            set
            {
                _RefStatus = value;
            }
        }
        private int _Status = 0;
        public int Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
            }
        }
        private Guid _PaymentMethod = Guid.NewGuid();
        public Guid PaymentMethod
        {
            get { return _PaymentMethod; }
            set
            {
                _PaymentMethod = value;
            }
        }
        private string _TermID = "";
        public string TermID
        {
            get { return _TermID; }
            set
            {
                _TermID = value;
            }
        }
        private DateTime _PaymentDate = DateTime.Now;
        public DateTime PaymentDate
        {
            get { return _PaymentDate; }
            set
            {
                _PaymentDate = value;
            }
        }
        private DateTime _DeliveryDate = DateTime.Now;
        public DateTime DeliveryDate
        {
            get { return _DeliveryDate; }
            set
            {
                _DeliveryDate = value;
            }
        }
        private string _Barcode = "";
        public string Barcode
        {
            get { return _Barcode; }
            set
            {
                _Barcode = value;
            }
        }
        private string _Department_ID = "";
        public string Department_ID
        {
            get { return _Department_ID; }
            set
            {
                _Department_ID = value;
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
        private string _Stock_ID = "";
        public string Stock_ID
        {
            get { return _Stock_ID; }
            set
            {
                _Stock_ID = value;
            }
        }
        private string _Branch_ID = "";
        public string Branch_ID
        {
            get { return _Branch_ID; }
            set
            {
                _Branch_ID = value;
            }
        }
        private string _Contract_ID = "";
        public string Contract_ID
        {
            get { return _Contract_ID; }
            set
            {
                _Contract_ID = value;
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
        private string _CustomerName = "";
        public string CustomerName
        {
            get { return _CustomerName; }
            set
            {
                _CustomerName = value;
            }
        }
        private string _CustomerAddress = "";
        public string CustomerAddress
        {
            get { return _CustomerAddress; }
            set
            {
                _CustomerAddress = value;
            }
        }
        private string _Contact = "";
        public string Contact
        {
            get { return _Contact; }
            set
            {
                _Contact = value;
            }
        }
        private string _Reason = "";
        public string Reason
        {
            get { return _Reason; }
            set
            {
                _Reason = value;
            }
        }
        private int _Payment = 0;
        public int Payment
        {
            get { return _Payment; }
            set
            {
                _Payment = value;
            }
        }
        private string _Currency_ID = "";
        public string Currency_ID
        {
            get { return _Currency_ID; }
            set
            {
                _Currency_ID = value;
            }
        }
        private double _ExchangeRate = 0;
        public double ExchangeRate
        {
            get { return _ExchangeRate; }
            set
            {
                _ExchangeRate = value;
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
        private double _Amount = 0;
        public double Amount
        {
            get { return _Amount; }
            set
            {
                _Amount = value;
            }
        }
        private double _FAmount = 0;
        public double FAmount
        {
            get { return _FAmount; }
            set
            {
                _FAmount = value;
            }
        }
        private DateTime _DiscountDate = DateTime.Now;
        public DateTime DiscountDate
        {
            get { return _DiscountDate; }
            set
            {
                _DiscountDate = value;
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
        private double _OtherDiscount = 0;
        public double OtherDiscount
        {
            get { return _OtherDiscount; }
            set
            {
                _OtherDiscount = value;
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
        private bool _IsClose = false;
        public bool IsClose
        {
            get { return _IsClose; }
            set
            {
                _IsClose = value;
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
        private string _User_ID = "";
        public string User_ID
        {
            get { return _User_ID; }
            set
            {
                _User_ID = value;
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
        private DateTime _Timestamp = DateTime.Now;
        public DateTime Timestamp
        {
            get { return _Timestamp; }
            set
            {
                _Timestamp = value;
            }
        }
        private string _CreateBy = "";
        public string CreateBy
        {
            get { return _CreateBy; }
            set
            {
                _CreateBy = value;
            }
        }
        private DateTime _Createdate = DateTime.Now;
        public DateTime Createdate
        {
            get { return _Createdate; }
            set
            {
                _Createdate = value;
            }
        }
        private string _ModifiedBy = "";
        public string ModifiedBy
        {
            get { return _ModifiedBy; }
            set
            {
                _ModifiedBy = value;
            }
        }
        private DateTime _ModifiedDate = DateTime.Now;
        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set
            {
                _ModifiedDate = value;
            }
        }
        private DateTime _LastEditDate = DateTime.Now;
        public DateTime LastEditDate
        {
            get { return _LastEditDate; }
            set { _LastEditDate = value; }
        }
        private DateTime _CreationDate = DateTime.Now;
        public DateTime CreationDate
        {
            get { return _CreationDate; }
            set { _CreationDate = value; }
        }   
    }
}
