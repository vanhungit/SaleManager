using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace QuanLiBanHang.Entity
{
    public class CUSTOMER_RECEIPT
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
        private string _RefOrgNo = "";
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
        private int _RefStatus;
        public int RefStatus
        {
            get { return _RefStatus; }
            set
            {
                _RefStatus = value;
            }
        }
        private Guid _PaymentMethod = Guid.NewGuid();
        /// <summary>
        /// uniqueidentifier
        /// </summary>
        public Guid PaymentMethod
        {
            get { return _PaymentMethod; }
            set
            {
                _PaymentMethod = value;
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
        private string _CurrencyID ="";
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
        private string _BranchID = "";
        public string BranchID
        {
            get { return _BranchID; }
            set
            {
                _BranchID = value;
            }
        }
        private string _ContractID = "";
        public string ContractID
        {
            get { return _ContractID; }
            set
            {
                _ContractID = value;
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
        private string _CustomerTax ="";
        public string CustomerTax
        {
            get { return _CustomerTax; }
            set
            {
                _CustomerTax = value;
            }
        }
        private string _ContactName = "";
        public string ContactName
        {
            get { return _ContactName; }
            set
            {
                _ContactName = value;
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
        private double _Discount = 0;
        public double Discount
        {
            get { return _Discount; }
            set
            {
                _Discount = value;
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
        private bool _Reconciled = false;
        public bool Reconciled
        {
            get { return _Reconciled; }
            set
            {
                _Reconciled = value;
            }
        }
        private bool _IsPublic = false;
        public bool IsPublic
        {
            get { return _IsPublic; }
            set
            {
                _IsPublic = value;
            }
        }
        private string _CreatedBy = "";
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set
            {
                _CreatedBy = value;
            }
        }
        private DateTime _CreatedDate = DateTime.Now;
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set
            {
                _CreatedDate = value;
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
        private string _OwnerID ="";
        public string OwnerID
        {
            get { return _OwnerID; }
            set
            {
                _OwnerID = value;
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
        private long _Sorted =0;
        public long Sorted
        {
            get { return _Sorted; }
            set
            {
                _Sorted = value;
            }
        }
        private bool _Active =false;
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
