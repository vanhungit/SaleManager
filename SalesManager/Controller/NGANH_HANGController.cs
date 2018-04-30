using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesManager.Entity;
using System.Data;
using MicrosoftHelper;

namespace SalesManager.Controller
{
    public class NGANH_HANGController
    {
        private List<NGANH_HANG> MapADJUSTMENT(DataTable dt)
        {
            List<NGANH_HANG> rs = new List<NGANH_HANG>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NGANH_HANG obj = new NGANH_HANG();
                if (dt.Columns.Contains("ID_NGANH"))
                    obj.ID_NGANH = dt.Rows[i]["ID_NGANH"].ToString();
                if (dt.Columns.Contains("TEN_NGANH"))
                    obj.TEN_NGANH = (dt.Rows[i]["TEN_NGANH"].ToString());
                if (dt.Columns.Contains("DESCRIPTION"))
                    obj.DESCRIPTION = dt.Rows[i]["DESCRIPTION"].ToString();
                if (dt.Columns.Contains("IsMain"))
                    obj.IsMain = bool.Parse(dt.Rows[i]["IsMain"].ToString());

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
        public int ThemNGANHHANG(NGANH_HANG obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_NGANHHANG_Insert",
                     obj.ID_NGANH
                   , obj.TEN_NGANH
                   , obj.DESCRIPTION
                   , obj.IsMain
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
        public int CapNhatNGANH_HANG(NGANH_HANG obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_NGANHHANG_Update",
                     ID
                   , obj.TEN_NGANH
                   , obj.DESCRIPTION
                   , obj.IsMain
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
        public DataTable LayDSNGANH_HANG()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_NGANHHANG_Getlist");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public NGANH_HANG PRODUCT_NGANHHANG_Get(string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_NGANHHANG_Get", ID);
                return MapADJUSTMENT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int XoaNGANHHANG(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_NGANHHANG_Delete", ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
