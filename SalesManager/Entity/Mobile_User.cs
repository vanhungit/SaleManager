using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SalesManager.Entity
{
    class Mobile_User
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
        private string _IP_Address ="";
        public string IP_Address
        {
            get { return _IP_Address; }
            set
            {
                _IP_Address = value;
            }
        }
        private string _MobiName ="";
        public string MobiName
        {
            get { return _MobiName; }
            set
            {
                _MobiName = value;
            }
        }
        private string _SeriNumber = "";
        public string SeriNumber
        {
            get { return _SeriNumber; }
            set
            {
                _SeriNumber = value;
            }
        }
        private string _Employee_ID ="";
        public string Employee_ID
        {
            get { return _Employee_ID; }
            set
            {
                _Employee_ID = value;
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
        private DateTime _CreateDate = DateTime.Now;
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set
            {
                _CreateDate = value;
            }
        }
        private string _Decription = "";
        public string Decription
        {
            get { return _Decription; }
            set
            {
                _Decription = value;
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
