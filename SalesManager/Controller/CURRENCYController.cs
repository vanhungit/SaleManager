using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class CURRENCYController
    {
        private List<CURRENCY> MapCURRENCY(DataTable dt)
        {
            List<CURRENCY> rs = new List<CURRENCY>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                CURRENCY obj = new CURRENCY();
                if (dt.Columns.Contains("Currency_ID"))
                    obj.Currency_ID = dt.Rows[i]["Currency_ID"].ToString();
                if (dt.Columns.Contains("CurrencyName"))
                    obj.CurrencyName = dt.Rows[i]["CurrencyName"].ToString();
                if (dt.Columns.Contains("Exchange"))
                    obj.Exchange =double.Parse(dt.Rows[i]["Exchange"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        public int CURRENCY_Insert(CURRENCY obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CURRENCY_Insert",
                    obj.Currency_ID,
                    obj.CurrencyName,
                    obj.Exchange,
                    obj.Active
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int CURRENCY_Delete(string Currency_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CURRENCY_Delete", Currency_ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public CURRENCY CURRENCY_Get(string Currency_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CURRENCY_Get", Currency_ID);
                return MapCURRENCY(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CURRENCY> CURRENCY_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CURRENCY_GetList");
                return MapCURRENCY(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CURRENCY_Update(CURRENCY obj, string Currency_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CURRENCY_Update",
                    Currency_ID ,
                    obj.CurrencyName ,
                    obj.Exchange,
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
