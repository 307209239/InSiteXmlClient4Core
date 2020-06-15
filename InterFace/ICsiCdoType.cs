namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// CDO 类型
    /// </summary>
    public interface ICsiCdoType
    {
        /// <summary>
        /// CDO 的ID
        /// </summary>
        /// <returns></returns>
        int GetCdoTypeId();
        /// <summary>
        /// CDO 类型名称
        /// </summary>
        /// <returns></returns>
        string GetCdoTypeName();
    }
}