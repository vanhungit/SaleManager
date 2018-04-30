using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace QuanLiBanHang.Entity
{
    public class STOCK_TRANSFER
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
        private string _FromStock_ID;
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
        private string _Branch_ID;
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
        private string _Currency_ID = "";
        public string Currency_ID
        {
            get { return _Currency_ID; }
            set
            {
                _Currency_ID = value;
            }
        }
        private double _ExchangeRate =0;
        public double ExchangeRate
        {
            get { return _ExchangeRate; }
            set
            {
                _ExchangeRate = value;
            }
        }
        private string _Barcode ="";
        public string Barcode
        {
            get { return _Barcode; }
            set
            {
                _Barcode = value;
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
        private bool _IsReview = false;
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
        private bool _IsClose = false;
        public bool IsClose
        {
            get { return _IsClose; }
            set
            {
                _IsClose = value;
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
        private string _Description ="";
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
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
