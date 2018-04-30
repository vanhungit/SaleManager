using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class DEBT
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
        private string _CustomerID = "";
        public string CustomerID
        {
            get { return _CustomerID; }
            set
            {
                _CustomerID = value;
            }
        }
        private string _ProductID = "";
        public string ProductID
        {
            get { return _ProductID; }
            set
            {
                _ProductID = value;
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
        private string _TermID = "";
        public string TermID
        {
            get { return _TermID; }
            set
            {
                _TermID = value;
            }
        }
        private DateTime _DueDate = DateTime.Now;
        public DateTime DueDate
        {
            get { return _DueDate; }
            set
            {
                _DueDate = value;
            }
        }
        private double _Quantity=0;
        public double Quantity
        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
            }
        }
        private double _ReQuantity = 0;
        public double ReQuantity
        {
            get { return _ReQuantity; }
            set
            {
                _ReQuantity = value;
            }
        }
        private double _Price = 0;
        public double Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
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
        private bool _IsChanged =  false;
        public bool IsChanged
        {
            get { return _IsChanged; }
            set
            {
                _IsChanged = value;
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
