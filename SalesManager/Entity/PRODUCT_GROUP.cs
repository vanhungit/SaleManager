using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class PRODUCT_GROUP
    {
        #region private properties
        private string _ProductGroup_ID ="";
        public string ProductGroup_ID
        {
            get { return _ProductGroup_ID; }
            set
            {
                _ProductGroup_ID = value;
            }
        }
        private string _ProductGroup_Name = "";
        public string ProductGroup_Name
        {
            get { return _ProductGroup_Name; }
            set
            {
                _ProductGroup_Name = value;
            }
        }
        private string _ID_NGANH = "";
        public string ID_NGANH
        {
            get { return _ID_NGANH; }
            set
            {
                _ID_NGANH = value;
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
        private bool _IsMain = false;
        public bool IsMain
        {
            get { return _IsMain; }
            set
            {
                _IsMain = value;
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
