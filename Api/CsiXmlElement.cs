using System;
using System.Collections;
using InSiteXmlClient4Core.InterFace;
using System.Xml;
using InSiteXmlClient4Core.Util;

namespace InSiteXmlClient4Core.Api
{
    public class CsiXmlElement : ICsiXmlElement
    {
        private ICsiDocument mDocument;
        private XmlElement mDOMElement;

        public CsiXmlElement(ICsiDocument doc, XmlElement domElement)
        {
            this.mDocument = null;
            this.mDocument = doc;
            this.mDOMElement = domElement;
        }

        public CsiXmlElement(ICsiDocument document, string tagName, ICsiXmlElement parentElement)
        {
            this.mDocument = null;
            if (StringUtil.IsEmptyString(tagName))
            {
                throw new Exceptions.CsiClientException(0x2e0016L, base.GetType().FullName + ".csiXMLElement()");
            }
            this.mDocument = document;
            string str = tagName;
            ICsiXmlElement element = parentElement;
            CsiXmlElement child = null;
            while (str != null)
            {
                int index = str.IndexOf(".");
                if (index > 0)
                {
                    tagName = str.Substring(0, index);
                    str = str.Substring(index + 1);
                }
                else
                {
                    tagName = str;
                    str = null;
                }
                this.mDOMElement = (document as CsiDocument).CreateDomElement(tagName);
                child = new CsiXmlElement(document, this.mDOMElement);
                element.AppendChild(child);
                element = child;
            }
        }

        public ICsiXmlElement AppendChild(ICsiXmlElement child)
        {
            CsiXmlElement impl = (CsiXmlElement)child;
            try
            {
                if (this.mDOMElement.OwnerDocument == impl.GetDomElement().OwnerDocument)
                {
                    this.mDOMElement.AppendChild(impl.GetDomElement());
                }
            }
            catch (Exception exception)
            {
                throw new Exceptions.CsiClientException(-1L, exception, base.GetType().FullName + ".appendChild()");
            }
            return child;
        }

        public ICsiContainer AsContainer() =>(this as ICsiContainer);

        public ICsiContainerList AsContainerList() =>
            (this as ICsiContainerList);

        public ICsiDataField AsDataField() =>
            (this as ICsiDataField);

        public ICsiDataList AsDataList() =>
            (this as ICsiDataList);

        public ICsiField AsField() =>
            (this as ICsiField);

        public ICsiList AsList() =>
            (this as ICsiList);

        public ICsiNamedObject AsNamedObject() =>
            (this as ICsiNamedObject);

        public ICsiNamedObjectList AsNamedObjectList() =>
            (this as ICsiNamedObjectList);

        public ICsiNamedSubentity AsNamedSubentity() =>
            (this as ICsiNamedSubentity);

        public ICsiNamedSubentityList AsNamedSubentityList() =>
            (this as ICsiNamedSubentityList);

        public ICsiObject AsObject() =>
            (this as ICsiObject);

        public ICsiObjectList AsObjectList() =>
            (this as ICsiObjectList);

        public ICsiRequestData AsRequestData() =>
            (this as ICsiRequestData);

        public ICsiRevisionedObject AsRevisionedObject() =>
            (this as ICsiRevisionedObject);

        public ICsiRevisionedObjectList AsRevisionedObjectList() =>
            (this as ICsiRevisionedObjectList);

        public ICsiService AsService() =>
            (this as ICsiService);

        public ICsiSubentity AsSubentity() =>
            (this as ICsiSubentity);

        public ICsiSubentityList AsSubentityList() =>
            (this as ICsiSubentityList);

        protected ICsiXmlElement ClearXmlElementChildByName(string parent) =>
            this.ClearXmlElementChildByName(parent, null);

        protected ICsiXmlElement ClearXmlElementChildByName(string parent, string child)
        {
            ICsiXmlElement element = this.FindChildByName(parent);
            if (element == null)
            {
                return new CsiXmlElement(this.GetOwnerDocument(), parent, this);
            }
            this.removeChildByName(element, child);
            return element;
        }

