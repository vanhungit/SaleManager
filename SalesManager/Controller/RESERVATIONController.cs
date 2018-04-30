using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SalesManager.Entity;

namespace SalesManager.Controller
{
    public class RESERVATIONController
    {
        private List<RESERVATION> MapRESERVATION(DataTable dt)
        {
            List<RESERVATION> rs = new List<RESERVATION>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                RESERVATION obj = new RESERVATION();
                if (dt.Columns.Contains("ID"))
                    obj.ID = dt.Rows[i]["ID"].ToString();
                if (dt.Columns.Contains("RefDate"))
                    obj.RefDate = DateTime.Parse(dt.Rows[i]["RefDate"].ToString());
                if (dt.Columns.Contains("TransferDate"))
                    obj.TransferDate = DateTime.Parse(dt.Rows[i]["TransferDate"].ToString());
                if (dt.Columns.Contains("Ref_OrgNo"))
                    obj.Ref_OrgNo = dt.Rows[i]["Ref_OrgNo"].ToString();
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("RefStatus"))
                    obj.RefStatus = int.Parse(dt.Rows[i]["RefStatus"].ToString());
                if (dt.Columns.Contains("Status"))
                    obj.Status = int.Parse(dt.Rows[i]["Status"].ToString());
                if (dt.Columns.Contains("Department_ID"))
                    obj.Department_ID = dt.Rows[i]["Department_ID"].ToString();
                if (dt.Columns.Contains("Employee_ID"))
                    obj.Employee_ID = (dt.Rows[i]["Employee_ID"].ToString());
                if (dt.Columns.Contains("FromStock_ID"))
                    obj.FromStock_ID = (dt.Rows[i]["FromStock_ID"].ToString());
                if (dt.Columns.Contains("Sender_ID"))
                    obj.Sender_ID = (dt.Rows[i]["Sender_ID"].ToString());
                if (dt.Columns.Contains("ToStock_ID"))
                    obj.ToStock_ID = (dt.Rows[i]["ToStock_ID"].ToString());
                if (dt.Columns.Contains("Receiver_ID"))
                    obj.Receiver_ID = (dt.Rows[i]["Receiver_ID"].ToString());
                if (dt.Columns.Contains("Barcode"))
                    obj.Barcode = dt.Rows[i]["Barcode"].ToString();
                if (dt.Columns.Contains("Branch_ID"))
                    obj.Branch_ID = dt.Rows[i]["Branch_ID"].ToString();
                if (dt.Columns.Contains("SO_ID"))
                    obj.SO_ID = dt.Rows[i]["SO_ID"].ToString();
                if (dt.Columns.Contains("PO_ID"))
                    obj.PO_ID = dt.Rows[i]["PO_ID"].ToString();
                if (dt.Columns.Contains("ProductOrder_ID"))
                    obj.ProductOrder_ID = dt.Rows[i]["ProductOrder_ID"].ToString();          
                if (dt.Columns.Contains("Currency_ID"))
                    obj.Currency_ID = dt.Rows[i]["Currency_ID"].ToString();
                if (dt.Columns.Contains("ExchangeRate"))
                    obj.ExchangeRate = double.Parse(dt.Rows[i]["ExchangeRate"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("IsReview"))
                    obj.IsReview = bool.Parse(dt.Rows[i]["IsReview"].ToString());
                if (dt.Columns.Contains("IsClose"))
                    obj.IsClose = bool.Parse(dt.Rows[i]["IsClose"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = int.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("User_ID"))
                    obj.User_ID = dt.Rows[i]["User_ID"].ToString();
                if (dt.Columns.Contains("CreateBy"))
                    obj.CreateBy = dt.Rows[i]["CreateBy"].ToString();
                if (dt.Columns.Contains("Createdate"))
                    obj.Createdate = DateTime.Parse(dt.Rows[i]["Createdate"].ToString());
                if (dt.Columns.Contains("ModifiedBy"))
                    obj.ModifiedBy = dt.Rows[i]["ModifiedBy"].ToString();
                if (dt.Columns.Contains("ModifiedDate"))
                    obj.ModifiedDate = DateTime.Parse(dt.Rows[i]["ModifiedDate"].ToString());
                //if (dt.Columns.Contains("Timestamp"))
                //obj.Timestamp = DateTime.Parse(dt.Rows[i]["Timestamp"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
    }
}
