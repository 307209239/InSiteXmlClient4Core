using System;
using System.Collections;
using InSiteXmlClient4Core.Exceptions;
using InSiteXmlClient4Core.InterFace;
using InSiteXmlClient4Core.Util;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiSession : ICsiSession
    {
        private Hashtable mDocuments;
        private string mUserName;
        private string mPassword;
        private string mSessionId;
        private ICsiConnection mConnection;
        public CsiSession(string name, string password, ICsiConnection connection)
        {
            this.mDocuments = new Hashtable();
            this.mUserName = name;
            this.mPassword = password;
            this.mConnection = connection;
        }

        private void CreateConnect(string userName, string password, ICsiXmlElement parent)
        {
            ICsiDocument document = parent.GetOwnerDocument();
            ICsiXmlElement element = new CsiXmlElement(document, "__connect", parent);
            ICsiNamedObject obj2 = new CsiNamedObject(document, "user", element);
            obj2.SetRef(userName);
            ICsiDataField field = new CsiDataField(document, "password", element);
            field.SetEncryptedValue(password);
           
        }

        private void CreateConnectWithoutPassword(string userName, string sessionId, ICsiXmlElement parent)
        {
            ICsiDocument document = parent.GetOwnerDocument();
            ICsiXmlElement element = new CsiXmlElement(document, "__useSession", parent);
            ICsiNamedObject obj2 = new CsiNamedObject(document, "user", element);
            obj2.SetRef(userName);
            ICsiDataField field = new CsiDataField(document, "sessionId", element);
            field.SetAttribute("__encrypted", "no");
            field.SetValue(sessionId);
        }

        public ICsiDocument CreateDocument(string name)
        {
            ICsiDocument document2;
            lock (this)
            {
                string str;
                if (!StringUtil.IsEmptyString(name))
                {
                    try
                    {
                        if (this.FindDocument(name) == null)
                        {
                            ICsiDocument document = new CsiDocument(this);
                            this.mDocuments[name] = document;
                            ICsiXmlElement parent = new CsiXmlElement(document, "__session", ((CsiDocument) document).GetRootElement());
                            if (string.IsNullOrEmpty(this.mPassword))
                            {
                                this.CreateConnectWithoutPassword(this.mUserName, this.mSessionId, parent);
                                return document;
                            }
                            this.CreateConnect(this.mUserName, this.mPassword, parent);
                            return document;
                        }
                        str = base.GetType().FullName + ".createDocument()";
                        throw new CsiClientException(0x2e0015L, str);
                    }
                    catch (Exception exception)
                    {
                        throw new CsiClientException(-1L, exception, base.GetType().FullName + ".createDocument()");
                    }
                }
                str = base.GetType().FullName + ".createDocument()";
                throw new CsiClientException(0x2e0016L, str);
            }
            return document2;
        }

        public ICsiDocument FindDocument(string name) =>
            (this.mDocuments[name] as ICsiDocument);

        public void RemoveDocument(string name)
        {
            lock (this)
            {
                this.mDocuments.Remove(name);
            }
        }

        internal ICsiDocument Submit(ICsiDocument document)
        {
            string xml = document.AsXml();
            string str2 = string.Empty;
            try
            {
                str2 = this.mConnection.Submit(xml);
            }
            catch (Exception exception)
            {
                throw new CsiClientException(-1L, exception, base.GetType().FullName + ".submit()");
            }
            return new CsiDocument(this, str2);
        }
        /// <summary>
        /// 会话ID
        /// </summary>
        public string SessionId
        {
            get => this.mSessionId;
            set => this.mSessionId = value;
        }
    }
}