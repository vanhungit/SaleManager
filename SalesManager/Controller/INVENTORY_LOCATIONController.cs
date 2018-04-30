using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesManager.Entity;
using System.Data;

namespace SalesManager.Controller
{
    public class INVENTORY_LOCATIONController
    {
        private List<INVENTORY_LOCATION> MapINVENTORY(DataTable dt)
        {
            List<INVENTORY_LOCATION> rs = new List<INVENTORY_LOCATION>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                INVENTORY_LOCATION obj = new INVENTORY_LOCATION();
                if (dt.Columns.Contains("Location_ID"))
                    obj.Location_ID = (dt.Rows[i]["Location_ID"].ToString());
                if (dt.Columns.Contains("Organization_ID"))
                    obj.Organization_ID = dt.Rows[i]["Organization_ID"].ToString();
                if (dt.Columns.Contains("Stock_ID"))
                    obj.Stock_ID = (dt.Rows[i]["Stock_ID"].ToString());
                if (dt.Columns.Contains("StoreLocation"))
                    obj.StoreLocation = (dt.Rows[i]["StoreLocation"].ToString());
                if (dt.Columns.Contains("StorageBin"))
                    obj.StorageBin = dt.Rows[i]["StorageBin"].ToString();
                if (dt.Columns.Contains("NumberRange"))
                    obj.NumberRange = int.Parse(dt.Rows[i]["NumberRange"].ToString());
                if (dt.Columns.Contains("Barcode"))
                    obj.Barcode = dt.Rows[i]["Barcode"].ToString();
                if (dt.Columns.Contains("MaxWeight"))
                    obj.MaxWeight = double.Parse(dt.Rows[i]["MaxWeight"].ToString());
                if (dt.Columns.Contains("Limit"))
                    obj.MaxCubic = double.Parse(dt.Rows[i]["MaxWeight"].ToString());
                if (dt.Columns.Contains("X_Coordinate"))
                    obj.X_Coordinate = double.Parse(dt.Rows[i]["X_Coordinate"].ToString());
                if (dt.Columns.Contains("Y_Coordinate"))
                    obj.Y_Coordinate = double.Parse(dt.Rows[i]["Y_Coordinate"].ToString());
                if (dt.Columns.Contains("Z_Coordinate"))
                    obj.Z_Coordinate = double.Parse(dt.Rows[i]["Z_Coordinate"].ToString());
                if (dt.Columns.Contains("Pick_UOM"))
                    obj.Pick_UOM = dt.Rows[i]["Pick_UOM"].ToString();
                if (dt.Columns.Contains("Dimension_UOM"))
                    obj.Dimension_UOM = dt.Rows[i]["Dimension_UOM"].ToString();
                if (dt.Columns.Contains("Length"))
                    obj.Length = double.Parse(dt.Rows[i]["Length"].ToString());
                if (dt.Columns.Contains("Y_Coordinate"))
                    obj.Width = double.Parse(dt.Rows[i]["Width"].ToString());
                if (dt.Columns.Contains("Height"))
                    obj.Height = double.Parse(dt.Rows[i]["Height"].ToString());
                if (dt.Columns.Contains("LocatorStatus"))
                    obj.LocatorStatus = int.Parse(dt.Rows[i]["LocatorStatus"].ToString());
                if (dt.Columns.Contains("EmptyFlag"))
                    obj.EmptyFlag = bool.Parse(dt.Rows[i]["EmptyFlag"].ToString());
                if (dt.Columns.Contains("MixedItemFlag"))
                    obj.MixedItemFlag = bool.Parse(dt.Rows[i]["MixedItemFlag"].ToString());
                if (dt.Columns.Contains("CreateBy"))
                    obj.CreateBy = dt.Rows[i]["CreateBy"].ToString();
                if (dt.Columns.Contains("Createdate"))
                    obj.Createdate = DateTime.Parse(dt.Rows[i]["Createdate"].ToString());
                if (dt.Columns.Contains("ModifiedBy"))
                    obj.ModifiedBy = dt.Rows[i]["ModifiedBy"].ToString();
                if (dt.Columns.Contains("ModifiedDate"))
                    obj.ModifiedDate = DateTime.Parse(dt.Rows[i]["ModifiedDate"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
    }
}
