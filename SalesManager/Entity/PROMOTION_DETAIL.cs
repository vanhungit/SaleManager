using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SalesManager.Entity
{
    public class PROMOTION_DETAIL
    {
        private Guid _ID = Guid.NewGuid();
        public Guid ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        private string _Promotion_ID = "";
        public string Promotion_ID
        {
            get { return _Promotion_ID; }
            set
            {
                _Promotion_ID = value;
            }
        }
        private string _PRODUCT_ID = "";
        public string PRODUCT_ID
        {
            get { return _PRODUCT_ID; }
            set
            {
                _PRODUCT_ID = value;
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
        private string _ProductGroup_ID = "";
        public string ProductGroup_ID
        {
            get { return _ProductGroup_ID; }
            set
            {
                _ProductGroup_ID = value;
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
        private double _FromAmount = 0;
        public double FromAmount
        {
            get { return _FromAmount; }
            set
            {
                _FromAmount = value;
            }
        }
        private double _ToAmount = 0;
        public double ToAmount
        {
            get { return _ToAmount; }
            set
            {
                _ToAmount = value;
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
        private string _ModifyBy = "";
        public string ModifyBy
        {
            get { return _ModifyBy; }
            set
            {
                _ModifyBy = value;
            }
        }
        private DateTime _ModifyDate = DateTime.Now;
        public DateTime ModifyDate
        {
            get { return _ModifyDate; }
            set
            {
                _ModifyDate = value;
            }
        }
    }
}
