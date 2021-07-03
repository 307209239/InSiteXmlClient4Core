using System;
using System.Collections;
using System.Reflection;
using System.Security;
using InSiteXmlClient4Core.InterFace;
using InSiteXmlClient4Core.Util;
using System.Xml;
using InSiteXmlClient4Core.Exceptions;

namespace InSiteXmlClient4Core.Api
{
    /// <summary>
    /// XML帮助类
    /// </summary>
    public class CsiXmlHelper

    {
        private const string MkElementDoesNotExist = "元素 <{0}> 不存在.\n";
        private const string MkFailToCreateElement = "元素 <{0}> 创建失败.\n";
        private const string MkIndexIsOutOfBound = "索引 {0} 超过边界\n";
        private const string MkInvalidElement = "元素 <{0}> 无效.";

        private CsiXmlHelper()
        {
        }

        public static ICsiXmlElement CreateCsiElement(ICsiDocument document, XmlElement element)
        {
            string typeName = null;
            string name = null;
            string str5;
            ICsiXmlElement element3;
            try
            {
                name = element.Name;
                string attribute = element.GetAttribute("__nodeType");
                if (StringUtil.IsEmptyString(attribute))
                {
                    attribute = element.GetAttribute("__type");
                }
                if (StringUtil.IsEmptyString(attribute))
                {
                    XmlElement parentNode = (XmlElement)element.ParentNode;
                    if (parentNode != null)
                    {
                        string data = parentNode.GetAttribute("__nodeType");
                        if (!StringUtil.IsEmptyString(data))
                        {
                            if (name.Equals("__listItem"))
                            {
                                if (data.EndsWith("List"))
                                {
                                    attribute = data.Substring(0, data.Length - "List".Length);
                                }
                            }
                            else if (name.Equals("__defaultValue") && "__label".Equals(parentNode.Name))
                            {
                                attribute = data;
                            }
                        }
                    }
                }
                if (!StringUtil.IsEmptyString(attribute))
                {
                    typeName = CsiConstants.NodeToClassMapping[attribute] as string;
                }
                if (typeName == null)
                {
                    typeName = CsiConstants.NodeToClassMapping[name] as string;
                }
                if (typeName == null)
                {
                    typeName = "Camstar.XMLClient.API.CsiXmlElement";
                }
                Type type = Type.GetType(typeName, true);
                Type type2 = typeof(ICsiDocument);
                Type type3 = typeof(XmlElement);
                element3 = (ICsiXmlElement)type.GetConstructor(new[] { type2, type3 }).Invoke(new object[] { document, element });
            }
            catch (TypeLoadException exception)
            {
                str5 = $"csiXmlHelper.createcsiElementment() - TypeLoadException: Tag = {name}, className = {typeName}";
                throw new CsiClientException(-1L, exception, str5);
            }
            catch (MethodAccessException exception2)
            {
                str5 = $"csiXmlHelper.createcsiElementment() - MethodAccessException: Tag = {name}, className = {typeName}";
                throw new CsiClientException(-1L, exception2, str5);
            }
            catch (SecurityException exception3)
            {
                str5 = $"csiXmlHelper.createcsiElementment() - SecurityException: Tag = {name}, className = {typeName}";
                throw new CsiClientException(-1L, exception3, str5);
            }
            catch (UnauthorizedAccessException exception4)
            {
                str5 = $"csiXmlHelper.createcsiElementment() - UnauthorizedAccessException: Tag = {name}, className = {typeName}";
                throw new CsiClientException(-1L, exception4, str5);
            }
            catch (ArgumentException exception5)
            {
                str5 = $"csiXmlHelper.createcsiElementment() - ArgumentException: Tag = {name}, className = {typeName}";
                throw new CsiClientException(-1L, exception5, str5);
            }
            catch (TargetInvocationException exception6)
            {
                str5 = $"csiXmlHelper.createcsiElementment() - TargetInvocationException: 标签:{name}, 类:{typeName}";
                throw new CsiClientException(-1L, exception6, str5);
            }
            catch (Exception exception7)
            {
                str5 = $"csiXmlHelper.createcsiElementment(): 标签 = {name}, 类 = {typeName}";
                throw new CsiClientException(-1L, exception7, str5);
            }
            return element3;
        }

        public static ICsiXmlElement FindCreateSetValue(ICsiXmlElement sourceElement, string tagName, string val, bool isCdata=false)
        {
            CsiXmlElement impl = (CsiXmlElement)sourceElement.FindChildByName(tagName);
            if (impl == null)
            {
                impl = new CsiXmlElement(sourceElement.GetOwnerDocument(), tagName, sourceElement);
            }
            if (!(!isCdata || StringUtil.IsEmptyString(val)))
            {
                SetCdataNode(impl.GetDomElement(), val);
                return impl;
            }
            SetTextNode(impl.GetDomElement(), val);
            return impl;
        }

        public static ICsiXmlElement FindCreateSetValue2(ICsiXmlElement sourceElement, string firstLevelTag, string secondLevelTag, string val) =>
            FindCreateSetValue2(sourceElement, firstLevelTag, secondLevelTag, val, false);

