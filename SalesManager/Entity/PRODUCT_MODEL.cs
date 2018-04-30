using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace QuanLiBanHang.Entity
{
    public class PRODUCT_MODEL
    {
        #region private properties
        private string _ID = "";
        /// <summary>
        /// uniqueidentifier
        /// </summary>
        public string ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        private string _Code = "";
        public string Code
        {
            get { return _Code; }
            set
            {
                _Code = value;
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
        private string _Description = "";
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
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
        
        #endregion
    }
}
