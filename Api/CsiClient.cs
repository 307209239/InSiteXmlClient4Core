using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using InSiteXmlClient4Core.InterFace;

namespace InSiteXmlClient4Core.Api
{
    /// <summary>
    /// 客户端
    /// </summary>
    public class CsiClient
    {
        private Hashtable mConnections;

        public CsiClient()
        {
            this.mConnections = new Hashtable();
        }
        /// <summary>
        /// 创建连接
        /// </summary>
        /// <param name="host">服务器地址</param>
        /// <param name="port">端口</param>
        /// <returns></returns>
        public ICsiConnection CreateConnection(string host, int port)
        {
            lock (this)
            {
                ICsiConnection connection;
                if (this.FindConnection(host, port) == null)
                {
                    connection = new CsiConnection(host, port);
                    //connection.SetConnectionTimeout(1000*120);
                    string str = host + "_" + port;
                    this.mConnections[str] = connection;
                }
                else
                {
                    string src = base.GetType().FullName + "创建连接";
                    throw new Exceptions.CsiClientException(3014681L, src);
                }
                return connection;
            }
        }
        /// <summary>
        /// 查找连接
        /// </summary>
        /// <param name="host">服务器地址</param>
        /// <param name="port">端口</param>
        /// <returns></returns>
        public ICsiConnection FindConnection(string host, int port)
        {
            string str = host + "_" + port;
            return (this.mConnections[str]) as CsiConnection;
        }
        /// <summary>
        /// 删除连接
        /// </summary>
        /// <param name="host">服务器</param>
        /// <param name="port">端口</param>
        public void RemoveConnection(string host, int port)
        {
            lock (this)
            {
                string key = host + "_" + port;
                this.mConnections.Remove(key);
            }
        }
    }
}
