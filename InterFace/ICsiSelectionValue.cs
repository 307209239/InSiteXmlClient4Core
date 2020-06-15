namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 选择的值
    /// </summary>
    public interface ICsiSelectionValue : ICsiXmlElement
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        /// <returns></returns>
        string GetDisplayName();
        /// <summary>
        /// 值
        /// </summary>
        /// <returns></returns>
        string GetValue();
    }
}