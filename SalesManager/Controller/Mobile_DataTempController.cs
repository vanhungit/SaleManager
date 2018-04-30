using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesManager.Entity;
using System.Data;
using MicrosoftHelper;

namespace SalesManager.Controller
{
    class Mobile_DataTempController
    {
        private List<Mobile_DataTemp> MapMobile_DataTemp(DataTable dt)
        {
            List<Mobile_DataTemp> rs = new List<Mobile_DataTemp>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                Mobile_DataTemp obj = new Mobile_DataTemp();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid(dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("IP_Address"))
                    obj.IP_Address = dt.Rows[i]["IP_Address"].ToString();
                if (dt.Columns.Contains("MobiName"))
                    obj.MobiName = (dt.Rows[i]["MobiName"].ToString());
                if (dt.Columns.Contains("SeriNumber"))
                    obj.SeriNumber =(dt.Rows[i]["SeriNumber"].ToString());
                if (dt.Columns.Contains("StoreName"))
                    obj.StoreName = dt.Rows[i]["StoreName"].ToString();
                if (dt.Columns.Contains("Barcode"))
                    obj.Barcode = (dt.Rows[i]["Barcode"].ToString());
                if (dt.Columns.Contains("ProductName"))
                    obj.ProductName = (dt.Rows[i]["ProductName"].ToString());
                if (dt.Columns.Contains("Sale_Price"))
                    obj.Sale_Price = double.Parse(dt.Rows[i]["Sale_Price"].ToString());
                if (dt.Columns.Contains("CurrentQty"))
                    obj.CurrentQty = double.Parse(dt.Rows[i]["CurrentQty"].ToString());
                if (dt.Columns.Contains("CreateDate"))
                    obj.CreateDate = DateTime.Parse(dt.Rows[i]["CreateDate"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        public int Mobile_Temp_Data_Insert(Mobile_DataTemp obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "Mobile_Temp_Data_Insert",
                    obj.ID
                   , obj.IP_Address
                   , obj.MobiName
                   , obj.SeriNumber
                   , obj.StoreName
                   , obj.Barcode
                   , obj.ProductName
                   , obj.Sale_Price
                   , obj.CurrentQty
                   , obj.CreateDate
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public DataTable Mobile_Temp_Data_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Mobile_Temp_Data_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Mobile_Temp_Data_Delete(Guid ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "Mobile_Temp_Data_Delete", ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
