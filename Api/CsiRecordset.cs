using InSiteXmlClient4Core.Exceptions;
using InSiteXmlClient4Core.InterFace;
using System;
using System.Collections;
using System.Xml;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiRecordsetField : CsiXmlElement, ICsiRecordsetField, ICsiXmlElement
    {
        public CsiRecordsetField(ICsiDocument doc, XmlElement element) : base(doc, element)
        {

        }
        public CsiRecordsetField(ICsiDocument doc, string name, ICsiXmlElement parent) : base(doc, name, parent)
        {

        }

        public virtual string GetName()
        {
            return this.GetElementName();
        }

        public virtual string GetValue()
        {
            string result = string.Empty;
            try
            {
                XmlElement element = base.GetDomElement();
                if (element.HasChildNodes && element.ChildNodes.Count > 0)
                {
                    string value = element.FirstChild.Value;
                    result = ((value != null) ? value : "");
                }
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }
    }

    internal class CsiRecordset : CsiXmlElement, ICsiRecordset, ICsiXmlElement
    {
        public CsiRecordset(ICsiDocument doc, XmlElement domElement)
           : base(doc, domElement)
        {

        }

        public CsiRecordset(ICsiDocument doc, ICsiXmlElement oParent)
          : base(doc, "__recordSet", oParent)
        {
        }

        private XmlNode mCurrentElement;

        public Array GetFields()
        {
            Array result;
            try
            {
                ArrayList arrayList = new ArrayList();
                bool flag = this.mCurrentElement != null;
                if (flag)
                {
                    XmlNodeList childNodes = this.mCurrentElement.ChildNodes;
                    for (int i = 0; i < childNodes.Count; i++)
                    {
                        XmlNode xmlNode = childNodes[i];
                        bool flag2 = xmlNode.NodeType == XmlNodeType.Element;
                        if (flag2)
                        {
                            arrayList.Add(new CsiRecordsetField(this.GetOwnerDocument(), xmlNode as XmlElement));
                        }
                    }
                }
                result = arrayList.ToArray();
            }
            catch (Exception exp)
            {
                throw new CsiClientException(-1L, exp, base.GetType().FullName + ".GetFields()");
            }
            return result;
        }

        public virtual long GetRecordCount()
        {
            return CsiXmlHelper.GetChildCount(base.GetDomElement());
        }

        private XmlNode GoToNextElementNode(XmlNode element, bool bForward)
        {
            XmlNode result;
            try
            {
                XmlNode xmlNode = element;
                while (xmlNode != null && (xmlNode.NodeType != XmlNodeType.Element || !xmlNode.Name.Equals("__row")))
                {
                    if (bForward)
                    {
                        xmlNode = xmlNode.NextSibling;
                    }
                    else
                    {
                        xmlNode = xmlNode.PreviousSibling;
                    }
                }
                result = xmlNode;
            }
            catch (Exception exp)
            {
                throw new CsiClientException(-1L, exp, base.GetType().FullName + ".GoToNextElementNode()");
            }
            return result;
        }

        public void MoveFirst()
        {
            try
            {
                this.mCurrentElement = this.GoToNextElementNode(base.GetDomElement().FirstChild, true);
            }
            catch (Exception exp)
            {
                throw new CsiClientException(-1L, exp, base.GetType().FullName + ".MoveFirst()");
            }
        }

        public void MoveLast()
        {
            try
            {
                this.mCurrentElement = this.GoToNextElementNode(base.GetDomElement().LastChild, false);
            }
            catch (Exception exp)
            {
                throw new CsiClientException(-1L, exp, base.GetType().FullName + ".MoveLast()");
            }
        }

        public void MoveNext()
        {
            try
            {
                bool flag = this.mCurrentElement == null;
                if (flag)
                {
                    this.MoveFirst();
                }
                else
                {
                    XmlNode nextSibling = this.mCurrentElement.NextSibling;
                    bool flag2 = nextSibling == null;
                    if (flag2)
                    {
                        this.MoveFirst();
                    }
                    else
                    {
                        this.mCurrentElement = this.GoToNextElementNode(nextSibling, true);
                        bool flag3 = this.mCurrentElement == null;
                        if (flag3)
                        {
                            this.MoveLast();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new CsiClientException(-1L, ex.Message, base.GetType().FullName + ".MoveNext()");
            }
        }

        public void MovePrevious()
        {
            try
            {
                bool flag = this.mCurrentElement == null;
                if (flag)
                {
                    this.MoveFirst();
                }
                else
                {
                    XmlNode previousSibling = this.mCurrentElement.PreviousSibling;
                    bool flag2 = previousSibling == null;
                    if (flag2)
                    {
                        this.MoveFirst();
                    }
                    else
                    {
                        this.mCurrentElement = this.GoToNextElementNode(previousSibling, false);
                        bool flag3 = this.mCurrentElement == null;
                        if (flag3)
                        {
                            this.MoveFirst();
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                throw new CsiClientException(-1L, exp, base.GetType().FullName + ".MovePrevious()");
            }
        }
    }
}
