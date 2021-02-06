using InSiteXmlClient4Core.InterFace;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiSelectionValue : CsiXmlElement, ICsiSelectionValue, ICsiXmlElement
    {
        public CsiSelectionValue(ICsiDocument doc, XmlElement domElement)
          : base(doc, domElement)
        {
        }

        public virtual string GetDisplayName()
        {
            return this.GetData("__displayName");
        }

        public virtual string GetValue()
        {
            return this.GetData("__value");
        }

        private string GetData(string tagName)
        {
            return (this.FindChildByName(tagName) as CsiXmlElement).GetDomElement().FirstChild.Value;
        }
    }
}
