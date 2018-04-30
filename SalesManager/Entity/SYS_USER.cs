using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class SYS_USER
    {
        private string _UserID = "";
        public string UserID
        {
            get { return _UserID; }
            set
            {
                _UserID = value;
            }
        }
        private string _UserName = "";
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
            }
        }
        private string _Password = "";
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
            }
        }
        private string _Group_ID = "";
        public string Group_ID
        {
            get { return _Group_ID; }
            set
            {
                _Group_ID = value;
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
        private string _PartID = "";
        public string PartID
        {
            get { return _PartID; }
            set
            {
                _PartID = value;
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
