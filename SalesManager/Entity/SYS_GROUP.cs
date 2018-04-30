using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class SYS_GROUP
    {
        private string _Group_ID = "";
        public string Group_ID
        {
            get { return _Group_ID; }
            set
            {
                _Group_ID = value;
            }
        }
        private string _Group_Name = "";
        public string Group_Name
        {
            get { return _Group_Name; }
            set
            {
                _Group_Name = value;
            }
        }
        private string _Group_NameEn ="";
        public string Group_NameEn
        {
            get { return _Group_NameEn; }
            set
            {
                _Group_NameEn = value;
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
