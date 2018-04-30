using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesManager.Entity;
using System.Data;
using MicrosoftHelper;

namespace SalesManager.Controller
{
    public class CheckPriceController
    {
        private List<CheckPrice> MapCheckPrice(DataTable dt)
        {
            List<CheckPrice> rs = new List<CheckPrice>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CheckPrice obj = new CheckPrice();
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
                if (dt.Columns.Contains("Unit"))
                    obj.Unit = (dt.Rows[i]["Unit"].ToString());
                if (dt.Columns.Contains("SalePrice"))
                    obj.SalePrice = double.Parse(dt.Rows[i]["SalePrice"].ToString());
                if (dt.Columns.Contains("BarcodeNew"))
                    obj.BarcodeNew = (dt.Rows[i]["BarcodeNew"].ToString());
                if (dt.Columns.Contains("AXcodeNew"))
                    obj.AXcodeNew = (dt.Rows[i]["AXcodeNew"].ToString());
                if (dt.Columns.Contains("NameNew"))
                    obj.NameNew = (dt.Rows[i]["NameNew"].ToString());
                if (dt.Columns.Contains("UnitNew"))
                    obj.UnitNew = (dt.Rows[i]["UnitNew"].ToString());
                if (dt.Columns.Contains("SalePriceNew"))
                    obj.SalePriceNew = double.Parse(dt.Rows[i]["SalePriceNew"].ToString());
                if (dt.Columns.Contains("CameraImage"))
                    obj.CameraImage = (byte[])(dt.Rows[i]["CameraImage"]);
                if (dt.Columns.Contains("Signature"))
                    obj.Signature = (byte[])(dt.Rows[i]["Signature"]);
                if (dt.Columns.Contains("Sticknote"))
                    obj.Sticknote = int.Parse(dt.Rows[i]["Sticknote"].ToString());
                if (dt.Columns.Contains("Timerow"))
                    obj.Timerow = DateTime.Parse(dt.Rows[i]["Timerow"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public DataTable CheckPrice_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CheckPrice_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CheckPrice CheckPrice_Get(long STT, string SeriNum)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CheckPrice_Get", STT, SeriNum);
                return MapCheckPrice(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
