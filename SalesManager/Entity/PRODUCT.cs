using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class PRODUCT
    {
        #region private properties
        private string _Product_ID ="";
        public string Product_ID
        {
            get { return _Product_ID; }
            set
            {
                _Product_ID = value;
            }
        }
        private string _Product_Name ="";
        public string Product_Name
        {
            get { return _Product_Name; }
            set
            {
                _Product_Name = value;
            }
        }
        private string _Product_NameEN ="";
        public string Product_NameEN
        {
            get { return _Product_NameEN; }
            set
            {
                _Product_NameEN = value;
            }
        }
        private int _Product_Type_ID = 0;
        public int Product_Type_ID
        {
            get { return _Product_Type_ID; }
            set
            {
                _Product_Type_ID = value;
            }
        }
        private int _Manufacturer_ID = 0;
        public int Manufacturer_ID
        {
            get { return _Manufacturer_ID; }
            set
            {
                _Manufacturer_ID = value;
            }
        }
        private string _Model_ID ="";
        public string Model_ID
        {
            get { return _Model_ID; }
            set
            {
                _Model_ID = value;
            }
        }
        private string _Product_Group_ID = "";
        public string Product_Group_ID
        {
            get { return _Product_Group_ID; }
            set
            {
                _Product_Group_ID = value;
            }
        }
        private string _Provider_ID ="";
        public string Provider_ID
        {
            get { return _Provider_ID; }
            set
            {
                _Provider_ID = value;
            }
        }
        private string _Origin ="";
        public string Origin
        {
            get { return _Origin; }
            set
            {
                _Origin = value;
            }
        }
        private string _Barcode ="";
        public string Barcode
        {
            get { return _Barcode; }
            set
            {
                _Barcode = value;
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
        private string _UnitConvert = "";
        public string UnitConvert
        {
            get { return _UnitConvert; }
            set
            {
                _UnitConvert = value;
            }
        }
        private double _UnitRate = 0;
        public double UnitRate
        {
            get { return _UnitRate; }
            set
            {
                _UnitRate = value;
            }
        }
        private double _Org_Price = 0;
        public double Org_Price
        {
            get { return _Org_Price; }
            set
            {
                _Org_Price = value;
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
        private double _Retail_Price =0;
        public double Retail_Price
        {
            get { return _Retail_Price; }
            set
            {
                _Retail_Price = value;
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
        private double _CurrentCost = 0;
        public double CurrentCost
        {
            get { return _CurrentCost; }
            set
            {
                _CurrentCost = value;
            }
        }
        private double _AverageCost =0;
        public double AverageCost
        {
            get { return _AverageCost; }
            set
            {
                _AverageCost = value;
            }
        }
        private int _Warranty =0;
        public int Warranty
        {
            get { return _Warranty; }
            set
            {
                _Warranty = value;
            }
        }
        private double _VAT_ID =0;
        public double VAT_ID
        {
            get { return _VAT_ID; }
            set
            {
                _VAT_ID = value;
            }
        }
        private double _ImportTax_ID =0;
        public double ImportTax_ID
        {
            get { return _ImportTax_ID; }
            set
            {
                _ImportTax_ID = value;
            }
        }
        private double _ExportTax_ID =0;
        public double ExportTax_ID
        {
            get { return _ExportTax_ID; }
            set
            {
                _ExportTax_ID = value;
            }
        }
        private double _LuxuryTax_ID =0;
        public double LuxuryTax_ID
        {
            get { return _LuxuryTax_ID; }
            set
            {
                _LuxuryTax_ID = value;
            }
        }
        private string _Customer_ID = "";
        public string Customer_ID
        {
            get { return _Customer_ID; }
            set
            {
                _Customer_ID = value;
            }
        }
        private string _Customer_Name = "";
        public string Customer_Name
        {
            get { return _Customer_Name; }
            set
            {
                _Customer_Name = value;
            }
        }
        private int _CostMethod = 0;
        public int CostMethod
        {
            get { return _CostMethod; }
            set
            {
                _CostMethod = value;
            }
        }
        private double _MinStock = 0;
        public double MinStock
        {
            get { return _MinStock; }
            set
            {
                _MinStock = value;
            }
        }
        private double _MaxStock = 0;
        public double MaxStock
        {
            get { return _MaxStock; }
            set
            {
                _MaxStock = value;
            }
        }
        private double _Discount =0;
        public double Discount
        {
            get { return _Discount; }
            set
            {
                _Discount = value;
            }
        }
        private double _Commission =0;
        public double Commission
        {
            get { return _Commission; }
            set
            {
                _Commission = value;
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
        private string _Color = "";
        public string Color
        {
            get { return _Color; }
            set
            {
                _Color = value;
            }
        }
        private bool _Expiry = false;
        public bool Expiry
        {
            get { return _Expiry; }
            set
            {
                _Expiry = value;
            }
        }
        private double _LimitOrders =0;
        public double LimitOrders
        {
            get { return _LimitOrders; }
            set
            {
                _LimitOrders = value;
            }
        }
        private double _ExpiryValue = 0;
        public double ExpiryValue
        {
            get { return _ExpiryValue; }
            set
            {
                _ExpiryValue = value;
            }
        }
        private bool _Batch = false;
        public bool Batch
        {
            get { return _Batch; }
            set
            {
                _Batch = value;
            }
        }
        private double _Depth = 0;
        public double Depth
        {
            get { return _Depth; }
            set
            {
                _Depth = value;
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
        private double _Width =0;
        public double Width
        {
            get { return _Width; }
            set
            {
                _Width = value;
            }
        }
        private double _Thickness = 0;
        public double Thickness
        {
            get { return _Thickness; }
            set
            {
                _Thickness = value;
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
        private Byte[] _Photo;
        public Byte[] Photo
        {
            get { return _Photo; }
            set
            {
                _Photo = value;
            }
        }
        private string _Currency_ID = "";
        public string Currency_ID
        {
            get { return _Currency_ID; }
            set
            {
                _Currency_ID = value;
            }
        }
        private double _ExchangeRate = 0;
        public double ExchangeRate
        {
            get { return _ExchangeRate; }
            set
            {
                _ExchangeRate = value;
            }
        }
        private string _Stock_ID ="";
        public string Stock_ID
        {
            get { return _Stock_ID; }
            set
            {
                _Stock_ID = value;
            }
        }
        private string _UserID ="";
        public string UserID
        {
            get { return _UserID; }
            set
            {
                _UserID = value;
            }
        }
        private bool _Serial = false;
        public bool Serial
        {
            get { return _Serial; }
            set
            {
                _Serial = value;
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
        
        
        
        #endregion 
    }
}
