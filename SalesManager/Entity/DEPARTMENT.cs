using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class DEPARTMENT
    {
        #region private properties
        private string _Department_ID = "";
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public string Department_ID
        {
            get { return _Department_ID; }
            set
            {
                _Department_ID = value;
            }
        }
        private string _Department_Name ="";
        public string Department_Name
        {
            get { return _Department_Name; }
            set
            {
                _Department_Name = value;
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
