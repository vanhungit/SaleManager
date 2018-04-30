using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManager.Entity
{
    public class PRINTERMAPPING
    {
        private string _Station_ID = "";
        public string Station_ID
        {
            get { return _Station_ID; }
            set
            {
                _Station_ID = value;
            }
        }
        private string _Store_ID ="";
        public string Store_ID
        {
            get { return _Store_ID; }
            set
            {
                _Store_ID = value;
            }
        }
        private string _LocalPort = "";
        public string LocalPort
        {
            get { return _LocalPort; }
            set
            {
                _LocalPort = value;
            }
        }
        private string _NetworkPort = "";
        public string NetworkPort
        {
            get { return _NetworkPort; }
            set
            {
                _NetworkPort = value;
            }
        }
        private string _PrinterName = "";
        public string PrinterName
        {
            get { return _PrinterName; }
            set
            {
                _PrinterName = value;
            }
        }
        private string _Details = "";
        public string Details
        {
            get { return _Details; }
            set
            {
                _Details = value;
            }
        }
        private bool _Disabled = false;
        public bool Disabled
        {
            get { return _Disabled; }
            set
            {
                _Disabled = value;
            }
        }
        private bool _Two_Color_Printing = false;
        public bool Two_Color_Printing
        {
            get { return _Two_Color_Printing; }
            set
            {
                _Two_Color_Printing = value;
            }
        }
        private bool _CutReceipt = false;
        public bool CutReceipt
        {
            get { return _CutReceipt; }
            set
            {
                _CutReceipt = value;
            }
        }
        private int _LineFeedsBeforeCut = 0;
        public int LineFeedsBeforeCut
        {
            get { return _LineFeedsBeforeCut; }
            set
            {
                _LineFeedsBeforeCut = value;
            }
        }
 
    }
}
