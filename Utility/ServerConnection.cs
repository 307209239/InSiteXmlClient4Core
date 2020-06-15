using System;
using System.IO;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using InSiteXmlClient4Core.Util;

namespace InSiteXmlClient4Core.Utility
{
    /// <summary>
    ///     服务器连接
    /// </summary>
    public class ServerConnection
    {
        private string mConfigurationFile = string.Empty;
        private string mHost = "localhost";
        private string mInboundXML = string.Empty;
        private string mInboundXMLFile = string.Empty;
        private bool mLogXml;
        private int mPort = 2881;
        private NetworkStream mStream;
        private TcpClient mTcpClient;
        private string mXMLLogPath = "C:\\Temp";

        /// <summary>
        ///     服务器地址
        /// </summary>
        public virtual string Host
        {
            get => mHost;
            set => mHost = StringUtil.IsEmptyString(value) ? "localhost" : value;
        }

        /// <summary>
        ///     端口
        /// </summary>
        public virtual int Port
        {
            get => mPort;
            set
            {
                if (0 <= value && value <= ushort.MaxValue)
                    mPort = value;
                else
                    mPort = 2881;
            }
        }

        /// <summary>
        ///     发送超时时间
        /// </summary>
        public virtual int SendTimeout { get; set; } = 300000;

        /// <summary>
        ///     接收超时时间
        /// </summary>
        public virtual int ReceiveTimeout { get; set; } = 300000;

        #region CAMStar

        public virtual string ConfigurationFile
        {
            get => mConfigurationFile;
            set
            {
                if (StringUtil.IsEmptyString(value))
                    return;
                mConfigurationFile = value;
            }
        }

        public virtual bool LogXml
        {
            get => mLogXml;
            set => mLogXml = value;
        }

        public virtual string XmlLogPath
        {
            get => mXMLLogPath;
            set
            {
                mXMLLogPath = value;
                try
                {
                    mXMLLogPath = Environment.GetEnvironmentVariable("TEMP");
                }
                catch (SecurityException ex)
                {
                    LogHelper.Error<ServerConnection>(ex.Message);
                }
            }
        }

        public virtual string InboundXml
        {
            get => mInboundXML;
            set
            {
                if (StringUtil.IsEmptyString(value))
                    return;
                mInboundXML = value;
            }
        }

