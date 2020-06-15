namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// NDO 类型
    /// </summary>
    public interface ICsiNamedObject : ICsiObject, ICsiField, ICsiXmlElement
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        string GetRef();
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="name"></param>
        void SetRef(string name);
    }
}