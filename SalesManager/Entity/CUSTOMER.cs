using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace QuanLiBanHang.Entity
{
    public class CUSTOMER
    {
        private string _Customer_ID = "";
        public string Customer_ID
        {
            get { return _Customer_ID; }
            set
            {
                _Customer_ID = value;
            }
        }
        private long _OrderID = 0;
        public long OrderID
        {
            get { return _OrderID; }
            set
            {
                _OrderID = value;
            }
        }
        private string _CustomerName = "";
        public string CustomerName
        {
            get { return _CustomerName; }
            set
            {
                _CustomerName = value;
            }
        }
        private string _Customer_Type_ID = "";
        public string Customer_Type_ID
        {
            get { return _Customer_Type_ID; }
            set
            {
                _Customer_Type_ID = value;
            }
        }
        private string _Customer_Group_ID;
        public string Customer_Group_ID
        {
            get { return _Customer_Group_ID; }
            set
            {
                _Customer_Group_ID = value;
            }
        }
        private string _CustomerAddress = "";
        public string CustomerAddress
        {
            get { return _CustomerAddress; }
            set
            {
                _CustomerAddress = value;
            }
        }
        private string _Birthday ="";
        public string Birthday
        {
            get { return _Birthday; }
            set
            {
                _Birthday = value;
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
        private string _Tax ="";
        public string Tax
        {
            get { return _Tax; }
            set
            {
                _Tax = value;
            }
        }
        private string _Tel = "";
        public string Tel
        {
            get { return _Tel; }
            set { _Tel = value; }
        }
        private string _Fax ="";
        public string Fax
        {
            get { return _Fax; }
            set
            {
                _Fax = value;
            }
        }
        private string _Email = "";
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
            }
        }
        private string _Mobile = "";
        public string Mobile
        {
            get { return _Mobile; }
            set
            {
                _Mobile = value;
            }
        }
        private string _Website = "";
        public string Website
        {
            get { return _Website; }
            set
            {
                _Website = value;
            }
        }
        private string _Contact = "";
        public string Contact
        {
            get { return _Contact; }
            set
            {
                _Contact = value;
            }
        }
        private string _Position = "";
        public string Position
        {
            get { return _Position; }
            set
            {
                _Position = value;
            }
        }
        private string _NickYM = "";
        public string NickYM
        {
            get { return _NickYM; }
            set
            {
                _NickYM = value;
            }
        }
        private string _NickSky = "";
        public string NickSky
        {
            get { return _NickSky; }
            set
            {
                _NickSky = value;
            }
        }
        private string _Area ="";
        public string Area
        {
            get { return _Area; }
            set
            {
                _Area = value;
            }
        }
        private string _District = "";
        public string District
        {
            get { return _District; }
            set
            {
                _District = value;
            }
        }
        private string _Contry = "";
        public string Contry
        {
            get { return _Contry; }
            set
            {
                _Contry = value;
            }
        }
        private string _City = "";
        public string City
        {
            get { return _City; }
            set
            {
                _City = value;
            }
        }
        private string _BankAccount = "";
        public string BankAccount
        {
            get { return _BankAccount; }
            set
            {
                _BankAccount = value;
            }
        }
        private string _BankName = "";
        public string BankName
        {
            get { return _BankName; }
            set
            {
                _BankName = value;
            }
        }
        private double _CreditLimit = 0;
        public double CreditLimit
        {
            get { return _CreditLimit; }
            set { _CreditLimit = value; }
        }
        private double _Discount = 0;
        public double Discount
        {
            get { return _Discount; }
            set
            {
                _Discount = value;
            }
        }
        private bool _IsDebt =false;
        public bool IsDebt
        {
            get { return _IsDebt; }
            set
            {
                _IsDebt = value;
            }
        }
        private bool _IsDebtDetail = false;
        public bool IsDebtDetail
        {
            get { return _IsDebtDetail; }
            set
            {
                _IsDebtDetail = value;
            }
        }
        private bool _IsProvider = false;
        public bool IsProvider
        {
            get { return _IsProvider; }
            set
            {
                _IsProvider = value;
            }
        }
        private string _Description ="";
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
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
