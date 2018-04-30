using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Controller;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using QuanLiBanHang.Entity;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using MicrosoftHelper;
namespace SalesManager
{
    public partial class frmThemVaiTro : Form
    {
        DataTable dtable = new DataTable();
        SYS_GROUP objSYS_GROUP = new SYS_GROUP();
        public frmThemVaiTro()
        {
            InitializeComponent();
            HienThiVaiTro(treeList1);
        }
        public void HienThiVaiTro(TreeList tl)
        {
            tl.BeginUnboundLoad();
            string noderoot_0 = "";
            string noderoot_1 = "";
            string noderoot_2 = "";
            TreeListNode parentForRootNodes = null;
            DataTable TableGroupUser = new SYS_USER_RULEController().SYS_GetbyLevel("admin", "", 0);
            foreach (DataRow datarow in TableGroupUser.Rows)
            {
                noderoot_0 = datarow["Object_Name"].ToString();
                TreeListNode rootNode = tl.AppendNode(new object[] { noderoot_0, true, true, true, true, true, true, true, datarow["Object_ID"].ToString() }, parentForRootNodes);
                DataTable TableUser = new SYS_USER_RULEController().SYS_GetbyLevel("admin", datarow["Object_ID"].ToString(), 1);
                foreach (DataRow datarowchild in TableUser.Rows)
                {
                    noderoot_1 = datarowchild["Object_Name"].ToString();
                    TreeListNode rootNode1 = tl.AppendNode(new object[] { noderoot_1, true, true, true, true, true, true, true, datarowchild["Object_ID"].ToString() }, rootNode);
                    DataTable Tablechild = new SYS_USER_RULEController().SYS_GetbyLevel("admin", datarowchild["Object_ID"].ToString(), 2);
                    foreach (DataRow rowchild in Tablechild.Rows)
                    {
                        noderoot_2 = rowchild["Object_Name"].ToString();
                        TreeListNode rootNode2 = tl.AppendNode(new object[] { noderoot_2, true, true, true, true, true, true, true, rowchild["Object_ID"].ToString() }, rootNode1);
                        DataTable Tablechild2 = new SYS_USER_RULEController().SYS_GetbyLevel("admin", rowchild["Object_ID"].ToString(), 3);
                        foreach (DataRow rowchild2 in Tablechild2.Rows)
                        {
                            tl.AppendNode(new object[] { rowchild2["Object_Name"].ToString(), true, true, true, true, true, true, true, rowchild2["Object_ID"].ToString() }, rootNode2);
                        }
                        tl.EndUnboundLoad();
                    }
                }

            }

        }
        public void InsertUserRule(SYS_USER_RULE obj)
        {
            SqlConnection con = new SqlConnection(DataProvider.ConnectionString);
            con.Open();
            SqlCommand sqlcmd = con.CreateCommand();
            sqlcmd.CommandText = "Insert Into SYS_USER_RULE ( Goup_ID, Object_ID, Rule_ID, AllowAdd, AllowDelete, AllowEdit, AllowAccess, AllowPrint, AllowExport, AllowImport, Active ) values ( @Goup_ID, @Object_ID, @Rule_ID, @AllowAdd, @AllowDelete, @AllowEdit, @AllowAccess, @AllowPrint, @AllowExport, @AllowImport, @Active) ";
            sqlcmd.Parameters.Add("@Goup_ID", SqlDbType.VarChar,20).Value = obj.Goup_ID;
            sqlcmd.Parameters.Add("@Object_ID", SqlDbType.VarChar, 50).Value = obj.Object_ID;
            sqlcmd.Parameters.Add("@Rule_ID", SqlDbType.VarChar, 20).Value = obj.Rule_ID;
            sqlcmd.Parameters.Add("@AllowAdd", SqlDbType.Bit).Value = obj.AllowAdd;
            sqlcmd.Parameters.Add("@AllowDelete", SqlDbType.Bit).Value = obj.AllowDelete;
            sqlcmd.Parameters.Add("@AllowEdit", SqlDbType.Bit).Value = obj.AllowEdit;
            sqlcmd.Parameters.Add("@AllowAccess", SqlDbType.Bit).Value = obj.AllowAccess;
            sqlcmd.Parameters.Add("@AllowPrint", SqlDbType.Bit).Value = obj.AllowPrint;
            sqlcmd.Parameters.Add("@AllowExport", SqlDbType.Bit).Value = obj.AllowExport;
            sqlcmd.Parameters.Add("@AllowImport", SqlDbType.Bit).Value = obj.AllowImport;
            sqlcmd.Parameters.Add("@Active", SqlDbType.Bit).Value = obj.Active;
            sqlcmd.ExecuteNonQuery();
            con.Close();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SYS_USER_RULE objSYS_USER_RULE = new SYS_USER_RULE();
            int rs = -1;
            int rsobj = -1;
            objSYS_GROUP.Group_ID = txtGroup_ID.Text;
            objSYS_GROUP.Group_Name = txtGroup_Name.Text;
            objSYS_GROUP.Group_NameEn = txtGroup_Name.Text;
            objSYS_GROUP.Description = txtGroup_Description.Text;
            objSYS_GROUP.Active = chk_Active.Checked;
            rsobj = new SYS_GROUPController().SYS_GROUP_Insert(objSYS_GROUP);
            for (int i = 0; i < treeList1.Nodes.Count; i++)
            {
                objSYS_USER_RULE.Goup_ID = txtGroup_ID.Text;
                objSYS_USER_RULE.Object_ID = treeList1.Nodes[i][8].ToString();
                objSYS_USER_RULE.Rule_ID = "view";
                objSYS_USER_RULE.AllowAdd = bool.Parse(treeList1.Nodes[i][1].ToString());
                objSYS_USER_RULE.AllowEdit = bool.Parse(treeList1.Nodes[i][2].ToString());
                objSYS_USER_RULE.AllowDelete = bool.Parse(treeList1.Nodes[i][3].ToString());
                objSYS_USER_RULE.AllowPrint = bool.Parse(treeList1.Nodes[i][4].ToString());
                objSYS_USER_RULE.AllowImport = bool.Parse(treeList1.Nodes[i][5].ToString());
                objSYS_USER_RULE.AllowExport = bool.Parse(treeList1.Nodes[i][6].ToString());
                objSYS_USER_RULE.AllowAccess = bool.Parse(treeList1.Nodes[i][7].ToString());
                objSYS_USER_RULE.Active = true;
                rs = new SYS_USER_RULEController().SYS_USER_RULE_Update(objSYS_USER_RULE);
                if (rs < 0)
                {
                    XtraMessageBox.Show("Lưu Thất Bại 1!","Thông Báo");
                    break;
                }
                for(int j = 0;j < treeList1.Nodes[i].Nodes.Count;j++)
                {
                    rs = -1;
                    objSYS_USER_RULE.Goup_ID = txtGroup_ID.Text;
                    objSYS_USER_RULE.Object_ID = treeList1.Nodes[i].Nodes[j][8].ToString();
                    objSYS_USER_RULE.Rule_ID = "view";
                    objSYS_USER_RULE.AllowAdd = bool.Parse(treeList1.Nodes[i].Nodes[j][1].ToString());
                    objSYS_USER_RULE.AllowEdit = bool.Parse(treeList1.Nodes[i].Nodes[j][2].ToString());
                    objSYS_USER_RULE.AllowDelete = bool.Parse(treeList1.Nodes[i].Nodes[j][3].ToString());
                    objSYS_USER_RULE.AllowPrint = bool.Parse(treeList1.Nodes[i].Nodes[j][4].ToString());
                    objSYS_USER_RULE.AllowImport = bool.Parse(treeList1.Nodes[i].Nodes[j][5].ToString());
                    objSYS_USER_RULE.AllowExport = bool.Parse(treeList1.Nodes[i].Nodes[j][6].ToString());
                    objSYS_USER_RULE.AllowAccess = bool.Parse(treeList1.Nodes[i].Nodes[j][7].ToString());
                    objSYS_USER_RULE.Active = true;

                    rs = new SYS_USER_RULEController().SYS_USER_RULE_Update(objSYS_USER_RULE);
                    if (rs < 0)
                    {
                        XtraMessageBox.Show("Lưu Thất Bại 2!", "Thông Báo");
                        break;
                    }
                    for (int k = 0; k < treeList1.Nodes[i].Nodes[j].Nodes.Count; k++)
                    {
                        rs = -1;
                        objSYS_USER_RULE.Goup_ID = txtGroup_ID.Text;
                        objSYS_USER_RULE.Object_ID = treeList1.Nodes[i].Nodes[j].Nodes[k][8].ToString();
                        objSYS_USER_RULE.Rule_ID = "view";
                        objSYS_USER_RULE.AllowAdd = bool.Parse(treeList1.Nodes[i].Nodes[j].Nodes[k][1].ToString());
                        objSYS_USER_RULE.AllowEdit = bool.Parse(treeList1.Nodes[i].Nodes[j].Nodes[k][2].ToString());
                        objSYS_USER_RULE.AllowDelete = bool.Parse(treeList1.Nodes[i].Nodes[j].Nodes[k][3].ToString());
                        objSYS_USER_RULE.AllowPrint = bool.Parse(treeList1.Nodes[i].Nodes[j].Nodes[k][4].ToString());
                        objSYS_USER_RULE.AllowImport = bool.Parse(treeList1.Nodes[i].Nodes[j].Nodes[k][5].ToString());
                        objSYS_USER_RULE.AllowExport = bool.Parse(treeList1.Nodes[i].Nodes[j].Nodes[k][6].ToString());
                        objSYS_USER_RULE.AllowAccess = bool.Parse(treeList1.Nodes[i].Nodes[j].Nodes[k][7].ToString());
                        objSYS_USER_RULE.Active = true;

                        rs = new SYS_USER_RULEController().SYS_USER_RULE_Update(objSYS_USER_RULE);
                        if (rs < 0)
                        {
                            XtraMessageBox.Show("Lưu Thất Bại 3!", "Thông Báo");
                            break;
                        }
                        for (int l = 0; l < treeList1.Nodes[i].Nodes[j].Nodes[k].Nodes.Count; l++)
                        {
                            rs = -1;
                            objSYS_USER_RULE.Goup_ID = txtGroup_ID.Text;
                            objSYS_USER_RULE.Object_ID = treeList1.Nodes[i].Nodes[j].Nodes[k].Nodes[l][8].ToString();
                            objSYS_USER_RULE.Rule_ID = "view";
                            objSYS_USER_RULE.AllowAdd = bool.Parse(treeList1.Nodes[i].Nodes[j].Nodes[k].Nodes[l][1].ToString());
                            objSYS_USER_RULE.AllowEdit = bool.Parse(treeList1.Nodes[i].Nodes[j].Nodes[k].Nodes[l][2].ToString());
                            objSYS_USER_RULE.AllowDelete = bool.Parse(treeList1.Nodes[i].Nodes[j].Nodes[k].Nodes[l][3].ToString());
                            objSYS_USER_RULE.AllowPrint = bool.Parse(treeList1.Nodes[i].Nodes[j].Nodes[k].Nodes[l][4].ToString());
                            objSYS_USER_RULE.AllowImport = bool.Parse(treeList1.Nodes[i].Nodes[j].Nodes[k].Nodes[l][5].ToString());
                            objSYS_USER_RULE.AllowExport = bool.Parse(treeList1.Nodes[i].Nodes[j].Nodes[k].Nodes[l][6].ToString());
                            objSYS_USER_RULE.AllowAccess = bool.Parse(treeList1.Nodes[i].Nodes[j].Nodes[k].Nodes[l][7].ToString());
                            objSYS_USER_RULE.Active = true;

                            rs = new SYS_USER_RULEController().SYS_USER_RULE_Update(objSYS_USER_RULE);
                            if (rs < 0)
                            {
                                XtraMessageBox.Show("Lưu Thất Bại 4!", "Thông Báo");
                                break;
                            }
                        }
                    }
                }
                
            }
            XtraMessageBox.Show("Lưu thành công!");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

      
    }
}
