using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using System.Data;
using MicrosoftHelper;

namespace SalesManager.Entity
{
    public class BANGGIAController
    {
        private List<BANGGIA> MapADJUSTMENT(DataTable dt)
        {
            List<BANGGIA> rs = new List<BANGGIA>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BANGGIA obj = new BANGGIA();
                if (dt.Columns.Contains("ID"))
                    obj.ID = (dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("Name_ListPrice"))
                    obj.Name_ListPrice = dt.Rows[i]["Name_ListPrice"].ToString();
                if (dt.Columns.Contains("Refdate"))
                    obj.Refdate = DateTime.Parse(dt.Rows[i]["Refdate"].ToString());
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("StartDate"))
                    obj.StartDate = DateTime.Parse(dt.Rows[i]["StartDate"].ToString());
                if (dt.Columns.Contains("StopDate"))
                    obj.StopDate = DateTime.Parse(dt.Rows[i]["StopDate"].ToString());
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
        public BANGGIA LayTenBANGGIA(string BANGGIA_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "BANGGIA_Get", BANGGIA_ID);
                return MapADJUSTMENT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ThemBANGGIA(BANGGIA obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "BANGGIA_Insert",
                    obj.ID
                   , obj.Name_ListPrice
                   , obj.Refdate
                   , obj.RefType
                   , obj.StartDate
                   , obj.StopDate
                   , obj.Active
                   , obj.CreateBy
                   , obj.Createdate
                   , obj.ModifyBy
                   , obj.ModifyDate
                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CapNhatBANGGIA(BANGGIA obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "BANGGIA_Update", ID,
                    obj.Name_ListPrice
                   , obj.Refdate
                   , obj.RefType
                   , obj.StartDate
                   , obj.StopDate
                   , obj.Active
                   , obj.CreateBy
                   , obj.Createdate
                   , obj.ModifyBy
                   , obj.ModifyDate
                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LayDSBANGGIA()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "BANGGIA_Getlist");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable BANGGIA_GetList_ByDate(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "BANGGIA_GetList_ByDate", From, To);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LoaiBangGia()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "BANGGIA_LOAI_Getlist");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int XoaBANGGIA(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "BANGGIA_Delete", ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SetBangGia(string ID, int Type)
        {
            try
            {
                DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "BANGGIA_Set", ID, Type);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
                return -1;
            }
        }
    }
}