        public ICsiXmlElement FindChildByName(string tagName)
        {
            ICsiXmlElement element = null;
            string[] stringList = StringUtil.GetStringList(tagName, '.');
            XmlElement element2 = this.RecursiveGetElement(this.GetDomElement(), stringList);
            if (element2 != null)
            {
                element = CsiXmlHelper.CreateCsiElement(this.GetOwnerDocument(), element2);
            }
            return element;
        }

        protected virtual ICsiXmlElement FindChildByName(string firstLevelChildTagName, string secondLevelChildTagName, string nameText)
        {
            IEnumerator enumerator = CsiXmlHelper.GetChildrenByName(this.GetOwnerDocument(), this.GetDomElement(), firstLevelChildTagName).GetEnumerator();
            while (enumerator.MoveNext())
            {
                ICsiXmlElement current = enumerator.Current as ICsiXmlElement;
                if (current.FindChildByName(secondLevelChildTagName) is CsiXmlElement impl)
                {
                    string str = impl.GetDomElement().Value;
                    if (str == null)
                    {
                        str = impl.GetElementValue();
                    }
                    if (nameText.Equals(str))
                    {
                        return current;
                    }
                }
            }
            return null;
        }

        public virtual Array GetAllChildren() =>
            this.GetAllChildren(false);

        protected internal Array GetAllChildren(bool bDoNotIncludeTagsWith__)
        {
            ArrayList list = new ArrayList();
            for (XmlNode node = this.mDOMElement.FirstChild; node != null; node = node.NextSibling)
            {
                if ((node.NodeType == XmlNodeType.Element) && (!bDoNotIncludeTagsWith__ || !node.Name.StartsWith("__")))
                {
                    list.Add(CsiXmlHelper.CreateCsiElement(this.GetOwnerDocument(), (XmlElement)node));
                }
            }
            return list.ToArray();
        }

        public string GetAttribute(string key) =>
            this.mDOMElement.GetAttribute(key);

        protected virtual ICsiExceptionData GetChildExceptionData()
        {
            string tagName = "__responseData" + '.' + "__exceptionData";
            return (this.FindChildByName(tagName) as ICsiExceptionData);
        }

        public Array GetChildrenByName(string name) =>
            CsiXmlHelper.GetChildrenByName(this.GetOwnerDocument(), this.GetDomElement(), name);

        protected internal XmlElement GetDomElement() =>
            this.mDOMElement;

