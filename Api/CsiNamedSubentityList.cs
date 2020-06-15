using InSiteXmlClient4Core.InterFace;
using System.Xml;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiNamedSubentityList : CsiObjectList, ICsiNamedSubentityList, ICsiObjectList, ICsiList, ICsiField, ICsiXmlElement
    {
        public CsiNamedSubentityList(ICsiDocument doc, XmlElement domElement)
          : base(doc, domElement)
        {
        }

        public CsiNamedSubentityList(ICsiDocument doc, string name, ICsiXmlElement parent)
          : base(doc, name, parent)
        {
        }

        public override bool IsNamedSubentityList()
        {
            return true;
        }

        public ICsiNamedSubentity AppendItem(string name)
        {
            ICsiNamedSubentity csiNamedSubentity = (ICsiNamedSubentity)new CsiNamedSubentity(this.GetOwnerDocument(), "__listItem", (ICsiXmlElement)this);
            csiNamedSubentity.SetAttribute("__listItemAction", "add");
            csiNamedSubentity.SetName(name);
            return csiNamedSubentity;
        }

        public ICsiNamedSubentity DeleteItemByName(string itemName)
        {
            ICsiNamedSubentity csiNamedSubentity = (ICsiNamedSubentity)new CsiNamedSubentity(this.GetOwnerDocument(), "__listItem", (ICsiXmlElement)this);
            csiNamedSubentity.SetAttribute("__listItemAction", "delete");
            CsiXmlHelper.FindCreateSetValue2((ICsiXmlElement)csiNamedSubentity, "__key", "__name", itemName, true);
            return csiNamedSubentity;
        }

        public ICsiNamedSubentity ChangeItemByName(string itemName)
        {
            ICsiNamedSubentity csiNamedSubentity = (ICsiNamedSubentity)new CsiNamedSubentity(this.GetOwnerDocument(), "__listItem", (ICsiXmlElement)this);
            csiNamedSubentity.SetAttribute("__listItemAction", "change");
            CsiXmlHelper.FindCreateSetValue2((ICsiXmlElement)csiNamedSubentity, "__key", "__name", itemName, true);
            return csiNamedSubentity;
        }

        public ICsiNamedSubentity ChangeItemByIndex(int index)
        {
            ICsiNamedSubentity csiNamedSubentity = (ICsiNamedSubentity)new CsiNamedSubentity(this.GetOwnerDocument(), "__listItem", (ICsiXmlElement)this);
            csiNamedSubentity.SetAttribute("__listItemAction", "change");
            CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)csiNamedSubentity, "__index", XmlConvert.ToString(index));
            return csiNamedSubentity;
        }

        public ICsiNamedSubentity GetItemByIndex(int index)
        {
            CsiXmlElement csiXmlElementImpl = this.GetItem(index);
            if (csiXmlElementImpl == null)
                return (ICsiNamedSubentity)null;
            return (ICsiNamedSubentity)new CsiNamedSubentity(this.GetOwnerDocument(), csiXmlElementImpl.GetDomElement());
        }

        public ICsiNamedSubentity GetItemByName(string name)
        {
            CsiXmlElement csiXmlElementImpl = this.GetItem(name);
            if (csiXmlElementImpl == null)
                return (ICsiNamedSubentity)null;
            return (ICsiNamedSubentity)new CsiNamedSubentity(this.GetOwnerDocument(), csiXmlElementImpl.GetDomElement());
        }
    }
}