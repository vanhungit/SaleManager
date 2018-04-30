using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Entity;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors;

namespace SalesManager
{
    public partial class UC_KetThucNhap : UserControl
    {
        int luachon, loai;
        DataTable import;
        public UC_KetThucNhap(DataTable _table, int tuychon, int khuvuc)
        {
            InitializeComponent();
            luachon = tuychon;
            loai = khuvuc;
            import = _table;
            if (khuvuc == 0)//khu vực
            {
                CUSTOMER_GROUP objcustomer = new CUSTOMER_GROUP();
                foreach (DataRow datarow in import.Rows)
                {
                    try
                    {
                        objcustomer.Customer_Group_ID = datarow["Mã Khu Vực"].ToString().Trim();
                        objcustomer.Customer_Group_Name = datarow["Tên Khu Vực"].ToString().Trim();
                        objcustomer.Description = datarow["Ghi Chú"].ToString().Trim();
                        objcustomer.Active = true;
                        int rs = new CUSTOMER_GROUPController().ThemCUSTOMER_GROUP(objcustomer);
                        listBoxControl1.Items.Add("Khu Vực " +datarow["Mã Khu Vực"].ToString().Trim() +" Nhập Thành Công");
                    }
                    catch
                    {
                        listBoxControl1.Items.Add("Khu Vực " + datarow["Mã Khu Vực"].ToString().Trim() + " Nhập Thất Bại");
                        break;
                    }
                }
            }
            else if (khuvuc == 1)//khách hàng
            {
                CUSTOMER objcustomer = new CUSTOMER();
                foreach (DataRow datarow in import.Rows)
                {
                    try
                    {
                        objcustomer.Customer_ID = datarow["Mã Khách Hàng"].ToString().Trim();
                        objcustomer.CustomerName = datarow["Tên Khách Hàng"].ToString().Trim();
                        objcustomer.CustomerAddress = datarow["Địa Chỉ"].ToString().Trim();
                        objcustomer.Tax = datarow["Mã Số Thuế"].ToString().Trim();
                        objcustomer.Tel = datarow["Điện Thoại Bàn"].ToString().Trim();
                        objcustomer.Mobile = datarow["Di Động"].ToString().Trim();
                        objcustomer.Email = datarow["Email"].ToString().Trim();
                        objcustomer.Fax = datarow["Fax"].ToString().Trim();
                        objcustomer.BankAccount = datarow["Số Tài Khoản"].ToString().Trim();
                        objcustomer.BankName = datarow["Tên Ngân Hàng"].ToString().Trim();
                        objcustomer.Contact = datarow["Người Liên Hệ"].ToString().Trim();
                        objcustomer.Position = datarow["Chức Vụ"].ToString().Trim();
                        objcustomer.Description = datarow["Ghi Chú"].ToString().Trim();
                        objcustomer.Website = datarow["Website"].ToString().Trim();
                        objcustomer.Barcode = datarow["Mã Vạch"].ToString().Trim();
                        objcustomer.CreditLimit = double.Parse(datarow["Giới Hạn Nợ"].ToString().Trim());
                        objcustomer.Discount = double.Parse(datarow["Chiết Khấu"].ToString().Trim());
                        objcustomer.NickYM = datarow["Nick Yahoo"].ToString().Trim();
                        objcustomer.NickSky = datarow["Nick Skype"].ToString().Trim();
                        objcustomer.Active = true;
                        int rs = new CUSTOMERController().ThemCUSTOMER(objcustomer);
                        listBoxControl1.Items.Add("Khách Hàng " + datarow["Mã Khách Hàng"].ToString().Trim() + " Nhập Thành Công");
                    }
                    catch
                    {
                        listBoxControl1.Items.Add("Khách Hàng " + datarow["Mã Khách Hàng"].ToString().Trim() + " Nhập Thất Bại");
                        break;
                    }
                }
            }
            else if (khuvuc == 2)// nhà phân phối
            {
                PROVIDER objprovider = new PROVIDER();
                foreach (DataRow datarow in import.Rows)
                {
                    try
                    {
                        objprovider.Customer_ID = datarow["Mã Nhà Cung Cấp"].ToString().Trim();
                        objprovider.Barcode = datarow["Mã Vạch"].ToString().Trim();
                        objprovider.OrderID = 0;
                        objprovider.CustomerName = datarow["Tên Nhà Cung Cấp"].ToString().Trim();
                        objprovider.Customer_Type_ID = "0";
                        //objprovider.Customer_Group_ID = datarow["Mã Khách Hàng"].ToString().Trim();
                        objprovider.CustomerAddress = datarow["Địa Chỉ"].ToString().Trim();
                        objprovider.Tax = datarow["Mã Số Thuế"].ToString().Trim();
                        objprovider.Fax = datarow["Fax"].ToString().Trim();
                        objprovider.Tel = datarow["Điện Thoại Bàn"].ToString().Trim();
                        objprovider.Mobile = datarow["Di Động"].ToString().Trim();
                        objprovider.Contact = datarow["Người Liên Hệ"].ToString().Trim();
                        objprovider.Website = datarow["Website"].ToString().Trim();
                        objprovider.BankAccount = datarow["Số Tài Khoản"].ToString().Trim();
                        objprovider.BankName = datarow["Tên Ngân Hàng"].ToString().Trim();
                        objprovider.CreditLimit = double.Parse(datarow["Giới Hạn Nợ"].ToString().Trim());
                        objprovider.Discount = double.Parse(datarow["Chiết Khấu"].ToString().Trim());
                        objprovider.Position = datarow["Chức Vụ"].ToString().Trim();
                        objprovider.Email = datarow["Email"].ToString().Trim();
                        objprovider.Description = datarow["Ghi Chú"].ToString().Trim();
                        objprovider.Active = true;
                        int rs = new PROVIDERController().PROVIDER_Insert(objprovider);
                        listBoxControl1.Items.Add("Khách Hàng " + datarow["Mã Nhà Cung Cấp"].ToString().Trim() + " Nhập Thành Công");
                    }
                    catch
                    {
                        listBoxControl1.Items.Add("Khách Hàng " + datarow["Mã Nhà Cung Cấp"].ToString().Trim() + " Nhập Thất Bại");
                        break;
                    }
                }
            }
            else if (khuvuc == 3)// nhóm hàng
            {
                PRODUCT_GROUP objproduct = new PRODUCT_GROUP();
                foreach (DataRow datarow in import.Rows)
                {
                    try
                    {
                        objproduct.ProductGroup_ID = datarow["Mã Nhóm Hàng"].ToString().Trim();
                        objproduct.ProductGroup_Name = datarow["Tên Nhóm Hàng"].ToString().Trim();
                        objproduct.Description = datarow["Ghi Chú"].ToString().Trim();
                        objproduct.Active = true;
                        int rs = new PRODUCT_GROUPController().PRODUCT_GROUP_Insert(objproduct);
                        listBoxControl1.Items.Add("Nhóm Hàng " + datarow["Mã Nhóm Hàng"].ToString().Trim() + " Nhập Thành Công");
                    }
                    catch
                    {
                        listBoxControl1.Items.Add("Nhóm Hàng " + datarow["Mã Nhóm Hàng"].ToString().Trim() + " Nhập Thất Bại");
                        break;
                    }
                }
            }
            else if (khuvuc == 4)// kho hàng
            {
                STOCK objstock = new STOCK();
                foreach (DataRow datarow in import.Rows)
                {
                    try
                    {
                        objstock.Stock_ID = datarow["Mã Kho"].ToString().Trim();
                        objstock.Stock_Name = datarow["Tên Kho"].ToString().Trim();
                        objstock.Mobi = datarow["Di Động"].ToString().Trim();
                        objstock.Contact = datarow["Người Liên Hệ"].ToString().Trim();
                        objstock.Address = datarow["Địa Chỉ"].ToString().Trim();
                        objstock.Telephone = datarow["Điện Thoại Bàn"].ToString().Trim();
                        objstock.Fax = datarow["Fax"].ToString().Trim();
                        objstock.Email = datarow["Email"].ToString().Trim();
                        objstock.Description = datarow["Ghi Chú"].ToString().Trim();
                        objstock.Manager = datarow["Người Quản Lý"].ToString().Trim();
                        objstock.Manager = "NV000001";
                        objstock.Active = true;
                        int rs = new STOCKController().STOCK_Insert(objstock);
                        listBoxControl1.Items.Add("Kho Hàng " + datarow["Mã Kho"].ToString().Trim() + " Nhập Thành Công");
                    }
                    catch
                    {
                        listBoxControl1.Items.Add("Kho Hàng " + datarow["Mã Kho"].ToString().Trim() + " Nhập Thất Bại");
                        break;
                    }
                }
            }
            else if (khuvuc == 5)// đơn vị
            {
                UNIT objunit = new UNIT();
                foreach (DataRow datarow in import.Rows)
                {
                    try
                    {
                        objunit.Unit_ID = datarow["Mã Đơn Vị"].ToString().Trim();
                        objunit.Unit_Name = datarow["Tên Đơn Vị"].ToString().Trim();
                        objunit.Description = datarow["Ghi Chú"].ToString().Trim();
                        objunit.Active = true;
                        int rs = new UNITController().UNIT_Insert(objunit);
                        listBoxControl1.Items.Add("Đơn Vị " + datarow["Mã Đơn Vị"].ToString().Trim() + " Nhập Thành Công");
                    }
                    catch
                    {
                        listBoxControl1.Items.Add("Đơn Vị " + datarow["Mã Đơn Vị"].ToString().Trim() + " Nhập Thất Bại");
                        break;
                    }
                }

            }
            else if (khuvuc == 6)// hàng hóa
            {
                PRODUCT objproduct = new PRODUCT();
                byte[] buff = { 1 };
                objproduct.Photo = buff;
                foreach (DataRow datarow in import.Rows)
                {
                    try
                    {
                        //objproduct.Product_Type_ID = datarow["Mã Đơn Vị"].ToString().Trim();
                        //objproduct.Provider_ID = datarow["Mã Đơn Vị"].ToString().Trim();
                        //objproduct.Product_Group_ID = datarow["Mã Đơn Vị"].ToString().Trim();
                        //objproduct.Product_ID = datarow["Mã Đơn Vị"].ToString().Trim();
                        //objproduct.Barcode = txtbarcode.Text;
                        //objproduct.Product_Name = txtten.Text;
                        //objproduct.Unit = (new UNITController().UNIT_GetByName(lookdonvi.Text)).Unit_ID;
                        //objproduct.Origin = txtxuatxu.Text;
                        //objproduct.MinStock = double.Parse(caltoithieu.Text);
                        //objproduct.Customer_ID = (new PROVIDERController().PROVIDER_GetByName(looknhacungcap.Text)).Customer_ID;
                        //objproduct.Org_Price = double.Parse(calcgiamua.Text);
                        //objproduct.Sale_Price = double.Parse(calcgiasi.Text);
                        //objproduct.Retail_Price = double.Parse(calcgiale.Text);
                        //objproduct.UnitRate = 1;
                        //objproduct.Customer_Name = looknhacungcap.Text;
                        //objproduct.ExchangeRate = 1;
                        //objproduct.Active = true;
                        //objproduct.UserID = "US000001";
                        //objproduct.Currency_ID = "VND";
                        //int rs = new PRODUCTController().PRODUCT_Insert_Photo(objproduct);
                        listBoxControl1.Items.Add("Đơn Vị " + datarow["Mã Đơn Vị"].ToString().Trim() + " Nhập Thành Công");
                    }
                    catch
                    {
                        listBoxControl1.Items.Add("Đơn Vị " + datarow["Mã Đơn Vị"].ToString().Trim() + " Nhập Thất Bại");
                        break;
                    }
                }

            }
        }
    }
}
