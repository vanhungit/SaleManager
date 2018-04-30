using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Data;
using System.Xml;
using System.IO;

namespace SalesManager
{
    class MobilityNetwork
    {
        static int upCount = 0;
        static object lockObj = new object();
        const bool resolveNames = true;
        DataTable dtable = new DataTable();
        public DataTable ViewDataTable()
        {
            WaitDialog.CreateWaitDialog("Đang dò dữ liệu ...", "Máy Kiểm Kê");
            dtable.Columns.Add("IP_Address");
            dtable.Columns.Add("MobileName");
            dtable.Columns.Add("ThoiGian");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string ipBase = "192.168.0.";
            for (int i = 1; i < 255; i++)
            {
                //for (int j = 1; j < 4; j++)
                {
                    string ip = ipBase + i.ToString();
                    //string ip = "192.168.43.34";
                    Ping p = new Ping();
                    p.PingCompleted += new PingCompletedEventHandler(p_PingCompleted);
                    //countdown.AddCount();
                    p.SendAsync(ip, 2000, ip);
                }
            }
            //countdown.Signal();
            //countdown.Wait();
            sw.Stop();
            TimeSpan span = new TimeSpan(sw.ElapsedTicks);
            WaitDialog.CloseWaitDialog();
            return dtable;
        }
        public  void p_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            string ip = (string)e.UserState;
            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {
                if (resolveNames)
                {
                    string name;
                    try
                    {
                        IPHostEntry hostEntry = Dns.GetHostEntry(ip);
                        name = hostEntry.HostName;
                    }
                    catch (SocketException ex)
                    {
                        name = "?";
                    }
                    DataRow r = dtable.NewRow();
                    r[0] = ip;
                    r[1] = name;
                    r[2] = e.Reply.RoundtripTime;
                    dtable.Rows.Add(r);
                    //Console.WriteLine("{0} ({1}) is up: ({2} ms)", ip, name, e.Reply.RoundtripTime);
                }
                else
                {
                    DataRow r = dtable.NewRow();
                    r[0] = ip;
                    r[1] = "";
                    r[2] = e.Reply.RoundtripTime;
                    dtable.Rows.Add(r);
                    //Console.WriteLine("{0} is up: ({1} ms)", ip, e.Reply.RoundtripTime);
                }
                lock (lockObj)
                {
                    upCount++;
                }
            }
            else if (e.Reply == null)
            {
                //Console.WriteLine("Pinging {0} failed. (Null Reply object?)", ip);
            }
            //countdown.Signal();
        }
        public string ServerName()
        {
            string Server_Name = "";
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
                    Server_Name = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    //barStaticItemDatabase.Caption = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                }
                else if (xmlnode[i].ChildNodes.Item(4).InnerText.Trim() == "0")
                {
                    Server_Name = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    //barStaticItemDatabase.Caption = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                }
            }
            fs.Close();
            return Server_Name;
        }
        public string DatabaseName()
        {
            string Database_Name = "";
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
                    Database_Name = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                }
                else if (xmlnode[i].ChildNodes.Item(4).InnerText.Trim() == "0")
                {
                    Database_Name = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                }
            }
            fs.Close();
            return Database_Name;
        }
        public string GetComputerName()
        {
            return System.Environment.MachineName;
        }
        public string GetIP()
        {
            return Dns.GetHostAddresses(Dns.GetHostName()).Where(address => address.AddressFamily == AddressFamily.InterNetwork).First().ToString();
        }
    }
}
