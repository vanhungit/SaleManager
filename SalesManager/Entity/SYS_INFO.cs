using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace QuanLiBanHang.Entity
{
    public class SYS_INFO
    {
        private string _SysInfo_ID = "";
        public string SysInfo_ID
        {
            get { return _SysInfo_ID; }
            set
            {
                _SysInfo_ID = value;
            }
        }
        private string _Application = "";
        public string Application
        {
            get { return _Application; }
            set
            {
                _Application = value;
            }
        }
        private string _Version = "";
        public string Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
            }
        }
        private int _Type = 0;
        public int Type
        {
            get { return _Type; }
            set
            {
                _Type = value;
            }
        }
        private DateTime _Created = DateTime.Now;
        public DateTime Created
        {
            get { return _Created; }
            set
            {
                _Created = value;
            }
        }
        private string _Description = "";
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
            }
        }
        private int _Interface = 0;
        public int Interface
        {
            get { return _Interface; }
            set
            {
                _Interface = value;
            }
        }
        private string _Guid_ID = "";
        public string Guid_ID
        {
            get { return _Guid_ID; }
            set
            {
                _Guid_ID = value;
            }
        }
        
    }
}
