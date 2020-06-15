namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 父级信息
    /// </summary>
    public interface ICsiParentInfo : ICsiXmlElement
    {/// <summary>
    /// 批次
    /// </summary>
    /// <param name="name"></param>
    /// <param name="level"></param>
        void GetContainerRef(out string name, out string level);
        /// <summary>
        /// 名称
        /// </summary>
        /// <returns></returns>
        string GetName();
        /// <summary>
        /// NDO
        /// </summary>
        /// <returns></returns>
        string GetNamedObjectRef();
        /// <summary>
        /// 获取父级ID
        /// </summary>
        string GetParentId();
        /// <summary>
        /// 获取父级信息
        /// </summary>
        ICsiParentInfo GetParentInfo();
        /// <summary>
        /// RO
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="revision">版本</param>
        /// <param name="useRor">是否用默认版本</param>
        void GetRevisionedObjectRef(out string name, out string revision, out bool useRor);
        /// <summary>
        /// 父级信息
        /// </summary>
        ICsiParentInfo ParentInfo();
        /// <summary>
        /// 设置批次
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        void SetContainerRef(string name, string level);
        /// <summary>
        /// 设置名称
        /// </summary>
        /// <param name="name"></param>
        void SetName(string name);
        /// <summary>
        /// 设置NDO
        /// </summary>
        /// <param name="name"></param>
        void SetNamedObjectRef(string name);
        /// <summary>
        /// 设置object ID
        /// </summary>
        /// <param name="Id"></param>
        void SetObjectId(string Id);
        /// <summary>
        /// 设置object 类型
        /// </summary>
        /// <param name="cdoType"></param>
        void SetObjectType(string cdoType);
        /// <summary>
        /// 父级ID
        /// </summary>
        /// <param name="id"></param>
        void SetParentId(string id);
        /// <summary>
        /// 设置RO
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="revision">版本</param>
        /// <param name="useRor">是否使用默认版本</param>
        void SetRevisionedObjectRef(string name, string revision, bool useRor);
    }
}