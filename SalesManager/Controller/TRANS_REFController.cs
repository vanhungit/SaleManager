using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class TRANS_REFController
    {
        private List<TRANS_REF> MapTRANS_REF(DataTable dt)
        {
            List<TRANS_REF> rs = new List<TRANS_REF>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                TRANS_REF obj = new TRANS_REF();
                if (dt.Columns.Contains("ID"))
                    obj.ID = (dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("RefID"))
                    obj.RefID = (dt.Rows[i]["RefID"].ToString());
                if (dt.Columns.Contains("RefOrgNo"))
                    obj.RefOrgNo = (dt.Rows[i]["RefOrgNo"].ToString());
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("RefDate"))
                    obj.RefDate = DateTime.Parse(dt.Rows[i]["RefDate"].ToString());
                if (dt.Columns.Contains("TransFrom"))
                    obj.TransFrom = (dt.Rows[i]["TransFrom"].ToString());
                if (dt.Columns.Contains("TransTo"))
                    obj.TransTo = (dt.Rows[i]["TransTo"].ToString());
                if (dt.Columns.Contains("Department_ID"))
                    obj.Department_ID = (dt.Rows[i]["Department_ID"].ToString());
                if (dt.Columns.Contains("Employee_ID"))
                    obj.Employee_ID = (dt.Rows[i]["Employee_ID"].ToString());
                if (dt.Columns.Contains("Stock_ID"))
                    obj.Stock_ID = (dt.Rows[i]["Stock_ID"].ToString());
                if (dt.Columns.Contains("Branch_ID"))
                    obj.Branch_ID = (dt.Rows[i]["Branch_ID"].ToString());
                if (dt.Columns.Contains("Contract_ID"))
                    obj.Contract_ID = (dt.Rows[i]["Contract_ID"].ToString());
                if (dt.Columns.Contains("Contract"))
                    obj.Contract = (dt.Rows[i]["Contract"].ToString());
                if (dt.Columns.Contains("Reason"))
                    obj.Reason = (dt.Rows[i]["Reason"].ToString());
                if (dt.Columns.Contains("Currency_ID"))
                    obj.Currency_ID = (dt.Rows[i]["Currency_ID"].ToString());
                if (dt.Columns.Contains("ExchangeRate"))
                    obj.ExchangeRate = double.Parse(dt.Rows[i]["ExchangeRate"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("Discount"))
                    obj.Discount = double.Parse(dt.Rows[i]["Discount"].ToString());
                if (dt.Columns.Contains("FAmount"))
                    obj.FAmount = double.Parse(dt.Rows[i]["FAmount"].ToString());
                if (dt.Columns.Contains("FDiscount"))
                    obj.FDiscount = double.Parse(dt.Rows[i]["FDiscount"].ToString());
                if (dt.Columns.Contains("IsClose"))
                    obj.IsClose = bool.Parse(dt.Rows[i]["IsClose"].ToString());
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = (dt.Rows[i]["Description"].ToString());
                if (dt.Columns.Contains("User_ID"))
                    obj.User_ID = (dt.Rows[i]["User_ID"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        public int TRANS_REF_Insert(TRANS_REF obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_REF_Insert",
                        obj.ID,
                        obj.RefID,
                        obj.RefOrgNo,
                        obj.RefType,
                        obj.RefDate,
                        obj.TransFrom,
                        obj.TransTo,
                        obj.Department_ID,
                        obj.Employee_ID,
                        obj.Stock_ID,
                        obj.Branch_ID,
                        obj.Contract_ID,
                        obj.Contract,
                        obj.Reason,
                        obj.Currency_ID,
                        obj.ExchangeRate,
                        obj.Amount,
                        obj.Discount,
                        obj.FAmount,
                        obj.FDiscount,
                        obj.IsClose,
                        obj.Sorted,
                        obj.Description,
                        obj.User_ID,
                        obj.Active
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int TRANS_REF_Delete(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_REF_Delete", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int TRANS_REF_DeleteByID(string RefID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_REF_DeleteByID", RefID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int TRANS_REF_Exist(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_REF_Exist", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int TRANS_REF_ExistByID(string RefID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_REF_ExistByID", RefID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public TRANS_REF TRANS_REF_Get(string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "TRANS_REF_Get", ID);
                return MapTRANS_REF(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TRANS_REF> TRANS_REF_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "TRANS_REF_GetList");
                return MapTRANS_REF(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable TRANS_REF_GetList_ByDate(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "TRANS_REF_GetList_ByDate",From,To);
                return(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable TRANS_REF_GetList_ByDate_Type(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "TRANS_REF_GetList_ByDate_Type", From, To);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable TRANS_REF_GetListAll()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "TRANS_REF_GetListAll");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable TRANS_REF_GetListAll_Type()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "TRANS_REF_GetListAll_Type");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TRANS_REF> TRANS_REF_Search(TRANS_REF obj)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "TRANS_REF_Search",
                    obj.RefOrgNo,
                    obj.RefType,
                    obj.RefDate,
                    obj.TransFrom,
                    obj.TransTo,
                    obj.Contract,
                    obj.Reason,
                    obj.ExchangeRate,
                    obj.Amount,
                    obj.Discount,
                    obj.FAmount,
                    obj.FDiscount,
                    obj.IsClose,
                    obj.Description
                    );
                return MapTRANS_REF(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int TRANS_REF_Update(TRANS_REF obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_REF_Update",
                        ID,
                        obj.RefID,
                        obj.RefOrgNo,
                        obj.RefType,
                        obj.RefDate,
                        obj.TransFrom,
                        obj.TransTo,
                        obj.Department_ID,
                        obj.Employee_ID,
                        obj.Stock_ID,
                        obj.Branch_ID,
                        obj.Contract_ID,
                        obj.Contract,
                        obj.Reason,
                        obj.Currency_ID,
                        obj.ExchangeRate,
                        obj.Amount,
                        obj.Discount,
                        obj.FAmount,
                        obj.FDiscount,
                        obj.IsClose,
                        obj.Sorted,
                        obj.Description,
                        obj.User_ID,
                        obj.Active
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int TRANS_REF_UpdateById(TRANS_REF obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_REF_UpdateById",
                        ID,
                        obj.RefID,
                        obj.RefOrgNo,
                        obj.RefType,
                        obj.RefDate,
                        obj.TransFrom,
                        obj.TransTo,
                        obj.Department_ID,
                        obj.Employee_ID,
                        obj.Stock_ID,
                        obj.Branch_ID,
                        obj.Contract_ID,
                        obj.Contract,
                        obj.Reason,
                        obj.Currency_ID,
                        obj.ExchangeRate,
                        obj.Amount,
                        obj.Discount,
                        obj.FAmount,
                        obj.FDiscount,
                        obj.IsClose,
                        obj.Description,
                        obj.User_ID,
                        obj.Active
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int TRANS_REF_UpdateById(string ID, long Sorted)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_REF_UpdateById",ID,Sorted);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int TRANS_REF_UpdateID(TRANS_REF obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_REF_UpdateID",
                        ID,
                        obj.RefID,
                        obj.RefOrgNo,
                        obj.RefType,
                        obj.RefDate,
                        obj.TransFrom,
                        obj.TransTo,
                        obj.Department_ID,
                        obj.Employee_ID,
                        obj.Stock_ID,
                        obj.Branch_ID,
                        obj.Contract_ID,
                        obj.Contract,
                        obj.Reason,
                        obj.Currency_ID,
                        obj.ExchangeRate,
                        obj.Amount,
                        obj.Discount,
                        obj.FAmount,
                        obj.FDiscount,
                        obj.IsClose,
                        obj.Sorted,
                        obj.Description,
                        obj.User_ID,
                        obj.Active
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
