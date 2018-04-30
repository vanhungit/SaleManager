using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class ADJUSTMENT
    {
        #region private propertise
        private string _ID = "";
        public string ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
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
        private string _Ref_OrgNo = "";
        public string Ref_OrgNo
        {
            get { return _Ref_OrgNo; }
            set
            {
                _Ref_OrgNo = value;
            }
        }
        private int _RefType =0;
        public int RefType
        {
            get { return _RefType; }
            set
            {
                _RefType = value;
            }
        }
        private string _Employee_ID ="";
        public string Employee_ID
        {
            get { return _Employee_ID; }
            set
            {
                _Employee_ID = value;
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
        private double _Amount =0;
        public double Amount
        {
            get { return _Amount; }
            set
            {
                _Amount = value;
            }
        }
        private bool _Accept = false;
        public bool Accept
        {
            get { return _Accept; }
            set
            {
                _Accept = value;
            }
        }
        private bool _IsClose = false;
        public bool IsClose
        {
            get { return _IsClose; }
            set
            {
                _IsClose = value;
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
        private string _User_ID = "";
        public string User_ID
        {
            get { return _User_ID; }
            set
            {
                _User_ID = value;
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
