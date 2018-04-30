using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManager.Entity
{
    public class NGANH_HANG
    {
        private string _ID_NGANH = "";
        public string ID_NGANH
        {
            get { return _ID_NGANH; }
            set
            {
                _ID_NGANH = value;
            }
        }
        private string _TEN_NGANH = "";
        public string TEN_NGANH
        {
            get { return _TEN_NGANH; }
            set
            {
                _TEN_NGANH = value;
            }
        }
        private string _DESCRIPTION = "";
        public string DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set
            {
                _DESCRIPTION = value;
            }
        }
        private bool _IsMain = false;
        public bool IsMain
        {
            get { return _IsMain; }
            set
            {
                _IsMain = value;
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
