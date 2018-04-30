using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace QuanLiBanHang.Entity
{
    public class SYS_LOG
    {
        private long _SYS_ID = 0;
        public long SYS_ID
        {
            get { return _SYS_ID; }
            set
            {
                _SYS_ID = value;
            }
        }
        private string _MChine = "";
        public string MChine
        {
            get { return _MChine; }
            set
            {
                _MChine = value;
            }
        }
        private string _IP = "";
        public string IP
        {
            get { return _IP; }
            set
            {
                _IP = value;
            }
        }
        private string _UserID = "";
        public string UserID
        {
            get { return _UserID; }
            set
            {
                _UserID = value;
            }
        }
        private DateTime _Created = DateTime.Now;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                _Created = value;
            }
        }
        private string _Module = "";
        public string Module
        {
            get { return _Module; }
            set
            {
                _Module = value;
            }
        }
        private int _Action = 0;
        public int Action
        {
            get { return _Action; }
            set
            {
                _Action = value;
            }
        }
        private string _Action_Name = "";
        public string Action_Name
        {
            get { return _Action_Name; }
            set
            {
                _Action_Name = value;
            }
        }
        private string _Reference = "";
        public string Reference
        {
            get { return _Reference; }
            set
            {
                _Reference = value;
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
