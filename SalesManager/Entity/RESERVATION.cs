using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManager.Entity
{
    public class RESERVATION
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
        private DateTime _TransferDate = DateTime.Now;
        public DateTime TransferDate
        {
            get { return _TransferDate; }
            set
            {
                _TransferDate = value;
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
        private string _FromStock_ID = "";
        public string FromStock_ID
        {
            get { return _FromStock_ID; }
            set
            {
                _FromStock_ID = value;
            }
        }
        private string _Sender_ID = "";
        public string Sender_ID
        {
            get { return _Sender_ID; }
            set
            {
                _Sender_ID = value;
            }
        }
        private string _ToStock_ID = "";
        public string ToStock_ID
        {
            get { return _ToStock_ID; }
            set
            {
                _ToStock_ID = value;
            }
        }
        private string _Receiver_ID = "";
        public string Receiver_ID
        {
            get { return _Receiver_ID; }
            set
            {
                _Receiver_ID = value;
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
        private string _SO_ID = "";
        public string SO_ID
        {
            get { return _SO_ID; }
            set
            {
                _SO_ID = value;
            }
        }
        private string _PO_ID = "";
        public string PO_ID
        {
            get { return _PO_ID; }
            set
            {
                _PO_ID = value;
            }
        }
        private string _ProductOrder_ID = "";
        public string ProductOrder_ID
        {
            get { return _ProductOrder_ID; }
            set
            {
                _ProductOrder_ID = value;
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
        private string _Barcode = "";
        public string Barcode
        {
            get { return _Barcode; }
            set
            {
                _Barcode = value;
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
        private bool _IsReview = true;
        public bool IsReview
        {
            get { return _IsReview; }
            set
            {
                _IsReview = value;
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
        private bool _IsClose = true;
        public bool IsClose
        {
            get { return _IsClose; }
            set
            {
                _IsClose = value;
            }
        }
        private int _Sorted = 0;
        public int Sorted
        {
            get { return _Sorted; }
            set
            {
                _Sorted = value;
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
        private bool _Active = true;
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
