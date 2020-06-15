using InSiteXmlClient4Core.InterFace;
using System;
using System.Collections;
using System.Xml;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiContainerList : CsiObjectList, ICsiContainerList, ICsiObjectList, ICsiList, ICsiField, ICsiXmlElement
    {
        public CsiContainerList(ICsiDocument doc, XmlElement domElement) : base(doc, domElement)
        {
        }

        public CsiContainerList(ICsiDocument doc, string name, ICsiXmlElement parent) : base(doc, name, parent)
        {
        }

        public ICsiContainer AppendItem(string name, string level)
        {
            CsiContainer container = new CsiContainer(this.GetOwnerDocument(), "__listItem", this);
            container.SetAttribute("__listItemAction", "add");
            container.SetRef(name, level);
            return container;
        }

        public ICsiContainer ChangeItemByIndex(int index)
        {
            CsiContainer sourceElement = new CsiContainer(this.GetOwnerDocument(), "__listItem", this);
            sourceElement.SetAttribute("__listItemAction", "change");
            CsiXmlHelper.FindCreateSetValue(sourceElement, "__index", Convert.ToString(index));
            return sourceElement;
        }

        public ICsiContainer ChangeItemByRef(string name, string level)
        {
            ICsiContainer sourceElement = new CsiContainer(this.GetOwnerDocument(), "__listItem", this);
            sourceElement.SetAttribute("__listItemAction", "change");
            CsiXmlHelper.FindCreateSetValue2(sourceElement, "__key", "__name", name, true);
            CsiXmlHelper.FindCreateSetValue3(sourceElement, "__key", "__level", "__name", level, true);
            return sourceElement;
        }

        public void DeleteItemByRef(string name, string level)
        {
            ICsiContainer sourceElement = new CsiContainer(this.GetOwnerDocument(), "__listItem", this);
            sourceElement.SetAttribute("__listItemAction", "delete");
            CsiXmlHelper.FindCreateSetValue2(sourceElement, "__key", "__name", name, true);
            CsiXmlHelper.FindCreateSetValue3(sourceElement, "__key", "__level", "__name", level, true);
        }

        public ICsiContainer GetItemByIndex(int index)
        {
            CsiXmlElement impl = this.GetItem(index);
            if (impl == null)
            {
                return null;
            }
            return new CsiContainer(this.GetOwnerDocument(), impl.GetDomElement());
        }

        public ICsiContainer GetItemByRef(string name, string level)
        {
            CsiContainer impl = null;
            IEnumerator enumerator = this.GetAllChildren().GetEnumerator();
            while (enumerator.MoveNext())
            {
                CsiObject current = enumerator.Current as CsiObject;
                impl = new CsiContainer(this.GetOwnerDocument(), current.GetDomElement());
                if ((level != null) && (level.Length == 0))
                {
                    level = null;
                }
                if (impl.Equals(name, level))
                {
                    return impl;
                }
                impl = null;
            }
            return impl;
        }

        public override bool IsContainerList() =>
            true;
    }
}