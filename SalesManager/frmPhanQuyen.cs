using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using QuanLiBanHang.Controller;
using QuanLiBanHang.Entity;
using System.Data.SqlClient;
using MicrosoftHelper;
using System.Xml;
using System.IO;
namespace SalesManager
{
    public partial class frmPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        SYS_USER objuser = new SYS_USER();
        public frmPhanQuyen()
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Phân quyền nhân viên");
            InitializeComponent();
            ReadXml_User();
            HienThiPhanQuyen(treeList2);
            HienThiVaiTro(treeList1,objuser.Group_ID);
            SqlDataAdapter AdapterGroupUser = new SqlDataAdapter("SELECT * from SYS_GROUP", DataProvider.ConnectionString);
            SqlDataAdapter AdapterUser = new SqlDataAdapter("select u.Group_ID, u.UserName, g.Group_Name, u.Description, u.Active from SYS_USER u, SYS_GROUP g where u.Group_ID = g.Group_ID ", DataProvider.ConnectionString);
            DataSet dataSet11 = new DataSet();
            AdapterGroupUser.Fill(dataSet11, "SYS_GROUP");
            AdapterUser.Fill(dataSet11, "SYS_USER");
            DataColumn keyColumn = dataSet11.Tables["SYS_GROUP"].Columns["Group_ID"];
            DataColumn foreignKeyColumn = dataSet11.Tables["SYS_USER"].Columns["Group_ID"];
            dataSet11.Relations.Add("Test", keyColumn, foreignKeyColumn);
            gridControl1.DataSource = dataSet11.Tables["SYS_GROUP"];
            gridControl1.ForceInitialize();
            gridControl1.LevelTree.Nodes.Add("Test", gridView2);
            gridView2.PopulateColumns(dataSet11.Tables["SYS_USER"]);
            gridView2.Columns["Group_ID"].VisibleIndex = -1;
            gridView2.Columns["Group_ID"].Caption = "Mã Nhóm";
            gridView2.Columns["UserName"].Caption = "Tên Đăng Nhập";
            gridView2.Columns["Group_Name"].Caption = "Vai Trò";
            gridView2.Columns["Description"].Caption = "Diễn Giải";
            gridView2.Columns["Active"].Caption = "Kích Hoạt";
            WaitDialog.CloseWaitDialog();
 
        }
        public void ReadXml_User()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            FileStream fs = new FileStream("account.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("account");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                //xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                //if (xmlnode[i].ChildNodes.Item(2).InnerText.Trim() == "True")
                {
                    objuser = new SYS_USERController().SYS_USER_Get_By_UserName(xmlnode[i].ChildNodes.Item(0).InnerText.Trim());
                }
            }
            fs.Close();
        }
        private void CreateColumns(TreeList tl)
        {
            // Create three columns.
            tl.BeginUpdate();
            tl.Columns.Add();
            tl.Columns[0].Caption = "Vai Trò Và Người Dùng";
            tl.Columns[0].VisibleIndex = 0;
            tl.EndUpdate();
        }

        private void CreateNodes(TreeList tl)
        {
            tl.BeginUnboundLoad();
            // Create a root node .
            TreeListNode parentForRootNodes = null;
            TreeListNode rootNode = tl.AppendNode(
                new object[] { "Quản Trị Hệ Thống" },
                parentForRootNodes);
            // Create a child of the rootNode
            tl.AppendNode(new object[] { "admin" }, rootNode);
            // Creating more nodes
            // ...
            TreeListNode rootNode2 = tl.AppendNode(
                new object[] { "User" },
                parentForRootNodes);
            // Create a child of the rootNode
            tl.AppendNode(new object[] { "vanhungbk" }, rootNode2);
            tl.EndUnboundLoad();
        }
        public void InitPhanQuyen(string Group_Name)
        {
            SqlDataAdapter AdapterGroupUser = new SqlDataAdapter("SELECT * from SYS_GROUP where Group_Name = N' " + Group_Name.Trim() + "'", DataProvider.ConnectionString);
            SqlDataAdapter AdapterUser = new SqlDataAdapter("select u.Group_ID, u.UserName, g.Group_Name, u.Description, u.Active from SYS_USER u, SYS_GROUP g where u.Group_ID = g.Group_ID and Group_Name = N' " + Group_Name.Trim() + "'", DataProvider.ConnectionString);
            DataSet dataSet11 = new DataSet();
            AdapterGroupUser.Fill(dataSet11, "SYS_GROUP");
            AdapterUser.Fill(dataSet11, "SYS_USER");
            DataColumn keyColumn = dataSet11.Tables["SYS_GROUP"].Columns["Group_ID"];
            DataColumn foreignKeyColumn = dataSet11.Tables["SYS_USER"].Columns["Group_ID"];
            dataSet11.Relations.Add("Test", keyColumn, foreignKeyColumn);
            gridControl1.DataSource = dataSet11.Tables["SYS_GROUP"];
            gridControl1.ForceInitialize();
            gridControl1.LevelTree.Nodes.Add("Test", gridView2);
            gridView2.PopulateColumns(dataSet11.Tables["SYS_USER"]);
            gridView2.Columns["Group_ID"].VisibleIndex = -1;
            gridView2.Columns["Group_ID"].Caption = "Mã Nhóm";
            gridView2.Columns["UserName"].Caption = "Tên Đăng Nhập";
            gridView2.Columns["Group_Name"].Caption = "Vai Trò";
            gridView2.Columns["Description"].Caption = "Diễn Giải";
            gridView2.Columns["Active"].Caption = "Kích Hoạt";
        }
        public void InitPhanQuyen_UserName(string UserName)
        {
            gridControl1.RefreshDataSource();
            SqlDataAdapter AdapterGroupUser = new SqlDataAdapter("SELECT * from SYS_GROUP ", DataProvider.ConnectionString);
            SqlDataAdapter AdapterUser = new SqlDataAdapter("select u.Group_ID, u.UserName, g.Group_Name, u.Description, u.Active from SYS_USER u, SYS_GROUP g where u.Group_ID = g.Group_ID and UserName ='" + UserName + "'", DataProvider.ConnectionString);
            DataSet dataSet11 = new DataSet();
            AdapterGroupUser.Fill(dataSet11, "SYS_GROUP");
            AdapterUser.Fill(dataSet11, "SYS_USER");
            DataColumn keyColumn = dataSet11.Tables["SYS_GROUP"].Columns["Group_ID"];
            DataColumn foreignKeyColumn = dataSet11.Tables["SYS_USER"].Columns["Group_ID"];
            dataSet11.Relations.Add("Test", keyColumn, foreignKeyColumn);
            gridControl1.DataSource = dataSet11.Tables["SYS_GROUP"];
            gridControl1.ForceInitialize();
            gridControl1.LevelTree.Nodes.Add("Test", gridView2);
            gridView2.PopulateColumns(dataSet11.Tables["SYS_USER"]);
            gridView2.Columns["Group_ID"].VisibleIndex = -1;
            gridView2.Columns["Group_ID"].Caption = "Mã Nhóm";
            gridView2.Columns["UserName"].Caption = "Tên Đăng Nhập";
            gridView2.Columns["Group_Name"].Caption = "Vai Trò";
            gridView2.Columns["Description"].Caption = "Diễn Giải";
            gridView2.Columns["Active"].Caption = "Kích Hoạt";
            gridControl1.Refresh();
        }
        public void HienThiPhanQuyen(TreeList tl)
        {
            tl.BeginUnboundLoad();
            string noderoot = "";
            TreeListNode parentForRootNodes = null;
            DataTable TableGroupUser = new SYS_GROUPController().SYS_GROUP_GetList();
            foreach (DataRow datarow in TableGroupUser.Rows)
            {
                noderoot = datarow["Group_Name"].ToString();
                TreeListNode rootNode = tl.AppendNode(new object[] { noderoot, datarow["Group_ID"].ToString() }, parentForRootNodes);
                DataTable TableUser = new SYS_USERController().SYS_USER_GetGroupID(datarow["Group_ID"].ToString());
                foreach (DataRow datarowchild in TableUser.Rows)
                {
                    tl.AppendNode(new object[] { datarowchild["UserName"].ToString(), datarowchild["UserID"].ToString() }, rootNode);
                }
                tl.EndUnboundLoad();
            }
        }
        public void HienThiVaiTro(TreeList tl,string Group_ID)
        {
            tl.BeginUnboundLoad();
            string noderoot_0 = "";
            string noderoot_1 = "";
            string noderoot_2 = "";
            TreeListNode parentForRootNodes = null;
            DataTable TableGroupUser = new SYS_USER_RULEController().SYS_GetbyLevel(Group_ID, "", 0);
            foreach (DataRow datarow in TableGroupUser.Rows)
            {
                noderoot_0 = datarow["Object_Name"].ToString();
                TreeListNode rootNode = tl.AppendNode(new object[] { noderoot_0, bool.Parse(datarow["AllowAdd"].ToString()), bool.Parse(datarow["AllowEdit"].ToString()), bool.Parse(datarow["AllowDelete"].ToString()), bool.Parse(datarow["AllowPrint"].ToString()), bool.Parse(datarow["AllowImport"].ToString()), bool.Parse(datarow["AllowExport"].ToString()), bool.Parse(datarow["AllowAccess"].ToString()), datarow["Object_ID"].ToString() }, parentForRootNodes);
                DataTable TableUser = new SYS_USER_RULEController().SYS_GetbyLevel(Group_ID, datarow["Object_ID"].ToString(), 1);
                foreach (DataRow datarowchild in TableUser.Rows)
                {
                    noderoot_1 = datarowchild["Object_Name"].ToString();
                    TreeListNode rootNode1 = tl.AppendNode(new object[] { noderoot_1, bool.Parse(datarowchild["AllowAdd"].ToString()), bool.Parse(datarowchild["AllowEdit"].ToString()), bool.Parse(datarowchild["AllowDelete"].ToString()), bool.Parse(datarowchild["AllowPrint"].ToString()), bool.Parse(datarowchild["AllowImport"].ToString()), bool.Parse(datarowchild["AllowExport"].ToString()), bool.Parse(datarowchild["AllowAccess"].ToString()), datarowchild["Object_ID"].ToString() }, rootNode);
                    DataTable Tablechild = new SYS_USER_RULEController().SYS_GetbyLevel(Group_ID, datarowchild["Object_ID"].ToString(), 2);
                    foreach (DataRow rowchild in Tablechild.Rows)
                    {
                        noderoot_2 = rowchild["Object_Name"].ToString();
                        TreeListNode rootNode2 = tl.AppendNode(new object[] { noderoot_2, bool.Parse(rowchild["AllowAdd"].ToString()), bool.Parse(rowchild["AllowEdit"].ToString()), bool.Parse(rowchild["AllowDelete"].ToString()), bool.Parse(rowchild["AllowPrint"].ToString()), bool.Parse(rowchild["AllowImport"].ToString()), bool.Parse(rowchild["AllowExport"].ToString()), bool.Parse(rowchild["AllowAccess"].ToString()), rowchild["Object_ID"].ToString() }, rootNode1);
                        DataTable Tablechild2 = new SYS_USER_RULEController().SYS_GetbyLevel(Group_ID, rowchild["Object_ID"].ToString(), 3);
                        foreach (DataRow rowchild2 in Tablechild2.Rows)
                        {
                            tl.AppendNode(new object[] { rowchild2["Object_Name"].ToString(), bool.Parse(rowchild2["AllowAdd"].ToString()), bool.Parse(rowchild2["AllowEdit"].ToString()), bool.Parse(rowchild2["AllowDelete"].ToString()), bool.Parse(rowchild2["AllowPrint"].ToString()), bool.Parse(rowchild2["AllowImport"].ToString()), bool.Parse(rowchild2["AllowExport"].ToString()), bool.Parse(rowchild2["AllowAccess"].ToString()), rowchild2["Object_ID"].ToString() }, rootNode2);
                        }
                        tl.EndUnboundLoad();
                    }
                }

            }

        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemVaiTro frm = new frmThemVaiTro();
            frm.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemNguoiDung frm = new frmThemNguoiDung();
            frm.ShowDialog();
        }


        private void treeList2_MouseClick(object sender, MouseEventArgs e)
        {
            if (treeList2.FocusedNode.HasChildren == true)
            {
                InitPhanQuyen(treeList2.FocusedNode.GetDisplayText("Group_Name"));
                //MessageBox.Show(treeList2.FocusedNode.GetDisplayText("Group_Name"));
            }
            else
            {
                InitPhanQuyen_UserName(treeList2.FocusedNode.GetDisplayText("Group_Name"));
                //MessageBox.Show(treeList2.FocusedNode.GetDisplayText("Group_Name"));

            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (treeList2.FocusedNode.Level == 0)
            {
                frmCapNhatPhanQuyen frm = new frmCapNhatPhanQuyen(treeList2.FocusedNode[1].ToString());
                frm.ShowDialog();
            }
            else
            {
                frmCapNhatNguoiDung frm = new frmCapNhatNguoiDung(treeList2.FocusedNode.GetDisplayText("Group_Name"));
                frm.ShowDialog();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (treeList2.FocusedNode.Level == 0)
            {
                if (treeList2.FocusedNode.HasChildren == true)
                {
                    XtraMessageBox.Show("Vui Lòng Xóa Các User Con Trước!","Thông Báo");
                }
                else
                {
                    if (XtraMessageBox.Show("Bạn Muốn Xóa Phân Quyền Này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        int rs = -1;
                        rs = new SYS_GROUPController().SYS_GROUP_Delete(treeList2.FocusedNode[1].ToString());
                        if (rs < 0)
                        {
                            XtraMessageBox.Show("Xóa Thất Bại!", "Thông Báo");
                        }
                        else
                            XtraMessageBox.Show("Xóa Thành Công!", "Thông Báo");
                    }
                }
            }
            else
            {
                if (XtraMessageBox.Show("Bạn Muốn Xóa User Này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int rs = -1;
                    rs = new SYS_USERController().SYS_USER_Delete(treeList2.FocusedNode[1].ToString());
                    if (rs < 0)
                    {
                        XtraMessageBox.Show("Xóa Thất Bại!", "Thông Báo");
                    }
                    else
                        XtraMessageBox.Show("Xóa Thành Công!", "Thông Báo");
                }

            }
        }

    }
}