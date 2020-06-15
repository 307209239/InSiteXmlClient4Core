using System.Xml;
using InSiteXmlClient4Core.Exceptions;
using InSiteXmlClient4Core.InterFace;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiQueryParameters : CsiParameters, ICsiQueryParameters, ICsiParameters, ICsiXmlElement
    {
        public CsiQueryParameters(ICsiDocument doc, ICsiXmlElement parent) : base(doc, "__queryParameters", parent)
        {
        }

        public CsiQueryParameters(ICsiDocument doc, XmlElement element) : base(doc, element)
        {
            string name = element.Name;
            if (!name.Equals("__queryParameters"))
            {
                string desc = CsiXmlHelper.GetInvalidElement(name) + "(有效元素是: __queryParameters). ";
                throw new CsiClientException(-1L, desc, base.GetType().FullName + ".Constructor()");
            }
        }

        public CsiQueryParameters(ICsiDocument doc, string queryName, ICsiXmlElement element) : this(doc, element)
        {
            base.SetAttribute("__queryName", queryName);
        }
    }
}