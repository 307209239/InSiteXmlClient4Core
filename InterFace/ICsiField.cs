using System;
using System.Collections.Generic;
using System.Text;

namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// ziduan
    /// </summary>
    public interface ICsiField : ICsiXmlElement
    {
        /// <summary>
        /// 获取标题
        /// </summary>
        /// <returns></returns>
        ICsiLabel GetCaption();
        /// <summary>
        /// 获取CDO 定义
        /// </summary>
        /// <returns></returns>
        ICsiCdoDefinition GetCdoDefinition();
        /// <summary>
        /// 获取默认值
        /// </summary>
        /// <returns></returns>
        ICsiField GetDefaultValue();
        /// <summary>
        /// 获取字段定义
        /// </summary>
        /// <returns></returns>
        ICsiFieldDefinition GetFieldDefinition();
        /// <summary>
        /// 获取字段集合
        /// </summary>
        /// <returns></returns>
        Array GetFields();
        /// <summary>
        /// 通用类型
        /// </summary>
        /// <returns></returns>
        Enum.CsiGenericTypes GetGenericType();
        /// <summary>
        /// 参数类型
        /// </summary>
        /// <returns></returns>
        Enum.CsiReferenceTypes GetReferenceType();
        ICsiSelectionValues GetSelectionValues();
        ICsiSelectionValuesEx GetSelectionValuesEx();
        /// <summary>
        /// 获取特殊类型
        /// </summary>
        /// <returns></returns>
        string GetSpecificType();
    }
}
