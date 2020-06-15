namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 子集合
    /// </summary>
    public interface ICsiSubentityList : ICsiObjectList, ICsiList, ICsiField, ICsiXmlElement
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        ICsiSubentity AppendItem();
        /// <summary>
        /// 更改
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        ICsiSubentity ChangeItemByIndex(int index);
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        ICsiSubentity GetItemByIndex(int index);
        /// <summary>
        ///  不设置ListAction
        /// </summary>
        /// <returns></returns>
        ICsiSubentity Item();
    }
}