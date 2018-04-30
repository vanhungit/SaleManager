using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace QuanLiBanHang.Entity
{
    public class CASH_METHOD
    {
        #region private propertise
        private Guid _ID = Guid.NewGuid();
        public Guid ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        private string _Code = "";
        public string Code
        {
            get { return _Code; }
            set
            {
                _Code = value;
            }
        }
        private string _Name = "";
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
            }
        }
        private string _NameEN = "";
        public string NameEN
        {
            get { return _NameEN; }
            set
            {
                _NameEN = value;
            }
        }
        private int _TypeID = 0;
        public int TypeID
        {
            get { return _TypeID; }
            set
            {
                _TypeID = value;
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
        private string _Description = "";
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
            }
        }
        private long _Sorted = 1;
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
