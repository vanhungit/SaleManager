using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Entity;
using QuanLiBanHang.Controller;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using DevExpress.XtraEditors;

namespace SalesManager
{
    public partial class frmCapNhatPhanQuyen : Form
    {
        SYS_GROUP objSYS_GROUP = new SYS_GROUP();
        public frmCapNhatPhanQuyen(string Group_ID)
        {
            InitializeComponent();
            objSYS_GROUP = new SYS_GROUPController().SYS_GROUP_Get(Group_ID);
            txtGroup_ID.Text = objSYS_GROUP.Group_ID;
            txtGroup_Name.Text = objSYS_GROUP.Group_Name;
            chk_Active.Checked = objSYS_GROUP.Active;
            txtGroup_Description.Text = objSYS_GROUP.Description;
            HienThiVaiTro(treeList1, Group_ID);
        }
        public void HienThiVaiTro(TreeList tl, string Group_ID)
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
            rsobj = new SYS_GROUPController().SYS_GROUP_Update(objSYS_GROUP, objSYS_GROUP.Group_ID);
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
                    XtraMessageBox.Show("Lưu Thất Bại 1!", "Thông Báo");
                    break;
                }
                for (int j = 0; j < treeList1.Nodes[i].Nodes.Count; j++)
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