        public virtual string InboundXmlFile
        {
            get => mInboundXMLFile;
            set
            {
                var chArray = new char[3]
                {
                    '\n',
                    char.MinValue,
                    ' '
                };
                if (!StringUtil.IsEmptyString(value) && value.Trim(chArray).Length > 1)
                {
                    mInboundXMLFile = value;
                    using (var streamReader = new StreamReader(mInboundXMLFile))
                    {
                        mInboundXML = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                }
                else
                {
                    mInboundXMLFile = "";
                }
            }
        }

        ~ServerConnection()
        {
            Disconnect();
        }

        /// <summary>
        ///     连接到服务器 ,Host:Localhost port:2881
        /// </summary>
        public virtual bool Connect()
        {
            return Connect("localHost", 2881);
        }

        /// <summary>
        ///     连接到服务器
        /// </summary>
        /// <param name="hostName">服务器地址</param>
        /// <param name="portNo">端口</param>
        /// <returns></returns>
        public virtual bool Connect(string hostName, int portNo)
        {
            if (Host == null)
                throw new ArgumentNullException();
            bool flag;
            try
            {
                mTcpClient = new TcpClient();
                mTcpClient.ReceiveBufferSize = 75000;
                mTcpClient.SendTimeout = SendTimeout;
                mTcpClient.ReceiveTimeout = ReceiveTimeout;
                mTcpClient.Connect(Host, Port);
                mStream = mTcpClient.GetStream();
                flag = true;
            }
            catch (SocketException ex)
            {
                mTcpClient = null;
                throw new Exception($"连接服务器:{Host} 端口{Port} 失败,{ex.Message}");
                flag = false;
            }

            return flag;
        }

        /// <summary>
        ///     断开连接
        /// </summary>
        public virtual void Disconnect()
        {
            if (mTcpClient == null)
                return;
            mStream?.Close();
            mTcpClient.Close();
            mTcpClient = null;
        }

        /// <summary>
        ///     发送
        /// </summary>
        /// <returns></returns>
        public virtual bool Send()
        {
            var flag = false;
            if (mTcpClient == null) return flag;
            try
            {
                SendRequest();
                flag = true;
            }
            catch (Exception ex)
            {
               
                throw new Exception($"发送失败：{ex.Message}");
            }

            return flag;
        }

        public virtual bool Send(string inputXml)
        {
            InboundXml = inputXml;
            return Send();
        }

        /// <summary>
        ///     接收数据
        /// </summary>
        /// <param name="outputXml"></param>
        /// <returns></returns>
        public virtual bool Receive(out string outputXml)
        {
            var flag = false;
            outputXml = string.Empty;
            if (mTcpClient != null)
                try
                {
                    outputXml = ReceiveResponse();
                    flag = true;
                    if (LogXml)
                        LogDocument("XmlResponse", outputXml);
                }
                catch (Exception ex)
                {
                 
                    throw new Exception($"接收失败：{ex.Message}");
                }

            return flag;
        }

        public virtual string Submit(string host, int port)
        {
            return Submit(host, port, null, null, mLogXml, null);
        }

        public virtual string Submit(string host, int port, string inboundXML)
        {
            return Submit(host, port, inboundXML, null, mLogXml, null);
        }

        public virtual string Submit(string host, int port, string inboundXML, bool logXML)
        {
            return Submit(host, port, inboundXML, null, logXML, null);
        }

        public virtual string Submit(string host, int port, string inboundXML, bool logXML, string xmlLogPath)
        {
            return Submit(host, port, inboundXML, null, logXML, xmlLogPath);
        }

        public virtual string Submit(string host, int port, string inboundXML, string inboundXMLFilePath)
        {
            return Submit(host, port, inboundXML, inboundXMLFilePath, mLogXml, null);
        }

        public virtual string Submit(string host, int port, string inboundXML, string inboundXMLFilePath, bool logXML)
        {
            return Submit(host, port, inboundXML, inboundXMLFilePath, logXML, null);
        }

        public virtual string Submit(string host, int port, string inboundXML, string inboundXMLFilePath, bool logXML,
            string xmlLogPath)
        {
            if (!StringUtil.IsEmptyString(host))
                mHost = host;
            if (port != -1)
                mPort = port;
            if (!StringUtil.IsEmptyString(inboundXML))
                mInboundXML = inboundXML;
            mLogXml = logXML;
            if (!StringUtil.IsEmptyString(inboundXMLFilePath))
                InboundXmlFile = inboundXMLFilePath;
            if (!StringUtil.IsEmptyString(xmlLogPath))
                XmlLogPath = xmlLogPath;
            return Submit();
        }


        public virtual string Submit(string host)
        {
            return Submit(host, -1, null, null, mLogXml, null);
        }

        public virtual string Submit(string host, string inboundXML)
        {
            return Submit(host, -1, inboundXML, null, mLogXml, null);
        }

        public virtual string Submit(string host, string inboundXML, bool logXML)
        {
            return Submit(host, -1, inboundXML, null, logXML, null);
        }

        public virtual string Submit(string host, string inboundXML, bool logXML, string xmlLogPath)
        {
            return Submit(host, -1, inboundXML, null, logXML, xmlLogPath);
        }

        public virtual string Submit(string host, string inboundXML, string inboundXMLFilePath)
        {
            return Submit(host, -1, inboundXML, inboundXMLFilePath, mLogXml, null);
        }

        public virtual string Submit(string host, string inboundXML, string inboundXMLFilePath, bool logXML)
        {
            return Submit(host, -1, inboundXML, inboundXMLFilePath, logXML, null);
        }

        public virtual string Submit(string host, string inboundXML, string inboundXMLFilePath, bool logXML,
            string xmlLogPath)
        {
            return Submit(host, -1, inboundXML, inboundXMLFilePath, logXML, xmlLogPath);
        }

        public virtual string Submit()
        {
            lock (this)
            {
                var outputXML = string.Empty;
                try
                {
                    if (Connect())
                        if (Send())
                            Receive(out outputXML);
                }
                catch (Exception ex)
                {
                    LogHelper.Error<ServerConnection>($"提交失败：{ex.Message}");
                }
                finally
                {
                    Disconnect();
                }

                return outputXML;
            }
        }


        protected virtual void SendRequest()
        {
            var str = EncryptPassword(InboundXml) + "\0";
            if (LogXml)
                LogDocument("XmlRequest", str);
            var bytes = Encoding.Unicode.GetBytes(str);
            mStream.Write(bytes, 0, bytes.Length);
        }

        protected virtual string ReceiveResponse()
        {
            var empty = string.Empty;
            byte num = 0;
            var flag = false;
            var numArray = new byte[mTcpClient.ReceiveBufferSize + 1];
            try
            {
                int count;
                do
                {
                    int offset;
                    if (flag)
                    {
                        offset = 1;
                        numArray[0] = num;
                    }
                    else
                    {
                        offset = 0;
                    }

                    count = mStream.Read(numArray, offset, mTcpClient.ReceiveBufferSize);
                    if (flag)
                        ++count;
                    if (count > 0)
                    {
                        flag = count % 2 == 1;
                        if (flag)
                        {
                            --count;
                            num = numArray[count];
                        }

                        empty += Encoding.Unicode.GetString(numArray, 0, count);
                    }
                } while (count > 0 || mStream.DataAvailable);
            }
            catch (IOException ex)
            {
                empty.TrimEnd(new char[1]);
                LogHelper.Error<ServerConnection>($"接收超时:{ex.Message}");
            }

            return empty.TrimEnd(new char[1]);
        }

        protected string GetConfigValue(XmlNode node, string keyName)
        {
            var str = string.Empty;
            var xmlNode = node.SelectSingleNode(keyName);
            if (xmlNode != null && !StringUtil.IsEmptyString(xmlNode.InnerText))
                str = xmlNode.InnerText;
            return str;
        }

        protected virtual string MaskPassword(string document)
        {
            var str = document;
            var startIndex = document.IndexOf("<password");
            var num = document.IndexOf("</password>");
            if (startIndex >= 0 && num >= 0)
            {
                var length = num + "</password>".Length - startIndex;
                var oldValue = document.Substring(startIndex, length);
                var newValue = "<password>" + new string('*', 8) + "</password>";
                str = document.Replace(oldValue, newValue);
            }

            return str;
        }

        protected virtual string EncryptPassword(string document)
        {
            var str1 = document;
            var xmlWriter = (XmlWriter) null;
            var reader = (XmlReader) null;
            var flag1 = false;
            try
            {
                var sb = new StringBuilder();
                xmlWriter = new XmlTextWriter(new StringWriter(sb));
                var settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;
                reader = XmlReader.Create(new StringReader(document), settings);
                if (reader.Read())
                    do
                    {
                        if (reader.NodeType == XmlNodeType.Element &&
                            (reader.LocalName == "__session" || reader.LocalName == "__connect"))
                        {
                            reader.Read();
                        }
                        else if (reader.NodeType == XmlNodeType.Element &&
                                 (reader.LocalName == "password" || reader.LocalName == "sessionId"))
                        {
                            for (var flag2 = reader.MoveToFirstAttribute(); flag2; flag2 = reader.MoveToNextAttribute())
                                if (reader.LocalName == "__encrypted" && string.Compare(reader.Value, "yes", true) == 0)
                                    flag1 = true;
                            reader.Close();
                        }
                        else
                        {
                            reader.Read();
                        }
                    } while (!reader.EOF && reader.ReadState != ReadState.Closed);

                reader = XmlReader.Create(new StringReader(document), settings);
                if (reader.Read())
                {
                    do
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "__InSite")
                        {
                            var str2 = (string) null;
                            xmlWriter.WriteStartElement(reader.LocalName);
                            for (var flag2 = reader.MoveToFirstAttribute(); flag2; flag2 = reader.MoveToNextAttribute())
                                if (reader.LocalName == "__encryption")
                                    str2 = reader.Value;
                                else
                                    xmlWriter.WriteAttributeString(reader.LocalName, reader.Value);
                            if (!flag1)
                                str2 = "2";
                            if (!string.IsNullOrEmpty(str2))
                                xmlWriter.WriteAttributeString("__encryption", str2);
                            reader.Read();
                        }
                        else if (reader.NodeType == XmlNodeType.Element &&
                                 (reader.LocalName == "__session" || reader.LocalName == "__connect"))
                        {
                            xmlWriter.WriteStartElement(reader.LocalName);
                            xmlWriter.WriteAttributes(reader, true);
                            reader.Read();
                        }
                        else if (reader.NodeType == XmlNodeType.EndElement &&
                                 (reader.LocalName == "__session" || reader.LocalName == "__connect"))
                        {
                            xmlWriter.WriteEndElement();
                            reader.Read();
                        }
                        else if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "password")
                        {
                            if (!flag1)
                            {
                                xmlWriter.WriteStartElement(reader.LocalName);
                                for (var flag2 = reader.MoveToFirstAttribute();
                                    flag2;
                                    flag2 = reader.MoveToNextAttribute())
                                    if (reader.LocalName != "__encrypted")
                                        xmlWriter.WriteAttributeString(reader.LocalName, reader.Value);
                                xmlWriter.WriteAttributeString("__encrypted", "no");
                                var content = (int) reader.MoveToContent();
                                var fieldData = reader.ReadElementContentAsString();
                                // xmlWriter.WriteValue(CryptUtil.Encrypt(fieldData));
                                xmlWriter.WriteValue(fieldData);
                                xmlWriter.WriteEndElement();
                            }
                            else
                            {
                                xmlWriter.WriteNode(reader, true);
                            }
                        }
                        else
                        {
                            xmlWriter.WriteNode(reader, true);
                        }
                    } while (!reader.EOF);

                    str1 = sb.ToString();
                }
            }
            catch (Exception ex)
            {
                str1 = document;
                LogHelper.Error<ServerConnection>($"密码加密失败：{ex.Message}");
            }
            finally
            {
                reader?.Close();
                xmlWriter?.Close();
            }

