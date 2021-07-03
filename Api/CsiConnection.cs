using System.Collections;
using System.Collections.Generic;
using InSiteXmlClient4Core.InterFace;
using InSiteXmlClient4Core.Utility;

namespace InSiteXmlClient4Core.Api
{
    /// <summary>
    /// 连接
    /// </summary>
    public class CsiConnection : ICsiConnection
    {
        private Hashtable _sessions = new Hashtable();
        private string _host;
        private int _port;
        private int _timeout;

        public CsiConnection(string host, int port)
        {
            this._host = host;
            this._port = port;
            this._timeout = 0;
        }

        /// <summary>
        /// 记录会话
        /// </summary>
        public bool LogSesssion
        {
            get { return mServerConnection.LogXml; }
            set { mServerConnection.LogXml = value; }
        }

        private ServerConnection mServerConnection = new ServerConnection();

        public ICsiSession CreateSession(string userName, string password, string sessionName)
        {
            lock (this)
            {
                if (this.FindSession(sessionName) != null)
                    throw new Exceptions.CsiClientException(3014680L, this.GetType().FullName + "创建会话");
                ICsiSession csiSession = (ICsiSession)new CsiSession(userName, password, (ICsiConnection)this);
                this._sessions[(object)sessionName] = (object)csiSession;
                return csiSession;
            }
        }

        public ICsiSession CreateSessionWithSessionId(string userName, string sessionId, string sessionName)
        {
            lock (this)
            {
                ICsiSession session;
                if (this.FindSession(sessionName) == null)
                {
                    session = new CsiSession(userName, string.Empty, this)
                    {
                        SessionId = sessionId
                    };
                    this._sessions[sessionName] = session;
                }
                else
                {
                    string src = base.GetType().FullName + "使用ID创建会话";
                    throw new Exceptions.CsiClientException(0x2e0018L, src);
                }
                return session;
            }
        }

        public ICsiSession FindSession(string sessionName) =>
            this._sessions[sessionName] as ICsiSession;

        public void RemoveSession(string sessionName)
        {
            lock (this)
            {
                this._sessions.Remove(sessionName);
            }
        }

        public int SetConnectionTimeout(int timeout)
        {
            int _timeout = this._timeout;
            this._timeout = (timeout > 0) ? timeout : 0;
            this.mServerConnection.SendTimeout = this.mServerConnection.ReceiveTimeout = this._timeout;
            return _timeout;
        }

        public string Submit(string requestXml) => this.mServerConnection.Submit(this._host, this._port, requestXml);
    }
}