using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using InSiteXmlClient4Core.Exceptions;
using InSiteXmlClient4Core.InterFace;
using InSiteXmlClient4Core.Util;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiDocument : ICsiDocument
    {
        protected ArrayList mExceptions = new ArrayList();
        private const string mkXMLVersion = "1.1";
        protected XmlDocument mRequestDocument;
        protected ICsiDocument mResponseDocument;
        protected ICsiSession mSession;
        protected ICsiXmlElement mRootElement;

        public CsiDocument(ICsiSession session)
        {
            this.mSession = session;
            this.mRequestDocument = new XmlDocument();
            this.mResponseDocument = (ICsiDocument)null;
            this.mRootElement = (ICsiXmlElement)new CsiXmlElement((ICsiDocument)this, this.mRequestDocument.CreateElement("__InSite"));
            this.mRequestDocument.AppendChild((XmlNode)(this.mRootElement as CsiXmlElement).GetDomElement());
            this.mRootElement.SetAttribute("__version", "1.1");
            this.mRootElement.SetAttribute("__encryption", "2");
        }

        public CsiDocument(ICsiSession session, string xml)
        {
            this.mSession = session;
            this.BuildFromString(xml);
            this.mResponseDocument = (ICsiDocument)null;
        }

        public ICsiDocument Submit()
        {
            this.mResponseDocument = (ICsiDocument)null;
            try
            {
                this.mResponseDocument = (this.mSession as CsiSession).Submit((ICsiDocument)this);
            }
            catch (Exception ex)
            {
                throw new CsiClientException(-1L, ex, this.GetType().FullName + ".submit(),"+this.AsXml());
            }
            return this.mResponseDocument;
        }

        public void BuildFromString(string xml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = false;
                doc.LoadXml(xml);
                this.SetDocument(doc);
            }
            catch (XmlException ex)
            {
                throw new CsiClientException(-1L, (Exception)ex, this.GetType().FullName + ".buildFromString()");
            }
        }

        public string AsXml()
        {
            StringBuilder sb = new StringBuilder();
            this.mRequestDocument.Save((XmlWriter)new XmlTextWriter((TextWriter)new StringWriter(sb)));
            return sb.ToString();
        }

        public ICsiService CreateService(string serviceType)
        {
            if (StringUtil.IsEmptyString(serviceType))
                throw new CsiClientException(-1L, "不能创建名称为空的服务", this.GetType().FullName + ".createService()");
            return (ICsiService)new CsiService((ICsiDocument)this, serviceType, this.mRootElement);
        }

        public virtual bool GetAlwaysReturnSelectionValues()
        {
            return this.GetRootElement().FindChildByName("__session" + (object)'.' + "__connect" + (object)'.' + "__processingDefaults" + (object)'.' + "__alwaysGetSelectionValues") != null;
        }

        public virtual void SetAlwaysReturnSelectionValues(bool val)
        {
            if (val == this.GetAlwaysReturnSelectionValues())
                return;
            ICsiXmlElement childByName1 = this.GetRootElement().FindChildByName("__session");
            if (childByName1 == null)
                throw new CsiClientException(-1L, "会话不存在", this.GetType().FullName + ".setAlwaysReturnSelectionValues()");
            ICsiXmlElement childByName2 = childByName1.FindChildByName("__connect");
            if (childByName2 == null)
                throw new CsiClientException(-1L, "连接不存在", this.GetType().FullName + ".setAlwaysReturnSelectionValues()");
            ICsiXmlElement parentElement = childByName2.FindChildByName("__processingDefaults") ?? (ICsiXmlElement)new CsiXmlElement((ICsiDocument)this, "__processingDefaults", childByName2);
            ICsiXmlElement childByName3 = parentElement.FindChildByName("__alwaysGetSelectionValues");
            if (childByName3 == null)
            {
                ICsiXmlElement csiXmlElement = (ICsiXmlElement)new CsiXmlElement((ICsiDocument)this, "__alwaysGetSelectionValues", parentElement);
            }
            else
                parentElement.RemoveChild(childByName3);
        }

        public virtual ICsiService GetService()
        {
            ICsiService csiService = (ICsiService)null;
            IEnumerator enumerator = this.GetServices().GetEnumerator();
            if (enumerator.MoveNext())
                csiService = enumerator.Current as ICsiService;
            return csiService;
        }

        public virtual ICsiService[] GetServices()
        {
            XmlNodeList elementsByTagName = this.mRequestDocument.GetElementsByTagName("__service");
            ICsiService[] csiServiceArray = (ICsiService[])new CsiService[elementsByTagName.Count];
            for (int index = 0; index < elementsByTagName.Count; ++index)
            {
                XmlNode xmlNode = elementsByTagName[index];
                csiServiceArray[index] = (ICsiService)new CsiService((ICsiDocument)this, xmlNode as XmlElement);
            }
            return csiServiceArray;
        }

        public bool CheckErrors()
        {
            if (this.mExceptions.Count == 0)
            {
                foreach (XmlNode xmlNode in this.mRequestDocument.GetElementsByTagName("__exceptionData"))
                    this.mExceptions.Add((object)new CsiExceptionData((ICsiDocument)this, xmlNode as XmlElement));
            }
            return this.mExceptions.Count > 0;
        }

        public virtual Array GetExceptions()
        {
            if (this.mExceptions.Count == 0 && !this.CheckErrors())
                return (Array)null;
            return (Array)this.mExceptions.ToArray();
        }

        public ICsiResponseData ResponseData()
        {
            return this.GetRootElement().FindChildByName("__responseData") as ICsiResponseData;
        }

        public ICsiExceptionData ExceptionData()
        {
            if (this.mExceptions.Count == 0 && !this.CheckErrors())
                return (ICsiExceptionData)null;
            return this.mExceptions[0] as ICsiExceptionData;
        }

        public ICsiRequestData RequestData()
        {
            return (ICsiRequestData)(this.GetRootElement().FindChildByName("__requestData") as CsiRequestData ?? new CsiRequestData((ICsiDocument)this, this.GetRootElement()));
        }

        public ICsiQuery CreateQuery()
        {
            return (ICsiQuery)new CsiQuery((ICsiDocument)this, this.mRootElement);
        }

        public virtual ICsiQuery GetQuery()
        {
            ICsiQuery csiQuery = (ICsiQuery)null;
            XmlNodeList elementsByTagName = this.mRequestDocument.GetElementsByTagName("__query");
            if (elementsByTagName.Count > 0)
                csiQuery = (ICsiQuery)new CsiQuery((ICsiDocument)this, elementsByTagName[0] as XmlElement);
            return csiQuery;
        }

        public virtual ICsiQuery[] GetQueries()
        {
            XmlNodeList elementsByTagName = this.mRequestDocument.GetElementsByTagName("__query");
            ICsiQuery[] csiQueryArray = (ICsiQuery[])new CsiQuery[elementsByTagName.Count];
            for (int index = 0; index < elementsByTagName.Count; ++index)
            {
                XmlNode xmlNode = elementsByTagName[index];
                csiQueryArray[index] = (ICsiQuery)new CsiQuery((ICsiDocument)this, xmlNode as XmlElement);
            }
            return csiQueryArray;
        }

        public string SaveRequestData(string filename, bool append)
        {
            FileMode mode = append ? FileMode.Append : FileMode.Create;
            FileStream fileStream = new FileStream(filename, mode);
            XmlTextWriter xmlTextWriter = new XmlTextWriter((Stream)fileStream, (Encoding)null);
            xmlTextWriter.Formatting = Formatting.Indented;
            this.mRequestDocument.Save((XmlWriter)xmlTextWriter);
            xmlTextWriter.Close();
            fileStream.Close();
            return this.AsXml();
        }

        public string SaveResponseData(string filename, bool append)
        {
            mResponseDocument?.SaveRequestData(filename, append);
            return this.mResponseDocument.AsXml();
        }

        public string GetTxnGuid()
        {
            string str = string.Empty;
            ICsiService service = this.GetService();
            if (service != null)
            {
                IEnumerator enumerator = service.GetChildrenByName("__txnGUID").GetEnumerator();
                if (enumerator.MoveNext())
                    str = (enumerator.Current as CsiXmlElement).GetElementValue();
            }
            return str;
        }

        protected internal XmlElement CreateDomElement(string tagName)
        {
            return this.mRequestDocument.CreateElement(tagName);
        }

        protected internal virtual ICsiXmlElement GetRootElement()
        {
            return this.mRootElement;
        }

        private void SetDocument(XmlDocument doc)
        {
            this.mRequestDocument = doc;
            this.mRootElement = (ICsiXmlElement)new CsiXmlElement((ICsiDocument)this, doc.DocumentElement);
            this.mExceptions.Clear();
        }
    }
}