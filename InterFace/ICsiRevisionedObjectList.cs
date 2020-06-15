namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// RO 集合
    /// </summary>
    public interface ICsiRevisionedObjectList : ICsiObjectList, ICsiList, ICsiField, ICsiXmlElement
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="revision"></param>
        /// <param name="useRor"></param>
        /// <returns></returns>
        ICsiRevisionedObject AppendItem(string name, string revision, bool useRor);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        ICsiRevisionedObject ChangeItemByIndex(int index);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="revision">版本</param>
        /// <param name="useRor">默认版本</param>
        /// <returns></returns>
        ICsiRevisionedObject ChangeItemByRef(string name, string revision, bool useRor);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="revision">版本</param>
        /// <param name="useRor">默认版本</param>
        void DeleteItemByRef(string name, string revision, bool useRor);
        /// <summary>
        /// 获取RO
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        ICsiRevisionedObject GetItemByIndex(int index);
        /// <summary>
        /// 获取项
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="revision">版本</param>
        /// <param name="useRor">是否默认版本</param>
        /// <returns></returns>
        ICsiRevisionedObject GetItemByRef(string name, string revision, bool useRor);
    }
}