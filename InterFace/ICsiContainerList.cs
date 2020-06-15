namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 批次集合
    /// </summary>
    public interface ICsiContainerList : ICsiObjectList, ICsiList, ICsiField, ICsiXmlElement
    {
        /// <summary>
        /// 添加项
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        ICsiContainer AppendItem(string name, string level);
        /// <summary>
        /// 更具索引更改
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        ICsiContainer ChangeItemByIndex(int index);
        /// <summary>
        /// 更具名称修改
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        ICsiContainer ChangeItemByRef(string name, string level);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        void DeleteItemByRef(string name, string level);
        /// <summary>
        /// 根据索引获取数据
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        ICsiContainer GetItemByIndex(int index);
        /// <summary>
        /// 根据名称获取数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        ICsiContainer GetItemByRef(string name, string level);
    }
}