            return str1;
        }

        protected virtual void LogDocument(string operation, string document)
        {
            try
            {
                var document1 = document.Replace("encoding=\"utf-16\"", "").Replace("encoding='UTF-16LE'", "")
                    .Replace("encoding=\"UTF-16LE\"", "");
                if (document1[document1.Length - 1] == 0)
                    document1 = document1.Remove(document1.Length - 1, 1);
                var streamWriter = new StreamWriter(Path.Combine(Path.GetTempPath(), "Insite.log"), false,
                    Encoding.Default);
                streamWriter.WriteLine(MaskPassword(document1));
                streamWriter.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private string XmlNodeToString(XmlNode node)
        {
            var empty = string.Empty;
            if (node != null)
            {
                var sb = new StringBuilder();
                var xmlTextWriter = new XmlTextWriter(new StringWriter(sb));
                node.WriteTo(xmlTextWriter);
                empty = sb.ToString();
            }

            return empty;
        }

        #endregion

        //#region 异步处理

        //public virtual async Task<string> SubmitAsync(string host, int port, string inboundXML,
        //    string inboundXMLFilePath, bool logXML, string xmlLogPath)
        //{
        //    if (!StringUtil.IsEmptyString(host))
        //        mHost = host;
        //    if (port != -1)
        //        mPort = port;
        //    if (!StringUtil.IsEmptyString(inboundXML))
        //        mInboundXML = inboundXML;
        //    mLogXml = logXML;
        //    if (!StringUtil.IsEmptyString(inboundXMLFilePath))
        //        InboundXmlFile = inboundXMLFilePath;
        //    if (!StringUtil.IsEmptyString(xmlLogPath))
        //        XmlLogPath = xmlLogPath;
        //    return await SubmitAsync();
        //}

        //protected virtual async Task SendRequestAsync()
        //{
        //    var str = EncryptPassword(InboundXml) + "\0";
        //    if (LogXml)
        //        LogDocument("XmlRequest", str);
        //    var bytes = Encoding.Unicode.GetBytes(str);
        //    await mStream.WriteAsync(bytes, 0, bytes.Length);
        //}

        //public virtual async Task<string> SubmitAsync()
        //{
        //    var outputXML = string.Empty;
        //    try
        //    {
        //        var c = await ConnectAsync();
        //        if (c)
        //        {
        //            var b = await SendAsync();
        //            if (b)
        //            {
        //                var r = await ReceiveAsync();
        //                outputXML = r.Item2;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error<ServerConnection>($"提交失败：{ex.Message}");
        //    }
        //    finally
        //    {
        //        Disconnect();
        //    }

        //    return outputXML;
        //}

        //public virtual async Task<bool> ConnectAsync()
        //{
        //    return await ConnectAsync("localHost", 2881);
        //}

        ///// <summary>
        /////     连接到服务器
        ///// </summary>
        ///// <param name="hostName">服务器地址</param>
        ///// <param name="portNo">端口</param>
        ///// <returns></returns>
        //public virtual async Task<bool> ConnectAsync(string hostName, int portNo)
        //{
        //    if (Host == null)
        //        throw new ArgumentNullException();
        //    bool flag;
        //    try
        //    {
        //        mTcpClient = new TcpClient();
        //        mTcpClient.ReceiveBufferSize = 75000;
        //        mTcpClient.SendTimeout = SendTimeout;
        //        mTcpClient.ReceiveTimeout = ReceiveTimeout;
        //        await mTcpClient.ConnectAsync(Host, Port);
        //        mStream = mTcpClient.GetStream();
        //        flag = true;
        //    }
        //    catch (SocketException ex)
        //    {
        //        mTcpClient = null;
        //        LogHelper.Error<ServerConnection>($"连接服务器:{Host} 端口{Port} 失败,{ex.Message}");
        //        flag = false;
        //    }

        //    return flag;
        //}

        ///// <summary>
        /////     接收数据
        ///// </summary>
        ///// <returns></returns>
        //public virtual async Task<Tuple<bool, string>> ReceiveAsync()
        //{
        //    var flag = false;
        //    var outputXml = string.Empty;
        //    if (mTcpClient != null)
        //        try
        //        {
        //            outputXml = await ReceiveResponseAsync();
        //            flag = true;
        //            if (LogXml)
        //                LogDocument("XmlResponse", outputXml);
        //        }
        //        catch (Exception ex)
        //        {
        //            LogHelper.Error<ServerConnection>($"接收失败：{ex.Message}");
        //        }

        //    return new Tuple<bool, string>(flag, outputXml);
        //}

        //protected virtual async Task<string> ReceiveResponseAsync()
        //{
        //    var empty = string.Empty;
        //    byte num = 0;
        //    var flag = false;
        //    var numArray = new byte[mTcpClient.ReceiveBufferSize + 1];
        //    try
        //    {
        //        int count;
        //        do
        //        {
        //            int offset;
        //            if (flag)
        //            {
        //                offset = 1;
        //                numArray[0] = num;
        //            }
        //            else
        //            {
        //                offset = 0;
        //            }

        //            count = await mStream.ReadAsync(numArray, offset, mTcpClient.ReceiveBufferSize);
        //            if (flag)
        //                ++count;
        //            if (count > 0)
        //            {
        //                flag = count % 2 == 1;
        //                if (flag)
        //                {
        //                    --count;
        //                    num = numArray[count];
        //                }

        //                empty += Encoding.Unicode.GetString(numArray, 0, count);
        //            }
        //        } while (count > 0 || mStream.DataAvailable);
        //    }
        //    catch (IOException ex)
        //    {
        //        empty.TrimEnd(new char[1]);
        //        LogHelper.Error<ServerConnection>($"接收超时:{ex.Message}");
        //    }

        //    return empty.TrimEnd(new char[1]);
        //}

        ///// <summary>
        /////     发送
        ///// </summary>
        ///// <returns></returns>
        //public virtual async Task<bool> SendAsync()
        //{
        //    var flag = false;
        //    if (mTcpClient == null) return flag;
        //    try
        //    {
        //        await SendRequestAsync();
        //        flag = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error<ServerConnection>($"发送失败：{ex.Message}");
        //        flag = false;
        //    }

        //    return flag;
        //}

        //#endregion
    }
}