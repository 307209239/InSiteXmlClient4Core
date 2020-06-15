using InSiteXmlClient4Core.InterFace;
using System.Xml;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiSubentity : CsiObject, ICsiSubentity, ICsiObject, ICsiField, ICsiXmlElement
    {
        public CsiSubentity(ICsiDocument doc, string name, ICsiXmlElement parent)
            : base(doc, name, parent)
        {
        }

        public CsiSubentity(ICsiDocument doc, XmlElement domElement)
            : base(doc, domElement)
        {
        }

        public override bool IsSubentity()
        {
            return true;
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