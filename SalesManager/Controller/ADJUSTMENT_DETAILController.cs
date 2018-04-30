using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using System.Data;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class ADJUSTMENT_DETAILController
    {
        private List<ADJUSTMENT_DETAIL> MapADJUSTMENT_DETAIL(DataTable dt)
        {
            List<ADJUSTMENT_DETAIL> rs = new List<ADJUSTMENT_DETAIL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ADJUSTMENT_DETAIL obj = new ADJUSTMENT_DETAIL();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid(dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("Adjustment_ID"))
                    obj.Adjustment_ID = dt.Rows[i]["Adjustment_ID"].ToString();
                if (dt.Columns.Contains("Product_ID"))
                    obj.Product_ID = dt.Rows[i]["Product_ID"].ToString();
                if (dt.Columns.Contains("Product_Name"))
                    obj.Product_Name = dt.Rows[i]["Product_Name"].ToString();
                if (dt.Columns.Contains("Stock_ID"))
                    obj.Stock_ID = dt.Rows[i]["Stock_ID"].ToString();
                if (dt.Columns.Contains("Unit"))
                    obj.Unit = dt.Rows[i]["Unit"].ToString();
                if (dt.Columns.Contains("UnitConvert"))
                    obj.UnitConvert = double.Parse(dt.Rows[i]["UnitConvert"].ToString());
                if (dt.Columns.Contains("Width"))
                    obj.Width = double.Parse(dt.Rows[i]["Width"].ToString());
                if (dt.Columns.Contains("Height"))
                    obj.Height = double.Parse(dt.Rows[i]["Height"].ToString());
                if (dt.Columns.Contains("Orgin"))
                    obj.Orgin = dt.Rows[i]["Orgin"].ToString();
                if (dt.Columns.Contains("CurrentQty"))
                    obj.QtyConvert = double.Parse(dt.Rows[i]["CurrentQty"].ToString());
                if (dt.Columns.Contains("NewQty"))
                    obj.NewQty = double.Parse(dt.Rows[i]["NewQty"].ToString());
                if (dt.Columns.Contains("QtyDiff"))
                    obj.QtyDiff = double.Parse(dt.Rows[i]["QtyDiff"].ToString());
                if (dt.Columns.Contains("UnitPrice"))
                    obj.UnitPrice = double.Parse(dt.Rows[i]["UnitPrice"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("QtyConvert"))
                    obj.QtyConvert = double.Parse(dt.Rows[i]["QtyConvert"].ToString());
                if (dt.Columns.Contains("StoreID"))
                    obj.StoreID = int.Parse(dt.Rows[i]["StoreID"].ToString());
                if (dt.Columns.Contains("Batch"))
                    obj.Batch = dt.Rows[i]["Batch"].ToString();
                if (dt.Columns.Contains("Serial"))
                    obj.Serial = dt.Rows[i]["Serial"].ToString();
                if (dt.Columns.Contains("Location"))
                    obj.Location = dt.Rows[i]["Location"].ToString();
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = int.Parse(dt.Rows[i]["Sorted"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int ThemADJUSTMENT_DETAIL(ADJUSTMENT_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "ADJUSTMENT_DETAIL_Insert",
                    obj.ID ,
                    obj.Adjustment_ID,
                    obj.Product_ID,
                    obj.Product_Name,
                    obj.Stock_ID,
                    obj.Unit,
                    obj.UnitConvert,
                    obj.Width,
                    obj.Height,
                    obj.Orgin,
                    obj.CurrentQty,
                    obj.NewQty,
                    obj.QtyDiff,
                    obj.UnitPrice,
                    obj.Amount,
                    obj.QtyConvert,
                    obj.StoreID,
                    obj.Batch,
                    obj.Serial,
                    obj.Location,
                    obj.Description,
                    obj.Sorted
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Employee_ID"></param>
        /// <returns></returns>
        public int XoaADJUSTMENT_DETAIL(string Employee_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "ADJUSTMENT_DETAIL_Delete", Employee_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Adjustment_ID"></param>
        /// <param name="Product_ID"></param>
        /// <returns></returns>
        public ADJUSTMENT_DETAIL LayTenADJUSTMENT_DETAIL(string Adjustment_ID, string Product_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "ADJUSTMENT_DETAIL_Get", Adjustment_ID, Product_ID);
                return MapADJUSTMENT_DETAIL(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ADJUSTMENT_DETAIL_GetbyAdjustment_ID(string Adjustment_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "ADJUSTMENT_DETAIL_GetbyAdjustment_ID", Adjustment_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ADJUSTMENT_DETAIL> LayDSADJUSTMENT_DETAIL()
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "ADJUSTMENT_DETAIL_GetList");
                return MapADJUSTMENT_DETAIL(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        
    }
}
