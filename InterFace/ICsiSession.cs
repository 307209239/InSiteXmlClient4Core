namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 会话
    /// </summary>
    public interface ICsiSession
    {
        /// <summary>
        /// 创建文档
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ICsiDocument CreateDocument(string name);
        /// <summary>
        /// 查找文档
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ICsiDocument FindDocument(string name);
        /// <summary>
        /// 删除文档
        /// </summary>
        /// <param name="name"></param>
        void RemoveDocument(string name);
        /// <summary>
        /// 会话ID
        /// </summary>

        string SessionId { get; set; }
    }
}