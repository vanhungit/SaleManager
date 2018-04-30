using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesManager.Entity;
using System.Data;

namespace SalesManager.Controller
{
    public class RESERVATION_DETAILController
    {
        private List<RESERVATION_DETAIL> MapRESERVATION_DETAIL(DataTable dt)
        {
            List<RESERVATION_DETAIL> rs = new List<RESERVATION_DETAIL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                RESERVATION_DETAIL obj = new RESERVATION_DETAIL();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid(dt.Rows[i]["ID"].ToString().Trim());
                if (dt.Columns.Contains("Reservation_ID"))
                    obj.Reservation_ID = dt.Rows[i]["Reservation_ID"].ToString();
                if (dt.Columns.Contains("Product_ID"))
                    obj.Product_ID = dt.Rows[i]["Product_ID"].ToString();
                if (dt.Columns.Contains("ProductName"))
                    obj.ProductName = dt.Rows[i]["ProductName"].ToString();
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("OutStock"))
                    obj.OutStock = dt.Rows[i]["OutStock"].ToString();
                if (dt.Columns.Contains("OutStockName"))
                    obj.OutStockName = dt.Rows[i]["OutStockName"].ToString();
                if (dt.Columns.Contains("LocationOut"))
                    obj.LocationOut = dt.Rows[i]["LocationOut"].ToString();
                if (dt.Columns.Contains("StatusOut"))
                    obj.StatusOut = int.Parse(dt.Rows[i]["StatusOut"].ToString());
                if (dt.Columns.Contains("InStock"))
                    obj.InStock = dt.Rows[i]["InStock"].ToString();
                if (dt.Columns.Contains("InStockName"))
                    obj.InStockName = dt.Rows[i]["InStockName"].ToString();
                if (dt.Columns.Contains("LocationIn"))
                    obj.LocationIn = dt.Rows[i]["LocationIn"].ToString();
                if (dt.Columns.Contains("StatusIn"))
                    obj.StatusIn = int.Parse(dt.Rows[i]["StatusIn"].ToString());
                if (dt.Columns.Contains("Unit"))
                    obj.Unit = dt.Rows[i]["Unit"].ToString();
                if (dt.Columns.Contains("UnitConvert"))
                    obj.UnitConvert = double.Parse(dt.Rows[i]["UnitConvert"].ToString());
                if (dt.Columns.Contains("UnitPrice"))
                    obj.UnitPrice = double.Parse(dt.Rows[i]["UnitPrice"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("QtyConvert"))
                    obj.QtyConvert = double.Parse(dt.Rows[i]["QtyConvert"].ToString());
                if (dt.Columns.Contains("Batch"))
                    obj.Batch = dt.Rows[i]["Batch"].ToString();
                if (dt.Columns.Contains("Serial"))
                    obj.Serial = dt.Rows[i]["Serial"].ToString();
                if (dt.Columns.Contains("StoreID"))
                    obj.StoreID = long.Parse(dt.Rows[i]["StoreID"].ToString());
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
    }
}
