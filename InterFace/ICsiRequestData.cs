using System;

namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 请求数据
    /// </summary>
    public interface ICsiRequestData : ICsiXmlElement
    {
        /// <summary>
        /// 请求所有字段
        /// </summary>
        void RequestAllFields();
        /// <summary>
        /// 请求所有字段包含子字段
        /// </summary>
        void RequestAllFieldsRecursive();
        /// <summary>
        /// 请求字段
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        ICsiRequestField RequestField(string fieldName);
        /// <summary>
        /// 请求字段
        /// </summary>
        /// <param name="fields">字段集合</param>
        void RequestFields(Array fields);
        /// <summary>
        /// 请求会话值
        /// </summary>
        void RequestSessionValues();
        /// <summary>
        /// 设置数据格式化模式
        /// </summary>
        /// <param name="mode"></param>
        void SetSerializationMode(Enum.SerializationModes mode);
    }
}