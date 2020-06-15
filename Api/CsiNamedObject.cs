using InSiteXmlClient4Core.InterFace;
using System.Xml;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiNamedObject : CsiObject, ICsiNamedObject, ICsiObject, ICsiField, ICsiXmlElement
    {
        public CsiNamedObject(ICsiDocument doc, XmlElement domElement) : base(doc, domElement)
        {
        }

        public CsiNamedObject(ICsiDocument doc, string name, ICsiXmlElement parent) : base(doc, name, parent)
        {
        }

        public virtual string GetRef()
        {
            CsiXmlElement csiElement = base.FindChildByName("__name") as CsiXmlElement;
            return CsiXmlHelper.GetFirstTextNodeValue(csiElement);
        }

        public override bool IsNamedObject() =>
            true;

        public virtual void SetRef(string val)
        {
            CsiXmlHelper.FindCreateSetValue(this, "__name", val, true);
        }
    }
}