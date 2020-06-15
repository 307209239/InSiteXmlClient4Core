namespace InSiteXmlClient4Core.InterFace
{
    public interface ICsiRevisionedObject : ICsiObject, ICsiField, ICsiXmlElement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetName();
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="revision">版本</param>
        /// <param name="useRor">默认版本</param>
        void GetRef(out string name, out string revision, out bool useRor);
        /// <summary>
        /// 版本
        /// </summary>
        /// <returns></returns>
        string GetRevision();
        /// <summary>
        /// 默认版本
        /// </summary>
        /// <returns></returns>
        bool GetUseRor();
        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="revision">版本</param>
        /// <param name="useRor">默认版本</param>
        void SetRef(string name, string revision, bool useRor);
    }
}