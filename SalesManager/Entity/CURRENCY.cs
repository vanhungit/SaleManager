using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace QuanLiBanHang.Entity
{
    public class CURRENCY
    {
        private string _Currency_ID = "";
        public string Currency_ID
        {
            get { return _Currency_ID; }
            set
            {
                _Currency_ID = value;
            }
        }
        private string _CurrencyName = "";
        public string CurrencyName
        {
            get { return _CurrencyName; }
            set
            {
                _CurrencyName = value;
            }
        }
        private double _Exchange = 0;
        public double Exchange
        {
            get { return _Exchange; }
            set
            {
                _Exchange = value;
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