        public static ICsiXmlElement FindCreateSetValue2(ICsiXmlElement sourceElement, string firstLevelTag, string secondLevelTag, string val, bool isCdata)
        {
            ICsiXmlElement element = sourceElement.FindChildByName(firstLevelTag);
            if (element == null)
            {
                element = new CsiXmlElement(sourceElement.GetOwnerDocument(), firstLevelTag, sourceElement);
            }
            return FindCreateSetValue(element, secondLevelTag, val, isCdata);
        }

        public static void FindCreateSetValue3(ICsiXmlElement sourceElement, string firstLevelTag, string secondLevelTag, string thirdLevelTag, string val)
        {
            FindCreateSetValue3(sourceElement, firstLevelTag, secondLevelTag, thirdLevelTag, val, false);
        }

        public static ICsiXmlElement FindCreateSetValue3(ICsiXmlElement sourceElement, string firstLevelTag, string secondLevelTag, string thirdLevelTag, string val, bool isCdata) =>
            FindCreateSetValue(FindCreateSetValue2(sourceElement, firstLevelTag, secondLevelTag, null, false), thirdLevelTag, val, isCdata);

        public static string GenerateGuid() =>
            Guid.NewGuid().ToString();

        public static long GetChildCount(XmlElement element)
        {
            long num3;
            try
            {
                XmlNodeList childNodes = element.ChildNodes;
                long num = 0L;
                for (int i = 0; i < childNodes.Count; i++)
                {
                    XmlNode node = childNodes[i];
                    if (node.NodeType == XmlNodeType.Element)
                    {
                        num += 1L;
                    }
                }
                num3 = num;
            }
            catch (Exception exception)
            {
                throw new CsiClientException(-1L, exception, "csiXmlHelper.getChildCount()");
            }
            return num3;
        }

        public static Array GetChildrenByName(ICsiDocument document, XmlElement element, string name)
        {
            Array array;
            try
            {
                ArrayList list = new ArrayList();
                for (XmlNode node = element.FirstChild; node != null; node = node.NextSibling)
                {
                    if ((node.NodeType == XmlNodeType.Element) && node.Name.Equals(name))
                    {
                        list.Add(CreateCsiElement(document, (XmlElement)node));
                    }
                }
                array = list.ToArray();
            }
            catch (Exception exception)
            {
                throw new CsiClientException(-1L, exception, "csiXmlHelper.getChildrenByName()");
            }
            return array;
        }

        public static string GetCreateFailed(string sObject) => $"元素 <{sObject}> 创建失败.";

        public static string GetFirstTextNodeValue(CsiXmlElement csiElement)
        {
            string str = string.Empty;
            if (csiElement != null)
            {
                for (XmlNode node = csiElement.GetDomElement().FirstChild; node != null; node = node.NextSibling)
                {
                    if ((node.NodeType == XmlNodeType.Text) || (node.NodeType == XmlNodeType.CDATA))
                    {
                        str = node.Value;
                    }
                }
            }
            return str;
        }

        public static string GetIndexOufOfBound(int index) => $"索引 {index} 超过边界";

        public static string GetInvalidElement(string sObject) => $"元素 <{sObject}> 无效.";

        public static string GetNotExists(string sObject) => $"元素 <{sObject}> 不存在.";

        public static void SetCdataNode(XmlElement target, string data)
        {
            try
            {
                if ((target != null) && !StringUtil.IsEmptyString(data))
                {
                    XmlNode nextSibling;
                    for (XmlNode node = target.FirstChild; node != null; node = nextSibling)
                    {
                        nextSibling = node.NextSibling;
                        if ((node.NodeType == XmlNodeType.Text) || (node.NodeType == XmlNodeType.CDATA))
                        {
                            target.RemoveChild(node);
                        }
                    }
                    target.AppendChild(target.OwnerDocument.CreateCDataSection(data));
                }
            }
            catch (Exception exception)
            {
                throw new CsiClientException(-1L, exception, "csiXmlHelper.setTextNode()");
            }
        }

        public static void SetTextNode(XmlElement target, string data)
        {
            try
            {
                if (target != null)
                {
                    XmlNode nextSibling;
                    for (XmlNode node = target.FirstChild; node != null; node = nextSibling)
                    {
                        nextSibling = node.NextSibling;
                        if ((node.NodeType == XmlNodeType.Text) || (node.NodeType == XmlNodeType.CDATA))
                        {
                            target.RemoveChild(node);
                        }
                    }
                    if (!StringUtil.IsEmptyString(data))
                    {
                        target.AppendChild(target.OwnerDocument.CreateTextNode(data));
                        target.RemoveAttribute("__empty");
                    }
                    else
                    {
                        target.RemoveAttribute("__empty");
                    }
                }
            }
            catch (Exception exception)
            {
                throw new CsiClientException(-1L, exception, "csiXmlHelper.setTextNode()");
            }
        }
    }
}