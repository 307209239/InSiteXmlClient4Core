using System.Xml;

namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 错误
    /// </summary>
    public interface ICsiExceptionData : ICsiXmlElement
    {
        /// <summary>
        /// 描述
        /// </summary>
        /// <returns></returns>
        string GetDescription();
        /// <summary>
        /// 错误代码
        /// </summary>
        /// <returns></returns>
        int GetErrorCode();
        /// <summary>
        /// 错误参数
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        string GetExceptionParameter(string tagName);
        /// <summary>
        /// 错误参数
        /// </summary>
        /// <returns></returns>
        XmlNodeList GetExceptionParameters();
        /// <summary>
        /// 失败内容
        /// </summary>
        /// <returns></returns>
        string GetFailureContext();
        /// <summary>
        /// 严重程度
        /// </summary>
        /// <returns></returns>
        int GetSeverity();
        /// <summary>
        /// 来源
        /// </summary>
        /// <returns></returns>
        string GetSource();
        /// <summary>
        /// 系统信息
        /// </summary>
        /// <returns></returns>
        string GetSystemMessage();
    }
}