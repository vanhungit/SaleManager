using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManager.Entity
{
    public class KYKHO_DETAIL
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
        private string _ID_KYKHO = "";
        public string ID_KYKHO
        {
            get { return _ID_KYKHO; }
            set
            {
                _ID_KYKHO = value;
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
        private string _Unit_ID = "";
        public string Unit_ID
        {
            get { return _Unit_ID; }
            set
            {
                _Unit_ID = value;
            }
        }
        private string _StockID = "";
        public string StockID
        {
            get { return _StockID; }
            set
            {
                _StockID = value;
            }
        }
        private string _ProductGroupID = "";
        public string ProductGroupID
        {
            get { return _ProductGroupID; }
            set
            {
                _ProductGroupID = value;
            }
        }
        private double _OpenQuantity = 0;
        public double OpenQuantity
        {
            get { return _OpenQuantity; }
            set
            {
                _OpenQuantity = value;
            }
        }
        private double _OpenAmount = 0;
        public double OpenAmount
        {
            get { return _OpenAmount; }
            set
            {
                _OpenAmount = value;
            }
        }
        private double _InQuantity = 0;
        public double InQuantity
        {
            get { return _InQuantity; }
            set
            {
                _InQuantity = value;
            }
        }
        private double _InAmount = 0;
        public double InAmount
        {
            get { return _InAmount; }
            set
            {
                _InAmount = value;
            }
        }
        private double _OutQuantity = 0;
        public double OutQuantity
        {
            get { return _OutQuantity; }
            set
            {
                _OutQuantity = value;
            }
        }
        private double _OutAmount = 0;
        public double OutAmount
        {
            get { return _OutAmount; }
            set
            {
                _OutAmount = value;
            }
        }
        private double _OnhandQuantity = 0;
        public double OnhandQuantity
        {
            get { return _OutQuantity; }
            set
            {
                _OutQuantity = value;
            }
        }
        private double _CloseAmount = 0;
        public double CloseAmount
        {
            get { return _CloseAmount; }
            set
            {
                _CloseAmount = value;
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
