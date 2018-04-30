using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class SYS_COMPANY
    {
        private string _Company_Id = "";
        public string Company_Id
        {
            get { return _Company_Id; }
            set
            {
                _Company_Id = value;
            }
        }
        private string _Company = "";
        public string Company
        {
            get { return _Company; }
            set
            {
                _Company = value;
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
        private string _Tel = "";
        public string Tel
        {
            get { return _Tel; }
            set
            {
                _Tel = value;
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
        private string _WebSite = "";
        public string WebSite
        {
            get { return _WebSite; }
            set
            {
                _WebSite = value;
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
        private string _Tax = "";
        public string Tax
        {
            get { return _Tax; }
            set
            {
                _Tax = value;
            }
        }
        private string _Licence = "";
        public string Licence
        {
            get { return _Licence; }
            set
            {
                _Licence = value;
            }
        }
        private byte[] _Photo;
        public byte[] Photo
        {
            get { return _Photo; }
            set
            {
                _Photo = value;
            }
        }
        
        
    }
}
