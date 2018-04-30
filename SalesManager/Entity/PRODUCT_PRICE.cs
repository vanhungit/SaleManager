using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace QuanLiBanHang.Entity
{
    public class PRODUCT_PRICE
    {
        #region private Properties
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
        private DateTime _RefDate = DateTime.Now;
        public DateTime RefDate
        {
            get { return _RefDate; }
            set
            {
                _RefDate = value;
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
        private DateTime _BeginDate = DateTime.Now;
        public DateTime BeginDate
        {
            get { return _BeginDate; }
            set
            {
                _BeginDate = value;
            }
        }
        private DateTime _EndDate = DateTime.Now;
        public DateTime EndDate
        {
            get { return _EndDate; }
            set
            {
                _EndDate = value;
            }
        }
        private string _ProductID = "";
        /// <summary>
        /// uniqueidentifier
        /// </summary>
        public string ProductID
        {
            get { return _ProductID; }
            set
            {
                _ProductID = value;
            }
        }
        private string _CustomerID = "";
        /// <summary>
        /// uniqueidentifier
        /// </summary>
        public string CustomerID
        {
            get { return _CustomerID; }
            set
            {
                _CustomerID = value;
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
        private double _DiscountRate = 0;
        public double DiscountRate
        {
            get { return _DiscountRate; }
            set
            {
                _DiscountRate = value;
            }
        }
        private double _CommissionRate = 0;
        public double CommissionRate
        {
            get { return _CommissionRate; }
            set
            {
                _CommissionRate = value;
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
        private double _BeginAmount = 0;
        public double BeginAmount
        {
            get { return _BeginAmount; }
            set
            {
                _BeginAmount = value;
            }
        }
        private double _EndAmount = 0;
        public double EndAmount
        {
            get { return _EndAmount; }
            set
            {
                _EndAmount = value;
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
        private string _OwnerID = "";
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
        private bool _Active = false;
        public bool Active
        {
            get { return _Active; }
            set
            {
                _Active = value;
            }
        }
        
        
        
        
        #endregion

    }
}
