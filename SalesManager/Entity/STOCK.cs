using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace QuanLiBanHang.Entity
{
    public class STOCK
    {
        private string _Stock_ID = "";
        public string Stock_ID
        {
            get { return _Stock_ID; }
            set
            {
                _Stock_ID = value;
            }
        }
        private string _Stock_Name = "";
        public string Stock_Name
        {
            get { return _Stock_Name; }
            set
            {
                _Stock_Name = value;
            }
        }
        private string _Contact = "";
        public string Contact
        {
            get { return _Contact; }
            set
            {
                _Contact = value;
            }
        }
        private string _Address = "";
        public string Address
        {
            get { return _Address; }
            set
            {
                _Address = value;
            }
        }
        private string _Email = "";
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
            }
        }
        private string _Telephone = "";
        public string Telephone
        {
            get { return _Telephone; }
            set
            {
                _Telephone = value;
            }
        }
        private string _Fax = "";
        public string Fax
        {
            get { return _Fax; }
            set
            {
                _Fax = value;
            }
        }
        private string _Mobi = "";
        public string Mobi
        {
            get { return _Mobi; }
            set
            {
                _Mobi = value;
            }
        }
        private string _Manager = "";
        public string Manager
        {
            get { return _Manager; }
            set
            {
                _Manager = value;
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
