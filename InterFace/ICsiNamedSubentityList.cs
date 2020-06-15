namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// NamedSubentity集合
    /// </summary>
    public interface ICsiNamedSubentityList : ICsiObjectList, ICsiList, ICsiField, ICsiXmlElement
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ICsiNamedSubentity AppendItem(string name);
        /// <summary>
        /// 更改
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        ICsiNamedSubentity ChangeItemByIndex(int index);
        /// <summary>
        /// 更改
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        ICsiNamedSubentity ChangeItemByName(string name);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        ICsiNamedSubentity DeleteItemByName(string name);
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        ICsiNamedSubentity GetItemByIndex(int index);
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        ICsiNamedSubentity GetItemByName(string name);
    }
}