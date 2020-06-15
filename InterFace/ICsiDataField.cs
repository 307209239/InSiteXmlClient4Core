namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 数据字段
    /// </summary>
    public interface ICsiDataField : ICsiField, ICsiXmlElement
    {
        /// <summary>
        /// 获取格式化后的值
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        string GetFormattedValue(Enum.DataFormats format);
        /// <summary>
        /// 获取值
        /// </summary>
        /// <returns></returns>
        string GetValue();
        /// <summary>
        /// 是否空值
        /// </summary>
        /// <returns></returns>
        bool IsEmptyValue();
        /// <summary>
        /// 设置为空值
        /// </summary>
        void SetEmptyValue();
        /// <summary>
        /// 设置加密值
        /// </summary>
        /// <param name="val"></param>
        void SetEncryptedValue(string val);
        /// <summary>
        /// 设置格式化的值
        /// </summary>
        /// <param name="val"></param>
        /// <param name="format"></param>
        void SetFormattedValue(string val, Enum.DataFormats format);
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="val"></param>
        void SetValue(string val);
    }
}