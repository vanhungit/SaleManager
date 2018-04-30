using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using System.Data;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class ADJUSTMENTController
    {
        private List<ADJUSTMENT> MapADJUSTMENT(DataTable dt)
        {
            List<ADJUSTMENT> rs = new List<ADJUSTMENT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ADJUSTMENT obj = new ADJUSTMENT();
                if (dt.Columns.Contains("ID"))
                    obj.ID = dt.Rows[i]["ID"].ToString();
                if (dt.Columns.Contains("RefDate"))
                    obj.RefDate = DateTime.Parse(dt.Rows[i]["RefDate"].ToString());
                if (dt.Columns.Contains("Ref_OrgNo"))
                    obj.Ref_OrgNo = dt.Rows[i]["Ref_OrgNo"].ToString();
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("Employee_ID"))
                    obj.Employee_ID = dt.Rows[i]["Employee_ID"].ToString();
                if (dt.Columns.Contains("Stock_ID"))
                    obj.Stock_ID = dt.Rows[i]["Stock_ID"].ToString();
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("Accept"))
                    obj.Accept = bool.Parse(dt.Rows[i]["Accept"].ToString());
                if (dt.Columns.Contains("IsClose"))
                    obj.IsClose = bool.Parse(dt.Rows[i]["IsClose"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("User_ID"))
                    obj.User_ID = dt.Rows[i]["User_ID"].ToString();
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int XoaADJUSTMENT(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "ADJUSTMENT_Delete", ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int CheckADJUSTMENT_ID(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "ADJUSTMENT_Exist", ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ADJUSTMENT_ID"></param>
        /// <returns></returns>
        public ADJUSTMENT LayTenADJUSTMENT(string ADJUSTMENT_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "ADJUSTMENT_Get", ADJUSTMENT_ID);
                return MapADJUSTMENT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LayDSADJUSTMENT()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "ADJUSTMENT_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ADJUSTMENT> LayDSADJUSTMENTbyDate(DateTime start,DateTime end, long moneytype)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "ADJUSTMENT_GetList_ByDate",start,end,moneytype);
                return MapADJUSTMENT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ThemADJUSTMENT(ADJUSTMENT obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "ADJUSTMENT_Insert", obj.ID,
                    obj.RefDate,
                    obj.Ref_OrgNo,
                    obj.RefType,
                    obj.Employee_ID,
                    obj.Stock_ID,
                    obj.Amount,
                    obj.Accept,
                    obj.IsClose,
                    obj.Description,
                    obj.User_ID,
                    obj.Active
                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CapNhatADJUSTMENT(ADJUSTMENT obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "ADJUSTMENT_Update", ID,
                    obj.RefDate,
                    obj.Ref_OrgNo,
                    obj.RefType,
                    obj.Employee_ID,
                    obj.Stock_ID,
                    obj.Amount,
                    obj.Accept,
                    obj.IsClose,
                    obj.Description,
                    obj.User_ID,
                    obj.Active
                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
