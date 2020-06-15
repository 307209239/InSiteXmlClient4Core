using System;

namespace InSiteXmlClient4Core.InterFace
{
    public interface ICsiDocument
    {
        /// <summary>
        /// 转换为XML
        /// </summary>
        /// <returns></returns>
        string AsXml();
        /// <summary>
        /// 建立表单字符串
        /// </summary>
        /// <param name="xml"></param>
        void BuildFromString(string xml);
        /// <summary>
        /// 检查错误
        /// </summary>
        /// <returns></returns>
        bool CheckErrors();
        /// <summary>
        /// 创建查询
        /// </summary>
        /// <returns></returns>
        ICsiQuery CreateQuery();
        /// <summary>
        /// 创建服务
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        ICsiService CreateService(string serviceType);
        /// <summary>
        /// 错误数据
        /// </summary>
        /// <returns></returns>
        ICsiExceptionData ExceptionData();
        /// <summary>
        /// 获取一直返回的选择值
        /// </summary>
        /// <returns></returns>
        bool GetAlwaysReturnSelectionValues();
        /// <summary>
        /// 错误
        /// </summary>
        /// <returns></returns>
        Array GetExceptions();
        /// <summary>
        /// 获取查询
        /// </summary>
        /// <returns></returns>
        ICsiQuery[] GetQueries();
        /// <summary>
        /// 获取查询
        /// </summary>
        /// <returns></returns>
        ICsiQuery GetQuery();
        /// <summary>
        /// 获取服务
        /// </summary>
        /// <returns></returns>
        ICsiService GetService();
        /// <summary>
        /// 获取服务
        /// </summary>
        /// <returns></returns>
        ICsiService[] GetServices();
        /// <summary>
        /// 操作GUID
        /// </summary>
        /// <returns></returns>
        string GetTxnGuid();
        /// <summary>
        /// 请求数据
        /// </summary>
        /// <returns></returns>
        ICsiRequestData RequestData();
        /// <summary>
        /// 返回数据
        /// </summary>
        /// <returns></returns>
        ICsiResponseData ResponseData();
        /// <summary>
        /// 保存请求数据
        /// </summary>
        /// <param name="filename">字段名</param>
        /// <param name="append">是否添加</param>
        /// <returns></returns>
        string SaveRequestData(string filename, bool append);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        string SaveResponseData(string filename, bool append);
        /// <summary>
        /// 设置一直返回选择值
        /// </summary>
        /// <param name="alwaysReturn"></param>
        void SetAlwaysReturnSelectionValues(bool alwaysReturn);
        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        ICsiDocument Submit();

    }
}