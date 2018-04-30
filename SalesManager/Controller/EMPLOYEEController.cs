using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class EMPLOYEEController
    {
        private List<EMPLOYEE> MapEmployee(DataTable dt)
        {
            List<EMPLOYEE> rs = new List<EMPLOYEE>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EMPLOYEE obj = new EMPLOYEE();
                if (dt.Columns.Contains("Employee_ID"))
                    obj.Employee_ID = dt.Rows[i]["Employee_ID"].ToString();
                if (dt.Columns.Contains("FirtName"))
                    obj.FirstName = dt.Rows[i]["FirtName"].ToString();
                if (dt.Columns.Contains("LastName"))
                    obj.LastName = dt.Rows[i]["LastName"].ToString();
                if (dt.Columns.Contains("Employee_Name"))
                    obj.Employee_Name = dt.Rows[i]["Employee_Name"].ToString();
                if (dt.Columns.Contains("Alias"))
                    obj.Alias = dt.Rows[i]["Alias"].ToString();
                if (dt.Columns.Contains("Sex"))
                    obj.Sex = bool.Parse(dt.Rows[i]["Sex"].ToString());
                if (dt.Columns.Contains("Address"))
                    obj.Address = dt.Rows[i]["Address"].ToString();
                if (dt.Columns.Contains("Country_ID"))
                    obj.CountryID = dt.Rows[i]["Country_ID"].ToString();
                if (dt.Columns.Contains("H_Tel"))
                    obj.H_Tel = dt.Rows[i]["H_Tel"].ToString();
                if (dt.Columns.Contains("O_Tel"))
                    obj.O_Tel = dt.Rows[i]["O_Tel"].ToString();
                if (dt.Columns.Contains("Mobile"))
                    obj.Mobile = dt.Rows[i]["Mobile"].ToString();
                if (dt.Columns.Contains("Fax"))
                    obj.Fax = dt.Rows[i]["Fax"].ToString();
                if (dt.Columns.Contains("Email"))
                    obj.Email = dt.Rows[i]["Email"].ToString();
                if (dt.Columns.Contains("Birthday"))
                    obj.Birthday = DateTime.Parse(dt.Rows[i]["Birthday"].ToString());
                if (dt.Columns.Contains("Married"))
                    obj.Married = int.Parse(dt.Rows[i]["Married"].ToString());
                if (dt.Columns.Contains("Position_ID"))
                    obj.Position_ID = dt.Rows[i]["Position_ID"].ToString();
                if (dt.Columns.Contains("JobTitle_ID"))
                    obj.JobTitle_ID = dt.Rows[i]["JobTitle_ID"].ToString();
                if (dt.Columns.Contains("Branch_ID"))
                    obj.Branch_ID = dt.Rows[i]["Branch_ID"].ToString();
                if (dt.Columns.Contains("Department_ID"))
                    obj.Department_ID = dt.Rows[i]["Department_ID"].ToString();
                if (dt.Columns.Contains("Team_ID"))
                    obj.Team_ID = dt.Rows[i]["Team_ID"].ToString();
                if (dt.Columns.Contains("PersonalTax_ID"))
                    obj.PersionalTax_ID = dt.Rows[i]["PersonalTax_ID"].ToString();
                if (dt.Columns.Contains("City_ID"))
                    obj.City_ID = dt.Rows[i]["City_ID"].ToString();
                if (dt.Columns.Contains("District_ID"))
                    obj.District_ID = dt.Rows[i]["District_ID"].ToString();
                if (dt.Columns.Contains("Manager_ID"))
                    obj.Manager_ID = dt.Rows[i]["Manager_ID"].ToString();
                if (dt.Columns.Contains("EmployeeType"))
                    obj.EmployeeType = int.Parse(dt.Rows[i]["EmployeeType"].ToString());
                if (dt.Columns.Contains("BasicSalary"))
                    obj.BasicSalary = double.Parse(dt.Rows[i]["BasicSalary"].ToString());
                if (dt.Columns.Contains("Advance"))
                    obj.Advance = double.Parse(dt.Rows[i]["Advance"].ToString());
                if (dt.Columns.Contains("AdvanceOther"))
                    obj.AdvanceOther = double.Parse(dt.Rows[i]["AdvanceOther"].ToString());
                if (dt.Columns.Contains("Commission"))
                    obj.Commission = double.Parse(dt.Rows[i]["Commission"].ToString());
                if (dt.Columns.Contains("Discount"))
                    obj.Discount = double.Parse(dt.Rows[i]["Discount"].ToString());
                if (dt.Columns.Contains("ProfitRate"))
                    obj.ProfitRate = double.Parse(dt.Rows[i]["ProfitRate"].ToString());
                if (dt.Columns.Contains("IsPublic"))
                    obj.IsPublic = bool.Parse(dt.Rows[i]["IsPublic"].ToString());
                if (dt.Columns.Contains("CreatedBy"))
                    obj.CreatedBy = dt.Rows[i]["CreatedBy"].ToString();
                if (dt.Columns.Contains("CreatedDate"))
                    obj.CreateDate = DateTime.Parse(dt.Rows[i]["CreatedDate"].ToString());
                if (dt.Columns.Contains("ModifiedBy"))
                    obj.ModifiedBy = dt.Rows[i]["ModifiedBy"].ToString();
                if (dt.Columns.Contains("ModifiedDate"))
                    obj.ModifiedDate = DateTime.Parse(dt.Rows[i]["ModifiedDate"].ToString());
                if (dt.Columns.Contains("OwnerID"))
                    obj.OwnerID = dt.Rows[i]["OwnerID"].ToString();
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = int.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <returns></returns>
        public DataTable LayDSNhanVien()
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "EMPLOYEE_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Them Nhan Vien
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int ThemNhanVien(EMPLOYEE obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "EMPLOYEE_Insert",obj.Employee_ID,obj.FirstName,obj.LastName,obj.Employee_Name,
                    obj.Alias,
                    obj.Sex,
                    obj.Address,
                    obj.CountryID,
                    obj.H_Tel,
                    obj.O_Tel,
                    obj.Mobile,
                    obj.Fax,
                    obj.Email,
                    obj.Birthday,
                    obj.Married,
                    obj.Position_ID,
                    obj.JobTitle_ID,
                    obj.Branch_ID,
                    obj.Department_ID,
                    obj.Team_ID,
                    obj.PersionalTax_ID,
                    obj.City_ID,
                    obj.District_ID,
                    obj.Manager_ID,
                    obj.EmployeeType,
                    obj.BasicSalary,
                    obj.Advance,
                    obj.AdvanceOther,
                    obj.Commission,
                    obj.Discount,
                    obj.ProfitRate,
                    obj.IsPublic,
                    obj.CreatedBy,
                    obj.CreateDate,
                    obj.ModifiedBy,
                    obj.ModifiedDate,
                    obj.OwnerID,
                    obj.Description,
                    obj.Sorted,
                    obj.Active
                    );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        /// <summary>
        /// Lấy tên nhân viên
        /// </summary>
        /// <param name="Employee_ID"></param>
        /// <returns></returns>
        public EMPLOYEE LayTenNhanVien(string Employee_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "EMPLOYEE_Get", Employee_ID);
                return MapEmployee(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EMPLOYEE EMPLOYEE_GetbyName(string Employee_Name)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "EMPLOYEE_GetbyName", Employee_Name);
                return MapEmployee(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Tìm mã nhân viên top 1
        /// </summary>
        /// <returns></returns>
        public EMPLOYEE Employee_Top1()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Employee_Top1");
                return MapEmployee(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="Employee_ID"></param>
        /// <returns></returns>
        public int XoaNhanVien(string Employee_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "EMPLOYEE_Delete", Employee_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy danh sách nhân viên theo phòng ban
        /// </summary>
        /// <param name="PhongBan"></param>
        /// <returns></returns>
        public List<EMPLOYEE> LayDSNVTheoPhongBan(string PhongBan)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "EMPLOYEE_GetListDepartment_ID", PhongBan);
                return MapEmployee(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Tìm kiếm nhân viên
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<EMPLOYEE> TimKiemNhanVien(EMPLOYEE obj)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "EMPLOYEE_GetListDepartment_ID",obj.FirstName,obj.LastName,obj.Employee_Name,
                    obj.Alias,
                    obj.Sex,
                    obj.Address,
                    obj.H_Tel,
                    obj.O_Tel,
                    obj.Mobile,
                    obj.Fax,
                    obj.Email,
                    obj.Birthday,
                    obj.Married,
                    obj.EmployeeType,
                    obj.BasicSalary,
                    obj.Advance,
                    obj.AdvanceOther,
                    obj.Commission,
                    obj.Discount,
                    obj.ProfitRate,
                    obj.Description
                    );
                return MapEmployee(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CapNhatNhanVien(EMPLOYEE obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "EMPLOYEE_Update", obj.Employee_ID, obj.FirstName, obj.LastName, obj.Employee_Name,
                    obj.Alias,
                    obj.Sex,
                    obj.Address,
                    obj.CountryID,
                    obj.H_Tel,
                    obj.O_Tel,
                    obj.Mobile,
                    obj.Fax,
                    obj.Email,
                    obj.Birthday,
                    obj.Married,
                    obj.Position_ID,
                    obj.JobTitle_ID,
                    obj.Branch_ID,
                    obj.Department_ID,
                    obj.Team_ID,
                    obj.PersionalTax_ID,
                    obj.City_ID,
                    obj.District_ID,
                    obj.Manager_ID,
                    obj.EmployeeType,
                    obj.BasicSalary,
                    obj.Advance,
                    obj.AdvanceOther,
                    obj.Commission,
                    obj.Discount,
                    obj.ProfitRate,
                    obj.IsPublic,
                    obj.CreatedBy,
                    obj.CreateDate,
                    obj.ModifiedBy,
                    obj.ModifiedDate,
                    obj.OwnerID,
                    obj.Description,
                    obj.Sorted,
                    obj.Active
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
