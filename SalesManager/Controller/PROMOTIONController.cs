using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesManager.Entity;
using System.Data;
using MicrosoftHelper;

namespace SalesManager.Controller
{
    class PROMOTIONController
    {
        private List<PROMOTION> MapPROMOTION(DataTable dt)
        {
            List<PROMOTION> rs = new List<PROMOTION>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PROMOTION obj = new PROMOTION();
                if (dt.Columns.Contains("ID"))
                    obj.ID = (dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("Name_Promotion"))
                    obj.Name_Promotion = dt.Rows[i]["Name_Promotion"].ToString();
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
        public int PROMOTION_Insert(PROMOTION obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROMOTION_Insert",
                    obj.ID
                   , obj.Name_Promotion
                   , obj.Refdate
                   , obj.RefType
                   , obj.StartDate
                   , obj.StopDate
                   , obj.CreateBy
                   , obj.Createdate
                   , obj.ModifyBy
                   , obj.ModifyDate
                   , obj.Active

                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PROMOTION_Update(PROMOTION obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROMOTION_Update",
                     obj.ID
                   , obj.Name_Promotion
                   , obj.Refdate
                   , obj.RefType
                   , obj.StartDate
                   , obj.StopDate
                   , obj.CreateBy
                   , obj.Createdate
                   , obj.ModifyBy
                   , obj.ModifyDate
                   , obj.Active);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PROMOTION PROMOTION_Get(string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString,dt, "PROMOTION_Get", ID);
                return MapPROMOTION(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PROMOTION_Delete(string ID)
        {
            try
            {
                DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROMOTION_Delete", ID);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
