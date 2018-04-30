using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class INVENTORY
    {
        #region Private Properties
        private long _ID = 0;
        public long ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        private string _RefID ="";
        public string RefID
        {
            get { return _RefID; }
            set
            {
                _RefID = value;
            }
        }
        private DateTime _RefDate = DateTime.Now;
        public DateTime RefDate
        {
            get { return _RefDate; }
            set
            {
                _RefDate = value;
            }
        }
        private int _RefType = 0;
        public int RefType
        {
            get { return _RefType; }
            set
            {
                _RefType = value;
            }
        }
        private string _Stock_ID = "";
        public string Stock_ID
        {
            get { return _Stock_ID; }
            set
            {
                _Stock_ID = value;
            }
        }
        private string _Product_ID = "";
        public string Product_ID
        {
            get { return _Product_ID; }
            set
            {
                _Product_ID = value;
            }
        }
        private string _Customer_ID ="";
        public string Customer_ID
        {
            get { return _Customer_ID; }
            set
            {
                _Customer_ID = value;
            }
        }
        private string _Currency_ID ="";
        public string Currency_ID
        {
            get { return _Currency_ID; }
            set
            {
                _Currency_ID = value;
            }
        }
        private DateTime _Limit = DateTime.Now;
        public DateTime Limit
        {
            get { return _Limit; }
            set
            {
                _Limit = value;
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
        private double _Amount = 0;
        public double Amount
        {
            get { return _Amount; }
            set
            {
                _Amount = value;
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
        private string _Serial = "";
        public string Serial
        {
            get { return _Serial; }
            set
            {
                _Serial = value;
            }
        }
        private string _ChassyNo ="";
        public string ChassyNo
        {
            get { return _ChassyNo; }
            set
            {
                _ChassyNo = value;
            }
        }
        private string _Color = "";
        public string Color
        {
            get { return _Color; }
            set
            {
                _Color = value;
            }
        }
        private string _Location ="";
        public string Location
        {
            get { return _Location; }
            set
            {
                _Location = value;
            }
        }
        private double _Width =0;
        public double Width
        {
            get { return _Width; }
            set
            {
                _Width = value;
            }
        }
        private double _Height =0;
        public double Height
        {
            get { return _Height; }
            set
            {
                _Height = value;
            }
        }
        private string _Orgin = "";
        public string Orgin
        {
            get { return _Orgin; }
            set
            {
                _Orgin = value;
            }
        }
        private string _Size = "";
        public string Size
        {
            get { return _Size; }
            set
            {
                _Size = value;
            }
        }
        private string _Descritopn = "";
        public string Descritopn
        {
            get { return _Descritopn; }
            set
            {
                _Descritopn = value;
            }
        }
        
        #endregion
    }
}
