namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 请求字段
    /// </summary>
    public interface ICsiRequestField : ICsiField, ICsiXmlElement
    {
        /// <summary>
        /// 请求所有字段
        /// </summary>
        void RequestAllFields();
        /// <summary>
        /// 请求所有字段 包含子字段
        /// </summary>
        void RequestAllFieldsRecursive();
        /// <summary>
        /// 请求标题
        /// </summary>
        void RequestCaption();
        /// <summary>
        /// 请求CDO定义
        /// </summary>
        void RequestCdoDefinition();
        /// <summary>
        /// 请求默认值
        /// </summary>
        void RequestDefaultValue();
        /// <summary>
        /// 请求字段
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        ICsiRequestField RequestField(string fieldName);
        /// <summary>
        /// 请求字段定义
        /// </summary>
        void RequestFieldDefinition();
        /// <summary>
        /// 请求数据集合
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="cdoTypeName">CDO类型</param>
        /// <returns></returns>
        ICsiRequestField RequestListItemByIndex(int index, string fieldName, string cdoTypeName);
        /// <summary>
        /// 请求数据集合
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="cdoTypeName">CDO类型</param>
        /// <returns></returns>
        ICsiRequestField RequestListItemByName(string name, string fieldName, string cdoTypeName);
        /// <summary>
        /// 请求选择的数据值
        /// </summary>
        void RequestSelectionValues();
        /// <summary>
        /// 请求选择的数据值
        /// </summary>
        /// <returns></returns>
        ICsiRequestSelectionValuesEx RequestSelectionValuesEx();
        /// <summary>
        /// 请求用户定义字段的定义
        /// </summary>
        void RequestUserDefinedFieldDefinitions();
        /// <summary>
        /// 请求用户定义字段
        /// </summary>
        void RequestUserDefinedFields();
        /// <summary>
        /// 设置数据格式化模式
        /// </summary>
        /// <param name="mode"></param>
        void SetSerializationMode(Enum.SerializationModes mode);
    }
}