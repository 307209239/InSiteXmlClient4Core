namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// NDO 集合
    /// </summary>
    public interface ICsiNamedObjectList : ICsiObjectList, ICsiList, ICsiField, ICsiXmlElement
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ICsiNamedObject AppendItem(string name);
        /// <summary>
        /// 更改
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        ICsiNamedObject ChangeItemByIndex(int index);
        /// <summary>
        /// 更改
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        ICsiNamedObject ChangeItemByName(string name);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="name">名称</param>
        void DeleteItemByName(string name);
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        ICsiNamedObject GetItemByIndex(int index);
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        ICsiNamedObject GetItemByName(string name);
    }
}