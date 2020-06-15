using System;
using System.Collections.Generic;
using System.Text;

namespace InSiteXmlClient4Core.InterFace
{
    public interface ICsiLabel:ICsiXmlElement
    {
        /// <summary>
        /// 获取默认值
        /// </summary>
        /// <returns></returns>
        string GetDefaultValue();
        /// <summary>
        /// 获取ID
        /// </summary>
        /// <returns></returns>
        int GetLabelId();
        /// <summary>
        /// 获取名称
        /// </summary>
        /// <returns></returns>
        string GetLabelName();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetValue();
    }
}
