namespace InSiteXmlClient4Core.InterFace
{
    public interface ICsiObjectList : ICsiList, ICsiField, ICsiXmlElement
    {
        /// <summary>
        /// 根据ID添加项
        /// </summary>
        /// <param name="instanceId"></param>
        void AppendItemById(string instanceId);
    }
}