        private XmlElement GetElement(XmlElement parent, string tag)
        {
            XmlElement element = null;
            ArrayList list = this.GetImmediateChildren(parent);
            int index = tag.IndexOf('[');
            if (index != -1)
            {
                string str = tag.Substring(0, index);
                int num2 = int.Parse(tag.Substring(index + 1, tag.IndexOf(']') - (index + 1)));
                if (tag.Equals(((XmlElement)list[num2]).Name) && (list[num2] is XmlElement))
                {
                    return (XmlElement)list[num2];
                }
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] is XmlElement)
                    {
                        element = (XmlElement)list[i];
                        if (tag.Equals(element.Name))
                        {
                            return element;
                        }
                    }
                }
            }
            return null;
        }

        public virtual string GetElementName() =>
            this.mDOMElement.Name;

        protected internal virtual string GetElementValue()
        {
            for (XmlNode node = this.GetDomElement().FirstChild; node != null; node = node.NextSibling)
            {
                if ((node.NodeType == XmlNodeType.Text) || (node.NodeType == XmlNodeType.CDATA))
                {
                    return node.Value;
                }
            }
            return null;
        }

        private ArrayList GetImmediateChildren(XmlElement element)
        {
            ArrayList list = new ArrayList();
            for (XmlNode node = element.FirstChild; node != null; node = node.NextSibling)
            {
                list.Add(node);
            }
            return list;
        }

        public virtual ICsiDocument GetOwnerDocument() =>
            this.mDocument;

        public virtual ICsiXmlElement GetParentElement()
        {
            XmlNode parentNode = this.mDOMElement.ParentNode;
            if ((parentNode != null) && (parentNode.NodeType == XmlNodeType.Element))
            {
                return CsiXmlHelper.CreateCsiElement(this.GetOwnerDocument(), parentNode as XmlElement);
            }
            return null;
        }

        public bool HasChildren()
        {
            if (this.GetDomElement().HasChildNodes)
            {
                for (XmlNode node = this.GetDomElement().FirstChild; node != null; node = node.NextSibling)
                {
                    if ((node.NodeType != XmlNodeType.Text) && (node.NodeType != XmlNodeType.CDATA))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public virtual bool IsContainer() =>
            false;

        public virtual bool IsContainerList() =>
            false;

        public virtual bool IsDataField() =>
            false;

        public virtual bool IsDataList() =>
            false;

        public virtual bool IsField() =>
            false;

        public virtual bool IsList() =>
            false;

        public virtual bool IsNamedObject() =>
            false;

        public virtual bool IsNamedObjectList() =>
            false;

        public virtual bool IsNamedSubentity() =>
            false;

        public virtual bool IsNamedSubentityList() =>
            false;

        public virtual bool IsObject() =>
            false;

        public virtual bool IsObjectList() =>
            false;

        public virtual bool IsRequestData() =>
            false;

        public virtual bool IsRevisionedObject() =>
            false;

        public virtual bool IsRevisionedObjectList() =>
            false;

        public virtual bool IsService() =>
            false;

        public virtual bool IsSubentity() =>
            false;

        public virtual bool IsSubentityList() =>
            false;

        private XmlElement RecursiveGetElement(XmlElement sourceElement, string[] tagsList)
        {
            XmlElement parent = sourceElement;
            if (tagsList.Length != 0)
            {
                for (int i = 0; i < tagsList.Length; i++)
                {
                    parent = this.GetElement(parent, tagsList[i]);
                    if ((parent == null) || (i == (tagsList.Length - 1)))
                    {
                        return parent;
                    }
                }
            }
            return null;
        }

        public void RemoveAllChildren()
        {
            try
            {
                while (this.mDOMElement.HasChildNodes)
                {
                    this.mDOMElement.RemoveChild(this.mDOMElement.FirstChild);
                }
            }
            catch (Exception exception)
            {
                throw new Exceptions.CsiClientException(-1L, exception, base.GetType().FullName + ".removeAllChildren()");
            }
        }

        public ICsiXmlElement RemoveChild(ICsiXmlElement child)
        {
            CsiXmlElement impl = (CsiXmlElement)child;
            this.mDOMElement.RemoveChild(impl.GetDomElement());
            return impl;
        }

        protected virtual void removeChildByName(ICsiXmlElement element, string name)
        {
            if (StringUtil.IsEmptyString(name))
            {
                element.RemoveAllChildren();
            }
            else
            {
                ICsiXmlElement child = element.FindChildByName(name);
                if (child != null)
                {
                    element.RemoveChild(child);
                }
            }
        }

        protected ICsiRequestField RequestForField(string fieldName)
        {
            CsiRequestField child = null;
            string[] stringList = StringUtil.GetStringList(fieldName, '.');
            CsiXmlElement parent = this;
            for (int i = 0; i < stringList.Length; i++)
            {
                XmlElement requestField = this.GetElement(parent.GetDomElement(), stringList[i]);
                if (requestField != null)
                {
                    child = new CsiRequestField(this.GetOwnerDocument(), requestField);
                }
                else
                {
                    child = new CsiRequestField(this.GetOwnerDocument(), stringList[i], parent);
                    parent.AppendChild(child);
                }
                parent = child;
            }
            return child;
        }

        public void SetAttribute(string key, string val)
        {
            try
            {
                this.mDOMElement.SetAttribute(key, val);
            }
            catch (XmlException exception)
            {
                throw new Exceptions.CsiClientException(-1L, exception, base.GetType().FullName + ".setAttribute()");
            }
        }
    }
}