using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManager.Entity
{
    public class KYKHO
    {
        private string _ID = "";
        public string ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        private string _KyKho_Name = "";
        public string KyKho_Name
        {
            get { return _KyKho_Name; }
            set
            {
                _KyKho_Name = value;
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
        private DateTime _Refdate = DateTime.Now;
        public DateTime Refdate
        {
            get { return _Refdate; }
            set
            {
                _Refdate = value;
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
        private DateTime _StartDate = DateTime.Now;
        public DateTime StartDate
        {
            get { return _StartDate; }
            set
            {
                _StartDate = value;
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
