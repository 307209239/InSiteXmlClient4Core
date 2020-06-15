using System;
using System.Collections.Generic;
using System.Text;

namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 批次接口
    /// </summary>
    public interface ICsiContainer : ICsiObject, ICsiField, ICsiXmlElement
    {
        /// <summary>
        /// 等级
        /// </summary>
        /// <returns></returns>
        string GetLevel();
        /// <summary>
        /// 获取批次名
        /// </summary>
        /// <returns></returns>
        string GetName();
        /// <summary>
        /// 根据名称获取批次
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        void GetRef(out string name, out string level);
        /// <summary>
        /// 设定批次
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        void SetRef(string name, string level);
    }
}
