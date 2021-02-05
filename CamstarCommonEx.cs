using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using InSiteXmlClient4Core.InterFace;

namespace InSiteXmlClient4Core
{
    /// <summary>
    /// CamstarCommon 扩展类
    /// </summary>
    public static class CamstarCommonEx
    {
        /// <summary>
        /// 打印文档
        /// </summary>
        /// <param name="document">文档</param>
        /// <param name="isInput">是否输入文档</param>
        public static void Print(this ICsiDocument document, bool isInput = false)
        {
            PrintDocument(document.AsXml(), isInput);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="isInput"></param>
        private static void PrintDocument(string doc, bool isInput)
        {
            string filePath = Path.GetTempPath();
            filePath = Path.Combine(filePath, isInput ? "request.xml" : "response.xml");
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                StreamWriter writer = new StreamWriter(fs);
                writer.Write(doc);
                writer.Flush();
                writer.Close();
                fs.Close();
            }

        }
        /// <summary>
        /// 检查错误，并返回错误信息,存在错误返回true
        /// </summary>
        /// <param name="document">文档</param>
        /// <param name="errorMsg">错误信息</param>
        /// <returns>存在错误返回true</returns>
        public static bool CheckErrors(this ICsiDocument document, ref string errorMsg)
        {
            ICsiExceptionData exceptionData;
            ICsiDataField completionMessage;
            ICsiService gService;

            if (document.CheckErrors())
            {
                exceptionData = document.ExceptionData();
                errorMsg = exceptionData.GetDescription();
                return true;
            }
            else
            {
                gService = document.GetService();
                if (gService != null)
                {
                    completionMessage = (ICsiDataField)gService.ResponseData().GetResponseFieldByName("CompletionMsg");
                    errorMsg = completionMessage.GetValue();
                }

                return false;
            }
        }
        /// <summary>
        /// 检查文档错误，并处理错误信息,存在错误返回true
        /// </summary>
        /// <param name="document">文档</param>
        /// <param name="action">处理方法</param>
        /// <returns>存在错误返回true</returns>
        public static bool CheckErrors(this ICsiDocument document, Action<string> action)
        {
            string msg = string.Empty;
            bool result = document.CheckErrors(ref msg);
            action(msg);
            return result;

        }
        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="csiDataField"></param>
        /// <param name="value"></param>
        public static void SetValue(this ICsiDataField csiDataField, object value)
        {

            if (value is bool b)
            {
                csiDataField.SetValue(b?1:0);
            }
            else if (value is DateTime)
            {
                csiDataField.SetValue(((DateTime)value).ToString("O"));
            }
            else
            {
                csiDataField.SetValue(value.ToString());
            }
        }



    }
}
