using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class SYS_OPTION
    {
        private string _Option_ID ="";
        public string Option_ID
        {
            get { return _Option_ID; }
            set
            {
                _Option_ID = value;
            }
        }
        private string _OptionValue = "";
        public string OptionValue
        {
            get { return _OptionValue; }
            set
            {
                _OptionValue = value;
            }
        }
        private int _ValueType = 0;
        public int ValueType
        {
            get { return _ValueType; }
            set
            {
                _ValueType = value;
            }
        }
        private bool _System = false;
        public bool System
        {
            get { return _System; }
            set
            {
                _System = value;
            }
        }
        private string _Description ="";
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
            }
        }
        
        
    }
}
