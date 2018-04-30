using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using System.Data;
using SalesManager.Entity;
using MicrosoftHelper;

namespace SalesManager.Controller
{
    public class KYKHOController
    {
        private List<KYKHO> MapADJUSTMENT(DataTable dt)
        {
            List<KYKHO> rs = new List<KYKHO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KYKHO obj = new KYKHO();
                if (dt.Columns.Contains("ID"))
                    obj.ID = dt.Rows[i]["ID"].ToString();
                if (dt.Columns.Contains("Refdate"))
                    obj.Refdate = DateTime.Parse(dt.Rows[i]["Refdate"].ToString());
                if (dt.Columns.Contains("KyKho_Name"))
                    obj.KyKho_Name = dt.Rows[i]["KyKho_Name"].ToString();
                if (dt.Columns.Contains("StockID"))
                    obj.StockID = dt.Rows[i]["StockID"].ToString();
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("RefStatus"))
                    obj.RefStatus = int.Parse(dt.Rows[i]["RefStatus"].ToString());
                if (dt.Columns.Contains("StartDate"))
                    obj.StartDate = DateTime.Parse(dt.Rows[i]["StartDate"].ToString());
                if (dt.Columns.Contains("EndDate"))
                    obj.EndDate = DateTime.Parse(dt.Rows[i]["EndDate"].ToString());
                if (dt.Columns.Contains("OpenQuantity"))
                    obj.OpenQuantity = double.Parse(dt.Rows[i]["OpenQuantity"].ToString());
                if (dt.Columns.Contains("OpenAmount"))
                    obj.OpenAmount = double.Parse(dt.Rows[i]["OpenAmount"].ToString());
                if (dt.Columns.Contains("InQuantity"))
                    obj.InQuantity = double.Parse(dt.Rows[i]["InQuantity"].ToString());
                if (dt.Columns.Contains("InAmount"))
                    obj.InAmount = double.Parse(dt.Rows[i]["InAmount"].ToString());
                if (dt.Columns.Contains("OutQuantity"))
                    obj.OutQuantity = double.Parse(dt.Rows[i]["OutQuantity"].ToString());
                if (dt.Columns.Contains("OutAmount"))
                    obj.OutAmount = double.Parse(dt.Rows[i]["OutAmount"].ToString());
                if (dt.Columns.Contains("OnhandQuantity"))
                    obj.OnhandQuantity = double.Parse(dt.Rows[i]["OnhandQuantity"].ToString());
                if (dt.Columns.Contains("CloseAmount"))
                    obj.CloseAmount = double.Parse(dt.Rows[i]["CloseAmount"].ToString());

                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());

                if (dt.Columns.Contains("CreateBy"))
                    obj.CreateBy = dt.Rows[i]["CreateBy"].ToString();
                if (dt.Columns.Contains("Createdate"))
                    obj.Createdate = DateTime.Parse(dt.Rows[i]["Createdate"].ToString());
                if (dt.Columns.Contains("ModifyBy"))
                    obj.ModifyBy = dt.Rows[i]["ModifyBy"].ToString();
                if (dt.Columns.Contains("ModifyDate"))
                    obj.ModifyDate = DateTime.Parse(dt.Rows[i]["ModifyDate"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public DataTable DSKyKho()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "KYKHO_Getlist");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable sp_HangHoaDauKy(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "sp_HangHoaDauKy", From, To);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable sp_BangKeDauKy(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "sp_BangKeDauKy", From, To);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ThemKyKho(KYKHO objkykho)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "KyKho_ChayTest", objkykho.ID
                    ,objkykho.KyKho_Name
                    ,objkykho.Refdate
                    ,objkykho.RefType
                    ,objkykho.RefStatus
                    ,objkykho.EndDate
                    ,objkykho.CreateBy
                    ,objkykho.Createdate
                    ,objkykho.ModifyBy
                    ,objkykho.ModifyDate
                    ,objkykho.Active
                );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
