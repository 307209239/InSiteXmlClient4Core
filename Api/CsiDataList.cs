using InSiteXmlClient4Core.InterFace;
using System;
using System.Xml;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiDataList : CsiList, ICsiDataList, ICsiList, ICsiField, ICsiXmlElement
    {
        public CsiDataList(ICsiDocument doc, XmlElement domElement) : base(doc, domElement)
    {
    }

    public CsiDataList(ICsiDocument doc, string name, ICsiXmlElement parent) : base(doc, name, parent)
    {
    }

    public ICsiDataField AppendItem(string val)
    {
        ICsiDataField impl = new CsiDataField(this.GetOwnerDocument(), "__listItem", this);
        impl.SetAttribute("__listItemAction", "add");
        impl.SetValue(val);
        return impl;
    }

    public ICsiDataField ChangeItemByIndex(int index, string val)
    {
        CsiDataField sourceElement = new CsiDataField(this.GetOwnerDocument(), "__listItem", this);
        sourceElement.SetAttribute("__listItemAction", "change");
        CsiXmlHelper.FindCreateSetValue(sourceElement, "__index", Convert.ToString(index));
        ICsiXmlElement element = CsiXmlHelper.FindCreateSetValue(sourceElement, "__value", val, true);
        return new CsiDataField(this.GetOwnerDocument(), (element as CsiXmlElement).GetDomElement());
    }

    public ICsiDataField ChangeItemByValue(string oldValue, string newValue)
    {
        CsiDataField sourceElement = new CsiDataField(this.GetOwnerDocument(), "__listItem", this);
        sourceElement.SetAttribute("__listItemAction", "change");
        CsiXmlHelper.FindCreateSetValue2(sourceElement, "__key", "__value", oldValue, true);
        ICsiXmlElement element = CsiXmlHelper.FindCreateSetValue(sourceElement, "__value", newValue, true);
        return new CsiDataField(this.GetOwnerDocument(), (element as CsiXmlElement).GetDomElement());
    }

    public ICsiDataField DeleteItemByValue(string val)
    {
        CsiDataField sourceElement = new CsiDataField(this.GetOwnerDocument(), "__listItem", this);
        sourceElement.SetAttribute("__listItemAction", "delete");
        ICsiXmlElement element = CsiXmlHelper.FindCreateSetValue2(sourceElement, "__key", "__value", val, true);
        return new CsiDataField(this.GetOwnerDocument(), (element as CsiXmlElement).GetDomElement());
    }

    public ICsiDataField GetItemByIndex(int index)
    {
        CsiXmlElement impl = this.GetItem(index);
        if (impl == null)
        {
            return null;
        }
        return new CsiDataField(this.GetOwnerDocument(), impl.GetDomElement());
    }

    public override bool IsDataList() =>
        true;
}
}