using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace QuanLiBanHang.Entity
{
    public class REFTYPE
    {
        private int _ID = 0;
        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        private string _Name = "";
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
            }
        }
        private string _NameEN = "";
        public string NameEN
        {
            get { return _NameEN; }
            set
            {
                _NameEN = value;
            }
        }
        private int _CategoryID = 0;
        public int CategoryID
        {
            get { return _CategoryID; }
            set
            {
                _CategoryID = value;
            }
        }
        private long _Sorted = 0;
        public long Sorted
        {
            get { return _Sorted; }
            set
            {
                _Sorted = value;
            }
        }
        private bool _IsSearch = false;
        public bool IsSearch
        {
            get { return _IsSearch; }
            set
            {
                _IsSearch = value;
            }
        }
        
        
    }
}
