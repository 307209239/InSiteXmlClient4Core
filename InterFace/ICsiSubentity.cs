namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 子字段
    /// </summary>
    public interface ICsiSubentity : ICsiObject, ICsiField, ICsiXmlElement
    {
        /// <summary>
        /// 获取父级信息
        /// </summary>
        /// <returns></returns>
        ICsiParentInfo GetParentInfo();
        /// <summary>
        /// 父级信息
        /// </summary>
        /// <returns></returns>
        ICsiParentInfo ParentInfo();
        /// <summary>
        /// 设置父级
        /// </summary>
        /// <param name="id"></param>
        void SetParentId(string id);
    }
}