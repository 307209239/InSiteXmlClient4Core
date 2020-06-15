namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 请求扩展
    /// </summary>
    public interface ICsiRequestSelectionValuesEx : ICsiXmlElement
    {
        /// <summary>
        /// 清空参数
        /// </summary>
        void ClearParameters();
        /// <summary>
        /// 创建查询参数
        /// </summary>
        /// <returns></returns>
        ICsiQueryParameters CreateQueryParameters();
        /// <summary>
        /// 请求记录数量
        /// </summary>
        /// <returns></returns>
        bool GetRequestRecordCount();
        /// <summary>
        /// 获取结果数
        /// </summary>
        /// <returns></returns>
        long GetResultsetSize();
        /// <summary>
        /// 开始行
        /// </summary>
        /// <returns></returns>
        long GetStartRow();
        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="val">值</param>
        void SetParameter(string name, string val);
        /// <summary>
        /// 设置请求记录的数量
        /// </summary>
        /// <param name="val"></param>
        void SetRequestRecordCount(bool val);
        /// <summary>
        /// 设置结果数量
        /// </summary>
        /// <param name="size"></param>
        void SetResultsetSize(long size);
        /// <summary>
        /// 设置开始行
        /// </summary>
        /// <param name="startRow"></param>
        void SetStartRow(long startRow);
    }
}