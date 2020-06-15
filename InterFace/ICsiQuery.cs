namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 查询
    /// </summary>
    public interface ICsiQuery : ICsiXmlElement
    {
        /// <summary>
        /// 清空参数
        /// </summary>
        void ClearParameters();
        /// <summary>
        /// 错误数据
        /// </summary>
        /// <returns></returns>
        ICsiExceptionData ExceptionData();
        /// <summary>
        /// 参数
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        string GetParameter(string name);
        /// <summary>
        /// 查询明细
        /// </summary>
        /// <returns></returns>
        string GetQueryName();
        /// <summary>
        /// 查询参数
        /// </summary>
        /// <returns></returns>
        ICsiQueryParameters GetQueryParameters();
        /// <summary>
        /// 记录数量
        /// </summary>
        /// <returns></returns>
        long GetRecordCount();
        /// <summary>
        /// 记录
        /// </summary>
        /// <returns></returns>
        ICsiRecordset GetRecordset();
        /// <summary>
        /// 记录头部
        /// </summary>
        /// <returns></returns>
        ICsiRecordsetHeader GetRecordsetHeader();
        /// <summary>
        /// 记录数量
        /// </summary>
        /// <returns></returns>
        bool GetRequestRecordCount();
        /// <summary>
        /// 行数
        /// </summary>
        /// <returns></returns>
        long GetRowsetSize();
        /// <summary>
        /// SQL
        /// </summary>
        /// <returns></returns>
        string GetSqlText();
        /// <summary>
        /// 开始行
        /// </summary>
        /// <returns></returns>
        long GetStartRow();
        /// <summary>
        /// 用户更改行数
        /// </summary>
        /// <returns></returns>
        long GetUserQueryChangeCount();
        /// <summary>
        /// 设置CDO类型
        /// </summary>
        /// <param name="typeId"></param>
        void SetCdoTypeId(int typeId);
        /// <summary>
        /// 参数
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        void SetParameter(string name, string value);
        /// <summary>
        /// 设置查询名称
        /// </summary>
        /// <param name="queryName">名称</param>
        void SetQueryName(string queryName);
        /// <summary>
        /// 设置请求数据量
        /// </summary>
        /// <param name="isRequested"></param>
        void SetRequestRecordCount(bool isRequested);
        /// <summary>
        /// 设置行数
        /// </summary>
        /// <param name="size"></param>
        void SetRowsetSize(long size);
        /// <summary>
        /// 设置SQL
        /// </summary>
        /// <param name="sql"></param>
        void SetSqlText(string sql);
        /// <summary>
        /// 设置行
        /// </summary>
        /// <param name="startRow"></param>
        void SetStartRow(long startRow);
        /// <summary>
        /// 设置用户查询名称
        /// </summary>
        /// <param name="queryName">名称</param>
        /// <param name="changeCount">行数</param>
        void SetUserQueryName(string queryName, long changeCount);
    }
}