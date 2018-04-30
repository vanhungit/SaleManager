using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SalesManager.Entity
{
    class Mobile_DataTemp
    {
        private Guid _ID = Guid.NewGuid();
        public Guid ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        private string _IP_Address = "";
        public string IP_Address
        {
            get { return _IP_Address; }
            set
            {
                _IP_Address = value;
            }
        }
        private string _MobiName ="";
        public string MobiName
        {
            get { return _MobiName; }
            set
            {
                _MobiName = value;
            }
        }
        private string _SeriNumber = "";
        public string SeriNumber
        {
            get { return _SeriNumber; }
            set
            {
                _SeriNumber = value;
            }
        }
        private string _StoreName = "";
        public string StoreName
        {
            get { return _StoreName; }
            set
            {
                _StoreName = value;
            }
        }
        private string _Barcode = "";
        public string Barcode
        {
            get { return _Barcode; }
            set
            {
                _Barcode = value;
            }
        }
        private string _ProductName = "";
        public string ProductName
        {
            get { return _ProductName; }
            set
            {
                _ProductName = value;
            }
        }
        private double _Sale_Price = 0;
        public double Sale_Price
        {
            get { return _Sale_Price; }
            set
            {
                _Sale_Price = value;
            }
        }
        private double _CurrentQty = 0;
        public double CurrentQty
        {
            get { return _CurrentQty; }
            set
            {
                _CurrentQty = value;
            }
        }
        private DateTime _CreateDate = DateTime.Now;
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set
            {
                _CreateDate = value;
            }
        } 
           
    }
}
