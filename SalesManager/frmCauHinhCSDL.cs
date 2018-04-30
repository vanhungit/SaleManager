using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using System.Data.Sql;
using System.Configuration;
using System.Net.Configuration;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
namespace SalesManager
{
    public partial class frmCauHinhCSDL : DevExpress.XtraEditors.XtraForm
    {
        int flag = 0;
        public frmCauHinhCSDL()
        {
            InitializeComponent();
        }
        #region Database Config
        public void Create_Xml(string IP_Address, string Database_Name, string UserName, string PassWord)
        {
            XmlTextWriter writer = new XmlTextWriter("Config_Data.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Table");
            createNode(IP_Address, Database_Name, UserName, PassWord,radioGroup1.SelectedIndex.ToString(),writer);
            //createNode(UserName, writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            //MessageBox.Show("XML File created ! ");

        }
        private void createNode(string IP_Address,string Database_Name,string UserName, string PassWord, string Type_User, XmlTextWriter writer)
        {
            writer.WriteStartElement("ConfigCSDL");
            writer.WriteStartElement("IPAddress");
            writer.WriteString(IP_Address);
            writer.WriteEndElement();
            writer.WriteStartElement("DatabseName");
            writer.WriteString(Database_Name);
            writer.WriteEndElement();
            writer.WriteStartElement("UserName");
            writer.WriteString(UserName);
            writer.WriteEndElement();
            writer.WriteStartElement("PassWord");
            writer.WriteString(PassWord);
            writer.WriteEndElement();
            writer.WriteStartElement("Type_User");
            writer.WriteString(Type_User);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
        #endregion
        #region ReadXML
        public void ReadXml()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            FileStream fs = new FileStream("Config_Data.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("ConfigCSDL");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                //xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                if (xmlnode[i].ChildNodes.Item(4).InnerText.Trim() == "1")
                {
                    cboserver.Items.Add(xmlnode[i].ChildNodes.Item(0).InnerText.Trim());
                    cboserver.Text = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    radioGroup1.SelectedIndex = 1;
                    txtTaiKhoan.Text = xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                    txtMatKhau.Text = xmlnode[i].ChildNodes.Item(3).InnerText.Trim();
                    cboDuLieu.Properties.Items.Add(xmlnode[i].ChildNodes.Item(1).InnerText.Trim());
                    cboDuLieu.Text = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();

                }
                else if (xmlnode[i].ChildNodes.Item(4).InnerText.Trim() == "0")
                {
                    cboserver.Items.Add(xmlnode[i].ChildNodes.Item(0).InnerText.Trim());
                    cboserver.Text = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    radioGroup1.SelectedIndex = 0;
                    cboDuLieu.Properties.Items.Add(xmlnode[i].ChildNodes.Item(1).InnerText.Trim());
                    cboDuLieu.Text = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                }
            }
            fs.Close();
        }
        #endregion
        
        public void CreateNodes(TreeList tl,string name)
        {
            tl.BeginUnboundLoad();
            tl.AppendNode(new object[] { name }, tl.FocusedNode);
            tl.EndUnboundLoad();
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            //MessageBox.Show(treeList1.Nodes[treeList1.FocusedNode.Id].GetDisplayText(0));
            //MessageBox.Show(treeList1.FocusedNode.GetDisplayText(0));
            if ((treeList1.FocusedNode.Id.ToString() == "1") && flag == 0)
            {
                string myServer = Environment.MachineName;
                DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
                for (int i = 0; i < servers.Rows.Count; i++)
                {
                    CreateNodes(treeList1, servers.Rows[i]["ServerName"].ToString());
                    cboserver.Items.Add(servers.Rows[i]["ServerName"].ToString());
                    cboserver.Text = servers.Rows[i]["ServerName"].ToString();
                }
                flag = 1;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if ((cboserver.Text != "") && (cboDuLieu.Text != ""))
            {
                try
                {
                    System.Configuration.Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    if (radioGroup1.SelectedIndex == 0)
                    {
                        _config.AppSettings.Settings["ConnectionString"].Value = "Server=" + cboserver.Text.Trim() + ";INITIAL CATALOG=" + cboDuLieu.Text.Trim() + ";INTEGRATED SECURITY=true";
                        Create_Xml(cboserver.Text.Trim(), cboDuLieu.Text.Trim(), "", "");

                    }
                    else if (radioGroup1.SelectedIndex == 1)
                    {
                        _config.AppSettings.Settings["ConnectionString"].Value = "Server=" + cboserver.Text.Trim() + ";Database=" + cboDuLieu.Text.Trim() + ";uid=" + txtTaiKhoan.Text.Trim() + ";pwd=" + txtMatKhau.Text.Trim() + "";
                        Create_Xml(cboserver.Text.Trim(), cboDuLieu.Text.Trim(), txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim());

                    }
                    _config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    MessageBox.Show("Lưu Thành Công!", "Thông Báo");

                }
                catch
                {
                    MessageBox.Show("Lưu Thất Bại!", "Thông Báo");
                }
            }
            else
                MessageBox.Show("Chưa Đủ Dữ Liệu!", "Thông Báo");
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                txtTaiKhoan.Enabled = false;
                txtMatKhau.Enabled = false;
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                txtTaiKhoan.Enabled = true;
                txtMatKhau.Enabled = true;
            }
        }

        private void frmCauHinhCSDL_Load(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                txtTaiKhoan.Enabled = false;
                txtMatKhau.Enabled = false;
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                txtTaiKhoan.Enabled = true;
                txtMatKhau.Enabled = true;
            }
            ReadXml();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang dò dữ liệu ...", "Tìm CSDL");
            if (radioGroup1.SelectedIndex == 1)
            {
                var connectionString = string.Format("Data Source={0};User ID={1};Password={2};", cboserver.Text, txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim());
                DataTable databases = null;
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConnection.Open();
                        databases = sqlConnection.GetSchema("Databases");
                        sqlConnection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Không thể kết nối", "Thông báo");
                    }
                }

                if (databases != null)
                {
                    foreach (DataRow row in databases.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            if (item.ToString().Trim() == "SaleExample")
                            {
                                cboDuLieu.Properties.Items.Add(item);
                            }
                        }
                    }
                }
            }
            else if(radioGroup1.SelectedIndex == 0)
            {
                var connectionString = string.Format("SERVER={0};INTEGRATED SECURITY=true;", cboserver.Text);
                DataTable databases = null;
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConnection.Open();
                        databases = sqlConnection.GetSchema("Databases");
                        sqlConnection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Không thể kết nối", "Thông báo");
                    }
                }

                if (databases != null)
                {
                    foreach (DataRow row in databases.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            if (item.ToString().Trim() == "SaleExample")
                            {
                                cboDuLieu.Properties.Items.Add(item);
                            }
                        }
                    }
                }
            }
            WaitDialog.CloseWaitDialog();
             
        }

    }
}
