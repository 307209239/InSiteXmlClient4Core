using System.Xml;
using InSiteXmlClient4Core.Exceptions;
using InSiteXmlClient4Core.InterFace;

namespace InSiteXmlClient4Core.Api
{
    public class CsiParameter : CsiXmlElement, ICsiParameter, ICsiXmlElement
    {
        private XmlElement mElementName;
        private XmlElement mElementValue;

        public CsiParameter(ICsiDocument doc, XmlElement element) : base(doc, element)
        {
            this.mElementName = ((CsiXmlElement)base.FindChildByName("__name")).GetDomElement();
            this.mElementValue = ((CsiXmlElement)base.FindChildByName("__value")).GetDomElement();
        }

        public CsiParameter(ICsiDocument doc, string paramName, ICsiXmlElement parent) : base(doc, "__parameter", parent)
        {
            this.mElementName = new CsiXmlElement(doc, "__name", this).GetDomElement();
            this.mElementValue = new CsiXmlElement(doc, "__value", this).GetDomElement();
            CsiXmlHelper.SetCdataNode(this.mElementName, paramName);
            CsiXmlHelper.SetCdataNode(this.mElementValue, "");
        }

        public virtual string GetValue()
        {
            string data;
            try
            {
                data = (this.mElementValue.FirstChild as XmlCDataSection).Data;
            }
            catch (XmlException exception)
            {
                throw new CsiClientException(-1L, exception, base.GetType().FullName + ".getValue()");
            }
            return data;
        }

        public virtual void SetValue(string val)
        {
            try
            {
                CsiXmlHelper.SetCdataNode(this.mElementValue, val);
            }
            catch (XmlException exception)
            {
                throw new CsiClientException(-1L, exception, base.GetType().FullName + ".setValue()");
            }
        }
    }
}