using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManager.Entity
{
    public class INVOICE
    {
        private long _ID = 0;
        public long ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
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
        private DateTime _RefDate = DateTime.Now;
        public DateTime RefDate
        {
            get { return _RefDate; }
            set
            {
                _RefDate = value;
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
        private string _StockID = "";
        public string StockID
        {
            get { return _StockID; }
            set
            {
                _StockID = value;
            }
        }
        private int _PrintCount = 0;
        public int PrintCount
        {
            get { return _PrintCount; }
            set
            {
                _PrintCount = value;
            }
        }
        private double _TongTien = 0;
        public double TongTien
        {
            get { return _TongTien; }
            set
            {
                _TongTien = value;
            }
        }
        private double _KhachTra = 0;
        public double KhachTra
        {
            get { return _KhachTra; }
            set
            {
                _KhachTra = value;
            }
        }
        private double _ConLai = 0;
        public double ConLai
        {
            get { return _ConLai; }
            set
            {
                _ConLai = value;
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
