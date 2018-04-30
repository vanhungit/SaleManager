using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesManager.Entity;
using System.Data;
using MicrosoftHelper;

namespace SalesManager.Controller
{
    public class INBOUND_DELIVERY_DETAILController
    {
        private List<INBOUND_DELIVERY_DETAIL> MapINBOUND_DELIVERY_DETAIL(DataTable dt)
        {
            List<INBOUND_DELIVERY_DETAIL> rs = new List<INBOUND_DELIVERY_DETAIL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                INBOUND_DELIVERY_DETAIL obj = new INBOUND_DELIVERY_DETAIL();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid(dt.Rows[i]["ID"].ToString().Trim());
                if (dt.Columns.Contains("Inbound_ID"))
                    obj.Inbound_ID = dt.Rows[i]["Inbound_ID"].ToString();
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
                if (dt.Columns.Contains("Location"))
                    obj.Location = dt.Rows[i]["Location"].ToString();
                if (dt.Columns.Contains("SO_ID"))
                    obj.SO_ID = dt.Rows[i]["SO_ID"].ToString();
                if (dt.Columns.Contains("SO_Line"))
                    obj.SO_Line = new Guid(dt.Rows[i]["SO_Line"].ToString());
                if (dt.Columns.Contains("PO_ID"))
                    obj.PO_ID = dt.Rows[i]["PO_ID"].ToString();
                if (dt.Columns.Contains("PO_Line"))
                    obj.PO_Line = new Guid(dt.Rows[i]["PO_Line"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("StoreID"))
                    obj.StoreID = long.Parse(dt.Rows[i]["StoreID"].ToString());
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("LastEditDate"))
                    obj.LastEditDate = DateTime.Parse(dt.Rows[i]["LastEditDate"].ToString());
                if (dt.Columns.Contains("CreationDate"))
                    obj.CreationDate = DateTime.Parse(dt.Rows[i]["CreationDate"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public int INBOUND_DELIVERY_DETAIL_Insert(INBOUND_DELIVERY_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "INBOUND_DELIVERY_DETAIL_Insert",
                    obj.ID
                   , obj.Inbound_ID
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
                   , obj.PO_ID
                   , obj.PO_Line
                   , obj.SO_ID
                   , obj.SO_Line
                   , obj.StoreID
                   , obj.Description
                   , obj.Sorted
                   , obj.LastEditDate
                   , obj.CreationDate
                   , obj.Active
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public DataTable NKTP_TRUNGGIAN_DETAIL_Get()
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "NKTP_TRUNGGIAN_DETAIL_Get");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INBOUND_DELIVERY_DETAIL_Getlist()
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INBOUND_DELIVERY_DETAIL_GetAll");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
