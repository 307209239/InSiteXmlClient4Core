namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 服务
    /// </summary>
    public interface ICsiService : ICsiObject, ICsiField, ICsiXmlElement
    {
        /// <summary>
        /// 错误数据
        /// </summary>
        /// <returns></returns>
        ICsiExceptionData ExceptionData();
        /// <summary>
        /// 获取时间
        /// </summary>
        /// <returns></returns>
        string GetUtcOffset();
        /// <summary>
        /// 输入数据
        /// </summary>
        /// <returns></returns>
        ICsiObject InputData();
        /// <summary>
        /// 请求数据
        /// </summary>
        /// <returns></returns>
        ICsiRequestData RequestData();
        /// <summary>
        /// 返回数据
        /// </summary>
        /// <returns></returns>
        ICsiResponseData ResponseData();
        /// <summary>
        /// 服务类型名称
        /// </summary>
        /// <returns></returns>
        string ServiceTypeName();
        /// <summary>
        /// 设置执行
        /// </summary>
        void SetExecute();
        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="offset"></param>
        void SetUtcOffset(string offset);
        /// <summary>
        /// 使用操作GUID
        /// </summary>

        bool UseTxnGuid { set; }
    }
}