using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class SYS_COMPANYController
    {
        
            private List<SYS_COMPANY> MapSYS_COMPANY(DataTable dt)
            {
                List<SYS_COMPANY> rs = new List<SYS_COMPANY>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    SYS_COMPANY obj = new SYS_COMPANY();
                    if (dt.Columns.Contains("Company_Id"))
                        obj.Company_Id = dt.Rows[i]["Company_Id"].ToString();
                    if (dt.Columns.Contains("Company"))
                        obj.Company = dt.Rows[i]["Company"].ToString();
                    if (dt.Columns.Contains("Address"))
                        obj.Address = dt.Rows[i]["Address"].ToString();
                    if (dt.Columns.Contains("Tel"))
                        obj.Tel = dt.Rows[i]["Tel"].ToString();
                    if (dt.Columns.Contains("Fax"))
                        obj.Fax = dt.Rows[i]["Fax"].ToString();
                    if (dt.Columns.Contains("WebSite"))
                        obj.WebSite = dt.Rows[i]["WebSite"].ToString();
                    if (dt.Columns.Contains("Email"))
                        obj.Email = dt.Rows[i]["Email"].ToString();
                    if (dt.Columns.Contains("Tax"))
                        obj.Tax = dt.Rows[i]["Tax"].ToString();
                    if (dt.Columns.Contains("Licence"))
                        obj.Licence = dt.Rows[i]["Licence"].ToString();
                    if (dt.Columns.Contains("Photo"))
                        obj.Photo = (byte[])(dt.Rows[i]["Photo"]);

                    rs.Add(obj);
                }
                return rs;
            }
            public int SYS_COMPANY_Insert(SYS_COMPANY obj)
            {
                try
                {
                    return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_COMPANY_Insert",
                        obj.Company_Id,
                        obj.Company,
                        obj.Address,
                        obj.Tel,
                        obj.Fax,
                        obj.WebSite,
                        obj.Email,
                        obj.Tax,
                        obj.Licence,
                        obj.Photo
                    );
                }
                catch
                {
                    //throw ex;
                    return -1;
                }
            }
            public int SYS_COMPANY_Delete(string Company_Id)
            {
                try
                {
                    return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_COMPANY_Delete", Company_Id);
                }
                catch
                {
                    //throw ex;
                    return -1;
                }
            }
            public SYS_COMPANY SYS_COMPANY_Get(string Company_Id)
            {
                DataTable dt = new DataTable();
                try
                {
                    DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_COMPANY_Get", Company_Id);
                    return MapSYS_COMPANY(dt)[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public List<SYS_COMPANY> SYS_COMPANY_GetList()
            {
                DataTable dt = new DataTable();
                try
                {
                    DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_COMPANY_GetList");
                    return MapSYS_COMPANY(dt);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public int SYS_COMPANY_Update(SYS_COMPANY obj, string Company_Id)
            {
                try
                {
                    return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_COMPANY_Update",
                        Company_Id ,
                        obj.Company ,
                        obj.Address,
                        obj.Tel,
                        obj.Fax,
                        obj.WebSite,
                        obj.Email,
                        obj.Tax,
                        obj.Licence,
                        obj.Photo 
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
