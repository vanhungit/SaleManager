using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManager.Entity
{
    public class InventoryMobile
    {
        private long _STT = 0;
        public long STT
        {
            get { return _STT; }
            set
            {
                _STT = value;
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
        private string _SeriNum = "";
        public string SeriNum
        {
            get { return _SeriNum; }
            set
            {
                _SeriNum = value;
            }
        }
        private string _Location = "";
        public string Location
        {
            get { return _Location; }
            set
            {
                _Location = value;
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
        private string _AXcode = "";
        public string AXcode
        {
            get { return _AXcode; }
            set
            {
                _AXcode = value;
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
        private string _Batch = "";
        public string Batch
        {
            get { return _Batch; }
            set
            {
                _Batch = value;
            }
        }
        private string _Unit = "";
        public string Unit
        {
            get { return _Unit; }
            set
            {
                _Unit = value;
            }
        }
        private double _Quantity = 0;
        public double Quantity
        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
            }
        }
        private DateTime _Timerow = DateTime.Now;
        public DateTime Timerow
        {
            get { return _Timerow; }
            set
            {
                _Timerow = value;
            }
        } 
    }

}
