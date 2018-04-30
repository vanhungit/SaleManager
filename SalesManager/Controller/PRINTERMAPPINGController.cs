using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesManager.Entity;
using System.Data;
using MicrosoftHelper;

namespace SalesManager.Controller
{
    public class PRINTERMAPPINGController
    {
        private List<PRINTERMAPPING> MapPRINTERMAPPING(DataTable dt)
        {
            List<PRINTERMAPPING> rs = new List<PRINTERMAPPING>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PRINTERMAPPING obj = new PRINTERMAPPING();
                if (dt.Columns.Contains("Station_ID"))
                    obj.Station_ID = dt.Rows[i]["Station_ID"].ToString();
                if (dt.Columns.Contains("Store_ID"))
                    obj.Store_ID = dt.Rows[i]["Store_ID"].ToString();
                if (dt.Columns.Contains("LocalPort"))
                    obj.LocalPort = dt.Rows[i]["LocalPort"].ToString();
                if (dt.Columns.Contains("NetworkPort"))
                    obj.NetworkPort = dt.Rows[i]["NetworkPort"].ToString();
                if (dt.Columns.Contains("PrinterName"))
                    obj.PrinterName = dt.Rows[i]["PrinterName"].ToString();
                if (dt.Columns.Contains("Details"))
                    obj.Details = dt.Rows[i]["Details"].ToString();
                if (dt.Columns.Contains("Disabled"))
                    obj.Disabled = bool.Parse(dt.Rows[i]["Disabled"].ToString());
                if (dt.Columns.Contains("Two_Color_Printing"))
                    obj.Two_Color_Printing = bool.Parse(dt.Rows[i]["Two_Color_Printing"].ToString());
                if (dt.Columns.Contains("CutReceipt"))
                    obj.CutReceipt = bool.Parse(dt.Rows[i]["CutReceipt"].ToString());
                if (dt.Columns.Contains("LineFeedsBeforeCut"))
                    obj.LineFeedsBeforeCut = int.Parse(dt.Rows[i]["LineFeedsBeforeCut"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public int PRINTERMAPPING_Insert(PRINTERMAPPING obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "Printer_Mapping_Insert",
                    obj.Station_ID,
                    obj.Store_ID,
                    obj.LocalPort,
                    obj.NetworkPort,
                    obj.PrinterName,
                    obj.Details,
                    obj.Disabled,
                    obj.Two_Color_Printing,
                    obj.CutReceipt,
                    obj.LineFeedsBeforeCut
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int Printer_Mapping_Update(PRINTERMAPPING obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "Printer_Mapping_Update",
                    obj.Station_ID,
                    obj.Store_ID,
                    obj.LocalPort,
                    obj.NetworkPort,
                    obj.PrinterName,
                    obj.Details,
                    obj.Disabled,
                    obj.Two_Color_Printing,
                    obj.CutReceipt,
                    obj.LineFeedsBeforeCut
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public PRINTERMAPPING Printer_Mapping_Get(string PrinterName)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Printer_Mapping_Get", PrinterName);
                return MapPRINTERMAPPING(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PRINTERMAPPING Printer_Mapping_Getby(string station,string PrinterName)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Printer_Mapping_Getby",station, PrinterName);
                return MapPRINTERMAPPING(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Printer_Mapping_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Printer_Mapping_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
