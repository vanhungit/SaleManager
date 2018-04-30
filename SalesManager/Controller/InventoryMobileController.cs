using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesManager.Entity;
using System.Data;
using MicrosoftHelper;

namespace SalesManager.Controller
{
    public class InventoryMobileController
    {
        private List<InventoryMobile> MapInventoryMobile(DataTable dt)
        {
            List<InventoryMobile> rs = new List<InventoryMobile>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                InventoryMobile obj = new InventoryMobile();
                if (dt.Columns.Contains("STT"))
                    obj.STT = long.Parse(dt.Rows[i]["STT"].ToString());
                if (dt.Columns.Contains("IP_Address"))
                    obj.IP_Address = (dt.Rows[i]["IP_Address"].ToString());
                if (dt.Columns.Contains("SeriNum"))
                    obj.SeriNum = (dt.Rows[i]["SeriNum"].ToString());
                if (dt.Columns.Contains("Location"))
                    obj.Location = dt.Rows[i]["Location"].ToString();
                if (dt.Columns.Contains("Barcode"))
                    obj.Barcode = (dt.Rows[i]["Barcode"].ToString());
                if (dt.Columns.Contains("AXcode"))
                    obj.AXcode = (dt.Rows[i]["AXcode"].ToString());
                if (dt.Columns.Contains("Name"))
                    obj.Name = (dt.Rows[i]["Name"].ToString());
                if (dt.Columns.Contains("Batch"))
                    obj.Batch = (dt.Rows[i]["Batch"].ToString());
                if (dt.Columns.Contains("Unit"))
                    obj.Unit = (dt.Rows[i]["Unit"].ToString());
                if (dt.Columns.Contains("Quantity"))
                    obj.Quantity = double.Parse(dt.Rows[i]["Quantity"].ToString());
                if (dt.Columns.Contains("Timerow"))
                    obj.Timerow = DateTime.Parse(dt.Rows[i]["Timerow"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public DataTable InventoryMobile_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "InventoryMobile_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
