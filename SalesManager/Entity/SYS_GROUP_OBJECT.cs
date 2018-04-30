using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;

namespace QuanLiBanHang.Entity
{
    public class SYS_GROUP_OBJECT
    {
        private string _Object_ID = "";
        public string Object_ID
        {
            get { return _Object_ID; }
            set
            {
                _Object_ID = value;
            }
        }
        private string _Goup_ID = "";
        public string Goup_ID
        {
            get { return _Goup_ID; }
            set
            {
                _Goup_ID = value;
            }
        }
        private string _Active = "";
        public string Active
        {
            get { return _Active; }
            set
            {
                _Active = value;
            }
        }
        
    }
}
