using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class TRANS_REF
    {
        private string _ID = "";
        /// <summary>
        /// uniqueidentifier
        /// </summary>
        public string ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        private string _RefID = "";
        public string RefID
        {
            get { return _RefID; }
            set
            {
                _RefID = value;
            }
        }
        private string _RefOrgNo ="";
        public string RefOrgNo
        {
            get { return _RefOrgNo; }
            set
            {
                _RefOrgNo = value;
            }
        }
        private int _RefType =0;
        public int RefType
        {
            get { return _RefType; }
            set
            {
                _RefType = value;
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
        private string _TransFrom ="";
        public string TransFrom
        {
            get { return _TransFrom; }
            set
            {
                _TransFrom = value;
            }
        }
        private string _TransTo = "";
        public string TransTo
        {
            get { return _TransTo; }
            set
            {
                _TransTo = value;
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
        private string _Contract = "";
        public string Contract
        {
            get { return _Contract; }
            set
            {
                _Contract = value;
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
        private double _Amount = 0;
        public double Amount
        {
            get { return _Amount; }
            set
            {
                _Amount = value;
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
        private double _FAmount = 0;
        public double FAmount
        {
            get { return _FAmount; }
            set
            {
                _FAmount = value;
            }
        }
        private double _FDiscount = 0;
        public double FDiscount
        {
            get { return _FDiscount; }
            set
            {
                _FDiscount = value;
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
        private string _Description = "";
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
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
        
        
        
    }
}
