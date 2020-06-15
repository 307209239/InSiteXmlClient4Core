using InSiteXmlClient4Core.InterFace;
using System.Xml;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiRevisionedObject : CsiObject, ICsiRevisionedObject, ICsiObject, ICsiField, ICsiXmlElement
    {
        public CsiRevisionedObject(ICsiDocument doc, string name, ICsiXmlElement parent)
            : base(doc, name, parent)
        {
        }

        public CsiRevisionedObject(ICsiDocument doc, XmlElement domElement)
            : base(doc, domElement)
        {
        }

        public override bool IsRevisionedObject()
        {
            return true;
        }

        public virtual string GetName()
        {
            if (this.FindChildByName("__name") is CsiXmlElement childByName)
                return CsiXmlHelper.GetFirstTextNodeValue(childByName);
            return string.Empty;
        }

        public virtual string GetRevision()
        {
            if (this.FindChildByName("__rev") is CsiXmlElement childByName)
                return CsiXmlHelper.GetFirstTextNodeValue(childByName);
            return string.Empty;
        }

        public virtual bool GetUseRor()
        {
            if (this.FindChildByName("__useROR") is CsiXmlElement childByName)
                return CsiXmlHelper.GetFirstTextNodeValue(childByName).Equals("true");
            return false;
        }

        public void SetRef(string name, string revision, bool useRor)
        {
            CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)this, "__name", name, true);
            if (!useRor && revision != null)
                CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)this, "__rev", revision, true);
            CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)this, "__useROR", useRor ? "true" : "false");
        }

        public void GetRef(out string name, out string revision, out bool useRor)
        {
            name = this.GetName();
            revision = this.GetRevision();
            useRor = this.GetUseRor();
        }
    }
}