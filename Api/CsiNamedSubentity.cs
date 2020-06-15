using System;
using System.Xml;
using InSiteXmlClient4Core.InterFace;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiNamedSubentity : CsiObject, ICsiNamedSubentity, ICsiObject, ICsiField, ICsiXmlElement
    {
        public CsiNamedSubentity(ICsiDocument doc, string name, ICsiXmlElement parent)
            : base(doc, name, parent)
        {
        }

        public CsiNamedSubentity(ICsiDocument doc, XmlElement domElement)
            : base(doc, domElement)
        {
        }

        public override bool IsNamedSubentity()
        {
            return true;
        }

        public virtual string GetName()
        {
            return CsiXmlHelper.GetFirstTextNodeValue(this.FindChildByName("__name") as CsiXmlElement);
        }

        public virtual void SetName(string name)
        {
            CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)this, "__name", name, true);
        }

        public virtual ICsiParentInfo GetParentInfo()
        {
            return this.FindChildByName("__parent") as ICsiParentInfo;
        }

        public virtual void SetParentId(string parentId)
        {
            CsiXmlHelper.FindCreateSetValue2((ICsiXmlElement)this, "__parent", "__Id", parentId);
        }

        public ICsiParentInfo ParentInfo()
        {
            return this.GetParentInfo() ?? (ICsiParentInfo)new CsiParentInfo(this.GetOwnerDocument(), "__parent", (ICsiXmlElement)this);
        }
    }
}