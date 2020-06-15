using InSiteXmlClient4Core.InterFace;
using System.Xml;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiRevisionedObjectList : CsiObjectList, ICsiRevisionedObjectList, ICsiObjectList, ICsiList, ICsiField, ICsiXmlElement
    {
        public CsiRevisionedObjectList(ICsiDocument doc, XmlElement domElement)
          : base(doc, domElement)
        {
        }

        public CsiRevisionedObjectList(ICsiDocument doc, string name, ICsiXmlElement parent)
          : base(doc, name, parent)
        {
        }

        public override bool IsRevisionedObjectList()
        {
            return true;
        }

        public ICsiRevisionedObject AppendItem(string itemName, string revision, bool useROR)
        {
            ICsiRevisionedObject revisionedObject = (ICsiRevisionedObject)new CsiRevisionedObject(this.GetOwnerDocument(), "__listItem", (ICsiXmlElement)this);
            revisionedObject.SetAttribute("__listItemAction", "add");
            revisionedObject.SetRef(itemName, revision, useROR);
            return revisionedObject;
        }

        public void DeleteItemByRef(string itemName, string revision, bool useROR)
        {
            ICsiRevisionedObject revisionedObject = (ICsiRevisionedObject)new CsiRevisionedObject(this.GetOwnerDocument(), "__listItem", (ICsiXmlElement)this);
            revisionedObject.SetAttribute("__listItemAction", "delete");
            CsiXmlHelper.FindCreateSetValue2((ICsiXmlElement)revisionedObject, "__key", "__name", itemName, true);
            CsiXmlHelper.FindCreateSetValue2((ICsiXmlElement)revisionedObject, "__key", "__rev", revision, true);
            CsiXmlHelper.FindCreateSetValue2((ICsiXmlElement)revisionedObject, "__key", "__useROR", useROR ? "true" : "false");
        }

        public ICsiRevisionedObject ChangeItemByRef(string itemName, string revision, bool useROR)
        {
            ICsiRevisionedObject revisionedObject = (ICsiRevisionedObject)new CsiRevisionedObject(this.GetOwnerDocument(), "__listItem", (ICsiXmlElement)this);
            revisionedObject.SetAttribute("__listItemAction", "change");
            CsiXmlHelper.FindCreateSetValue2((ICsiXmlElement)revisionedObject, "__key", "__name", itemName, true);
            CsiXmlHelper.FindCreateSetValue2((ICsiXmlElement)revisionedObject, "__key", "__rev", revision, true);
            CsiXmlHelper.FindCreateSetValue2((ICsiXmlElement)revisionedObject, "__key", "__useROR", useROR ? "true" : "false");
            return revisionedObject;
        }

        public ICsiRevisionedObject ChangeItemByIndex(int index)
        {
            ICsiRevisionedObject revisionedObject = (ICsiRevisionedObject)new CsiRevisionedObject(this.GetOwnerDocument(), "__listItem", (ICsiXmlElement)this);
            revisionedObject.SetAttribute("__listItemAction", "change");
            CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)revisionedObject, "__index", XmlConvert.ToString(index));
            return revisionedObject;
        }

        public ICsiRevisionedObject GetItemByIndex(int index)
        {
            CsiXmlElement csiXmlElementImpl = this.GetItem(index);
            if (csiXmlElementImpl == null)
                return (ICsiRevisionedObject)null;
            return (ICsiRevisionedObject)new CsiRevisionedObject(this.GetOwnerDocument(), csiXmlElementImpl.GetDomElement());
        }

        public ICsiRevisionedObject GetItemByRef(string itemName, string revision, bool useROR)
        {
            foreach (object allChild in this.GetAllChildren())
            {
                CsiXmlElement csiXmlElementImpl = allChild as CsiXmlElement;
                if (!(csiXmlElementImpl.FindChildByName("__name") is CsiXmlElement childByName1) ||
                    !itemName.Equals(CsiXmlHelper.GetFirstTextNodeValue(childByName1))) continue;
                if (!(csiXmlElementImpl.FindChildByName("__useROR") is CsiXmlElement childByName2) ||
                    XmlConvert.ToBoolean(CsiXmlHelper.GetFirstTextNodeValue(childByName2)) != useROR) continue;
                if (useROR || Util.StringUtil.IsEmptyString(revision))
                    return (ICsiRevisionedObject) new CsiRevisionedObject(this.GetOwnerDocument(),
                        csiXmlElementImpl.GetDomElement());
                if (!(csiXmlElementImpl.FindChildByName("__rev") is CsiXmlElement childByName3) || !revision.Equals(CsiXmlHelper.GetFirstTextNodeValue(childByName3)))
                    continue;
                return (ICsiRevisionedObject)new CsiRevisionedObject(this.GetOwnerDocument(), csiXmlElementImpl.GetDomElement());
            }
            return null;
        }
    }
}