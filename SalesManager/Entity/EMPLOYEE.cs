using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
namespace QuanLiBanHang.Entity
{
    public class EMPLOYEE
    {
        #region private propertise
        private string _Employee_ID = "";
        public string Employee_ID
        {
            get { return _Employee_ID; }
            set
            {
                _Employee_ID = value;
            }
        }
         
        private string _FirstName = "";
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
            }
        }
        
        private string _LastName = "";
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
            }
        }
        private string _Employee_Name ="";
        public string Employee_Name
        {
            get { return _Employee_Name; }
            set
            {
                _Employee_Name = value;
            }
        }
        private string _Alias = "";
        public string Alias
        {
            get { return _Alias; }
            set
            {
                _Alias = value;
            }
        }
        private bool _Sex = false;
        public bool Sex
        {
            get { return _Sex; }
            set
            {
                _Sex = value;
            }
        }
        private string _Address = "";
        public string Address
        {
            get { return _Address; }
            set
            {
                _Address = value;
            }
        }
        private string _CountryID = "";
        public string CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
        private string _H_Tel = "";
        public string H_Tel
        {
            get { return _H_Tel; }
            set
            {
                _H_Tel = value;
            }
        }
        private string _O_Tel = "";
        public string O_Tel
        {
            get { return _O_Tel; }
            set
            {
                _O_Tel = value;
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
        private string _Fax = "";
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
            set { _Email = value; }
        }
        private DateTime _Birthday = DateTime.Now;
        public DateTime Birthday
        {
            get { return _Birthday; }
            set
            {
                _Birthday = value;
            }
        }
        private int _Married = 0;
        public int Married
        {
            get { return _Married; }
            set
            {
                _Married = value;
            }
        }
        private string _Position_ID = "";
        public string Position_ID
        {
            get { return _Position_ID; }
            set
            {
                _Position_ID = value;
            }
        }
        private string _JobTitle_ID = "";
        public string JobTitle_ID
        {
            get { return _JobTitle_ID; }
            set
            {
                _JobTitle_ID = value;
            }
        }
        private string _Branch_ID = "";
        public string Branch_ID
        {
            get { return _Branch_ID; }
            set
            {
                _Branch_ID = value;
            }
        }
        private string _Department_ID = "";
        public string Department_ID
        {
            get { return _Department_ID; }
            set
            {
                _Department_ID = value;
            }
        }
        private string _Team_ID = "";
        public string Team_ID
        {
            get { return _Team_ID; }
            set
            {
                _Team_ID = value;
            }
        }
        private string _PersionalTax_ID = "";
        public string PersionalTax_ID
        {
            get { return _PersionalTax_ID; }
            set
            {
                _PersionalTax_ID = value;
            }
        }
        private string _City_ID = "";
        public string City_ID
        {
            get { return _City_ID; }
            set
            {
                _City_ID = value;
            }
        }
        private string _District_ID = "";
        public string District_ID
        {
            get { return _District_ID; }
            set
            {
                _District_ID = value;
            }
        }
        private string _Manager_ID = "";
        public string Manager_ID
        {
            get { return _Manager_ID; }
            set
            {
                _Manager_ID = value;
            }
        }
        private int _EmployeeType = 0;
        public int EmployeeType
        {
            get { return _EmployeeType; }
            set
            {
                _EmployeeType = value;
            }
        }
        private double _BasicSalary = 0;
        public double BasicSalary
        {
            get { return _BasicSalary; }
            set
            {
                _BasicSalary = value;
            }
        }
        private double _Advance = 0;
        public double Advance
        {
            get { return _Advance; }
            set
            {
                _Advance = value;
            }
        }
        private double _AdvanceOther = 0;
        public double AdvanceOther
        {
            get { return _AdvanceOther; }
            set
            {
                _AdvanceOther = value;
            }
        }
        private double _Commission = 0;
        public double Commission
        {
            get { return _Commission; }
            set
            {
                _Commission = value;
            }
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
        private double _ProfitRate = 0;
        public double ProfitRate
        {
            get { return _ProfitRate; }
            set
            {
                _ProfitRate = value;
            }
        }
        private bool _IsPublic = false;
        public bool IsPublic
        {
            get { return _IsPublic; }
            set
            {
                _IsPublic = value;
            }
        }
        private string _CreatedBy = "";
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set
            {
                _CreatedBy = value;
            }
        }
        private DateTime _CreateDate = DateTime.Now;
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set
            {
                _CreateDate = value;
            }
        }
        private string _ModifiedBy = "";
        public string ModifiedBy
        {
            get { return _ModifiedBy; }
            set
            {
                _ModifiedBy = value;
            }
        }
        private DateTime _ModifiedDate = DateTime.Now;
        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set
            {
                _ModifiedDate = value;
            }
        }
        private string _OwnerID = "";
        public string OwnerID
        {
            get { return _OwnerID; }
            set
            {
                _OwnerID = value;
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
        private int _Sorted = 0;
        public int Sorted
        {
            get { return _Sorted; }
            set
            {
                _Sorted = value;
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
