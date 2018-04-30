using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManager.Entity
{
    public class BANGGIA_DETAIL
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
        private string _ID_BANGGIA = "";
        public string ID_BANGGIA
        {
            get { return _ID_BANGGIA; }
            set
            {
                _ID_BANGGIA = value;
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
        private double _Org_Price = 0;
        public double Org_Price
        {
            get { return _Org_Price; }
            set
            {
                _Org_Price = value;
            }
        }
        private double _Sale_Price = 0;
        public double Sale_Price
        {
            get { return _Sale_Price; }
            set
            {
                _Sale_Price = value;
            }
        }
        private double _Retail_Price = 0;
        public double Retail_Price
        {
            get { return _Retail_Price; }
            set
            {
                _Retail_Price = value;
            }
        }
        private double _Org_Price_New = 0;
        public double Org_Price_New
        {
            get { return _Org_Price_New; }
            set
            {
                _Org_Price_New = value;
            }
        }
        private double _Sale_Price_New = 0;
        public double Sale_Price_New
        {
            get { return _Sale_Price_New; }
            set
            {
                _Sale_Price_New = value;
            }
        }
        private double _Retail_Price_New = 0;
        public double Retail_Price_New
        {
            get { return _Retail_Price_New; }
            set
            {
                _Retail_Price_New = value;
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
