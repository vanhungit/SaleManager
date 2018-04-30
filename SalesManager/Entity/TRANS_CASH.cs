using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class TRANS_CASH
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
        private string _BookID ="";
        public string BookID
        {
            get { return _BookID; }
            set
            {
                _BookID = value;
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
        private DateTime _RefDate = DateTime.Now;
        public DateTime RefDate
        {
            get { return _RefDate; }
            set
            {
                _RefDate = value;
            }
        }
        private string _RefNo = "";
        /// <summary>
        /// uniqueidentifier
        /// </summary>
        public string RefNo
        {
            get { return _RefNo; }
            set
            {
                _RefNo = value;
            }
        }
        private string _RefOrgNo = "";
        /// <summary>
        /// uniqueidentifier
        /// </summary>
        public string RefOrgNo
        {
            get { return _RefOrgNo; }
            set
            {
                _RefOrgNo = value;
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
        private string _CustomerID = "";
        public string CustomerID
        {
            get { return _CustomerID; }
            set
            {
                _CustomerID = value;
            }
        }
        private string _PaymentMethod = "";
        /// <summary>
        /// uniqueidentifier
        /// </summary>
        public string PaymentMethod
        {
            get { return _PaymentMethod; }
            set
            {
                _PaymentMethod = value;
            }
        }
        private string _CurrencyID = "";
        public string CurrencyID
        {
            get { return _CurrencyID; }
            set
            {
                _CurrencyID = value;
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
        private double _Balance = 0;
        public double Balance
        {
            get { return _Balance; }
            set
            {
                _Balance = value;
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
        private double _FBalance = 0;
        public double FBalance
        {
            get { return _FBalance; }
            set
            {
                _FBalance = value;
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
        
        
        
    }
}
