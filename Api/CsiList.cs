using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using InSiteXmlClient4Core.Enum;
using InSiteXmlClient4Core.Exceptions;
using InSiteXmlClient4Core.InterFace;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiList : CsiField, ICsiList, ICsiField, ICsiXmlElement
    {
        public CsiList(ICsiDocument doc, XmlElement domElement) : base(doc, domElement)
        {
        }

        public CsiList(ICsiDocument doc, string name, ICsiXmlElement parent) : base(doc, name, parent)
        {
        }

        public virtual void DeleteItemByIndex(int index)
        {
            ICsiXmlElement sourceElement = new CsiXmlElement(this.GetOwnerDocument(), "__listItem", this);
            sourceElement.SetAttribute("__listItemAction", "delete");
            CsiXmlHelper.FindCreateSetValue(sourceElement, "__index", Convert.ToString(index));
        }

        protected internal virtual CsiXmlElement GetItem(int index)
        {
            IEnumerator enumerator = this.GetListItems().GetEnumerator();
            int num = 0;
            while (enumerator.MoveNext())
            {
                CsiXmlElement current = enumerator.Current as CsiXmlElement;
                if (num++ == index)
                {
                    return current;
                }
            }
            return null;
        }

        public virtual Array GetListItems()
        {
            Array array = CsiXmlHelper.GetChildrenByName(this.GetOwnerDocument(), base.GetDomElement(), "__listItem");
            if (array.Length > 0)
            {
                return array;
            }
            return null;
        }

        public override bool IsList() =>
            true;

        public virtual void SetListAction(ListActions action)
        {
            string val = "change";
            switch (action)
            {
                case ListActions.ListActionChange:
                    break;

                case ListActions.ListActionReplace:
                    val = "replace";
                    break;

                default:
                    {
                        string src = base.GetType().FullName + ".setListAction()";
                        throw new CsiClientException(-2147467259L, src);
                    }
            }
            base.SetAttribute("__listAction", val);
        }

        public virtual void SetProxyField(string val)
        {
            base.SetAttribute("__proxyField", val);
        }
      
    }
}