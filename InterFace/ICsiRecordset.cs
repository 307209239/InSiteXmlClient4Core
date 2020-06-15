using System;

namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 记录集合
    /// </summary>
    public interface ICsiRecordset : ICsiXmlElement
    {
        /// <summary>
        /// 字段集合
        /// </summary>
        /// <returns></returns>
        Array GetFields();
        /// <summary>
        /// 数量
        /// </summary>
        /// <returns></returns>
        long GetRecordCount();
        /// <summary>
        /// 移动到第一个
        /// </summary>
        void MoveFirst();
        /// <summary>
        /// 移动到最后
        /// </summary>
        void MoveLast();
        /// <summary>
        /// 移动到下一个
        /// </summary>
        void MoveNext();
        /// <summary>
        /// 移动到上一个
        /// </summary>
        void MovePrevious();
    }
}