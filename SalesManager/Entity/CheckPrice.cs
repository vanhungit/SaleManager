using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManager.Entity
{
    public class CheckPrice
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
        
        private string _Unit = "";
        public string Unit
        {
            get { return _Unit; }
            set
            {
                _Unit = value;
            }
        }
        private double _SalePrice = 0;
        public double SalePrice
        {
            get { return _SalePrice; }
            set
            {
                _SalePrice = value;
            }
        }

        private string _BarcodeNew = "";
        public string BarcodeNew
        {
            get { return _BarcodeNew; }
            set
            {
                _BarcodeNew = value;
            }
        }
        private string _AXcodeNew = "";
        public string AXcodeNew
        {
            get { return _AXcodeNew; }
            set
            {
                _AXcodeNew = value;
            }
        }
        private string _NameNew = "";
        public string NameNew
        {
            get { return _NameNew; }
            set
            {
                _NameNew = value;
            }
        }

        private string _UnitNew = "";
        public string UnitNew
        {
            get { return _UnitNew; }
            set
            {
                _UnitNew = value;
            }
        }
        private double _SalePriceNew = 0;
        public double SalePriceNew
        {
            get { return _SalePriceNew; }
            set
            {
                _SalePriceNew = value;
            }
        }
        private Byte[] _CameraImage;
        public Byte[] CameraImage
        {
            get { return _CameraImage; }
            set
            {
                _CameraImage = value;
            }
        }
        private Byte[] _Signature;
        public Byte[] Signature
        {
            get { return _Signature; }
            set
            {
                _Signature = value;
            }
        }
        private int _Sticknote = 0;
        public int Sticknote
        {
            get { return _Sticknote; }
            set
            {
                _Sticknote = value;
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
