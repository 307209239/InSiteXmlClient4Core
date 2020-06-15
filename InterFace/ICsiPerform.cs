namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 执行事件
    /// </summary>
    public interface ICsiPerform : ICsiXmlElement
    {
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <returns></returns>
        ICsiParameters AddParameters();
    }
}