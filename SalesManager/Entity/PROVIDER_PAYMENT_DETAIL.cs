using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class PROVIDER_PAYMENT_DETAIL
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
        private Guid _PaymentID = Guid.NewGuid();
        /// <summary>
        /// uniqueidentifier
        /// </summary>
        public Guid PaymentID
        {
            get { return _PaymentID; }
            set
            {
                _PaymentID = value;
            }
        }
        private Guid _RefOrgNo = Guid.NewGuid();
        /// <summary>
        /// uniqueidentifier
        /// </summary>
        public Guid RefOrgNo
        {
            get { return _RefOrgNo; }
            set
            {
                _RefOrgNo = value;
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
        private double _Quantity = 0;
        public double Quantity
        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
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
        private double _Debit = 0;
        public double Debit
        {
            get { return _Debit; }
            set
            {
                _Debit = value;
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
        private double _DiscountPercent = 0;
        public double DiscountPercent
        {
            get { return _DiscountPercent; }
            set
            {
                _DiscountPercent = value;
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
        private double _FAmount = 0;
        public double FAmount
        {
            get { return _FAmount; }
            set
            {
                _FAmount = value;
            }
        }
        private double _FDebit = 0;
        public double FDebit
        {
            get { return _FDebit; }
            set
            {
                _FDebit = value;
            }
        }
        private double _FPayment = 0;
        public double FPayment
        {
            get { return _FPayment; }
            set
            {
                _FPayment = value;
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
