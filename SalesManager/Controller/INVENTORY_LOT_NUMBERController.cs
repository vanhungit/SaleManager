using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SalesManager.Entity;

namespace SalesManager.Controller
{
    public class INVENTORY_LOT_NUMBERController
    {
        private List<INVENTORY_LOT_NUMBER> MapINVENTORY_LOT_NUMBER(DataTable dt)
        {
            List<INVENTORY_LOT_NUMBER> rs = new List<INVENTORY_LOT_NUMBER>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                INVENTORY_LOT_NUMBER obj = new INVENTORY_LOT_NUMBER();
                if (dt.Columns.Contains("ID"))
                    obj.ID = long.Parse(dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("RefID"))
                    obj.RefID = dt.Rows[i]["RefID"].ToString();
                if (dt.Columns.Contains("RefDate"))
                    obj.RefDate = DateTime.Parse(dt.Rows[i]["RefDate"].ToString());
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("Stock_ID"))
                    obj.Stock_ID = dt.Rows[i]["Stock_ID"].ToString();
                if (dt.Columns.Contains("Product_ID"))
                    obj.Product_ID = dt.Rows[i]["Product_ID"].ToString();
                if (dt.Columns.Contains("Customer_ID"))
                    obj.Customer_ID = dt.Rows[i]["Customer_ID"].ToString();
                if (dt.Columns.Contains("Currency_ID"))
                    obj.Currency_ID = dt.Rows[i]["Currency_ID"].ToString();
                if (dt.Columns.Contains("Limit"))
                    obj.Limit = DateTime.Parse(dt.Rows[i]["Limit"].ToString());
                if (dt.Columns.Contains("Quantity"))
                    obj.Quantity = double.Parse(dt.Rows[i]["Quantity"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("Batch"))
                    obj.Batch = dt.Rows[i]["Batch"].ToString();
                if (dt.Columns.Contains("Serial"))
                    obj.Serial = dt.Rows[i]["Serial"].ToString();
                if (dt.Columns.Contains("ChassyNo"))
                    obj.ChassyNo = dt.Rows[i]["ChassyNo"].ToString();
                if (dt.Columns.Contains("Color"))
                    obj.Color = dt.Rows[i]["Color"].ToString();
                if (dt.Columns.Contains("Location"))
                    obj.Location = dt.Rows[i]["Location"].ToString();
                if (dt.Columns.Contains("Width"))
                    obj.Width = double.Parse(dt.Rows[i]["Width"].ToString());
                if (dt.Columns.Contains("Height"))
                    obj.Height = double.Parse(dt.Rows[i]["Height"].ToString());
                if (dt.Columns.Contains("Orgin"))
                    obj.Orgin = dt.Rows[i]["Orgin"].ToString();
                if (dt.Columns.Contains("Size"))
                    obj.Size = dt.Rows[i]["Size"].ToString();
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                rs.Add(obj);
            }
            return rs;
        }
    }
}
