using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesManager.Entity;
using System.Data;
using MicrosoftHelper;

namespace SalesManager.Controller
{
    public class PURCHASE_RETURN_DETAILController
    {
        private List<PURCHASE_RETURN_DETAIL> MapPURCHASE_RETURN_DETAIL(DataTable dt)
        {
            List<PURCHASE_RETURN_DETAIL> rs = new List<PURCHASE_RETURN_DETAIL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                PURCHASE_RETURN_DETAIL obj = new PURCHASE_RETURN_DETAIL();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid(dt.Rows[i]["ID"].ToString().Trim());
                if (dt.Columns.Contains("Return_ID"))
                    obj.Return_ID = dt.Rows[i]["Return_ID"].ToString();
                if (dt.Columns.Contains("RefPurchase_ID"))
                    obj.RefPurchase_ID = dt.Rows[i]["RefPurchase_ID"].ToString();
                if (dt.Columns.Contains("RefInward_ID"))
                    obj.RefInward_ID = dt.Rows[i]["RefInward_ID"].ToString();
                if (dt.Columns.Contains("Product_ID"))
                    obj.Product_ID = dt.Rows[i]["Product_ID"].ToString();
                if (dt.Columns.Contains("ProductName"))
                    obj.ProductName = dt.Rows[i]["ProductName"].ToString();
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("Stock_ID"))
                    obj.Stock_ID = dt.Rows[i]["Stock_ID"].ToString();
                if (dt.Columns.Contains("Unit"))
                    obj.Unit = dt.Rows[i]["Unit"].ToString();
                if (dt.Columns.Contains("UnitConvert"))
                    obj.UnitConvert = double.Parse(dt.Rows[i]["UnitConvert"].ToString());
                if (dt.Columns.Contains("Vat"))
                    obj.Vat = int.Parse(dt.Rows[i]["Vat"].ToString());
                if (dt.Columns.Contains("VatAmount"))
                    obj.VatAmount = double.Parse(dt.Rows[i]["VatAmount"].ToString());
                if (dt.Columns.Contains("CurrentQty"))
                    obj.CurrentQty = double.Parse(dt.Rows[i]["CurrentQty"].ToString());
                if (dt.Columns.Contains("Quantity"))
                    obj.Quantity = double.Parse(dt.Rows[i]["Quantity"].ToString());
                if (dt.Columns.Contains("UnitPrice"))
                    obj.UnitPrice = double.Parse(dt.Rows[i]["UnitPrice"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("QtyConvert"))
                    obj.QtyConvert = double.Parse(dt.Rows[i]["QtyConvert"].ToString());
                if (dt.Columns.Contains("DiscountRate"))
                    obj.DiscountRate = double.Parse(dt.Rows[i]["DiscountRate"].ToString());
                if (dt.Columns.Contains("Discount"))
                    obj.Discount = double.Parse(dt.Rows[i]["Discount"].ToString());
                if (dt.Columns.Contains("Charge"))
                    obj.Charge = double.Parse(dt.Rows[i]["Charge"].ToString());
                if (dt.Columns.Contains("Limit"))
                    obj.Limit = DateTime.Parse(dt.Rows[i]["Limit"].ToString());
                if (dt.Columns.Contains("Width"))
                    obj.Width = double.Parse(dt.Rows[i]["Width"].ToString());
                if (dt.Columns.Contains("Height"))
                    obj.Height = double.Parse(dt.Rows[i]["Height"].ToString());
                if (dt.Columns.Contains("Orgin"))
                    obj.Orgin = dt.Rows[i]["Orgin"].ToString();
                if (dt.Columns.Contains("Size"))
                    obj.Size = dt.Rows[i]["Size"].ToString();
                if (dt.Columns.Contains("Color"))
                    obj.Color = dt.Rows[i]["Color"].ToString();
                if (dt.Columns.Contains("Batch"))
                    obj.Batch = dt.Rows[i]["Batch"].ToString();
                if (dt.Columns.Contains("Serial"))
                    obj.Serial = dt.Rows[i]["Serial"].ToString();
                if (dt.Columns.Contains("ChassyNo"))
                    obj.ChassyNo = dt.Rows[i]["ChassyNo"].ToString();
                if (dt.Columns.Contains("IME"))
                    obj.IME = dt.Rows[i]["IME"].ToString();
                //if (dt.Columns.Contains("Location"))
                //    obj.Location = dt.Rows[i]["Location"].ToString();
                if (dt.Columns.Contains("StoreID"))
                    obj.StoreID = long.Parse(dt.Rows[i]["StoreID"].ToString());
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                if (dt.Columns.Contains("LastEditDate"))
                    obj.LastEditDate = DateTime.Parse(dt.Rows[i]["LastEditDate"].ToString());
                if (dt.Columns.Contains("CreationDate"))
                    obj.CreationDate = DateTime.Parse(dt.Rows[i]["CreationDate"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public int PURCHASE_RETURN_DETAIL_Insert(PURCHASE_RETURN_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PURCHASE_RETURN_DETAIL_Insert",
                    obj.ID
                   , obj.Return_ID
                   , obj.RefPurchase_ID
                   , obj.RefInward_ID
                   , obj.Product_ID
                   , obj.ProductName
                   , obj.RefType
                   , obj.Stock_ID
                   , obj.Unit
                   , obj.UnitConvert
                   , obj.Vat
                   , obj.VatAmount
                   , obj.CurrentQty
                   , obj.Quantity
                   , obj.UnitPrice
                   , obj.Amount
                   , obj.QtyConvert
                   , obj.DiscountRate
                   , obj.Discount
                   , obj.Charge
                   , obj.Limit
                   , obj.Width
                   , obj.Height
                   , obj.Orgin
                   , obj.Size
                   , obj.Color
                   , obj.Batch
                   , obj.Serial
                   , obj.ChassyNo
                   , obj.IME
                   , obj.Location
                   , obj.StoreID
                   , obj.Description
                   , obj.Sorted
                   , obj.Active
                   , obj.LastEditDate
                   , obj.CreationDate
                );
            }
            catch (Exception ex)
            {
                throw ex;
                return -1;
            }
        }
    }
}
