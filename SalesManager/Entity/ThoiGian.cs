using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SalesManager.Entity
{
    class ThoiGian
    {
        private int _Begindayofmonth = 1;
        public int Begindayofmotnh
        {
            get { return _Begindayofmonth; }
            set
            {
                _Begindayofmonth = value;
            }
        }
        private int _Enddayofmonth = 1;
        public int Enddayofmonth
        {
            get { return _Enddayofmonth; }
            set { _Enddayofmonth = value; }
        }
        private int _Qui = 1;
        public int Qui
        {
            get { return _Qui; }
            set
            {
                _Qui = value;
            }
        }
        
    }
}
