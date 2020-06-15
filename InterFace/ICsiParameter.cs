using System;
using System.Collections.Generic;
using System.Text;

namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 参数
    /// </summary>
    public interface ICsiParameter:ICsiXmlElement
    {
        string GetValue();
        void SetValue(string val);
    }
}
