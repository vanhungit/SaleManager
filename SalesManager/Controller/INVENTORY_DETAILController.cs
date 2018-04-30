using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class INVENTORY_DETAILController
    {
        private List<INVENTORY_DETAIL> MapINVENTORY_DETAIL(DataTable dt)
        {
            List<INVENTORY_DETAIL> rs = new List<INVENTORY_DETAIL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                INVENTORY_DETAIL obj = new INVENTORY_DETAIL();
                if (dt.Columns.Contains("ID"))
                    obj.ID = long.Parse(dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("RefNo"))
                    obj.RefNo = dt.Rows[i]["RefNo"].ToString();
                if (dt.Columns.Contains("RefDate"))
                    obj.RefDate = DateTime.Parse(dt.Rows[i]["RefDate"].ToString());
                if (dt.Columns.Contains("RefDetailNo"))
                    obj.RefDetailNo = dt.Rows[i]["RefDetailNo"].ToString();
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("RefStatus"))
                    obj.RefStatus = int.Parse(dt.Rows[i]["RefStatus"].ToString());
                if (dt.Columns.Contains("StoreID"))
                    obj.StoreID =long.Parse(dt.Rows[i]["StoreID"].ToString());
                if (dt.Columns.Contains("Stock_ID"))
                    obj.Stock_ID = dt.Rows[i]["Stock_ID"].ToString();
                if (dt.Columns.Contains("Product_ID"))
                    obj.Product_ID = dt.Rows[i]["Product_ID"].ToString();
                if (dt.Columns.Contains("Product_Name"))
                    obj.Product_Name = dt.Rows[i]["Product_Name"].ToString();
                if (dt.Columns.Contains("Customer_ID"))
                    obj.Customer_ID = dt.Rows[i]["Customer_ID"].ToString();
                if (dt.Columns.Contains("Employee_ID"))
                    obj.Employee_ID = dt.Rows[i]["Employee_ID"].ToString();
                if (dt.Columns.Contains("Batch"))
                    obj.Batch = dt.Rows[i]["Batch"].ToString();
                if (dt.Columns.Contains("Serial"))
                    obj.Serial = dt.Rows[i]["Serial"].ToString();
                if (dt.Columns.Contains("Unit"))
                    obj.Unit = dt.Rows[i]["Unit"].ToString();
                if (dt.Columns.Contains("Price"))
                    obj.Price =double.Parse(dt.Rows[i]["Price"].ToString());
                if (dt.Columns.Contains("Quantity"))
                    obj.Quantity = double.Parse(dt.Rows[i]["Quantity"].ToString());
                if (dt.Columns.Contains("UnitPrice"))
                    obj.UnitPrice = double.Parse(dt.Rows[i]["UnitPrice"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("E_Qty"))
                    obj.E_Qty = double.Parse(dt.Rows[i]["E_Qty"].ToString());
                if (dt.Columns.Contains("E_Amt"))
                    obj.E_Amt = double.Parse(dt.Rows[i]["E_Amt"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("Book_ID"))
                    obj.Book_ID = dt.Rows[i]["Book_ID"].ToString();
                rs.Add(obj);
            }
            return rs;
        }
        public int INVENTORY_DETAIL_Insert(INVENTORY_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "INVENTORY_DETAIL_Insert",
                    obj.ID,
                    obj.RefNo,
                    obj.RefDate,
                    obj.RefDetailNo,
                    obj.RefType,
                    obj.RefStatus,
                    obj.StoreID,
                    obj.Stock_ID,
                    obj.Product_ID,
                    obj.Product_Name,
                    obj.Customer_ID,
                    obj.Employee_ID,
                    obj.Batch,
                    obj.Serial,
                    obj.Unit,
                    obj.Price,
                    obj.Quantity,
                    obj.UnitPrice,
                    obj.Amount,
                    obj.E_Qty,
                    obj.E_Amt,
                    obj.Description,
                    obj.Sorted,
                    obj.Book_ID
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int INVENTORY_DETAIL_Delete(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "INVENTORY_DETAIL_Delete", ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int INVENTORY_DETAIL_Exist(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "INVENTORY_DETAIL_Exist", ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<INVENTORY_DETAIL> INVENTORY_DETAIL_Get(long ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_DETAIL_Get",ID);
                return MapINVENTORY_DETAIL(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<INVENTORY_DETAIL> INVENTORY_DETAIL_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_DETAIL_GetList");
                return MapINVENTORY_DETAIL(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int INVENTORY_DETAIL_PACKET(
                    string ID ,
                    string Transfer_ID ,
                    DateTime RefDate ,
                    int RefType ,
                    string Currency_ID ,
                    string Customer_ID ,
                    string Employee_ID ,
                    string Product_ID ,
                    string Product_Name ,
                    string OutStock ,
                    string InStock ,
                    string Unit ,
                    double UnitConvert ,
                    double UnitPrice ,
                    double Quantity ,
                    double Amount ,
                    double QtyConvert ,
                    int StoreID ,
                    string Batch ,
                    string Serial ,
                    string Description ,
                    long Sorted 
        )
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "INVENTORY_DETAIL_PACKET",
                     ID ,
                     Transfer_ID ,
                     RefDate ,
                     RefType ,
                     Currency_ID ,
                     Customer_ID ,
                     Employee_ID ,
                     Product_ID ,
                     Product_Name ,
                     OutStock ,
                     InStock ,
                     Unit ,
                     UnitConvert ,
                     UnitPrice ,
                     Quantity ,
                     Amount ,
                     QtyConvert ,
                     StoreID ,
                     Batch ,
                     Serial ,
                     Description ,
                     Sorted 
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int INVENTORY_DETAIL_INWARD(
                    string ID ,
                    string Inward_ID ,
                    string Product_ID ,
                    string ProductName ,
                    DateTime RefDate ,
                    int RefType ,
                    string Currency_ID ,
                    string Stock_ID ,
                    string Customer_ID ,
                    string  Employee_ID ,
                    string Unit ,
                    double Price ,           
                    double Quantity ,
                    double UnitPrice ,
                    double Amount , 
                    double Discount ,
                    double Charge ,
                    DateTime Limit ,
                    double Width ,
                    double Height ,
                    string Orgin ,
                    string Size ,
                    string Color ,
                    string Batch ,
                    string Serial ,
                    string ChassyNo ,
                    string IME ,
                    string Location ,    
                    long StoreID ,
                    string Description ,
                    long Sorted ,
                    int Active 
        )
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "INVENTORY_DETAIL_INWARD",
                     ID ,
                     Inward_ID ,
                     Product_ID ,
                     ProductName ,
                     RefDate ,
                     RefType ,
                     Currency_ID ,
                     Stock_ID ,
                     Customer_ID ,
                     Employee_ID ,
                     Unit ,
                     Price ,           
                     Quantity ,
                     UnitPrice ,
                     Amount , 
                     Discount ,
                     Charge ,
                     Limit ,
                     Width ,
                     Height ,
                     Orgin ,
                     Size ,
                     Color ,
                     Batch ,
                     Serial ,
                     ChassyNo ,
                     IME ,
                     Location ,    
                     StoreID ,
                     Description ,
                     Sorted ,
                     Active 
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int INVENTORY_DETAIL_OUTWARD(
                    string ID ,
                    string Outward_ID ,
                    DateTime RefDate ,
                    string Stock_ID ,
                    int RefType ,
                    string Currency_ID ,
                    string Customer_ID ,
                    string Employee_ID ,
                    string Product_ID ,
                    string ProductName ,    
                    string Unit ,    
                    double Quantity ,
                    double UnitPrice ,
                    double Amount ,
                    double Discount ,
                    double Charge ,
                    string Batch ,
                    string Serial ,
                    string ChassyNo ,
                    string IME ,
                    double Width ,
                    double Height ,
                    string Orgin ,
                    string Size ,
                    long StoreID ,
                    string Description ,
                    long Sorted ,
                    int Active 
       )
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "INVENTORY_DETAIL_OUTWARD",
                    ID ,
                    Outward_ID ,
                    RefDate ,
                    Stock_ID ,
                    RefType ,
                    Currency_ID ,
                    Customer_ID ,
                    Employee_ID ,
                    Product_ID ,
                    ProductName ,    
                    Unit ,    
                    Quantity ,
                    UnitPrice ,
                    Amount ,
                    Discount ,
                    Charge ,
                    Batch ,
                    Serial ,
                    ChassyNo ,
                    IME ,
                    Width ,
                    Height ,
                    Orgin ,
                    Size ,
                    StoreID ,
                    Description ,
                    Sorted ,
                    Active 
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public List<INVENTORY_DETAIL> INVENTORY_DETAIL_Search(INVENTORY_DETAIL obj)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CUSTOMER_RECEIPT_DETAIL_Search",
                        obj.RefNo,
                        obj.RefDate,
                        obj.RefDetailNo,
                        obj.RefType,
                        obj.Product_Name,
                        obj.Batch,
                        obj.Serial,
                        obj.Unit,
                        obj.Price,
                        obj.Quantity,
                        obj.UnitPrice,
                        obj.Amount,
                        obj.E_Qty,
                        obj.E_Amt,
                        obj.Description 
                    );
                return MapINVENTORY_DETAIL(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_DETAIL_STOCK_CARD(DateTime FromDate, DateTime ToDate,string Stock_Id, string Product_ID, string Product_Name)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_DETAIL_STOCK_CARD",FromDate,ToDate,Stock_Id, Product_ID, Product_Name);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_DETAIL_SoCTHHoa(DateTime FromDate, DateTime ToDate, string Stock_Id, string Product_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_DETAIL_SoCTHHoa", FromDate, ToDate, Stock_Id, Product_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_DETAIL_SUMMARY_THXNTON(DateTime FromDate, DateTime ToDate, string Stock_Id)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_DETAIL_SUMMARY_THXNTON", FromDate, ToDate, Stock_Id);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_DETAIL_SUMMARY_STOCK(DateTime FromDate, DateTime ToDate, string Stock_Id)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_DETAIL_SUMMARY_STOCK", FromDate, ToDate, Stock_Id);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_DETAIL_SUMMARY(DateTime FromDate, DateTime ToDate, string Stock_Id, string Product_ID, string Product_Name)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_DETAIL_SUMMARY", FromDate, ToDate, Stock_Id, Product_ID, Product_Name);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_DETAIL_SUMMARY_ByDate(DateTime FromDate, DateTime ToDate, string Stock_Id, string Product_ID, string Product_Name)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_DETAIL_SUMMARY_ByDate", FromDate, ToDate, Stock_Id, Product_ID, Product_Name);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_DETAIL_THEKHO(DateTime FromDate, DateTime ToDate, string Kho)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_DETAIL_THEKHO", FromDate, ToDate,Kho);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int INVENTORY_DETAIL_TRANSFER(
                    string  ID ,
                    string Transfer_ID ,
                    string RefDate ,
                    DateTime RefType ,
                    string Currency_ID ,
                    string Customer_ID ,
                    string Employee_ID ,
                    string Product_ID ,
                    string Product_Name ,
                    string OutStock ,
                    string InStock ,
                    string Unit ,
                    double UnitConvert ,
                    double UnitPrice ,
                    double Quantity ,
                    double Amount ,
                    double QtyConvert ,
                    long StoreID ,
                    string Batch ,
                    string Serial ,
                    string Description ,
                    long Sorted 
       )
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "INVENTORY_DETAIL_TRANSFER",
                     ID ,
                     Transfer_ID ,
                     RefDate ,
                     RefType ,
                     Currency_ID ,
                     Customer_ID ,
                     Employee_ID ,
                     Product_ID ,
                     Product_Name ,
                     OutStock ,
                     InStock ,
                     Unit ,
                     UnitConvert ,
                     UnitPrice ,
                     Quantity ,
                     Amount ,
                     QtyConvert ,
                     StoreID ,
                     Batch ,
                     Serial ,
                     Description ,
                     Sorted 
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int INVENTORY_DETAIL_Update(INVENTORY_DETAIL obj,string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "INVENTORY_DETAIL_Update",
                    ID,
                    obj.RefNo,
                    obj.RefDate,
                    obj.RefDetailNo,
                    obj.RefType,
                    obj.RefStatus,
                    obj.StoreID,
                    obj.Stock_ID,
                    obj.Product_ID,
                    obj.Product_Name,
                    obj.Customer_ID,
                    obj.Employee_ID,
                    obj.Batch,
                    obj.Serial,
                    obj.Unit,
                    obj.Price,
                    obj.Quantity,
                    obj.UnitPrice,
                    obj.Amount,
                    obj.E_Qty,
                    obj.E_Amt,
                    obj.Description,
                    obj.Sorted,
                    obj.Book_ID
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }

    }
}
