using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace QuanLiBanHang.Entity
{
    public class CUSTOMER_GROUP
    {
        #region private properties
        private string _Customer_Group_ID = "";
        public string Customer_Group_ID
        {
            get { return _Customer_Group_ID; }
            set
            {
                _Customer_Group_ID = value;
            }
        }
        private string _Customer_Group_Name = "";
        public string Customer_Group_Name
        {
            get { return _Customer_Group_Name; }
            set
            {
                _Customer_Group_Name = value;
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
