namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// NamedSubentity
    /// </summary>
    public interface ICsiNamedSubentity : ICsiObject, ICsiField, ICsiXmlElement
    {
        /// <summary>
        /// 获取名称
        /// </summary>
        /// <returns></returns>
        string GetName();
        /// <summary>
        /// 获取父信息
        /// </summary>
        /// <returns></returns>
        ICsiParentInfo GetParentInfo();
        /// <summary>
        /// 父信息
        /// </summary>
        /// <returns></returns>
        ICsiParentInfo ParentInfo();
        /// <summary>
        /// 设置名称
        /// </summary>
        /// <param name="name"></param>
        void SetName(string name);
        /// <summary>
        /// 设置父ID
        /// </summary>
        /// <param name="id"></param>
        void SetParentId(string id);
    }
}