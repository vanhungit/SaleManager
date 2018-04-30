using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class SYS_USER_RULE
    {
        private string _Goup_ID = "";
        public string Goup_ID
        {
            get { return _Goup_ID; }
            set
            {
                _Goup_ID = value;
            }
        }
        private string _Object_ID = "";
        public string Object_ID
        {
            get { return _Object_ID; }
            set
            {
                _Object_ID = value;
            }
        }
        private string _Rule_ID = "";
        public string Rule_ID
        {
            get { return _Rule_ID; }
            set
            {
                _Rule_ID = value;
            }
        }
        private bool _AllowAdd = false;
        public bool AllowAdd
        {
            get { return _AllowAdd; }
            set
            {
                _AllowAdd = value;
            }
        }
        private bool _AllowDelete = false;
        public bool AllowDelete
        {
            get { return _AllowDelete; }
            set
            {
                _AllowDelete = value;
            }
        }
        private bool _AllowEdit = false;
        public bool AllowEdit
        {
            get { return _AllowEdit; }
            set
            {
                _AllowEdit = value;
            }
        }
        private bool _AllowAccess = false;
        public bool AllowAccess
        {
            get { return _AllowAccess; }
            set
            {
                _AllowAccess = value;
            }
        }
        private bool _AllowPrint = false;
        public bool AllowPrint
        {
            get { return _AllowPrint; }
            set
            {
                _AllowPrint = value;
            }
        }
        private bool _AllowExport = false;
        public bool AllowExport
        {
            get { return _AllowExport; }
            set
            {
                _AllowExport = value;
            }
        }
        private bool _AllowImport = false;
        public bool AllowImport
        {
            get { return _AllowImport; }
            set
            {
                _AllowImport = value;
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
