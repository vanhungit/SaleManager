using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using QuanLiBanHang.Entity;
using System.Data;
using System.Drawing;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class PRODUCTController
    {
        private List<PRODUCT> MapPRODUCT(DataTable dt)
        {
            List<PRODUCT> rs = new List<PRODUCT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PRODUCT obj = new PRODUCT();
                if (dt.Columns.Contains("Product_ID"))
                    obj.Product_ID = dt.Rows[i]["Product_ID"].ToString();
                if (dt.Columns.Contains("Product_Name"))
                    obj.Product_Name = dt.Rows[i]["Product_Name"].ToString();
                if (dt.Columns.Contains("Product_NameEN"))
                    obj.Product_NameEN = dt.Rows[i]["Product_NameEN"].ToString();
                if (dt.Columns.Contains("Product_Type_ID"))
                    obj.Product_Type_ID = int.Parse(dt.Rows[i]["Product_Type_ID"].ToString());
                if (dt.Columns.Contains("Manufacturer_ID"))
                    obj.Manufacturer_ID = int.Parse(dt.Rows[i]["Manufacturer_ID"].ToString());
                if (dt.Columns.Contains("Model_ID"))
                    obj.Model_ID = dt.Rows[i]["Model_ID"].ToString();
                if (dt.Columns.Contains("Product_Group_ID"))
                    obj.Product_Group_ID = dt.Rows[i]["Product_Group_ID"].ToString();
                if (dt.Columns.Contains("Provider_ID"))
                    obj.Provider_ID = dt.Rows[i]["Provider_ID"].ToString();
                if (dt.Columns.Contains("Origin"))
                    obj.Origin = dt.Rows[i]["Origin"].ToString();
                if (dt.Columns.Contains("Barcode"))
                    obj.Barcode = dt.Rows[i]["Barcode"].ToString();
                if (dt.Columns.Contains("Unit"))
                    obj.Unit = dt.Rows[i]["Unit"].ToString();
                if (dt.Columns.Contains("UnitConvert"))
                    obj.UnitConvert = dt.Rows[i]["UnitConvert"].ToString();
                if (dt.Columns.Contains("UnitRate"))
                    obj.UnitRate = double.Parse(dt.Rows[i]["UnitRate"].ToString());
                if (dt.Columns.Contains("Org_Price"))
                    obj.Org_Price = double.Parse(dt.Rows[i]["Org_Price"].ToString());
                if (dt.Columns.Contains("Sale_Price"))
                    obj.Sale_Price = double.Parse(dt.Rows[i]["Sale_Price"].ToString());
                if (dt.Columns.Contains("Retail_Price"))
                    obj.Retail_Price = double.Parse(dt.Rows[i]["Retail_Price"].ToString());
                if (dt.Columns.Contains("Quantity"))
                    obj.Quantity = double.Parse(dt.Rows[i]["Quantity"].ToString());
                if (dt.Columns.Contains("CurrentCost"))
                    obj.CurrentCost = double.Parse(dt.Rows[i]["CurrentCost"].ToString());
                if (dt.Columns.Contains("AverageCost"))
                    obj.AverageCost = double.Parse(dt.Rows[i]["AverageCost"].ToString());
                if (dt.Columns.Contains("Warranty"))
                    obj.Warranty = int.Parse(dt.Rows[i]["Warranty"].ToString());
                if (dt.Columns.Contains("VAT_ID"))
                    obj.VAT_ID = double.Parse(dt.Rows[i]["VAT_ID"].ToString());
                if (dt.Columns.Contains("ImportTax_ID"))
                    obj.ImportTax_ID = double.Parse(dt.Rows[i]["ImportTax_ID"].ToString());
                if (dt.Columns.Contains("ExportTax_ID"))
                    obj.ExportTax_ID = double.Parse(dt.Rows[i]["ExportTax_ID"].ToString());
                if (dt.Columns.Contains("LuxuryTax_ID"))
                    obj.LuxuryTax_ID = double.Parse(dt.Rows[i]["LuxuryTax_ID"].ToString());
                if (dt.Columns.Contains("Customer_ID"))
                    obj.Customer_ID = dt.Rows[i]["Customer_ID"].ToString();
                if (dt.Columns.Contains("Customer_Name"))
                    obj.Customer_Name = dt.Rows[i]["Customer_Name"].ToString();
                if (dt.Columns.Contains("CostMethod"))
                    obj.CostMethod = int.Parse(dt.Rows[i]["CostMethod"].ToString());
                if (dt.Columns.Contains("MinStock"))
                    obj.MinStock = double.Parse(dt.Rows[i]["MinStock"].ToString());
                if (dt.Columns.Contains("MaxStock"))
                    obj.MaxStock = double.Parse(dt.Rows[i]["MaxStock"].ToString());
                if (dt.Columns.Contains("Discount"))
                    obj.Discount = double.Parse(dt.Rows[i]["Discount"].ToString());
                if (dt.Columns.Contains("Commission"))
                    obj.Commission = double.Parse(dt.Rows[i]["Commission"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Color"))
                    obj.Color = dt.Rows[i]["Color"].ToString();
                if (dt.Columns.Contains("Expiry"))
                    obj.Expiry = bool.Parse(dt.Rows[i]["Expiry"].ToString());
                if (dt.Columns.Contains("LimitOrders"))
                    obj.LimitOrders = double.Parse(dt.Rows[i]["LimitOrders"].ToString());
                if (dt.Columns.Contains("ExpiryValue"))
                    obj.ExpiryValue = double.Parse(dt.Rows[i]["ExpiryValue"].ToString());
                if (dt.Columns.Contains("Batch"))
                    obj.Batch = bool.Parse(dt.Rows[i]["Batch"].ToString());
                if (dt.Columns.Contains("Depth"))
                    obj.Depth = double.Parse(dt.Rows[i]["Depth"].ToString());
                if (dt.Columns.Contains("Height"))
                    obj.Height = double.Parse(dt.Rows[i]["Height"].ToString());
                if (dt.Columns.Contains("Width"))
                    obj.Width = double.Parse(dt.Rows[i]["Width"].ToString());
                if (dt.Columns.Contains("Thickness"))
                    obj.Thickness = double.Parse(dt.Rows[i]["Thickness"].ToString());
                if (dt.Columns.Contains("Size"))
                    obj.Size = dt.Rows[i]["Size"].ToString();
                //if (dt.Columns.Contains("Photo"))
                //    obj.Photo = (byte[])(dt.Rows[i]["Photo"]);
                if (dt.Columns.Contains("Currency_ID"))
                    obj.Currency_ID = dt.Rows[i]["Currency_ID"].ToString();
                if (dt.Columns.Contains("ExchangeRate"))
                    obj.ExchangeRate = double.Parse(dt.Rows[i]["ExchangeRate"].ToString());
                if (dt.Columns.Contains("Stock_ID"))
                    obj.Stock_ID = dt.Rows[i]["Stock_ID"].ToString();
                if (dt.Columns.Contains("UserID"))
                    obj.UserID = dt.Rows[i]["UserID"].ToString();
                //if (dt.Columns.Contains("Serial"))
                //    obj.Serial = bool.Parse(dt.Rows[i]["Serial"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public int PRODUCT_Insert(PRODUCT obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_Insert",
                    obj.Product_ID,
                    obj.Product_Name,
                    obj.Product_Type_ID,
                    obj.Manufacturer_ID,
                    obj.Product_Group_ID,
                    obj.Provider_ID,
                    obj.Origin,
                    obj.Barcode,
                    obj.Unit,
                    obj.UnitConvert,
                    obj.UnitRate,
                    obj.Org_Price,
                    obj.Sale_Price,
                    obj.Retail_Price,
                    obj.Quantity,
                    obj.CurrentCost,
                    obj.AverageCost,
                    obj.Warranty,
                    obj.VAT_ID,
                    obj.ImportTax_ID,
                    obj.ExportTax_ID,
                    obj.LuxuryTax_ID,
                    obj.Customer_ID,
                    obj.Customer_Name,
                    obj.CostMethod,
                    obj.MinStock,
                    obj.MaxStock,
                    obj.Discount,
                    obj.Commission,
                    obj.Description,
                    obj.Color,
                    obj.Expiry,
                    obj.LimitOrders,
                    obj.ExpiryValue,
                    obj.Batch,
                    obj.Depth,
                    obj.Height,
                    obj.Width,
                    obj.Thickness,
                    obj.Size,
                    obj.UserID,
                    obj.Active
                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PRODUCT_Insert_Photo(PRODUCT obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_Insert_Photo",
                    obj.Product_ID,
                    obj.Product_Name,
                    obj.Product_Type_ID,
                    obj.Manufacturer_ID,
                    obj.Product_Group_ID,
                    obj.Provider_ID,
                    obj.Origin,
                    obj.Barcode,
                    obj.Unit,
                    obj.UnitConvert,
                    obj.UnitRate,
                    obj.Org_Price,
                    obj.Sale_Price,
                    obj.Retail_Price,
                    obj.Quantity,
                    obj.CurrentCost,
                    obj.AverageCost,
                    obj.Warranty,
                    obj.VAT_ID,
                    obj.ImportTax_ID,
                    obj.ExportTax_ID,
                    obj.LuxuryTax_ID,
                    obj.Customer_ID,
                    obj.Customer_Name,
                    obj.CostMethod,
                    obj.MinStock,
                    obj.MaxStock,
                    obj.Discount,
                    obj.Commission,
                    obj.Description,
                    obj.Color,
                    obj.Expiry,
                    obj.LimitOrders,
                    obj.ExpiryValue,
                    obj.Batch,
                    obj.Depth,
                    obj.Height,
                    obj.Width,
                    obj.Thickness,
                    obj.Size,
                    obj.Photo,
                    obj.UserID,
                    obj.Active
                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PRODUCT_Delete(string Product_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_Delete", Product_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PRODUCT PRODUCT_Get(string Product_ID)
        {
            DataTable dt = new DataTable();
            //try
            //{
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_Get", Product_ID);
                return MapPRODUCT(dt)[0];
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        public PRODUCT PRODUCT_Getbybarcode(string Barcode)
        {
            DataTable dt = new DataTable();
            PRODUCT objproduct = new PRODUCT();
            try
            {
            DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_Getbybarcode", Barcode);
            return MapPRODUCT(dt)[0];//Lưu ý bị lỗi khi barcode không tồn tại
            }
           catch (Exception ex)
           {
                //throw ex;
               return objproduct;
           }
        }
        public List<PRODUCT> PRODUCT_Get_BTP()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_Get_BTP");
                return MapPRODUCT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PRODUCT> PRODUCT_Get_Quantity()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_Get_Quantity");
                return MapPRODUCT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PRODUCT> PRODUCT_Get_TP()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_Get_TP");
                return MapPRODUCT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PRODUCT> PRODUCT_GetByName(string Product_Name)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GetByName", Product_Name);
                return MapPRODUCT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PRODUCT> PRODUCT_GetByStock(string Product_ID, string Stock_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GetByStock", Product_ID, Stock_ID);
                return MapPRODUCT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PRODUCT> PRODUCT_GetByStockAll(string Product_ID, string Stock_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GetByStockAll", Product_ID, Stock_ID);
                return MapPRODUCT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PRODUCT PRODUCT_GetByStore(string Product_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GetByStore", Product_ID);
                return MapPRODUCT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PRODUCT> PRODUCT_GetFull()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GetFull");
                return MapPRODUCT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PRODUCT_GetList()
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Product_MaxQuantitySale(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Product_MaxQuantitySale",From,To);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Product_MaxAmountSale(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Product_MaxAmountSale", From, To);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Product_ChartMaxAmountSale(DateTime From, DateTime To, string ProductID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Product_ChartMaxAmountSale", From, To, ProductID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Product_ChartMaxQuantitySale(DateTime From, DateTime To, string ProductID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Product_ChartMaxQuantitySale", From, To, ProductID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Product_MaxQuantityImport(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Product_MaxQuantityImport", From, To);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Product_ChartMaxQuantityImport(DateTime From, DateTime To, string ProductID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Product_ChartMaxQuantityImport", From, To, ProductID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Product_MaxAmountImport(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Product_MaxAmountImport", From, To);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Product_ChartMaxAmountImport(DateTime From, DateTime To, string ProductID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Product_ChartMaxAmountImport", From, To, ProductID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable sp_PRODUCT_GetByStore_ByStockID(string Stock_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "sp_PRODUCT_GetByStore_ByStockID", Stock_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Mobi_PRODUCT_GetByStore_ByStockID(string Stock_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Mobi_PRODUCT_GetByStore_ByStockID", Stock_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PRODUCT_GetFull_Stock()
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GetFull_Stock");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PRODUCT> PRODUCT_GetList_Build()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GetList_Build");
                return MapPRODUCT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PRODUCT_GetLookup_ForInvoice()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GetLookup_ForInvoice");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PrintBarcode()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PrintBarcode");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PRODUCT> PRODUCT_GetLookupByStock()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GetLookupByStock");
                return MapPRODUCT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PRODUCT_GetLookupByStock_SALE()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GetLookupByStock_SALE");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PRODUCT_GetLookupByStock_SALE_Stock(string Stock_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GetLookupByStock_SALE_Stock", Stock_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PRODUCT> PRODUCT_GetPack()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GetPack");
                return MapPRODUCT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PRODUCT_History(string ProductID, string ProductName)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_History", ProductID, ProductName);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PRODUCT_History_Modify()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_History_Modify");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable sp_PRODUCT_GetByStore_TKTH()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "sp_PRODUCT_GetByStore_TKTH");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable sp_PRODUCT_GetByStore_Invoice()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "sp_PRODUCT_GetByStore_Invoice");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PRODUCT_MAKER(string Product_ID, string Stock_ID, long INVENTORYID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_MAKER", Product_ID, Stock_ID, INVENTORYID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PRODUCT_MAKER_General(string RefID, string Product_ID, string Stock_ID, long INVENTORYID, string Currency, double Rate)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_MAKER_General", RefID, Product_ID, Stock_ID, INVENTORYID, Currency, Rate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PRODUCT_mergByProductId(string IdSrc, string IdDesc)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_mergByProductId", IdSrc, IdDesc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PRODUCT> PRODUCT_Search(string Product_ID, string Product_Name)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_Search", Product_ID, Product_Name);
                return MapPRODUCT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PRODUCT_Update(PRODUCT obj, string Product_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_Update",
                    Product_ID,
                    obj.Product_Name,
                    obj.Product_Type_ID,
                    obj.Manufacturer_ID,
                    obj.Product_Group_ID,
                    obj.Provider_ID,
                    obj.Origin,
                    obj.Barcode,
                    obj.Unit,
                    obj.UnitConvert,
                    obj.UnitRate,
                    obj.Org_Price,
                    obj.Sale_Price,
                    obj.Retail_Price,
                    obj.Quantity,
                    obj.CurrentCost,
                    obj.AverageCost,
                    obj.Warranty,
                    obj.VAT_ID,
                    obj.ImportTax_ID,
                    obj.ExportTax_ID,
                    obj.LuxuryTax_ID,
                    obj.Customer_ID,
                    obj.Customer_Name,
                    obj.CostMethod,
                    obj.MinStock,
                    obj.MaxStock,
                    obj.Discount,
                    obj.Commission,
                    obj.Description,
                    obj.Color,
                    obj.Expiry,
                    obj.LimitOrders,
                    obj.ExpiryValue,
                    obj.Batch,
                    obj.Depth,
                    obj.Height,
                    obj.Width,
                    obj.Thickness,
                    obj.Size,
                    obj.UserID,
                    obj.Active
                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PRODUCT_Update_Photo(PRODUCT obj, string Product_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_Update_Photo",
                    Product_ID,
                    obj.Product_Name,
                    obj.Product_Type_ID,
                    obj.Manufacturer_ID,
                    obj.Product_Group_ID,
                    obj.Provider_ID,
                    obj.Origin,
                    obj.Barcode,
                    obj.Unit,
                    obj.UnitConvert,
                    obj.UnitRate,
                    obj.Org_Price,
                    obj.Sale_Price,
                    obj.Retail_Price,
                    obj.Quantity,
                    obj.CurrentCost,
                    obj.AverageCost,
                    obj.Warranty,
                    obj.VAT_ID,
                    obj.ImportTax_ID,
                    obj.ExportTax_ID,
                    obj.LuxuryTax_ID,
                    obj.Customer_ID,
                    obj.Customer_Name,
                    obj.CostMethod,
                    obj.MinStock,
                    obj.MaxStock,
                    obj.Discount,
                    obj.Commission,
                    obj.Description,
                    obj.Color,
                    obj.Expiry,
                    obj.LimitOrders,
                    obj.ExpiryValue,
                    obj.Batch,
                    obj.Depth,
                    obj.Height,
                    obj.Width,
                    obj.Thickness,
                    obj.Size,
                    obj.Photo,
                    obj.UserID,
                    obj.Active
                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PRODUCT_UPDATE_Price(double Percent, long Type)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_UPDATE_Price", Percent, Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
