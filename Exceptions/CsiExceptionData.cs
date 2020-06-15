using System.Xml;
using InSiteXmlClient4Core.Api;
using InSiteXmlClient4Core.InterFace;

namespace InSiteXmlClient4Core.Exceptions
{
    internal class CsiExceptionData : CsiXmlElement, ICsiExceptionData, ICsiXmlElement
    {
        public CsiExceptionData(ICsiDocument doc, XmlElement domElement) : base(doc, domElement)
        {
        }

        public CsiExceptionData(ICsiDocument doc, string name, ICsiXmlElement parent) : base(doc, name, parent)
        {
        }

        public virtual string GetDescription() =>
            this.GetNodeValue("__errorDescription");

        public virtual int GetErrorCode() =>
            int.Parse(base.GetDomElement().GetElementsByTagName("__errorCode")[0].FirstChild.Value);

        public virtual string GetExceptionParameter(string tagName)
        {
            string str = string.Empty;
            XmlNodeList list = this.GetExceptionParameters();
            foreach (XmlNode node in list)
            {
                if (node.Name == tagName)
                {
                    return node.FirstChild.Value;
                }
            }
            return str;
        }

        public virtual XmlNodeList GetExceptionParameters()
        {
            XmlNodeList elementsByTagName = base.GetDomElement().GetElementsByTagName("__exceptionParameters");
            if (elementsByTagName.Count > 0)
            {
                return elementsByTagName[0].ChildNodes;
            }
            return elementsByTagName;
        }

        public virtual string GetFailureContext() =>
            this.GetNodeValue("__failureContext");

        private string GetNodeValue(string tagName)
        {
            string str = string.Empty;
            XmlNodeList elementsByTagName = base.GetDomElement().GetElementsByTagName(tagName);
            if (elementsByTagName.Count > 0)
            {
                XmlNode firstChild = elementsByTagName[0].FirstChild;
                if (firstChild != null)
                {
                    str = firstChild.Value;
                }
            }
            return str;
        }

        public virtual int GetSeverity() =>
            int.Parse( base.GetDomElement().GetElementsByTagName("__severity")[0].FirstChild.Value);

        public virtual string GetSource() =>
            this.GetNodeValue("__errorSource");

        public virtual string GetSystemMessage() =>
            this.GetNodeValue("__errorSystemMessage");
    }
}