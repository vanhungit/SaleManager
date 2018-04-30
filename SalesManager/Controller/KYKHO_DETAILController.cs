using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using System.Data;
using SalesManager.Entity;

namespace SalesManager.Controller
{
    public class KYKHO_DETAILController
    {
        private List<KYKHO_DETAIL> MapADJUSTMENT_DETAIL(DataTable dt)
        {
            List<KYKHO_DETAIL> rs = new List<KYKHO_DETAIL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KYKHO_DETAIL obj = new KYKHO_DETAIL();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid(dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("ID_KYKHO"))
                    obj.ID_KYKHO = dt.Rows[i]["ID_KYKHO"].ToString();
                if (dt.Columns.Contains("ProductID"))
                    obj.ProductID = dt.Rows[i]["ProductID"].ToString();
                if (dt.Columns.Contains("ProductName"))
                    obj.ProductName = dt.Rows[i]["ProductName"].ToString();
                if (dt.Columns.Contains("StockID"))
                    obj.StockID = dt.Rows[i]["StockID"].ToString();
                if (dt.Columns.Contains("Unit_ID"))
                    obj.Unit_ID = dt.Rows[i]["Unit_ID"].ToString();
                if (dt.Columns.Contains("ProductGroupID"))
                    obj.ProductGroupID = (dt.Rows[i]["ProductGroupID"].ToString());
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
    }
}
