using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class UNIT
    {
        private string _Unit_ID = "";
        public string Unit_ID
        {
            get { return _Unit_ID; }
            set
            {
                _Unit_ID = value;
            }
        }
        private string _Unit_Name = "";
        public string Unit_Name
        {
            get { return _Unit_Name; }
            set
            {
                _Unit_Name = value;
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
