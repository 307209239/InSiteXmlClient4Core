using System;
using System.Collections;
using System.Runtime.Serialization;

namespace InSiteXmlClient4Core.Exceptions
{
    [Serializable]
    internal class CsiClientException : Exception
    {
        private long mErrorCode;
        private static readonly Hashtable mErrorMessages = new Hashtable();
        public const long mkAccessDenied = 0xce011dL;
        public const long mkBadPointer = 0xde0003L;
        public const long mkCreateObjFailed = 0xde001fL;
        public const long mkCsiXMLClientCannotCreateANewNode = 0x2e0014L;
        public const long mkCsiXMLClientCannotCreateAnObject = 0x2e0004L;
        public const long mkCsiXMLClientCannotCreateRequestTag = 0x2e0008L;
        public const long mkCsiXMLClientCannotFindAChild = 0x2e0005L;
        public const long mkCsiXMLClientCannotMakeDeepCopy = 0x2e0007L;
        public const long mkCsiXMLClientConnectionWithSameHostPortExists = 0x2e0019L;
        public const long mkCsiXMLClientDocumentWithSameNameExists = 0x2e0015L;
        public const long mkCsiXMLClientDOMErrGetNodeNameValue = 0x2e0000L;
        public const long mkCsiXMLClientDOMErrInvalidName = 0x2e0001L;
        public const long mkCsiXMLClientDOMNoModificationAllowed = 0x2e0003L;
        public const long mkCsiXMLClientDOMUnknownErr = 0x2e0002L;
        public const long mkCsiXMLClientEmptyName = 0x2e0016L;
        public const long mkCsiXMLClientFailToCreateAllFieldTag = 0x2e000aL;
        public const long mkCsiXMLClientFailToCreateAnAppendItem = 0x2e000dL;
        public const long mkCsiXMLClientFailToGetAllResponseFields = 0x2e0009L;
        public const long mkCsiXMLClientFailToGetAllSelectionValuesField = 0x2e000cL;
        public const long mkCsiXMLClientFailToGetDataSourceName = 0x2e000fL;
        public const long mkCsiXMLClientFailToGetQueryName = 0x2e0010L;
        public const long mkCsiXMLClientFailToGetRowSetSize = 0x2e0011L;
        public const long mkCsiXMLClientFailToGetSqlText = 0x2e0012L;
        public const long mkCsiXMLClientFailToGetStartRow = 0x2e0013L;
        public const long mkCsiXMLClientFailToRemoveParameterNodes = 0x2e000eL;
        public const long mkCsiXMLClientInsiteTagNotFound = 0x2e0006L;
        public const long mkCsiXMLClientNamedParameterNotFound = 0x2e000bL;
        public const long mkCsiXMLClientSessionWithSameNameExists = 0x2e0018L;
        public const long mkCsiXMLClientUnknownFormat = -2147467259L;
        public const long mkCsiXMLClientWrongParameters = 0x2e001aL;
        public const long mkGeneralError = 0x400L;
        public const long mkInvalidCDODefID = 0x401L;
        public const long mkInvalidCDOFieldID = 0x40aL;
        public const long mkObjectNotFound = 0xce0013L;
        private string mLongMessage;

        static CsiClientException()
        {
            mErrorMessages.Add(0x400L, "Admininstrative System Error");
            mErrorMessages.Add(0x401L, "无效的CDO的定义 \"#ErrorMsg.CDOID\"");
            mErrorMessages.Add(0x40aL, "无效的字段标识");
            mErrorMessages.Add(0xce0013L, "没有找到实例");
            mErrorMessages.Add(0xce011dL, "拒绝访问");
            mErrorMessages.Add(0xde0003L, "坏的指针");
            mErrorMessages.Add(0xde001fL, "创建实例失败");
            mErrorMessages.Add(0x2e0014L, "不能创建DOM元素");
            mErrorMessages.Add(0x2e0004L, "不能创建XMLClient实例");
            mErrorMessages.Add(0x2e0008L, "不能创建<__Request>标签");
            mErrorMessages.Add(0x2e0005L, "找不到指定的子节点");
            mErrorMessages.Add(0x2e0007L, "不能作深度复制");
            mErrorMessages.Add(0x2e0000L, "DOM试图获取节点的名称和值时发生错误");
            mErrorMessages.Add(0x2e0001L, "无效的名称");
            mErrorMessages.Add(0x2e0003L, "对DOM节点不允许修改");
            mErrorMessages.Add(0x2e0002L, "来自xml DOM的未知错误");
            mErrorMessages.Add(0x2e000aL, "创建<__allFields/> 标签失败");
            mErrorMessages.Add(0x2e000dL, "创建<__listItem/> 元素失败");
            mErrorMessages.Add(0x2e0009L, "未能获取所有返回字段");
            mErrorMessages.Add(0x2e000cL, "不能获得选择值");
            mErrorMessages.Add(0x2e000fL, "不能找到<__dataSourceName> 标签");
            mErrorMessages.Add(0x2e0010L, "<__queryName> 标签没有找到");
            mErrorMessages.Add(0x2e0011L, "<__rowSetSize> 标签没有找到!");
            mErrorMessages.Add(0x2e0012L, "<__queryText> 标签没有找到");
            mErrorMessages.Add(0x2e0013L, "<__startRow> 标签没有找到!");
            mErrorMessages.Add(0x2e000eL, "删除 <__parameter/>节点失败");
            mErrorMessages.Add(0x2e0006L, "<__InSite>标签没有找到");
            mErrorMessages.Add(0x2e000bL, "没有找到指定的参数");
            mErrorMessages.Add(0x2e0019L, "已存在相同主机名和端口的连接");
            mErrorMessages.Add(0x2e0018L, "已存在相同的会话名");
            mErrorMessages.Add(0x2e0015L, "已存在相同的文档名");
            mErrorMessages.Add(0x2e0016L, "名称为空");
            mErrorMessages.Add(-2147467259L, "未知的格式");
            mErrorMessages.Add(0x2e001aL, "错误的参数");
            mErrorMessages.Add(-1L, "连接服务器失败");
        }

        internal CsiClientException(long err, string src)
        {
            this.mLongMessage = string.Empty;
            this.mErrorCode = 0L;
            this.mErrorCode = err;
            string str = "";
            if (err != -1L)
            {
                str = (string)mErrorMessages[err];
            }
            this.mLongMessage = "(错误代码：" + err.ToString() + ",错误原因：" + src + "): " + str;
        }

        internal CsiClientException(long err, Exception exp, string src) : this(err, exp.Message, src)
        {
        }

        internal CsiClientException(long err, string desc, string src)
        {
            this.mLongMessage = string.Empty;
            this.mErrorCode = 0L;
            this.mErrorCode = err;
            if (err == -1L)
            {
                src= (string)mErrorMessages[err];
            }
            this.mLongMessage = "(错误代码：" + err.ToString() + ", 错误原因：" + src + "): " + desc;
        }

        public long ErrorCode =>
            this.mErrorCode;

        public override string Message =>
            this.mLongMessage;
    }
}