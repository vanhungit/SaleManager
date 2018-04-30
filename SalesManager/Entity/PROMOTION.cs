using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SalesManager.Entity
{
    public class PROMOTION
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
        private string _Name_Promotion = "";
        public string Name_Promotion
        {
            get { return _Name_Promotion; }
            set
            {
                _Name_Promotion = value;
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
        private DateTime _StartDate = DateTime.Now;
        public DateTime StartDate
        {
            get { return _StartDate; }
            set
            {
                _StartDate = value;
            }
        }
        private DateTime _StopDate = DateTime.Now;
        public DateTime StopDate
        {
            get { return _StopDate; }
            set
            {
                _StopDate = value;
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
