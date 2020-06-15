namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 祖安泽值扩展
    /// </summary>
    public interface ICsiSelectionValuesEx : ICsiXmlElement
    {
        /// <summary>
        /// 记录量
        /// </summary>
        /// <returns></returns>
        long GetRecordCount();
        /// <summary>
        /// 获取记录集
        /// </summary>
        /// <returns></returns>
        ICsiRecordset GetRecordset();
        /// <summary>
        /// 获取记录集头部
        /// </summary>
        /// <returns></returns>
        ICsiRecordsetHeader GetRecordsetHeader();
    }
}