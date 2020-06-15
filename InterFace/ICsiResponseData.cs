using System;

namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 返回数据
    /// </summary>
    public interface ICsiResponseData : ICsiXmlElement
    {
        /// <summary>
        /// 获取返回字段
        /// </summary>
        /// <param name="fieldName">名称</param>
        /// <returns></returns>
        ICsiField GetResponseFieldByName(string fieldName);
        /// <summary>
        /// 获取返回字段
        /// </summary>
        /// <returns></returns>
        Array GetResponseFields();
        /// <summary>
        /// 获取会话数据
        /// </summary>
        /// <returns></returns>
        ICsiSubentity GetSessionValues();
    }
}