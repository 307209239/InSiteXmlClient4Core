using InSiteXmlClient4Core.InterFace;
using System.Xml;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiSubentityList : CsiObjectList, ICsiSubentityList, ICsiObjectList, ICsiList, ICsiField, ICsiXmlElement
    {
        public CsiSubentityList(ICsiDocument doc, XmlElement domElement)
            : base(doc, domElement)
        {
        }

        public CsiSubentityList(ICsiDocument doc, string name, ICsiXmlElement parent)
            : base(doc, name, parent)
        {
        }

        public override bool IsSubentityList()
        {
            return true;
        }

        public ICsiSubentity AppendItem()
        {
            ICsiSubentity csiSubentity = (ICsiSubentity)new CsiSubentity(this.GetOwnerDocument(), "__listItem", (ICsiXmlElement)this);
            csiSubentity.SetAttribute("__listItemAction", "add");
            return csiSubentity;
        }

        public ICsiSubentity ChangeItemByIndex(int index)
        {
            ICsiSubentity csiSubentity = (ICsiSubentity)new CsiSubentity(this.GetOwnerDocument(), "__listItem", (ICsiXmlElement)this);
            csiSubentity.SetAttribute("__listItemAction", "change");
            CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)csiSubentity, "__index", XmlConvert.ToString(index));
            return csiSubentity;
        }

        public ICsiSubentity GetItemByIndex(int index)
        {
            CsiXmlElement csiXmlElementImpl = this.GetItem(index);
            if (csiXmlElementImpl == null)
                return (ICsiSubentity)null;
            return (ICsiSubentity)new CsiSubentity(this.GetOwnerDocument(), csiXmlElementImpl.GetDomElement());
        }

        public ICsiSubentity Item()
        {
            ICsiSubentity csiSubentity = (ICsiSubentity)new CsiSubentity(this.GetOwnerDocument(), "__listItem", (ICsiXmlElement)this);
            return csiSubentity;
        }
    }
}