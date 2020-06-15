using InSiteXmlClient4Core.InterFace;
using System.Xml;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiNamedObjectList : CsiObjectList, ICsiNamedObjectList, ICsiObjectList, ICsiList, ICsiField, ICsiXmlElement
    {
        public CsiNamedObjectList(ICsiDocument doc, XmlElement domElement) : base(doc, domElement)
        {
        }

        public CsiNamedObjectList(ICsiDocument doc, string name, ICsiXmlElement parent) : base(doc, name, parent)
        {
        }

        public ICsiNamedObject AppendItem(string itemName)
        {
            ICsiNamedObject obj2 = new CsiNamedObject(this.GetOwnerDocument(), "__listItem", this);
            obj2.SetAttribute("__listItemAction", "add");
            obj2.SetRef(itemName);
            return obj2;
        }

        public ICsiNamedObject ChangeItemByIndex(int index)
        {
            ICsiNamedObject sourceElement = new CsiNamedObject(this.GetOwnerDocument(), "__listItem", this);
            sourceElement.SetAttribute("__listItemAction", "change");
            CsiXmlHelper.FindCreateSetValue(sourceElement, "__index", XmlConvert.ToString(index));
            return sourceElement;
        }

        public ICsiNamedObject ChangeItemByName(string itemName)
        {
            CsiNamedObject sourceElement = new CsiNamedObject(this.GetOwnerDocument(), "__listItem", this);
            sourceElement.SetAttribute("__listItemAction", "change");
            CsiXmlHelper.FindCreateSetValue2(sourceElement, "__key", "__name", itemName, true);
            return sourceElement;
        }

        public void DeleteItemByName(string itemName)
        {
            ICsiNamedObject sourceElement = new CsiNamedObject(this.GetOwnerDocument(), "__listItem", this);
            sourceElement.SetAttribute("__listItemAction", "delete");
            CsiXmlHelper.FindCreateSetValue2(sourceElement, "__key", "__name", itemName, true);
        }

        public ICsiNamedObject GetItemByIndex(int index)
        {
            CsiXmlElement impl = this.GetItem(index);
            if (impl == null)
            {
                return null;
            }
            return new CsiNamedObject(this.GetOwnerDocument(), impl.GetDomElement());
        }

        public ICsiNamedObject GetItemByName(string name)
        {
            CsiXmlElement impl = this.GetItem(name);
            if (impl == null)
            {
                return null;
            }
            return new CsiNamedObject(this.GetOwnerDocument(), impl.GetDomElement());
        }

        public override bool IsNamedObjectList() =>
            true;
    }
}