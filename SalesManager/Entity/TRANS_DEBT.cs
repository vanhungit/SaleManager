﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class TRANS_DEBT
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
        private string _BookID = "";
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
        private string _RefDetailNo = "";
        public string RefDetailNo
        {
            get { return _RefDetailNo; }
            set
            {
                _RefDetailNo = value;
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
        private string _RefOrgNo = "";
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
        private int _RefStatus =0;
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
        private string _CurrencyID = "";
        public string CurrencyID
        {
            get { return _CurrencyID; }
            set
            {
                _CurrencyID = value;
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
        private bool _IsDebt = false;
        public bool IsDebt
        {
            get { return _IsDebt; }
            set
            {
                _IsDebt = value;
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
        private double _Discount =0;
        public double Discount
        {
            get { return _Discount; }
            set
            {
                _Discount = value;
            }
        }
        private double _Payment = 0;
        public double Payment
        {
            get { return _Payment; }
            set
            {
                _Payment = value;
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
        private double _FDiscount = 0;
        public double FDiscount
        {
            get { return _FDiscount; }
            set
            {
                _FDiscount = value;
            }
        }
        private double _FPayment =0;
        public double FPayment
        {
            get { return _FPayment; }
            set
            {
                _FPayment = value;
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
        private double _Debit =0;
        public double Debit
        {
            get { return _Debit; }
            set
            {
                _Debit = value;
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
        private long _Sorted =0;
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
