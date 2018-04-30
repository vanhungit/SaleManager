using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class CUSTOMER_TYPE
    {
        #region Private Properties
        private string _Customer_Type_ID = "";
        public string Customer_Type_ID
        {
            get { return _Customer_Type_ID; }
            set
            {
                _Customer_Type_ID = value;
            }
        }
        private string _Customer_Type_Name ="";
        public string Customer_Type_Name
        {
            get { return _Customer_Type_Name; }
            set
            {
                _Customer_Type_Name = value;
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
        
        #endregion
    }
}
