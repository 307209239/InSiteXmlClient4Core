namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 参数
    /// </summary>
    public interface ICsiParameters : ICsiXmlElement
    {
        void ClearAll();
        long GetCount();
        ICsiParameter GetParameterByName(string name);
        void RemoveParameterByName(string name);
        void SetParameter(string name, string val);
    }
}