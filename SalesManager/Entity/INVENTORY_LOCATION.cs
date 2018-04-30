using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManager.Entity
{
    public class INVENTORY_LOCATION
    {
        private string _Location_ID = "";
        public string Location_ID
        {
            get { return _Location_ID; }
            set
            {
                _Location_ID = value;
            }
        }
        private string _Organization_ID = "";
        public string Organization_ID
        {
            get { return _Organization_ID; }
            set
            {
                _Organization_ID = value;
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
        private string _StoreLocation = "";
        public string StoreLocation
        {
            get { return _StoreLocation; }
            set
            {
                _StoreLocation = value;
            }
        }
        private int _NumberRange = 0;
        public int NumberRange
        {
            get { return _NumberRange; }
            set
            {
                _NumberRange = value;
            }
        }
        private string _StorageBin = "";
        public string StorageBin
        {
            get { return _StorageBin; }
            set
            {
                _StorageBin = value;
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
        private double _MaxWeight = 0;
        public double MaxWeight
        {
            get { return _MaxWeight; }
            set
            {
                _MaxWeight = value;
            }
        }
        private double _MaxCubic = 0;
        public double MaxCubic
        {
            get { return _MaxCubic; }
            set
            {
                _MaxCubic = value;
            }
        }
        private double _X_Coordinate = 0;
        public double X_Coordinate
        {
            get { return _X_Coordinate; }
            set
            {
                _X_Coordinate = value;
            }
        }
        private double _Y_Coordinate = 0;
        public double Y_Coordinate
        {
            get { return _Y_Coordinate; }
            set
            {
                _Y_Coordinate = value;
            }
        }
        private double _Z_Coordinate = 0;
        public double Z_Coordinate
        {
            get { return _Z_Coordinate; }
            set
            {
                _Z_Coordinate = value;
            }
        }
        private string _Pick_UOM = "";
        public string Pick_UOM
        {
            get { return _Pick_UOM; }
            set
            {
                _Pick_UOM = value;
            }
        }
        private string _Dimension_UOM = "";
        public string Dimension_UOM
        {
            get { return _Dimension_UOM; }
            set
            {
                _Dimension_UOM = value;
            }
        }
        private double _Length = 0;
        public double Length
        {
            get { return _Length; }
            set
            {
                _Length = value;
            }
        }
        private double _Width = 0;
        public double Width
        {
            get { return _Width; }
            set
            {
                _Width = value;
            }
        }
        private double _Height = 0;
        public double Height
        {
            get { return _Height; }
            set
            {
                _Height = value;
            }
        }
        private int _LocatorStatus = 0;
        public int LocatorStatus
        {
            get { return _LocatorStatus; }
            set
            {
                _LocatorStatus = value;
            }
        }
        private bool _EmptyFlag = false;
        public bool EmptyFlag
        {
            get { return _EmptyFlag; }
            set
            {
                _EmptyFlag = value;
            }
        }
        private bool _MixedItemFlag = false;
        public bool MixedItemFlag
        {
            get { return _MixedItemFlag; }
            set
            {
                _MixedItemFlag = value;
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
        private string _CreateBy = "";
        public string CreateBy
        {
            get { return _CreateBy; }
            set
            {
                _CreateBy = value;
            }
        }
        private DateTime _Createdate = DateTime.Now;
        public DateTime Createdate
        {
            get { return _Createdate; }
            set
            {
                _Createdate = value;
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
