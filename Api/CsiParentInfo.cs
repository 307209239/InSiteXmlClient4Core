using System.Xml;
using InSiteXmlClient4Core.InterFace;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiParentInfo : CsiXmlElement, ICsiParentInfo, ICsiXmlElement
    {
        public CsiParentInfo(ICsiDocument doc, XmlElement domElement)
          : base(doc, domElement)
        {
        }

        public CsiParentInfo(ICsiDocument doc, string name, ICsiXmlElement parent)
          : base(doc, name, parent)
        {
        }

        public virtual void SetObjectId(string val)
        {
            CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)this, "__Id", val);
        }

        public virtual void SetObjectType(string type)
        {
            this.SetAttribute("__CDOTypeName", type);
        }

        public virtual string GetParentId()
        {
            return CsiXmlHelper.GetFirstTextNodeValue(this.FindChildByName("__Id") as CsiXmlElement);
        }

        public virtual void SetParentId(string parentId)
        {
            CsiXmlHelper.FindCreateSetValue2((ICsiXmlElement)this, "__parent", "__Id", parentId);
        }

        public virtual string GetNamedObjectRef()
        {
            return CsiXmlHelper.GetFirstTextNodeValue(this.FindChildByName("__name") as CsiXmlElement);
        }

        public virtual void SetNamedObjectRef(string val)
        {
            CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)this, "__name", val);
        }

        public virtual string GetName()
        {
            return CsiXmlHelper.GetFirstTextNodeValue(this.FindChildByName("__name") as CsiXmlElement);
        }

        public virtual void SetName(string name)
        {
            CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)this, "__name", name);
        }

        public virtual ICsiParentInfo GetParentInfo()
        {
            return this.FindChildByName("__parent") as ICsiParentInfo;
        }

        public ICsiParentInfo ParentInfo()
        {
            return this.GetParentInfo() ?? (ICsiParentInfo)new CsiParentInfo(this.GetOwnerDocument(), "__parent", (ICsiXmlElement)this);
        }

        public void SetContainerRef(string name, string level)
        {
            CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)this, "__name", name);
            if (level.Length <= 0)
                return;
            CsiXmlHelper.FindCreateSetValue2((ICsiXmlElement)this, "__level", "__name", level);
        }

        public void SetRevisionedObjectRef(string name, string rev, bool useROR)
        {
            CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)this, "__name", name);
            if (!useROR && rev != null)
                CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)this, "__rev", rev);
            CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)this, "__useROR", useROR ? "true" : "false");
        }

        public virtual void GetContainerRef(out string name, out string level)
        {
            name = this.GetName();
            level = this.GetLevel();
        }

        public virtual void GetRevisionedObjectRef(out string name, out string revision, out bool useROR)
        {
            name = this.GetName();
            revision = this.GetRevision();
            useROR = this.GetUseRor();
        }

        private string GetRevision()
        {
            if (this.FindChildByName("__rev") is CsiXmlElement childByName)
                return CsiXmlHelper.GetFirstTextNodeValue(childByName);
            return (string)null;
        }

        private bool GetUseRor()
        {
            if (this.FindChildByName("__useROR") is CsiXmlElement childByName)
                return CsiXmlHelper.GetFirstTextNodeValue(childByName).Equals("true");
            return false;
        }

        private string GetLevel()
        {
            if (!(this.FindChildByName("__level") is CsiXmlElement childByName1))
                return (string)null;
            if (childByName1.FindChildByName("__name") is CsiXmlElement childByName2)
                return CsiXmlHelper.GetFirstTextNodeValue(childByName2);
            return (string)null;
        }
    }
}