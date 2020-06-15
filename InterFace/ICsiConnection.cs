namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 连接
    /// </summary>
    public interface ICsiConnection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="sessionName"></param>
        /// <returns></returns>
        ICsiSession CreateSession(string userName, string password, string sessionName);
        ICsiSession CreateSessionWithSessionId(string userName, string sessionId, string sessionName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionName"></param>
        /// <returns></returns>
        ICsiSession FindSession(string sessionName);
        /// <summary>
        /// 删除会话
        /// </summary>
        /// <param name="sessionName"></param>
        void RemoveSession(string sessionName);
        /// <summary>
        /// 超时时间
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        int SetConnectionTimeout(int timeout);
        /// <summary>
        /// 提交数据
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        string Submit(string xml);
    }
}