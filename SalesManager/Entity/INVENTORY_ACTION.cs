using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class INVENTORY_ACTION
    {
        private int _Action_ID =0;
        public int Action_ID
        {
            get { return _Action_ID; }
            set
            {
                _Action_ID = value;
            }
        }
        private string _Action_Name ="";
        public string Action_Name
        {
            get { return _Action_Name; }
            set
            {
                _Action_Name = value;
            }
        }
        
        
    }
}
