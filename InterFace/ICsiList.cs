using System;
using System.Collections.Generic;
using System.Text;

namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 集合
    /// </summary>
    public interface ICsiList : ICsiField, ICsiXmlElement
    {
        /// <summary>
        /// 根据索引删除
        /// </summary>
        /// <param name="index"></param>
        void DeleteItemByIndex(int index);
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <returns></returns>
        Array GetListItems();
        /// <summary>
        /// 方法
        /// </summary>
        /// <param name="action"></param>
        void SetListAction(Enum.ListActions action);
        /// <summary>
        /// 端口字段
        /// </summary>
        /// <param name="name"></param>
        void SetProxyField(string name);
    }
}
