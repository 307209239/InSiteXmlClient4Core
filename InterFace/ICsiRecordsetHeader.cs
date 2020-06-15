using System;

namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 记录集合头部
    /// </summary>
    public interface ICsiRecordsetHeader : ICsiXmlElement
    {
        /// <summary>
        /// 列集合
        /// </summary>
        /// <returns></returns>
        Array GetColumns();
        /// <summary>
        /// 数量
        /// </summary>
        /// <returns></returns>
        long GetCount();
    }
}