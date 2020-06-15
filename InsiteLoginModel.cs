using System;
using System.Collections.Generic;
using System.Text;

namespace InSiteXmlClient4Core
{
    /// <summary>
    /// 登录实体
    /// </summary>
    public class InsiteLoginModel
    {
        public  string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
